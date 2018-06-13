using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.HRS;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL
{
    public class MatchingBLL : IMatchingBLL
    {
        private IUnitOfWork _unitOfWork;
        public MatchingBLL() : this(new UnitOfWork())
        {
        }

        public MatchingBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// This mehtod must be called every time any change happen in Placement 
        /// </summary>
        /// <param name="hrsPlacementId"></param>
        /// <param name="selectedSupportTypeId"></param>
        /// <param name="selectedServiceTypeId"></param>
        /// <returns></returns>
        public void AddMatchingCustomerListToPlacement(int hrsPlacementId, string selectedSupportTypeId, string selectedServiceTypeId)
        {
            ExecuteMatchingAlgoritmForPlacement(hrsPlacementId, selectedSupportTypeId, selectedServiceTypeId);
            FindMatchingCustomerForAllAvailablePlacement();
        }

        private void ExecuteMatchingAlgoritmForPlacement(int hrsPlacementId, string selectedSupportTypeId,string selectedServiceTypeId)
        {
            #region Algorithm to find best customer for a given placement

            //Step 1: Find the Placement
            //Step 2: If placement is not NULL and Placement status is Available then goto Step 3 or return false
            //Step 3: Find all the customers that matches the criteria
            //Step 4: Find Id of all the customers that are rejected by provider for the given placement
            //Step 5: Filter customers found in step 3, by excluding all found in step 4 and select the first one based on Priority
            //Step 6: Delete all the customer not found in step 5
            //Step 7: If new match found in step 6, add record in HRSCustomersMatched of the placement
            //Step 8: If no match found in step 6, update the placement with Status as Available

            #endregion

            #region Step1
            //Step 1: Find the Placement
            var hrsPlacement = _unitOfWork.Placement()
                .Select(includeProperties: "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer")
                .FirstOrDefault(x => x.PlacementId == hrsPlacementId);

            #endregion

            #region Step2
            //Step 2: If placement is not NULL and Placement status is Available then goto Step 3 or return false
            if (hrsPlacement?.PlacementStatus == PlacementStatus.Available)
            {
                #endregion

                #region Step 3
                //Step 3: Find all the customers that matches the criteria
                var customerGenders = GetCustomerGender(hrsPlacement);
                var matchedCustomers = _unitOfWork.HRSCustomer()
                    .Select()
                    .Where(x => x.MinBedroomSize <= hrsPlacement.MinimumBedroom
                                && x.SupportTypes.Select(s => s.SupportTypeId.ToString()).Contains(selectedSupportTypeId)
                                && x.ServiceTypes.Select(a => a.ServiceTypeId.ToString()).Contains(selectedServiceTypeId)
                                && customerGenders.Contains(x.Gender)
                                && (x.Status == Status.OnWaitingList || x.Status == Status.Reconsider))
                    .OrderByDescending(x => x.Priority).ToList();

                #endregion

                #region Step 4
                //Step 4: Find Id of all the customers that are rejected by provider for the given placement

                var excludedCustomerId = _unitOfWork.HRSMatchHistory().Select(includeProperties: "Customer")
                    .Where(x => x.Placement.PlacementId == hrsPlacement.PlacementId
                                && x.Outcome == Status.RejectedByProvider
                                && x.Reconsidered == false)
                    .Select(s => s.Customer.HRSCustomerId)
                    .ToArray();

                #endregion

                #region Step 5
                //Step 5: Filter customers found in step 3, by excluding all found in step 4 and select the first one based on Priority

                var matchedCustomer = matchedCustomers.Where(x => !excludedCustomerId.Contains(x.HRSCustomerId))
                    .OrderByDescending(x => x.Priority)
                    .FirstOrDefault();

                #endregion

                #region Step 6
                //Step 6: Delete all the customers not found in step 5

                var customerToBeDeletedList = matchedCustomer != null
                    ? hrsPlacement.HRSCustomersMatched.Where(x => x.Status != Status.RejectedByProvider
                                                                  && x.CustomerId != matchedCustomer.HRSCustomerId)
                        .ToList()
                    : hrsPlacement.HRSCustomersMatched.Where(x => x.Status != Status.RejectedByProvider)
                        .ToList();
                if (customerToBeDeletedList.Any())
                {
                    for (int i = 0; i < customerToBeDeletedList.Count; i++)
                    {
                        customerToBeDeletedList[i].Notes = customerToBeDeletedList[i].Notes + " Deleted by Placement Matching Algorithm";
                        _unitOfWork.HRSPlacementMatchedForCustomer().Update(customerToBeDeletedList[i]);
                        _unitOfWork.Commit();
                        _unitOfWork.HRSPlacementMatchedForCustomer().Delete(customerToBeDeletedList[i]);
                    }

                    _unitOfWork.Commit();
                }

                #endregion

                #region Step 7
                //Step 7: If new match found in step 6, add record in HRSCustomersMatched of the placement

                if (matchedCustomer != null)
                {
                    if (
                        !hrsPlacement.HRSCustomersMatched.Any(
                            x => x.CustomerId == matchedCustomer.HRSCustomerId && x.PlacementId == hrsPlacement.PlacementId))
                    {
                        var hrsPlacementMatchedForCustomer = GetHrsPlacementMatchedForCustomer(matchedCustomer, hrsPlacement);
                        _unitOfWork.HRSPlacementMatchedForCustomer().Insert(hrsPlacementMatchedForCustomer);
                    }
                    else
                    {
                        var hrsPlacementMatchedForCustomer = hrsPlacement.HRSCustomersMatched.FirstOrDefault(
                            x => x.CustomerId == matchedCustomer.HRSCustomerId &&
                                 x.PlacementId == hrsPlacement.PlacementId);
                        if (hrsPlacementMatchedForCustomer != null)
                            hrsPlacementMatchedForCustomer.Status = Status.PlacementMatched;
                        _unitOfWork.HRSPlacementMatchedForCustomer().Update(hrsPlacementMatchedForCustomer);
                    }
                    matchedCustomer.Status = Status.PlacementMatched;
                    _unitOfWork.HRSCustomer().Update(matchedCustomer);
                    hrsPlacement.PlacementStatus = PlacementStatus.MatchedByProvider;
                    _unitOfWork.Commit();
                }
                #endregion

                #region Step 8
                //Step 8: If no match found in step 6, update the placement with Status as Available
                
            
                //Deleted as redundant

                //else
                //{
                //    if (hrsPlacement.PlacementStatus == PlacementStatus.MatchedByProvider ||
                //        hrsPlacement.PlacementStatus == PlacementStatus.ReferredToProvider)
                //    {
                //        hrsPlacement.PlacementStatus = PlacementStatus.Available;
                //        _unitOfWork.Placement().Update(hrsPlacement);
                //        _unitOfWork.Commit();
                //    }
                //}

                #endregion

            }
        }

        private HRSPlacementMatchedForCustomer GetHrsPlacementMatchedForCustomer(HRSCustomer matchedCustomer, HRSPlacement hrsPlacement)
        {
            return new HRSPlacementMatchedForCustomer
            {
                CustomerId = matchedCustomer.HRSCustomerId,
                PlacementId = hrsPlacement.PlacementId,
                CreatedDate = DateTime.Now,
                Status = Status.PlacementMatched,
                CreatedBy = hrsPlacement.CreatedBy,
                EventDate = DateTime.Now,
                UserId = hrsPlacement.UserId,
                UserIPAddress = hrsPlacement.UserIPAddress
            };
        }

        private List<CustomerGender> GetCustomerGender(HRSPlacement hrsPlacement)
        {
            var customerGenders = new List<CustomerGender>();
            if (hrsPlacement.PlacementGender == PlacementGender.Male || hrsPlacement.PlacementGender == PlacementGender.Mixed)
            {
                customerGenders.Add(CustomerGender.Male);
            }
            if (hrsPlacement.PlacementGender == PlacementGender.Female ||
                hrsPlacement.PlacementGender == PlacementGender.Mixed)
            {
                customerGenders.Add(CustomerGender.Female);
            }
            if (hrsPlacement.PlacementGender == PlacementGender.Mixed)
            {
                customerGenders.Add(CustomerGender.Other);
            }

            return customerGenders;
        }

        public void AddMatchingPlacementListToCustomer(int hrsCustomerId, List<string> selectedSupportTypeIds, List<string> selectedServiceTypeIds)
        {
            ExecuteMatchingAlgoritmForCustomer(hrsCustomerId, selectedSupportTypeIds, selectedServiceTypeIds);
            FindMatchingPlacementForAllCustomerInWaitingState();
        }

        private void ExecuteMatchingAlgoritmForCustomer(int hrsCustomerId, List<string> selectedSupportTypeIds,List<string> selectedServiceTypeIds)
        {
            #region Algorithm to find all placements for a given customer

            //Step 1: Find the Customer
            //Step 2: If Customer is not NULL and Customer status is OnWaitingList then goto Step 3 or return
            //Step 3: Find all the placement that matches the criteria of the customer
            //Step 4: Find Id of all the placements that are rejected by provider for the given Customer
            //Step 5: Filter placements found in step 4, by excluding all found in step 5 and select all the placements.
            //Step 6: Delete all the placements that are not found in step 5
            //Step 7: Update the placement with Status as MatchedByProvider and Customer with status PlacementMatched and return;
            //Step 8: Insert All the matching placement(HRSPlacementMatchedForCustomer) into Customer with status PlacementMatchedByOfficer. 

            #endregion

            #region Step 1

            var customer = _unitOfWork.HRSCustomer()
                .Select(includeProperties: "SupportTypes,ServiceTypes,HRSPlacementsMatched.Placement.HRSProvider")
                .FirstOrDefault(x => x.HRSCustomerId == hrsCustomerId);

            #endregion

            #region Step 2

            if (customer?.Status == Status.OnWaitingList)
            {
                #endregion

                #region Step 3

                var placementGenders = GetPlacementGender(customer);
                var matchingPlacements = _unitOfWork.Placement().Select()
                    .Where(x => x.MinimumBedroom >= customer.MinBedroomSize
                                && placementGenders.Contains(x.PlacementGender)
                                && selectedSupportTypeIds.Contains(x.SupportTypeId.ToString())
                                &&
                                selectedServiceTypeIds.Intersect(x.ServiceTypes.Select(a => a.ServiceTypeId.ToString())).Any()
                                && (x.PlacementStatus == PlacementStatus.Available)
                    );

                #endregion

                #region Step 4

                var excludedPlacements = _unitOfWork.HRSMatchHistory()
                    .Select(includeProperties: "Placement")
                    .Where(x => x.Customer.HRSCustomerId == customer.HRSCustomerId
                                && x.Outcome == Status.RejectedByProvider
                                && x.Reconsidered == false);

                #endregion

                #region Step 5

                var matchingPlacementsList = matchingPlacements
                    .Where(x => !excludedPlacements.Any(v => v.Placement.PlacementId == x.PlacementId))
                    .ToList();

                #endregion

                #region Step 6

                var persistedMatchedPlacementIds = customer.HRSPlacementsMatched.Select(x => x.PlacementId).ToList();
                var currentMatchedPlacementIds = matchingPlacementsList.Select(x => x.PlacementId).ToList();
                var placementToBeDeleted =
                    customer.HRSPlacementsMatched.Where(
                        x => !currentMatchedPlacementIds.Contains(x.PlacementId) && x.Status != Status.RejectedByProvider && x.Status != Status.PlacementMatched)
                        .ToList();
                if (placementToBeDeleted.Any())
                {
                    for (int i = 0; i < placementToBeDeleted.Count; i++)
                    {
                        placementToBeDeleted[i].Notes = placementToBeDeleted[i].Notes + " Deleted by Customer Matching Algorithm";
                        _unitOfWork.HRSPlacementMatchedForCustomer().Update(placementToBeDeleted[i]);
                        _unitOfWork.Commit();
                        _unitOfWork.HRSPlacementMatchedForCustomer().Delete(placementToBeDeleted[i]);
                    }
                    _unitOfWork.Commit();
                }

                #endregion

                #region Step 7

                if (matchingPlacementsList.Count == 1)
                {
                    var matchedPlacement = matchingPlacementsList.First();
                    var hrsPlacementMatchedForCustomer = GetHrsPlacementMatchedForCustomer(matchedPlacement, customer);
                    hrsPlacementMatchedForCustomer.Status = Status.PlacementMatched;
                    _unitOfWork.HRSPlacementMatchedForCustomer().Insert(hrsPlacementMatchedForCustomer);
                    customer.Status = Status.PlacementMatched;
                    _unitOfWork.HRSCustomer().Update(customer);
                    matchedPlacement.PlacementStatus = PlacementStatus.MatchedByProvider;
                    _unitOfWork.Commit();
                }
                    #endregion

                    #region Step 8

                else
                {
                    if (matchingPlacementsList.Any())
                    {
                        var newPlacementMatchList =
                            matchingPlacementsList.Where(x => !persistedMatchedPlacementIds.Contains(x.PlacementId)).ToList();
                        foreach (var matchedPlacement in newPlacementMatchList)
                        {
                            var hrsPlacementMatchedForCustomer = GetHrsPlacementMatchedForCustomer(matchedPlacement, customer);
                            _unitOfWork.HRSPlacementMatchedForCustomer().Insert(hrsPlacementMatchedForCustomer);
                        }
                        _unitOfWork.Commit();
                    }
                }

                #endregion
            }
        }

        private HRSPlacementMatchedForCustomer GetHrsPlacementMatchedForCustomer(HRSPlacement matchedPlacement, HRSCustomer customer)
        {
            return new HRSPlacementMatchedForCustomer
            {
                PlacementId = matchedPlacement.PlacementId,
                CustomerId = customer.HRSCustomerId,
                Status = Status.PlacementMatchedByOfficer,
                CreatedBy = customer.CreatedBy,
                CreatedDate = DateTime.Now,
                EventDate = DateTime.Now
            };
        }

        private List<PlacementGender> GetPlacementGender(HRSCustomer customer)
        {
            var placementGenders = new List<PlacementGender> { PlacementGender.Mixed };
            if (customer.Gender == CustomerGender.Male)
            {
                placementGenders.Add(PlacementGender.Male);
            }
            else if (customer.Gender == CustomerGender.Female)
            {
                placementGenders.Add(PlacementGender.Female);
            }
            else if (customer.Gender == CustomerGender.Other)
            {
                placementGenders.Add(PlacementGender.Mixed);
            }

            return placementGenders;
        }

        private void FindMatchingPlacementForAllCustomerInWaitingState()
        {
            const string includeProperties = "ServiceTypes,SupportTypes,HRSPlacementsMatched.Placement.HRSProvider";
            var customers = _unitOfWork.HRSCustomer()
                            .Select(includeProperties: includeProperties)
                            .AsNoTracking()
                            .Where(x => x.Status == Status.OnWaitingList || x.Status == Status.Reconsider)
                            .ToList();
            var customerDtoList = Mapper.Map<List<HRSCustomerDTO>>(customers);
            foreach (var customer in customerDtoList)
            {
                ExecuteMatchingAlgoritmForCustomer(customer.HRSCustomerId, 
                    customer.SelectedSupportType.ToList(),
                    customer.SelectedServiceType.ToList());
            }
        }
        private void FindMatchingCustomerForAllAvailablePlacement()
        {
            var includeProperties = "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer";
            var placements =_unitOfWork.Placement()
                                .Select(includeProperties: includeProperties)
                                .Where(x => x.PlacementStatus == PlacementStatus.Available)
                                .AsNoTracking()
                                .AsQueryable();
            var placementDtoList = Mapper.Map<List<HRSPlacementDTO>>(placements);
            foreach (var placement in placementDtoList.Where(x=>x.RunMatchingAlgorithm))
            {
                ExecuteMatchingAlgoritmForPlacement(placement.PlacementId, placement.SupportTypeId.ToString(), placement.ServiceTypeId.ToString());
            }
        }
    }
}