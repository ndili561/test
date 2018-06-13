using System;
using System.Collections.Generic;
using System.Linq;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.VBL
{
    public class VBLCustomerInterestBLL : GatewayAPIClient, IVBLCustomerInterestBLL
    {
        private IUnitOfWork _unitOfWork;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public VBLCustomerInterestBLL() : this(new UnitOfWork(), new ApplicationHistoryBLL())
        {
        }

        public VBLCustomerInterestBLL(IUnitOfWork unitOfWork, IApplicationHistoryBLL applicationHistoryBLL)
        {
            _unitOfWork = unitOfWork;
            _applicationHistoryBLL = applicationHistoryBLL;
        }
        public VBLCustomerInterest GetLatestCustomerInterest(int applicationId)
        {
            var customerInterest =
                _unitOfWork.VBLCustomerInterests().Select().OrderByDescending(x => x.CustomerInterestId).FirstOrDefault(x => x.ApplicationId == applicationId);
            return customerInterest;
        }

        /// <summary>
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="propertyCode"></param>
        /// <returns></returns>
        public VBLCustomerInterest GetCustomerInterest(int taskId, string propertyCode)
        {
            var customerInterest =
                _unitOfWork
                    .VBLCustomerInterests()
                    .Select(ci => ci.TaskId == taskId && ci.PropertyCode == propertyCode)
                    .FirstOrDefault();

            return customerInterest;
        }

        public VBLCustomerInterestDTO Rejected(VBLCustomerInterestDTO customerInterest)
        {
            var result =
                _unitOfWork
                    .VBLCustomerInterests()
                    .Select(ci => ci.CustomerInterestId == customerInterest.CustomerInterestId)
                    .FirstOrDefault();

            if (result == null)
            {
                customerInterest.ErrorMessage = "Customer Interest status has been deleted";
            }
            else
            {
                result.CustomerInterestStatusId = 3;
                _unitOfWork.VBLCustomerInterests().Update(result);
                _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);
            }

            return customerInterest;
        }

        public List<VBLCustomerInterest> GetAllCustomerInterestsForApplication(int applicationId)
        {
            var customerinterests = _unitOfWork.VBLCustomerInterests().Select().Where(x => x.ApplicationId == applicationId && x.CustomerInterestStatusId != 11).OrderBy(x => x.CustomerInterestId).ToList();//Do not include the Reconsider in excluded
            return customerinterests;
        }


        public VBLCustomerInterestDTO Interested(VBLCustomerInterestDTO customerInterest)
        {
            if (customerInterest == null) return null;
            ValidateCustomerInterest(customerInterest);
            if (!string.IsNullOrWhiteSpace(customerInterest.ErrorMessage))
                return customerInterest;
            if (customerInterest.VoidId == -100)
            {
                //mutex process
                customerInterest = CreateInterestedMutexVBLCustomerInterests(customerInterest);
            }
            else
            {
                if (!customerInterest.IsRSLProperty)
                    _unitOfWork.CreateSuitabilityCheckTask(customerInterest);
               //UpdatePersistedValuesFromDto(customerInterest);
                var changeDescription =
                    $"The customer is interested in match; property code :{customerInterest.PropertyCode}";
                _applicationHistoryBLL.Create(customerInterest.ApplicationId, customerInterest.CreatedBy,
                    customerInterest.UserIPAddress, ApplicationActivity.PropertyInterest,
                    ApplicationChangeType.PropertyInterestStatusChanged,
                    changeDescription, customerInterest.PropertyCode, false);
                _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);
            }
            return customerInterest;
        }

        public VBLCustomerInterestDTO CreateInterestedMutexVBLCustomerInterests(VBLCustomerInterestDTO customerInterest)
        {
            //create the VBLCI for applicant A
            _unitOfWork.CreateSuitabilityCheckTask(customerInterest);
                    //UpdatePersistedValuesFromDto(customerInterest);
            //Create ApplicationHistory Details for Applicant A
            var changeDescription =
                   $"The customer is interested in mutual Exchange - Property Code :{customerInterest.PropertyCode}";
            _applicationHistoryBLL.Create(customerInterest.ApplicationId, customerInterest.CreatedBy,
                customerInterest.UserIPAddress, ApplicationActivity.PropertyInterest,
                ApplicationChangeType.PropertyInterestStatusChanged,
                changeDescription, customerInterest.PropertyCode, false);
            _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);
            //Create the MutexNotification for Applicant B
            //get the propertycode of the current application
            var mutexA =
                _unitOfWork
                    .VblMutualExchagePropertyDetail().Select()
                    .First(x => x.ApplicationId == customerInterest.ApplicationId);

            //get the applicationId of the matched property
            var mutexB =
                _unitOfWork
                    .VblMutualExchagePropertyDetail().Select()
                    .First(x => x.PropertyCode == customerInterest.PropertyCode);
            var mutexNotification = new MutualExchangeDTO
            {
                applicationIdA = customerInterest.ApplicationId,
                applicationIdB = mutexB.ApplicationId,
                propertyCodeA = mutexA.PropertyCode,
                propertyCodeB = customerInterest.PropertyCode,
                CIStatusA = customerInterest.CustomerInterestStatusId,
                CIStatusB = 10,
                UserId = customerInterest.UserId

            };
            //send to Gateway 
             _unitOfWork.CreateMutexTask(mutexNotification);
            //base.CreateMutexTask(mutexNotification);

            return customerInterest;
        }
        
        public VBLCustomerInterestDTO NotInterested(VBLCustomerInterestDTO customerInterest)
        {
            if (customerInterest == null) return null;
            ValidateCustomerInterest(customerInterest);
            if (!string.IsNullOrWhiteSpace(customerInterest.ErrorMessage))
                return customerInterest;
            if (customerInterest.VoidId == -100)
            {
                //mutex process
                customerInterest = CreateNotInterestedMutexVBLCustomerInterests(customerInterest);
            }
            else
            {
                UpdatePersistedValuesFromDto(customerInterest);
                var changeDescription =
                    $"The customer is not interested in  match property code :{customerInterest.PropertyCode} <br /> Comments: {customerInterest.Notes.Replace("\n", "<br />")}";
                _applicationHistoryBLL.Create(customerInterest.ApplicationId, customerInterest.CreatedBy,
                    customerInterest.UserIPAddress, ApplicationActivity.PropertyInterest,
                    ApplicationChangeType.PropertyInterestStatusChanged,
                    changeDescription, customerInterest.PropertyCode, true);
                _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);
            }
            return customerInterest;
        }

        public VBLCustomerInterestDTO CreateNotInterestedMutexVBLCustomerInterests(VBLCustomerInterestDTO customerInterest)
        {
            //get the propertycode of the current application
            var mutexA =
                _unitOfWork
                    .VblMutualExchagePropertyDetail().Select()
                    .First(x => x.ApplicationId == customerInterest.ApplicationId);

            //get the applicationId of the matched property
            var mutexB =
                _unitOfWork
                    .VblMutualExchagePropertyDetail().Select()
                    .First(x => x.PropertyCode == customerInterest.PropertyCode);
            //generate the VBLCI entry for current match
            UpdatePersistedValuesFromDto(customerInterest);
            //application history for current application
            var changeDescription =
                $"The customer is not interested in  match property code :{customerInterest.PropertyCode} <br /> Comments: {customerInterest.Notes.Replace("\n", "<br />")}";
            _applicationHistoryBLL.Create(customerInterest.ApplicationId, customerInterest.CreatedBy,
                customerInterest.UserIPAddress, ApplicationActivity.PropertyInterest,
                ApplicationChangeType.PropertyInterestStatusChanged,
                changeDescription, customerInterest.PropertyCode, true);
            _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);
            //generate the VBLCI for the opposite match
            var customerInterestB = new VBLCustomerInterestDTO
            {
                PropertyCode = mutexA.PropertyCode,
                VoidId = -100,
                CustomerInterestStatusId = 10,
                VoidContactId = 0,
                IsPreViewingUndertaken = false,
                StatusReasonsDate = DateTime.Now,
                OutcomeNotes = "",
                CustomerDecision = true,
                Notes = "",
                TaskId = 0,
                ActivityId = 0,
                IsRSLProperty = false,
                ApplicationHistoryId = 0,
                ApplicationId = mutexB.ApplicationId,
                LandlordId = 1,
                NotInterestedReasonID = null
            };
            UpdatePersistedValuesFromDto(customerInterestB);
            //application history for opposite application 
            var changeDescriptionB =
              $"Another customer is not interested in mutually exchanging with this property";
            _applicationHistoryBLL.Create(customerInterestB.ApplicationId, customerInterestB.CreatedBy,
                customerInterestB.UserIPAddress, ApplicationActivity.PropertyInterest,
                ApplicationChangeType.PropertyInterestStatusChanged,
                changeDescriptionB, customerInterestB.PropertyCode, true);
            _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);

            return customerInterest;
        }

        public VBLCustomerInterestDTO Reconsider(VBLCustomerInterestDTO customerInterest)
        {
            if (customerInterest == null) return null;
            ValidateCustomerInterest(customerInterest);
            if (!string.IsNullOrWhiteSpace(customerInterest.ErrorMessage))
                return customerInterest;
            UpdatePersistedValuesFromDto(customerInterest);
            var applicationHistoryList = _applicationHistoryBLL.GetApplicationHistoryList(customerInterest.PropertyCode);
            applicationHistoryList.ForEach(x =>
            {
                x.CanReconsider = false;
                x.UserId = customerInterest.UserId;
                x.UserIPAddress = customerInterest.UserIPAddress;
            });
            if (applicationHistoryList.Any())
                _applicationHistoryBLL.UpdateRange(applicationHistoryList);
            var changeDescription =
                $"The customer has reconsidered the match for property code :{customerInterest.PropertyCode}";
            _applicationHistoryBLL.Create(customerInterest.ApplicationId, customerInterest.CreatedBy,
                customerInterest.UserIPAddress, ApplicationActivity.PropertyInterest,
                ApplicationChangeType.PropertyInterestStatusChanged,
                changeDescription, customerInterest.PropertyCode, true);
            _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);
            return customerInterest;

        }

        public VBLCustomerInterestDTO MatchedFromWaitingList(VBLCustomerInterestDTO customerInterest)
        {
            if (customerInterest == null) return null;
            ValidateCustomerInterest(customerInterest);
            if (!string.IsNullOrWhiteSpace(customerInterest.ErrorMessage))
                return customerInterest;
            UpdatePersistedValuesFromDto(customerInterest);
            _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);
            return customerInterest;

        }

        public void UpdateRSLPropertyStatus(VBLCustomerInterestDTO customerInterest)
        {
            UpdateRSLProperty(customerInterest);
        }

        private void ValidateCustomerInterest(VBLCustomerInterestDTO customerInterest)
        {
            if (customerInterest.CustomerInterestId == 0 && (string.IsNullOrWhiteSpace(customerInterest.PropertyCode) || customerInterest.ApplicationId == 0))
            {
                customerInterest.ErrorMessage =
                                      $"The CustomerInterestId is 0 or Property Code or Customer Application Id is null.";
            }
        }

        /// <summary>
        /// This will only update the status when CustomerInterestId is supplied
        /// </summary>
        /// <param name="customerInterest"></param>
        private void UpdatePersistedValuesFromDto(VBLCustomerInterestDTO customerInterest)
        {
            var persistedCustomerInterest = _unitOfWork.VBLCustomerInterests()
                .Select(ci => ci.CustomerInterestId == customerInterest.CustomerInterestId)
                .FirstOrDefault();

            if (persistedCustomerInterest != null)
            {
                persistedCustomerInterest.Notes = customerInterest.Notes;
                persistedCustomerInterest.NotInterestedReasonId = null;
                persistedCustomerInterest.OutcomeNotes = customerInterest.OutcomeNotes;
                persistedCustomerInterest.CustomerDecision = customerInterest.CustomerDecision;
            }
            else
            {
                persistedCustomerInterest = _unitOfWork.VBLCustomerInterests()
                   .Select(ci => ci.ApplicationId == customerInterest.ApplicationId && ci.PropertyCode == customerInterest.PropertyCode &&
                                 ci.LandlordId == customerInterest.LandlordId).FirstOrDefault() ?? new VBLCustomerInterest();

                persistedCustomerInterest.TaskId = customerInterest.TaskId;
                persistedCustomerInterest.LandlordId = customerInterest.LandlordId;
                persistedCustomerInterest.VoidId = customerInterest.VoidId;
                persistedCustomerInterest.ApplicationId = customerInterest.ApplicationId;
                persistedCustomerInterest.PropertyCode = customerInterest.PropertyCode;
                persistedCustomerInterest.CreatedBy = customerInterest.CreatedBy;
                persistedCustomerInterest.CreatedDate = customerInterest.CreatedDate;
                persistedCustomerInterest.OutcomeNotes = customerInterest.Notes;

                if (customerInterest.CustomerInterestStatusId == 2)
                {
                    persistedCustomerInterest.Notes = "VBL: Not Interested " + customerInterest.Notes;
                    persistedCustomerInterest.NotInterestedReasonId = customerInterest.NotInterestedReasonID;
                }
            }

            persistedCustomerInterest.CustomerInterestStatusId = customerInterest.CustomerInterestStatusId;
            persistedCustomerInterest.ModifiedBy = customerInterest.ModifiedBy;
            persistedCustomerInterest.ModifiedDate = DateTime.Now;
            persistedCustomerInterest.StatusReasonsDate = customerInterest.StatusReasonsDate;
            persistedCustomerInterest.UserIPAddress = customerInterest.UserIPAddress;
            persistedCustomerInterest.UserId = customerInterest.UserId;

            if (persistedCustomerInterest.CustomerInterestId == 0 && persistedCustomerInterest.CustomerInterestStatusId != 11)
            {
                _unitOfWork.VBLCustomerInterests().Insert(persistedCustomerInterest);
            }
            else
            {
                _unitOfWork.VBLCustomerInterests().Update(persistedCustomerInterest);
            }

            customerInterest.PropertyCode = persistedCustomerInterest.PropertyCode;
        }


        public VBLCustomerInterestDTO UpSertVblCustomerInterest(VBLCustomerInterestDTO customerInterest)
        {
            if (customerInterest == null)
                return null;

            ValidateCustomerInterest(customerInterest);

            if (!string.IsNullOrWhiteSpace(customerInterest.ErrorMessage))
                return customerInterest;

            UpdatePersistedValuesFromDto(customerInterest);
            var changeDescription = "Matched from waiting list";

            _applicationHistoryBLL.Create(customerInterest.ApplicationId, customerInterest.CreatedBy,
                customerInterest.UserIPAddress, ApplicationActivity.PropertyInterest,
                ApplicationChangeType.PropertyInterestStatusChanged,
                changeDescription, customerInterest.PropertyCode, false);
            _unitOfWork.Commit(customerInterest.UserId, customerInterest.UserIPAddress);

            return customerInterest;
        }

        public IList<VBLCustomerInterest> GetCustomerInterests(IList<int> propertyMatchTaskIds)
        {
            return _unitOfWork
                .VBLCustomerInterests()
                .Select(ci => propertyMatchTaskIds.Contains(ci.TaskId))
                .ToList();
        }
    }
}
