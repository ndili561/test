using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class MatchedPlacementController : BaseController
    {
        public MatchedPlacementController() : base(new UnitOfWork())
        {
        }

        public MatchedPlacementController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public PageResult<HRSPlacementMatchedForCustomerDTO> GetMatchedPlacements(
            ODataQueryOptions<HRSPlacementMatchedForCustomer> options)
        {
            var matchedPlacements =
                options.ApplyTo(
                    UnitOfWork.HRSPlacementMatchedForCustomer()
                        .Select(includeProperties: "Placement.SupportType,Placement.ServiceTypes,Customer")
                        .AsNoTracking()// Please do not remove this as Newtonsoft will throw circular reference error while serialization.
                        .AsQueryable());
            var matchedPlacementDto = Mapper.Map<List<HRSPlacementMatchedForCustomerDTO>>(matchedPlacements);
            var result = new PageResult<HRSPlacementMatchedForCustomerDTO>(
                matchedPlacementDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        public HRSPlacementMatchedForCustomerDTO HRSPlacementMatchedForCustomer(int matchedPlacementId)
        {
            var result =
                UnitOfWork.HRSPlacementMatchedForCustomer()
                    .Select(
                        includeProperties:
                            "Placement.SupportType,Placement.ServiceTypes,Customer,Customer.SupportTypes,Customer.ServiceTypes,Placement.HRSProvider,Placement.Hostel")
                    .FirstOrDefault(x => x.HRSPlacementMatchedForCustomerId == matchedPlacementId);
            var hrsPlacementMatchedForCustomerDto = Mapper.Map<HRSPlacementMatchedForCustomerDTO>(result);
            if (result != null)
                hrsPlacementMatchedForCustomerDto.HOAQuestionsAndAnswerList =
                    UnitOfWork.GetHOAQuestionsAndAnswers(result.Customer.HOACaseReference).ToList();
            return hrsPlacementMatchedForCustomerDto;
        }

        [HttpPut]
        public HttpResponseMessage PutMatchedPlacement(int id,
            HRSPlacementMatchedForCustomerDTO hrsPlacementMatchedForCustomerDto)
        {
            var persistedPlacement =
                UnitOfWork.HRSPlacementMatchedForCustomer()
                    .Select(
                        includeProperties:
                            "Customer.HRSPlacementsMatched,Placement.SupportType,Placement.ServiceTypes,Placement.HRSProvider")
                    .FirstOrDefault(x => x.HRSPlacementMatchedForCustomerId == id);

            if (persistedPlacement != null)
            {
                var persistedPlacementMatchedForCustomer =
                    persistedPlacement.Customer.HRSPlacementsMatched
                        .Where(
                            x =>
                                x.PlacementId != persistedPlacement.PlacementId && x.Status != Status.RejectedByProvider)
                        .ToList();
                UnitOfWork.HRSPlacementMatchedForCustomer().RemoveRange(persistedPlacementMatchedForCustomer);
                // update the properties
                persistedPlacement.UserId = hrsPlacementMatchedForCustomerDto.UserId;
                persistedPlacement.UserIPAddress = hrsPlacementMatchedForCustomerDto.UserIPAddress;
                persistedPlacement.EventDate = DateTime.Now;
                persistedPlacement.Status = hrsPlacementMatchedForCustomerDto.Status;
                persistedPlacement.Notes = hrsPlacementMatchedForCustomerDto.Notes;
                persistedPlacement.RejectionReason = hrsPlacementMatchedForCustomerDto.RejectionReason;
                persistedPlacement.ModifiedDate = hrsPlacementMatchedForCustomerDto.ModifiedDate;
                persistedPlacement.ModifiedBy = hrsPlacementMatchedForCustomerDto.ModifiedBy;
            
                persistedPlacement.Customer.Status = hrsPlacementMatchedForCustomerDto.Status;
                switch (hrsPlacementMatchedForCustomerDto.Status)
                {
                    case Status.ReferredToProvider:
                        persistedPlacement.Placement.PlacementStatus = PlacementStatus.ReferredToProvider;
                        break;

                    case Status.RejectedByProvider:
                        persistedPlacement.Placement.PlacementStatus =
                            !AddMatchingCustomerListToPlacement(persistedPlacement.Placement.PlacementId,
                                persistedPlacement.Placement.SupportTypeId.ToString(),
                                persistedPlacement.Placement.ServiceTypes.Select(s => s.ServiceTypeId.ToString())
                                    .FirstOrDefault())
                                ? PlacementStatus.Available
                                : PlacementStatus.MatchedByProvider;

                        AddMatchingCustomerListToPlacement(persistedPlacement.Placement.PlacementId,
                            persistedPlacement.Placement.SupportTypeId.ToString(),
                            persistedPlacement.Placement.ServiceTypes.Select(s => s.ServiceTypeId.ToString())
                                .FirstOrDefault());

                        InsertIntoMatchHistory(persistedPlacement);

                        break;

                    case Status.AcceptedByProvider:
                        persistedPlacement.Placement.PlacementStatus = PlacementStatus.Occupied;
                        InsertIntoMatchHistory(persistedPlacement);
                        break;
                }
              
                UnitOfWork.Commit();
                SaveCaseNoteForHOA(hrsPlacementMatchedForCustomerDto, persistedPlacement);
            }
            hrsPlacementMatchedForCustomerDto = Mapper.Map<HRSPlacementMatchedForCustomerDTO>(persistedPlacement);
            var response = Request.CreateResponse(HttpStatusCode.Created, hrsPlacementMatchedForCustomerDto);
            response.Headers.Location =
                new Uri(Url.Link("DefaultApi",
                    new { id = hrsPlacementMatchedForCustomerDto.HRSPlacementMatchedForCustomerId }));
            if (hrsPlacementMatchedForCustomerDto.Status == Status.RejectedByProvider)
            {
                persistedPlacement.Customer.Status = Status.OnWaitingList;
                UnitOfWork.Commit();
            }

            return response;
        }

        private void InsertIntoMatchHistory(HRSPlacementMatchedForCustomer placement)
        {
            var match = new HRSMatchHistory

            {
                Placement = placement.Placement,
                Customer = placement.Customer,
                Outcome = placement.Status,
                Reason = placement.RejectionReason,
                DecisionDate = DateTime.Now,
                Reconsidered = false,
                CreatedDate = DateTime.Now,
                ModifiedBy = placement.ModifiedBy,
                ModifiedDate = placement.ModifiedDate
            };

            UnitOfWork.HRSMatchHistory().Insert(match);
            UnitOfWork.Commit();
        }

        private void SaveCaseNoteForHOA(HRSPlacementMatchedForCustomerDTO hrsPlacementMatchedForCustomerDto,
            HRSPlacementMatchedForCustomer persistedObject)
        {
            var caseNoteDescription = string.Empty;
            switch (hrsPlacementMatchedForCustomerDto.Status)
            {
                case Status.ReferredToProvider:
                    caseNoteDescription =
                        $"Referral made to : {persistedObject.Placement.HRSProvider.Code} for: {persistedObject.Placement.Address} by {hrsPlacementMatchedForCustomerDto.ModifiedByName}";
                    break;

                case Status.RejectedByProvider:
                    caseNoteDescription =
                        $"Customer Rejected by provider: {persistedObject.Placement.HRSProvider.Code} for: {persistedObject.Placement.Address} by {hrsPlacementMatchedForCustomerDto.ModifiedByName}";
                    break;

                case Status.AcceptedByProvider:
                    caseNoteDescription =
                        $"Customer Accepted by provider: {persistedObject.Placement.HRSProvider.Code} for: {persistedObject.Placement.Address} by {hrsPlacementMatchedForCustomerDto.ModifiedByName}";
                    break;
            }
            if (!string.IsNullOrWhiteSpace(caseNoteDescription))
            {
                var caseNote = new tblCaseNote
                {
                    CaseRefNumber = persistedObject.Customer.HOACaseReference,
                    CaseNoteDate = DateTime.Now,
                    CaseNoteType = "HRSNote",
                    CaseNoteUserID = hrsPlacementMatchedForCustomerDto.UserId,
                    CaseNote = caseNoteDescription
                };
                UnitOfWork.CaseNotes().Insert(caseNote);
                UnitOfWork.Commit();
            }
        }
    }
}