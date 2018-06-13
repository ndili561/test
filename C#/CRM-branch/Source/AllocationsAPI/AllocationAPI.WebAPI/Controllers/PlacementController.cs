using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AutoMapper;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Service.Api.DTOs;

namespace AllocationsAPI.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PlacementController : BaseController
    {
        public PlacementController() : base(new UnitOfWork())
        {
        }

        public PlacementController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public PageResult<HRSPlacementDTO> GetPlacements(ODataQueryOptions<HRSPlacement> options)
        {
            var placements =
                options.ApplyTo(
                    UnitOfWork.Placement()
                        .Select(includeProperties: "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer")
                        .AsNoTracking()// Please do not remove this as Newtonsoft will throw circular reference error while serialization.
                        .AsQueryable()).ToListAsync().Result;

            var placementDto = Mapper.Map<List<HRSPlacementDTO>>(placements);
            
            var result = new PageResult<HRSPlacementDTO>(
                placementDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        public HRSPlacementDTO Placement(int HRSPlacementId)
        {
            var result =
                UnitOfWork.Placement()
                    .Select(includeProperties: "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer")
                    .AsNoTracking()// Please do not remove this as Newtonsoft will throw circular reference error while serialization.
                    .FirstOrDefault(x => x.PlacementId == HRSPlacementId);
            

            var result2 = Mapper.Map<HRSPlacementDTO>(result);
            AddMatchingCustomerListToPlacement(result2.PlacementId, result2.SupportTypeId.ToString(), result2.ServiceTypeId.ToString());
            return result2;
        }

        [HttpPost]
        public HttpResponseMessage PostHRSPlacement(HRSPlacementDTO item)
        {
            var entityTobeSave = Mapper.Map<HRSPlacement>(item);
            entityTobeSave.PlacementStatus = PlacementStatus.Available;
            UnitOfWork.Placement().Insert(entityTobeSave);
            UnitOfWork.Commit();
            if (item.ServiceTypeId > 0)
            {
                var persistedServiceType =
                    UnitOfWork.ServiceType().Select().FirstOrDefault(x => x.ServiceTypeId == item.ServiceTypeId);
                entityTobeSave.ServiceTypes.Add(persistedServiceType);
                UnitOfWork.Placement().Update(entityTobeSave);
            }
            AddMatchingCustomerListToPlacement(entityTobeSave.PlacementId, item.SupportTypeId.ToString(), item.ServiceTypeId.ToString());
            UnitOfWork.Commit();
            item = Mapper.Map<HRSPlacementDTO>(entityTobeSave);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }

        public HttpResponseMessage PutPlacement(int id, HRSPlacementDTO placement)
        {
            var persistedObject =
                UnitOfWork.Placement()
                    .Select(includeProperties: "HRSCustomersMatched,SupportType,ServiceTypes,Hostel")
                    .FirstOrDefault(x => x.PlacementId == id);
            if (persistedObject != null)
            {
                persistedObject.UserId = placement.UserId;
                persistedObject.UserIPAddress = placement.UserIPAddress;
                persistedObject.ModifiedBy = placement.ModifiedBy;
                persistedObject.ModifiedDate = placement.ModifiedDate;
                persistedObject.HostelId = placement.HostelId;
                persistedObject.SupportTypeId = placement.SupportTypeId;
                persistedObject.PlacementId = placement.PlacementId;
                persistedObject.Address = placement.Address;
                persistedObject.Comments = placement.Comments;
                persistedObject.ContactName = placement.ContactName;
                persistedObject.ContactNumber = placement.ContactNumber;
                persistedObject.MinimumBedroom = placement.MinimumBedroom;
                persistedObject.PlacementGender = placement.PlacementGender;
                if (persistedObject.ServiceTypes.Any(x => x.ServiceTypeId != placement.ServiceTypeId) || !persistedObject.ServiceTypes.Any())
                {
                    persistedObject.ServiceTypes.Clear();
                    var persistedServiceType =
                        UnitOfWork.ServiceType()
                            .Select()
                            .FirstOrDefault(x => x.ServiceTypeId == placement.ServiceTypeId);
                    persistedObject.ServiceTypes.Add(persistedServiceType);
                }
                UnitOfWork.Placement().Update(persistedObject);
                UnitOfWork.Commit();
                AddMatchingCustomerListToPlacement(persistedObject.PlacementId, placement.SupportTypeId.ToString(), placement.ServiceTypeId.ToString());
            }
            var item = Mapper.Map<HRSPlacementDTO>(persistedObject);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.PlacementId }));
            return response;
        }
        [HttpDelete]
        public void DeletePlacement(int id, string userId, string userIPAddress)
        {
            using (var transactionscope = new TransactionScope())
            {
                var persistedPlacement = UnitOfWork.Placement()
                        .Select(includeProperties: "HRSCustomersMatched")
                        .FirstOrDefault(x => x.PlacementId == id);
                var customermatchcounter = persistedPlacement.HRSCustomersMatched.Count;
                for (var ctr = 0; ctr < customermatchcounter; ctr++)
                {
                    var placementMatch = persistedPlacement.HRSCustomersMatched[0];
                    var matchedcustomer =
                        UnitOfWork.HRSCustomer()
                            .Select()
                            .FirstOrDefault(c => c.HRSCustomerId == placementMatch.CustomerId);
                    if (matchedcustomer != null && matchedcustomer.Status != Status.RejectedByProvider && matchedcustomer.Status != Status.OnWaitingList )
                    {
                        matchedcustomer.Status = Status.OnWaitingList;
                        UnitOfWork.HRSCustomer().Update(matchedcustomer);
                    }
                    UnitOfWork.HRSPlacementMatchedForCustomer().Delete(placementMatch);
                }
                var matchHistoryList = UnitOfWork.HRSMatchHistory()
                        .Select().Where(x => x.Placement.PlacementId == id)
                        .ToList();
                foreach (var matchHistory in matchHistoryList)
                {
                    UnitOfWork.HRSMatchHistory().Delete(matchHistory);
                }
                UnitOfWork.Placement().Delete(persistedPlacement);
                UnitOfWork.Commit();

                transactionscope.Complete();

            }

        }
    }
}