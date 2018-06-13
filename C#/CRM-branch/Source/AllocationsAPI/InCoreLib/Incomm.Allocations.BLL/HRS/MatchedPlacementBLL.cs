using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.OData.Query;
using AutoMapper;
using DocumentFormat.OpenXml;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.HRS;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.HRS
{
    public class MatchedPlacementBLL : IMatchedPlacementBLL
    {
        private IUnitOfWork _unitOfWork;
        private IMatchingBLL _matchingBLL;
        public MatchedPlacementBLL() : this(new UnitOfWork(), new MatchingBLL())
        {
        }

        public MatchedPlacementBLL(IUnitOfWork unitOfWork, IMatchingBLL matchingBLL)
        {
            _unitOfWork = unitOfWork;
            _matchingBLL = matchingBLL;
        }

        public List<HRSPlacementMatchedForCustomerDTO> GetMoveOnCustomers(ODataQueryOptions<HRSPlacementMatchedForCustomer> options, int providerId)
        {
            var matchedPlacements =
               options.ApplyTo(
                   _unitOfWork.HRSPlacementMatchedForCustomer()
                       .Select(includeProperties: "Placement.HRSProvider,Customer")
                        .Where(x => (x.Status == Status.AcceptedByProvider || x.Status == Status.ReadyToLeave || x.Status == Status.Completed) && x.Placement.HRSProviderId == providerId && x.Placement.MoveOnPlacement == false && x.Placement.PlacementStatus == PlacementStatus.Completed)
                       .AsNoTracking()// Please do not remove this as Newtonsoft will throw circular reference error while serialization.
                       .AsQueryable()).ToListAsync().Result;

            return Mapper.Map<List<HRSPlacementMatchedForCustomerDTO>>(matchedPlacements);
        }

        public List<HRSPlacementMatchedForCustomerDTO> GetMatchedPlacements(ODataQueryOptions<HRSPlacementMatchedForCustomer> options)
        {
            var matchedPlacements =
                options.ApplyTo(
                    _unitOfWork.HRSPlacementMatchedForCustomer()
                        .Select(includeProperties: "Placement.SupportType,Placement.ServiceTypes,Customer")
                        .AsNoTracking()// Please do not remove this as Newtonsoft will throw circular reference error while serialization.
                        .AsQueryable());
            return Mapper.Map<List<HRSPlacementMatchedForCustomerDTO>>(matchedPlacements);
        }


        public HRSPlacementMatchedForCustomerDTO HRSPlacementMatchedForCustomer(int matchedPlacementId)
        {
            var includeProperties = "Placement.SupportType,Placement.ServiceTypes,Customer,Customer.SupportTypes,Customer.ServiceTypes,Placement.HRSProvider,Placement.Hostel";
            var result = _unitOfWork.HRSPlacementMatchedForCustomer()
                                   .Select(includeProperties: includeProperties)
                                   .FirstOrDefault(x => x.HRSPlacementMatchedForCustomerId == matchedPlacementId);
            var hrsPlacementMatchedForCustomerDto = Mapper.Map<HRSPlacementMatchedForCustomerDTO>(result);
            if (result != null)
            {
                hrsPlacementMatchedForCustomerDto.HOAQuestionsAndAnswerList = _unitOfWork.GetHOAQuestionsAndAnswers(result.Customer.HOACaseReference).ToList();
            }
            return hrsPlacementMatchedForCustomerDto;
        }

        public HRSPlacementMatchedForCustomerDTO PutMatchedPlacement(int id,HRSPlacementMatchedForCustomerDTO hrsPlacementMatchedForCustomerDto)
        {
            var includeProperties = "Customer.HRSPlacementsMatched,Placement.SupportType,Placement.ServiceTypes,Placement.HRSProvider";
             var persistedlacementMatchedForCustomer =_unitOfWork.HRSPlacementMatchedForCustomer()
                         .Select(includeProperties: includeProperties)
                         .FirstOrDefault(x => x.HRSPlacementMatchedForCustomerId == id);

            if (persistedlacementMatchedForCustomer != null)
            {
                var placementMatchedForCustomerToBeDeleted =
                    persistedlacementMatchedForCustomer.Customer.HRSPlacementsMatched
                        .Where(
                            x =>
                                x.PlacementId != persistedlacementMatchedForCustomer.PlacementId
                                && x.Status != Status.RejectedByProvider
                                && x.Status != Status.Completed
                                && x.Status != Status.AcceptedByProvider
                        )
                        .ToList();
                _unitOfWork.HRSPlacementMatchedForCustomer().RemoveRange(placementMatchedForCustomerToBeDeleted);
                // update the properties
                persistedlacementMatchedForCustomer.UserId = hrsPlacementMatchedForCustomerDto.UserId;
                persistedlacementMatchedForCustomer.UserIPAddress = hrsPlacementMatchedForCustomerDto.UserIPAddress;
                persistedlacementMatchedForCustomer.EventDate = DateTime.Now;
                persistedlacementMatchedForCustomer.Status = hrsPlacementMatchedForCustomerDto.Status;
                persistedlacementMatchedForCustomer.Notes = hrsPlacementMatchedForCustomerDto.Notes;
                persistedlacementMatchedForCustomer.RejectionReason = hrsPlacementMatchedForCustomerDto.RejectionReason;
                persistedlacementMatchedForCustomer.ModifiedDate = hrsPlacementMatchedForCustomerDto.ModifiedDate;
                persistedlacementMatchedForCustomer.ModifiedBy = hrsPlacementMatchedForCustomerDto.ModifiedBy;
                if (persistedlacementMatchedForCustomer.Placement.PlacementStatus != PlacementStatus.Occupied
                    && persistedlacementMatchedForCustomer.Placement.PlacementStatus != PlacementStatus.Completed
                    && persistedlacementMatchedForCustomer.Customer.Status != Status.AcceptedByProvider
                    && persistedlacementMatchedForCustomer.Customer.Status != Status.Completed)
                {
                    switch (hrsPlacementMatchedForCustomerDto.Status)
                    {
                        case Status.ReferredToProvider:
                            persistedlacementMatchedForCustomer.Status = Status.ReferredToProvider;
                            persistedlacementMatchedForCustomer.Placement.PlacementStatus = PlacementStatus.ReferredToProvider;
                            persistedlacementMatchedForCustomer.Customer.Status = Status.ReferredToProvider;
                            break;

                        case Status.RejectedByProvider:
                            persistedlacementMatchedForCustomer.Status = Status.RejectedByProvider;
                            persistedlacementMatchedForCustomer.Placement.PlacementStatus = PlacementStatus.Available;
                            persistedlacementMatchedForCustomer.Customer.Status= Status.OnWaitingList;
                            InsertOrUpdateMatchHistory(persistedlacementMatchedForCustomer);
                            _matchingBLL.AddMatchingCustomerListToPlacement(
                                persistedlacementMatchedForCustomer.PlacementId,
                                persistedlacementMatchedForCustomer.Placement.SupportTypeId.ToString(),
                                persistedlacementMatchedForCustomer.Placement.ServiceTypes.Select(
                                    s => s.ServiceTypeId.ToString())
                                    .FirstOrDefault());
                           
                            break;

                        case Status.AcceptedByProvider:
                            persistedlacementMatchedForCustomer.Status = Status.AcceptedByProvider;
                            persistedlacementMatchedForCustomer.Placement.PlacementStatus = PlacementStatus.Occupied;
                            persistedlacementMatchedForCustomer.Customer.Status = Status.AcceptedByProvider;
                            InsertOrUpdateMatchHistory(persistedlacementMatchedForCustomer);
                           // RemoveMatchesFromPlacementMatchForCustomers(persistedlacementMatchedForCustomer);
                            break;
                    }
                }
                _unitOfWork.Commit(persistedlacementMatchedForCustomer.UserId,
                        persistedlacementMatchedForCustomer.UserIPAddress);
                    SaveCaseNoteForHOA(hrsPlacementMatchedForCustomerDto, persistedlacementMatchedForCustomer);
                    if (hrsPlacementMatchedForCustomerDto.Status == Status.RejectedByProvider)
                    {
                        if (persistedlacementMatchedForCustomer.Customer.Status != Status.Completed
                            && persistedlacementMatchedForCustomer.Customer.Status != Status.AcceptedByProvider)
                            persistedlacementMatchedForCustomer.Customer.Status = Status.OnWaitingList;
                        if (persistedlacementMatchedForCustomer.Placement.PlacementStatus != PlacementStatus.Occupied
                            &&
                            persistedlacementMatchedForCustomer.Placement.PlacementStatus != PlacementStatus.Completed)
                            persistedlacementMatchedForCustomer.Placement.PlacementStatus = PlacementStatus.Available;
                        _unitOfWork.Commit(persistedlacementMatchedForCustomer.UserId,
                            persistedlacementMatchedForCustomer.UserIPAddress);
                    }
                }

            hrsPlacementMatchedForCustomerDto = Mapper.Map<HRSPlacementMatchedForCustomerDTO>(persistedlacementMatchedForCustomer);
            return hrsPlacementMatchedForCustomerDto;
        }

        private void RemoveMatchesFromPlacementMatchForCustomers(HRSPlacementMatchedForCustomer placement)
        {
            //redundant class
            
            //Get Data
            var placementMatchedForCustomers = _unitOfWork.HRSPlacementMatchedForCustomer()
                    .Select(
                        x =>
                            x.PlacementId == placement.PlacementId &&
                            x.CustomerId != placement.CustomerId &&
                            x.Status == Status.PlacementMatched);
            var customerPlacementMatchedForCustomers =
                _unitOfWork.HRSPlacementMatchedForCustomer()
                    .Select(
                        x =>
                            x.CustomerId == placement.CustomerId &&
                            x.Status == Status.PlacementMatched &&
                            x.PlacementId != placement.PlacementId);
            //First, Delete the matches from the placement side
            if (placementMatchedForCustomers.ToList().Any() )
            {
                //delete all placement matches
                var deletedplacmentmatch = new List<HRSPlacementMatchedForCustomer>();
                deletedplacmentmatch.AddRange(placementMatchedForCustomers);
                _unitOfWork.HRSPlacementMatchedForCustomer().DeleteRange(placementMatchedForCustomers);
                _unitOfWork.Commit();
                //for each customer match that was deleted, check that there is still an existing match for that customer
                foreach (HRSPlacementMatchedForCustomer e in deletedplacmentmatch)
                {
                    if (CheckCustomerStatus(e))
                    {
                        continue;
                    }
                    
                    //if not, update that customer's status.
                    var customerDetails =
                        _unitOfWork.HRSCustomer()
                            .Select()
                            .FirstOrDefault(
                            x =>
                                x.HRSCustomerId == e.CustomerId);
                    if (customerDetails != null)
                    {
                        customerDetails.Status = Status.OnWaitingList;
                        _unitOfWork.HRSCustomer().Update(customerDetails);
                    }        
                }
            }

            //Then delete the placements from the customer match side.
            if (customerPlacementMatchedForCustomers.ToList().Any())
            {
                //delete placement matches from the customer's side.
                var deletedcustomermatch = new List<HRSPlacementMatchedForCustomer>();
                deletedcustomermatch.AddRange(customerPlacementMatchedForCustomers);
                _unitOfWork.HRSPlacementMatchedForCustomer().DeleteRange(customerPlacementMatchedForCustomers);
                _unitOfWork.Commit();
                foreach (HRSPlacementMatchedForCustomer e in deletedcustomermatch)
                {
                    if (CheckPlacementStatus(e))
                    {
                        continue;
                    }

                    //if not, update that placments's status.
                    var placementDetails =
                        _unitOfWork.Placement()
                            .Select()
                            .FirstOrDefault(
                            x =>
                                x.PlacementId == e.PlacementId);
                    if (placementDetails != null)
                    {
                        placementDetails.PlacementStatus = PlacementStatus.Available;
                        _unitOfWork.Placement().Update(placementDetails);
                    }
                }
            }
        }

        private bool CheckPlacementStatus(HRSPlacementMatchedForCustomer placement)
        {
            return
                _unitOfWork.HRSPlacementMatchedForCustomer()
                    .Select(
                        x =>
                            x.PlacementId == placement.PlacementId &&
                            x.Status != Status.RejectedByProvider
                    ).Any();
            //return (placementMatchedForPlacements != null);
        }

        private bool CheckCustomerStatus(HRSPlacementMatchedForCustomer customer)
        {
            return _unitOfWork.HRSPlacementMatchedForCustomer()
                    .Select(
                        x =>
                            x.CustomerId == customer.CustomerId &&
                            x.Status != Status.RejectedByProvider
                    ).Any();

           
            

        }

        public void InsertOrUpdateMatchHistory(HRSPlacementMatchedForCustomer placementMatchedForCustomer)
        {
            var matchHistory = _unitOfWork.HRSMatchHistory()
                                          .Select()
                                          .FirstOrDefault(x => x.HRSCustomerId == placementMatchedForCustomer.CustomerId 
                                                                && x.PlacementId == placementMatchedForCustomer.PlacementId);
            if (matchHistory == null)
            {
                var match = new HRSMatchHistory
                {
                    PlacementId = placementMatchedForCustomer.PlacementId,
                    HRSCustomerId = placementMatchedForCustomer.CustomerId,
                    Outcome = placementMatchedForCustomer.Status,
                    Reason = placementMatchedForCustomer.RejectionReason,
                    Notes = placementMatchedForCustomer.Notes,
                    DecisionDate = DateTime.Now,
                    Reconsidered = false,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = placementMatchedForCustomer.ModifiedBy,
                    ModifiedDate = placementMatchedForCustomer.ModifiedDate
                };
                _unitOfWork.HRSMatchHistory().Insert(match);
            }
            else
            {
                matchHistory.Outcome = placementMatchedForCustomer.Status;
                matchHistory.Reason = placementMatchedForCustomer.RejectionReason;
                matchHistory.Notes = placementMatchedForCustomer.Notes;
                matchHistory.DecisionDate = DateTime.Now;
                matchHistory.ModifiedBy = placementMatchedForCustomer.ModifiedBy;
                matchHistory.ModifiedDate = placementMatchedForCustomer.ModifiedDate;
                _unitOfWork.HRSMatchHistory().Update(matchHistory);
            }
            _unitOfWork.Commit(placementMatchedForCustomer.UserId, placementMatchedForCustomer.UserIPAddress);


        }


        public void SaveCaseNoteForHOA(HRSPlacementMatchedForCustomerDTO hrsPlacementMatchedForCustomerDto,
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
                _unitOfWork.CaseNotes().Insert(caseNote);
                _unitOfWork.Commit(caseNote.UserId, caseNote.UserIPAddress);
            }
        }


        public HRSPlacementMatchedForCustomerDTO CreateMoveOnMatch(HRSPlacementMatchedForCustomerDTO item)
        {

            var entityTobeSave = Mapper.Map<HRSPlacementMatchedForCustomer>(item);
            _unitOfWork.HRSPlacementMatchedForCustomer().Insert(entityTobeSave);
            _unitOfWork.Commit();
            item = Mapper.Map<HRSPlacementMatchedForCustomerDTO>(entityTobeSave);
            var persistedPlacement =
               _unitOfWork.HRSPlacementMatchedForCustomer()
                   .Select(
                       includeProperties:
                           "Customer.HRSPlacementsMatched,Placement.SupportType,Placement.ServiceTypes,Placement.HRSProvider")
                   .FirstOrDefault(x => x.HRSPlacementMatchedForCustomerId == item.HRSPlacementMatchedForCustomerId);

            InsertOrUpdateMatchHistory(persistedPlacement);
            return item;
        }


    }
}
