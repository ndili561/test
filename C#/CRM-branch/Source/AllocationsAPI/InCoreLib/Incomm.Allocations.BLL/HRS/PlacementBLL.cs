using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using Incomm.Allocations.BLL.Interfaces.HRS;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL
{
    public class PlacementBLL :  IPlacementBLL
    {
        private IUnitOfWork _unitOfWork;
        private IMatchingBLL _matchingBLL;
        public PlacementBLL() : this(new UnitOfWork() ,new MatchingBLL())
        {
        }

        public PlacementBLL(IUnitOfWork unitOfWork , IMatchingBLL matchingBLL)
        {
            _unitOfWork = unitOfWork;
            _matchingBLL = matchingBLL;
        }
        public List<HRSPlacementDTO> GetPlacements(ODataQueryOptions<HRSPlacement> options)
        {
            var includeProperties = "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer";
            var placements = options.ApplyTo(_unitOfWork.Placement()
                                .Select(includeProperties: includeProperties)
                                .AsNoTracking()
                                .AsQueryable());
            var placementDtoList = Mapper.Map<List<HRSPlacementDTO>>(placements);
            if (placementDtoList.Any(x => x.RunMatchingAlgorithm))
            {
                var placement = placementDtoList.First(x => x.RunMatchingAlgorithm);
                _matchingBLL.AddMatchingCustomerListToPlacement(placement.PlacementId, placement.SupportTypeId.ToString(), placement.ServiceTypeId.ToString());
            }
            placementDtoList = Mapper.Map<List<HRSPlacementDTO>>(options.ApplyTo(_unitOfWork.Placement()
                                .Select(includeProperties: includeProperties)
                                .AsNoTracking()
                                .AsQueryable()));
            return placementDtoList;
            
        }

        public HRSPlacementDTO GetPlacement(int placementId)
        {
            const string includeProperties = "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer";
            var placement = _unitOfWork.Placement()
                                        .Select(includeProperties: includeProperties)
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.PlacementId == placementId);
            var placementDto = Mapper.Map<HRSPlacementDTO>(placement);
            if (placementDto.RunMatchingAlgorithm)
            {
                _matchingBLL.AddMatchingCustomerListToPlacement(placementDto.PlacementId, placementDto.SupportTypeId.ToString(), placementDto.ServiceTypeId.ToString());
                //Relaod the entity
                placementDto = Mapper.Map<HRSPlacementDTO>(_unitOfWork.Placement()
                    .Select(includeProperties: includeProperties)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.PlacementId == placementId));
            }
            return placementDto;
        }

        public HRSPlacementDTO PostHRSPlacement(HRSPlacementDTO placementDto)
        {
            var placement = Mapper.Map<HRSPlacement>(placementDto);
            placement.PlacementStatus = PlacementStatus.Available;
            _unitOfWork.Placement().Insert(placement);
            _unitOfWork.Commit(placementDto.UserId, placementDto.UserIPAddress);
            if (placementDto.ServiceTypeId > 0)
            {
                var persistedServiceType =_unitOfWork.ServiceType()
                                                    .Select()
                                                    .FirstOrDefault(x => x.ServiceTypeId == placementDto.ServiceTypeId);
                placement.ServiceTypes.Add(persistedServiceType);
                _unitOfWork.Placement().Update(placement);
                _unitOfWork.Commit(placementDto.UserId, placementDto.UserIPAddress);
            }
            if (placementDto.RunMatchingAlgorithm)
            {
                _matchingBLL.AddMatchingCustomerListToPlacement(placement.PlacementId, placementDto.SupportTypeId.ToString(), placementDto.ServiceTypeId.ToString());
            }
            return Mapper.Map<HRSPlacementDTO>(placement);
        }

        public HRSPlacementDTO PutPlacement(int id, HRSPlacementDTO placementDto)
        {
            var persistedPlacement = _unitOfWork.Placement()
                    .Select(includeProperties: "HRSCustomersMatched,SupportType,ServiceTypes,Hostel")
                    .FirstOrDefault(x => x.PlacementId == id);

            if (persistedPlacement != null)
            {
                if (persistedPlacement.PlacementStatus == PlacementStatus.Available ||
                    persistedPlacement.PlacementStatus == PlacementStatus.MatchedByProvider)
                {
                    persistedPlacement.HostelId = placementDto.HostelId;
                    persistedPlacement.SupportTypeId = placementDto.SupportTypeId;
                    persistedPlacement.PlacementId = placementDto.PlacementId;
                    persistedPlacement.MinimumBedroom = placementDto.MinimumBedroom;
                    persistedPlacement.PlacementGender = placementDto.PlacementGender;

                }
                persistedPlacement.UserId = placementDto.UserId;
                persistedPlacement.UserIPAddress = placementDto.UserIPAddress;
                persistedPlacement.ModifiedBy = placementDto.ModifiedBy;
                persistedPlacement.ModifiedDate = placementDto.ModifiedDate;
                persistedPlacement.Address = placementDto.Address;
                persistedPlacement.Comments = placementDto.Comments;
                persistedPlacement.ContactName = placementDto.ContactName;
                persistedPlacement.ContactNumber = placementDto.ContactNumber;
            
                if (placementDto.MoveOnPlacement)
                {
                    persistedPlacement.PlacementStatus = PlacementStatus.Occupied;
                }
                if (persistedPlacement.ServiceTypes.Any(x => x.ServiceTypeId != placementDto.ServiceTypeId) || !persistedPlacement.ServiceTypes.Any())
                {
                    persistedPlacement.ServiceTypes.Clear();
                    var persistedServiceType = _unitOfWork.ServiceType()
                                                        .Select()
                                                        .FirstOrDefault(x => x.ServiceTypeId == placementDto.ServiceTypeId);
                    persistedPlacement.ServiceTypes.Add(persistedServiceType);
                }
                _unitOfWork.Placement().Update(persistedPlacement);
                _unitOfWork.Commit(persistedPlacement.UserId, persistedPlacement.UserIPAddress);
                if (placementDto.RunMatchingAlgorithm)
                {
                    _matchingBLL.AddMatchingCustomerListToPlacement(persistedPlacement.PlacementId, placementDto.SupportTypeId.ToString(), placementDto.ServiceTypeId.ToString());
                }
            }
            var item = Mapper.Map<HRSPlacementDTO>(persistedPlacement);
            return item;
        }

        public void DeletePlacement(int id, string userId, string userIPAddress)
        {
           
                var persistedPlacement = _unitOfWork.Placement()
                        .Select(includeProperties: "HRSCustomersMatched")
                        .FirstOrDefault(x => x.PlacementId == id);
                var customermatchcounter = persistedPlacement.HRSCustomersMatched.Count;
                for (var ctr = 0; ctr < customermatchcounter; ctr++)
                {
                    var placementMatch = persistedPlacement.HRSCustomersMatched[0];
                    var matchedcustomer =
                        _unitOfWork.HRSCustomer()
                            .Select()
                            .FirstOrDefault(c => c.HRSCustomerId == placementMatch.CustomerId);
                    if (matchedcustomer != null && matchedcustomer.Status != Status.RejectedByProvider && matchedcustomer.Status != Status.OnWaitingList && matchedcustomer.Status != Status.AcceptedByProvider)
                    {
                        matchedcustomer.Status = Status.OnWaitingList;
                        _unitOfWork.HRSCustomer().Update(matchedcustomer);
                    }
                    _unitOfWork.HRSPlacementMatchedForCustomer().Delete(placementMatch);
                }
                var matchHistoryList = _unitOfWork.HRSMatchHistory()
                        .Select().Where(x => x.Placement.PlacementId == id)
                        .ToList();
                foreach (var matchHistory in matchHistoryList)
                {
                    _unitOfWork.HRSMatchHistory().Delete(matchHistory);
                }
                _unitOfWork.Placement().Delete(persistedPlacement);
                _unitOfWork.Commit(persistedPlacement.UserId, persistedPlacement.UserIPAddress);

              

            

        }
    }

    }
