using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.VBL
{
    public class SupportBLL : ISupportBLL
    {

        private IUnitOfWork _unitOfWork;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public SupportBLL() : this(new UnitOfWork(), new ApplicationHistoryBLL())
        {
        }

        public SupportBLL(IUnitOfWork unitOfWork, IApplicationHistoryBLL applicationHistoryBLL)
        {
            _unitOfWork = unitOfWork;
            _applicationHistoryBLL = applicationHistoryBLL;
        }


        public VBLContact GetContact(int contactId)
        {
            return _unitOfWork.VBLContacts()
                            .Select(includeProperties: "RequestedSupportDetails,ReceivingSupportDetails")
                            .FirstOrDefault(x => x.ContactId == contactId);
        }

        public VBLReceivingSupportDetails Create(VBLSupportDetailsDTO supportDetail)
        {
            var changeDescription = string.Empty;
            var currentSupport = _unitOfWork.VBLReceivingSupportDetails().Select().FirstOrDefault(x => x.ContactId == supportDetail.ContactId);
            var details = new VBLReceivingSupportDetails
            {
                ContactId = supportDetail.ContactId,
                Name = supportDetail.Name,
                SupportProviderId = supportDetail.SupportProviderId,
                ThirdPartyAuth = supportDetail.ThirdPartyAuth,
                SupportTypeId = supportDetail.SupportTypeId,
                CreatedDate = DateTime.Now
            };
            var savedDetails = _unitOfWork.VBLReceivingSupportDetails().Insert(details);
            _unitOfWork.Commit(supportDetail.UserId, supportDetail.UserIPAddress);
            SaveContactDetailsOfSupportMember(supportDetail, savedDetails.ReceivingSupportDetailId);
            var contact = _unitOfWork.VBLContacts().Select().First(x => x.ContactId == supportDetail.ContactId);
            var supportProvider =
                _unitOfWork
                    .VBLSupportProviders()
                    .Select()
                    .First(x => x.SupportProviderId == supportDetail.SupportProviderId);
            changeDescription = changeDescription +
                                string.Format("Current Support <span class=\"newvalue\">" + details.Name +
                                              "</span> added <br /> Type: <span class=\"newvalue\">" + supportProvider.Name + "</span><br />");
            if (!string.IsNullOrWhiteSpace(supportDetail.Landline))
            {
                changeDescription = changeDescription +
                                string.Format("Landline: <span class=\"newvalue\">" + supportDetail.Landline + "</span><br/>");
            }
            if (!string.IsNullOrWhiteSpace(supportDetail.Mobile))
            {
                changeDescription = changeDescription +
                                   string.Format("Mobile: <span class=\"newvalue\">" + supportDetail.Mobile + "</span><br/>");

            }
            if (!string.IsNullOrWhiteSpace(supportDetail.Email))
            {
                changeDescription = changeDescription +
                                string.Format("Email: <span class=\"newvalue\">" + supportDetail.Email + "</span><br/>");
            }
            changeDescription = changeDescription +
                                string.Format("3rd Party Auth?: <span class=\"newvalue\">" + supportDetail.ThirdPartyAuth + "</span><br/>");
            if (changeDescription != "")
            {
                if (currentSupport != null)
                {
                    _applicationHistoryBLL.Create(contact.ApplicationId, supportDetail.UserId,
                        supportDetail.UserIPAddress,
                        ApplicationActivity.Ammendment, ApplicationChangeType.IncomeDetails, changeDescription);
                }
                else
                {
                    _applicationHistoryBLL.Create(contact.ApplicationId, supportDetail.UserId,
                        supportDetail.UserIPAddress,
                        ApplicationActivity.NewDetails, ApplicationChangeType.IncomeDetails, changeDescription);
                }
            }
            return details;
        }

        public VBLSupportDetailsDTO GetSupport(int contactId, int supportId)
        {
            var support = _unitOfWork.VBLReceivingSupportDetails()
                            .Select(
                                    includeProperties: "SupportType,SupportProvider,ContactByDetails,ContactByDetails.ContactBy")
                                    .AsNoTracking()
                                .FirstOrDefault(x => x.ContactId == contactId &&x.ReceivingSupportDetailId == supportId);
            var supportDto = Mapper.Map<VBLSupportDetailsDTO>(support);
            supportDto.SupportDetailId = supportId;
            MapContactDetails(supportDto);
            return supportDto;
        }

        private void SaveContactDetailsOfSupportMember(VBLSupportDetailsDTO detailsDto, int supportDetailId)//work on removing removed entries
        {
            if (detailsDto.Landline != null)
            {
                var landlineDetails = GetContactDetail(supportDetailId, 1, detailsDto.Landline);
                if (landlineDetails.RowVersion == null)
                {
                    _unitOfWork.VBLSupportContactByDetails().Insert(landlineDetails);
                }
                else
                {
                    landlineDetails.ContactValue = detailsDto.Landline;
                    _unitOfWork.VBLSupportContactByDetails().Update(landlineDetails);

                }
            }
            else
            {
                var entityToDelete =
                    _unitOfWork
                        .VBLSupportContactByDetails()
                        .Select().FirstOrDefault(x => x.ReceivingSupportDetailId == supportDetailId && x.ContactById == 1);
                if(entityToDelete != null)
                {
                    _unitOfWork.VBLSupportContactByDetails().Delete(entityToDelete);
                }
            }
            if (detailsDto.Mobile != null)
            {
                var mobileDetails = GetContactDetail(supportDetailId, 3, detailsDto.Mobile);
                if (mobileDetails.RowVersion == null)
                {
                    _unitOfWork.VBLSupportContactByDetails().Insert(mobileDetails);
                }
                else
                {
                    mobileDetails.ContactValue = detailsDto.Mobile;
                    _unitOfWork.VBLSupportContactByDetails().Update(mobileDetails);

                }
            }
            else
            {
                var entityToDelete =
                    _unitOfWork
                        .VBLSupportContactByDetails()
                        .Select().FirstOrDefault(x => x.ReceivingSupportDetailId == supportDetailId && x.ContactById == 3);
                if (entityToDelete != null)
                {
                    _unitOfWork.VBLSupportContactByDetails().Delete(entityToDelete);
                }
            }
            if (detailsDto.Email != null)
            {
                var emailDetails = GetContactDetail(supportDetailId, 4, detailsDto.Email);
                if (emailDetails.RowVersion== null)
                {
                    _unitOfWork.VBLSupportContactByDetails().Insert(emailDetails);
                }
                else
                {
                    emailDetails.ContactValue = detailsDto.Email;
                    _unitOfWork.VBLSupportContactByDetails().Update(emailDetails);

                }
            }
            else
            {
                var entityToDelete =
                    _unitOfWork
                        .VBLSupportContactByDetails()
                        .Select().FirstOrDefault(x => x.ReceivingSupportDetailId == supportDetailId && x.ContactById == 4);
                if (entityToDelete != null)
                {
                    _unitOfWork.VBLSupportContactByDetails().Delete(entityToDelete);
                }
            }
            _unitOfWork.Commit(detailsDto.UserId, detailsDto.UserIPAddress);
        }

        private VBLSupportContactByDetails GetContactDetail(int supportDetailId, int contactById, string contactByValue)
        {
            var persistedSupport =
               _unitOfWork.VBLSupportContactByDetails()
                    .Select()
                    .FirstOrDefault(x => x.ReceivingSupportDetailId == supportDetailId && x.ContactById == contactById);
            if (persistedSupport != null)
            {
                return persistedSupport;
            }

            return new VBLSupportContactByDetails
            {
                ReceivingSupportDetailId = supportDetailId,
                ContactById = contactById,
                ContactValue = contactByValue,
                CreatedDate = DateTime.Now,
            };
        }
        public VBLContact Update(VBLContact contact, VBLContact persistedContact)
        {

            //delete existing entries
            if (contact.OtherSupportDetails != persistedContact.OtherSupportDetails)
            {
                persistedContact.OtherSupportDetails = contact.OtherSupportDetails;
                _unitOfWork.VBLContacts().Update(persistedContact);
                _unitOfWork.Commit();
            }

            UpsertRequestedSupportDetails(contact, persistedContact);
            return persistedContact;
        }

        public VBLSupportDetailsDTO UpdateSupport(VBLSupportDetailsDTO supportDto, VBLSupportDetailsDTO persistedSupport)
        {
            var support = _unitOfWork.VBLReceivingSupportDetails()
                .Select(x => x.ContactId == supportDto.ContactId && x.ReceivingSupportDetailId == supportDto.SupportDetailId)
                .FirstOrDefault();

            if (support == null)
            {
                throw new ArgumentNullException(nameof(support));
            }

            support.Name = supportDto.Name;
            support.SupportTypeId = supportDto.SupportTypeId;
            support.SupportProviderId = supportDto.SupportProviderId;
            support.ThirdPartyAuth = supportDto.ThirdPartyAuth;
            support.ReceivingSupportDetailId = supportDto.SupportDetailId;
            support.ModifiedDate = DateTime.Now;
            support.ModifiedBy = supportDto.UserId;
            support.ContactByDetails = null;
            _unitOfWork.VBLReceivingSupportDetails().Update(support);
            _unitOfWork.Commit();

            SaveContactDetailsOfSupportMember(supportDto, supportDto.SupportDetailId);

            return supportDto;
        }

        protected void UpsertRequestedSupportDetails(VBLContact contact, VBLContact persistedContact)
        {
            var changeDescription = string.Empty;
            var amend = persistedContact.RequestedSupportDetails.Count > 0;
            var supportTypes = new List<VBLSupportType>();
            var addedRequestedSupportDetails = contact.RequestedSupportDetails.Where(a => persistedContact.RequestedSupportDetails.All(x => x.SupportTypeId != a.SupportTypeId)).ToList();
            if (addedRequestedSupportDetails.Any())
            {
                supportTypes = _unitOfWork.VBLSupportTypes().Select().Where(x => x.Active).ToList();
                supportTypes = supportTypes.Where(x => addedRequestedSupportDetails.Select(a => a.SupportTypeId).Contains(x.SupportTypeId)).ToList();
                changeDescription = changeDescription + string.Format("Requested Support Type <span class=\"newvalue\">{0}</span> added", string.Join(", ", supportTypes.Select(x => x.Name))) + "<br>";
                foreach (var addedRequestedSupportDetail in addedRequestedSupportDetails)
                {
                    addedRequestedSupportDetail.CreatedBy = contact.UserId;
                    addedRequestedSupportDetail.CreatedDate = DateTime.Now;
                    _unitOfWork.VBLRequestedSupportDetails().Insert(addedRequestedSupportDetail);
                }
            }

            var deletedRequestedSupportDetails = persistedContact.RequestedSupportDetails.Where(
                a =>
                    contact.RequestedSupportDetails.All(
                        x => x.SupportTypeId != a.SupportTypeId)).ToList();
            var deletedIds = deletedRequestedSupportDetails.Select(a => a.SupportTypeId).ToArray();
            supportTypes = _unitOfWork.VBLSupportTypes().Select().Where(x => x.Active && deletedIds.Contains(x.SupportTypeId)).ToList();
            if (deletedRequestedSupportDetails.Any())
            {
                changeDescription = changeDescription +
                                    string.Format("Requested Support Type <span class=\"oldvalue\"{0}</span> deleted",
                                        string.Join(", ", supportTypes.Select(x => x.Name))) + "<br>";

                for (int ctr = 0; ctr < deletedRequestedSupportDetails.Count; ctr++)
                {
                    var deletedRequestedSupportDetail = deletedRequestedSupportDetails[ctr];
                    _unitOfWork.VBLRequestedSupportDetails().Delete(deletedRequestedSupportDetail);
                }
            }
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            if (changeDescription != "")
            {
                if (amend)
                {
                    _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                        ApplicationActivity.Ammendment, ApplicationChangeType.SupportDetails, changeDescription);
                }
                else
                {
                    _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                       ApplicationActivity.NewDetails, ApplicationChangeType.SupportDetails, changeDescription);
                }
            }
        }

        public void Delete(int id, string userId, string userIPAddress)
        {
            var persistedSupport = _unitOfWork.VBLReceivingSupportDetails().Select(includeProperties: "").FirstOrDefault(x => x.ReceivingSupportDetailId == id);
            var contactByList = _unitOfWork.VBLSupportContactByDetails().Select().Where(x => x.ReceivingSupportDetailId == id).ToList();
            for (var ctr = 0; ctr < contactByList.Count; ctr++)
            {
                var contact = contactByList[ctr];
                _unitOfWork.VBLSupportContactByDetails().Delete(contact);
            }
            _unitOfWork.VBLReceivingSupportDetails().Delete(persistedSupport);
            _unitOfWork.Commit(userId, userIPAddress);
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public List<VBLSupportDetailsDTO> GetSupport(int contactId)
        {
            var support =
                _unitOfWork
                    .VBLReceivingSupportDetails()
                    .Select(s => s.ContactId == contactId, includeProperties: "SupportType,SupportProvider,ContactByDetails,ContactByDetails.ContactBy")
                    .ToList();

            var supportDtos = CreateVblSupportDetailsDtoList(support);

            return supportDtos;
        }

        public EntityPager<VBLSupportDetailsDTO> GetSupport(int contactId, int pageSize, int pageNumber)
        {
            if (pageSize <= 0 || pageNumber <= 0)
            {
                return new EntityPager<VBLSupportDetailsDTO>
                {
                    Results = null,
                    TotalPages = 0,
                    PageSize = pageSize,
                    CurrentPageNumber = pageNumber
                };
            }

            var support =
                _unitOfWork
                    .VBLReceivingSupportDetails()
                    .Select(s => s.ContactId == contactId, includeProperties: "SupportType,SupportProvider,ContactByDetails,ContactByDetails.ContactBy")
                    .OrderByDescending(s => s.ReceivingSupportDetailId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            var numberOfItems = 
                _unitOfWork
                    .VBLReceivingSupportDetails()
                    .Select(s => s.ContactId == contactId)
                    .Count();

            var supportDtos = CreateVblSupportDetailsDtoList(support);

            return new EntityPager<VBLSupportDetailsDTO>
            {
                CurrentPageNumber = pageNumber,
                PageSize = pageSize,
                Results = supportDtos,
                TotalPages = (numberOfItems / pageSize) + (numberOfItems % pageSize == 0 ? 0 : 1)
            };
        }
        private List<VBLSupportDetailsDTO> CreateVblSupportDetailsDtoList(List<VBLReceivingSupportDetails> support)
        {
            var supportDtos = Mapper.Map<List<VBLSupportDetailsDTO>>(support);

            foreach (var dto in supportDtos)
            {
                MapContactDetails(dto);
            }

            return supportDtos;
        }

        private void MapContactDetails(VBLSupportDetailsDTO supportDetailsDto)
        {
            supportDetailsDto.Mobile =
                supportDetailsDto.ContactByDetails.Where(c => c.ContactBy.Code == "Mobile").Select(v => v.ContactValue).FirstOrDefault();
            supportDetailsDto.Landline =
                supportDetailsDto.ContactByDetails.Where(c => c.ContactBy.Code == "Phone").Select(v => v.ContactValue).FirstOrDefault();
            supportDetailsDto.Email =
                supportDetailsDto.ContactByDetails.Where(c => c.ContactBy.Code == "Email").Select(v => v.ContactValue).FirstOrDefault();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userIPAddress"></param>
        /// <returns></returns>
        public bool DeleteRequiredSupportDetails(int id, string userId, string userIPAddress)
        {
            bool success = false;

            var persistedSupport =
                _unitOfWork
                    .VBLRequestedSupportDetails()
                    .Select(s => s.RequestedSupportDetailId == id)
                    .SingleOrDefault();

            if (persistedSupport != null)
            {
                _unitOfWork.VBLRequestedSupportDetails().Delete(persistedSupport);
                try
                {
                    _unitOfWork.Commit(userId, userIPAddress);
                    success = true;
                }
                catch (Exception ex)
                {
                    //  TODO:  Include logging
                    success = false;
                }
            }

            return success;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public VBLRequiredSupportDetailDTO GetSupportDetails(int contactId)
        {
            var supportDetails = _unitOfWork.VBLRequestedSupportDetails().Select(d => d.ContactId == contactId).ToList();

            var supplierTypeIds = new List<int>();
            foreach (var vblRequestedSupportDetail in supportDetails)
            {
                supplierTypeIds.Add(vblRequestedSupportDetail.SupportTypeId);
            }

            var contact = _unitOfWork.VBLContacts().Select(c => c.ContactId == contactId).FirstOrDefault();

            VBLRequiredSupportDetailDTO details = new VBLRequiredSupportDetailDTO
            {
                ContactId = contactId,
                ContactConcurrency = contact.RowVersion,
                ModifiedByUserName = contact.ModifiedBy,
                OtherSupportDetails = contact.OtherSupportDetails,
                SupportTypeIds = supplierTypeIds,
                SupportDetailId = 0
            };
            
            return details;
        }
    }
}