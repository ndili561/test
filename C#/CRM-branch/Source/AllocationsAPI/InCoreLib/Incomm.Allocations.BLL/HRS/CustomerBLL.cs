using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using Incomm.Allocations.BLL.Interfaces.HRS;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL
{
    public class CustomerBLL : ICustomerBLL
    {
        private IUnitOfWork _unitOfWork;
        private IMatchingBLL _matchingBLL;
        const string IncludeProperties = "ServiceTypes,SupportTypes,HRSPlacementsMatched.Placement.HRSProvider";
        public CustomerBLL() : this(new UnitOfWork(), new MatchingBLL())
        {
        }

        public CustomerBLL(IUnitOfWork unitOfWork, IMatchingBLL matchingBLL)
        {
            _unitOfWork = unitOfWork;
            _matchingBLL = matchingBLL;
        }
        public CustomerViewModel GetProviderCustomerList(CustomerViewModel customerViewModel, int providerId)
        {
            throw new NotImplementedException();
        }

        public List<HRSCustomerDTO> GetHRSCustomers(ODataQueryOptions<HRSCustomer> options)
        {
            var customers = options.ApplyTo(_unitOfWork.HRSCustomer()
                                                        .Select(includeProperties: IncludeProperties)
                                                        .AsNoTracking()
                                                        .AsQueryable());
            var customerDtoList = Mapper.Map<List<HRSCustomerDTO>>(customers);
            if (customerDtoList.Any(x => x.RunMatchingAlgorithm))
            {
                var customerDto = customerDtoList.First(x => x.RunMatchingAlgorithm);
                _matchingBLL.AddMatchingPlacementListToCustomer(customerDto.HRSCustomerId, customerDto.SelectedSupportType.ToList(), customerDto.SelectedServiceType.ToList());
              
            }
            customerDtoList = Mapper.Map<List<HRSCustomerDTO>>(options.ApplyTo(_unitOfWork.HRSCustomer()
                                                                      .Select(includeProperties: IncludeProperties)
                                                                      .AsNoTracking()
                                                                      .AsQueryable()));
            return customerDtoList;
        }

        public HRSCustomerDTO GetHRSCustomer(int customerId)
        {
           
            var customer = _unitOfWork.HRSCustomer()
                    .Select(includeProperties: IncludeProperties)
                    .FirstOrDefault(x => x.HRSCustomerId == customerId);
            var customerDto = Mapper.Map<HRSCustomerDTO>(customer);
            if (customerDto.RunMatchingAlgorithm)
            {
                _matchingBLL.AddMatchingPlacementListToCustomer(customerId, customerDto.SelectedSupportType.ToList(),customerDto.SelectedServiceType.ToList());
            }
            return customerDto;
        }

        public HRSCustomerDTO RunMatchAlgorithmAndGetHRSCustomer(int hrsCustomerId, bool runMatchAlgorithm)
        {
            var customer = _unitOfWork.HRSCustomer()
                                    .Select(includeProperties: IncludeProperties)
                                    .FirstOrDefault(x => x.HRSCustomerId == hrsCustomerId);
            var customerDto = Mapper.Map<HRSCustomerDTO>(customer);
            if (customerDto.RunMatchingAlgorithm)
            {
                _matchingBLL.AddMatchingPlacementListToCustomer(hrsCustomerId, customerDto.SelectedSupportType.ToList(), customerDto.SelectedServiceType.ToList());
                customerDto = Mapper.Map<HRSCustomerDTO>(_unitOfWork.HRSCustomer()
                .Select(includeProperties: IncludeProperties)
                .FirstOrDefault(x => x.HRSCustomerId == hrsCustomerId));
            }
            return customerDto;
        }

        public HRSCustomerDTO PostHRSCustomer(HRSCustomerDTO item)
        {
            var entityTobeSave = Mapper.Map<HRSCustomer>(item);
            entityTobeSave.Status = Status.AssignedToHRSOfficer;
            _unitOfWork.HRSCustomer().Insert(entityTobeSave);
            _unitOfWork.Commit(entityTobeSave.UserId, entityTobeSave.UserIPAddress);
            var caseNote = new tblCaseNote
            {
                CaseRefNumber = entityTobeSave.HOACaseReference,
                CaseNoteDate = DateTime.Now,
                CaseNoteUserID = item.UserId,
                CaseNoteType = "HRSNote",
                CaseNote = $"Assigned to {item.GatewayOfficer}"
            };
            _unitOfWork.CaseNotes().Insert(caseNote);
            _unitOfWork.Commit();

            return item = Mapper.Map<HRSCustomerDTO>(entityTobeSave);
        }

        public HRSCustomerDTO UpdateCustomer(int id, HRSCustomerDTO hrsCustomerDto)
        {
            var persistedObject =
                _unitOfWork.HRSCustomer()
                    .Select(includeProperties: "SupportTypes,ServiceTypes,HRSPlacementsMatched.Placement ")
                    .FirstOrDefault(x => x.HRSCustomerId == id);
            if (persistedObject != null)
            {
                persistedObject.Status = hrsCustomerDto.Status;
                persistedObject.Priority = hrsCustomerDto.Priority;
                persistedObject.MinBedroomSize = hrsCustomerDto.MinBedroomSize;
                persistedObject.Gender = hrsCustomerDto.Gender;
                persistedObject.ServiceTypes.Clear();
                persistedObject.SupportTypes.Clear();
                if (hrsCustomerDto.SelectedServiceType != null)
                {
                    var serviceTypeList = hrsCustomerDto.SelectedServiceType.ToList();
                    foreach (var serviceType in serviceTypeList)
                    {
                        int selectedServiceTypeId;
                        int.TryParse(serviceType, out selectedServiceTypeId);
                        if (selectedServiceTypeId <= 0) continue;
                        var persistedServiceType =
                            _unitOfWork.ServiceType()
                                .Select()
                                .FirstOrDefault(x => x.ServiceTypeId == selectedServiceTypeId);
                        persistedObject.ServiceTypes.Add(persistedServiceType);
                        _unitOfWork.Commit(persistedServiceType.UserId, persistedServiceType.UserIPAddress);
                    }
                }
                if (hrsCustomerDto.SelectedSupportType != null)
                {
                    var supportTypeList = hrsCustomerDto.SelectedSupportType.ToList();
                    foreach (var supportType in supportTypeList)
                    {
                        int selectedSupportTypeId;
                        int.TryParse(supportType, out selectedSupportTypeId);
                        if (selectedSupportTypeId <= 0) continue;
                        var persistedSupportType =
                            _unitOfWork.SupportType()
                                .Select()
                                .FirstOrDefault(x => x.SupportTypeId == selectedSupportTypeId);
                        persistedObject.SupportTypes.Add(persistedSupportType);
                        _unitOfWork.Commit(persistedSupportType.UserId, persistedSupportType.UserIPAddress);
                    }
                }
                persistedObject.UserId = hrsCustomerDto.UserId;
                persistedObject.UserIPAddress = hrsCustomerDto.UserIPAddress;
                persistedObject.ModifiedDate = hrsCustomerDto.ModifiedDate;
                persistedObject.ModifiedBy = hrsCustomerDto.ModifiedBy;
                persistedObject.Status = hrsCustomerDto.Status;
                _unitOfWork.HRSCustomer().Update(persistedObject);
                _unitOfWork.Commit(persistedObject.UserId, persistedObject.UserIPAddress);
                if (hrsCustomerDto.RunMatchingAlgorithm)
                {
                    _matchingBLL.AddMatchingPlacementListToCustomer(persistedObject.HRSCustomerId, hrsCustomerDto.SelectedSupportType.ToList(), hrsCustomerDto.SelectedServiceType.ToList());
                }
            }
            return Mapper.Map<HRSCustomerDTO>(persistedObject);
        }

        public Task<List<HRSCustomerDTO>> GetHRSCustomersList(string assignedTo)
        {
            throw new NotImplementedException();
        }

        public List<HRSCustomerDTO> GetHRSCustomersListSync(string assignedTo)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {

            var matchedPlacemntToDelete =
                _unitOfWork.HRSPlacementMatchedForCustomer()
                    .Select()
                    .Where(x => x.Customer.HRSCustomerId == id )
                    .Where(x => x.Status != Status.RejectedByProvider)
                    .ToList();
            for (var ctr = 0; ctr < matchedPlacemntToDelete.Count; ctr++)
            {
                var placementMatch = matchedPlacemntToDelete[ctr];

                var placementToUpdate =
                    _unitOfWork.Placement().Select().FirstOrDefault(x => x.PlacementId == placementMatch.PlacementId);
                if (placementToUpdate.PlacementStatus != PlacementStatus.Completed &&
                    placementToUpdate.PlacementStatus != PlacementStatus.Occupied)
                {
                    placementToUpdate.PlacementStatus = PlacementStatus.Available;
                    _unitOfWork.Placement().Update(placementToUpdate);
                    _unitOfWork.Commit();

                }
                _unitOfWork.HRSPlacementMatchedForCustomer().Delete(placementMatch);
            }
            var matchesToDelete = _unitOfWork.HRSMatchHistory().Select().Where(x => x.Customer.HRSCustomerId == id);
            foreach (var matchHistory in matchesToDelete)
            {
                _unitOfWork.HRSMatchHistory().Delete(matchHistory);
            }
            _unitOfWork.Commit();
            var persistedObject = _unitOfWork.HRSCustomer().Select().FirstOrDefault(x => x.HRSCustomerId == id);
            _unitOfWork.HRSCustomer().Delete(persistedObject);
            _unitOfWork.Commit();


        }

        public HRSCustomerDTO GetHRSCustomerSync(int customerId)
        {
            throw new NotImplementedException();
        }

        public HRSCustomerDTO HRSCustomerByApplicationId(int applicationId)
        {
            var hoaCaseRef = _unitOfWork.VBLApplications().Select(a => a.ApplicationId == applicationId).FirstOrDefault()?.HOACaseRef;

            if (hoaCaseRef == null || hoaCaseRef == 0)
            {
                return null;
            }

            var customerId = _unitOfWork.HRSCustomer().Select(a => a.HOACaseReference == hoaCaseRef).FirstOrDefault()?.HRSCustomerId;

            if (customerId == null || customerId == 0)
            {
                return null;
            }

            return GetHRSCustomer(customerId.Value);
        }
    }
}