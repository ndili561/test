using AutoMapper;
using Incomm.Allocations.BLL.CRM.ApiClient;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO.CRM;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;
using InCoreLib.Domain.Allocations.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.OData.Query;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.VBL
{
    public class ContactBLL : IContactBLL
    {
        private string _includeProperties =
            "Application,Application.ApplicationStatus,ContactType,Relationship,DisabilityDetails,IncomeDetails.IncomeType,DisabilityTypes,IncommunitiesRelationshipTypes,ReceivingSupportDetails.ContactByDetails,ReceivingSupportDetails.SupportType,ReceivingSupportDetails.SupportProvider,ReceivingSupportDetails.ContactByDetails.ContactBy,RequestedSupportDetails.SupportType";
        private string searchProperties = "Application, Application.ApplicationStatus,ContactType,Title";


        private IUnitOfWork _unitOfWork;
        private IPersonApiClient _personApiClient;
        private ILookupApiClient _lookupApiClient;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public ContactBLL() : this(new UnitOfWork(), new PersonApiClient(), new LookupApiClient(), new ApplicationHistoryBLL())
        {
        }

        public ContactBLL(IUnitOfWork unitOfWork, IPersonApiClient personApiClient, ILookupApiClient lookupApiClient, IApplicationHistoryBLL applicationHistoryBLL)
        {
            _unitOfWork = unitOfWork;
            _personApiClient = personApiClient;
            _lookupApiClient = lookupApiClient;
            _applicationHistoryBLL = applicationHistoryBLL;
        }

        public string GetContactRowVersion(int contactId)
        {
            var applicationRowVersion = _unitOfWork.VBLContacts()
                .Select().AsNoTracking().FirstOrDefault(x => x.ContactId == contactId)?.RowVersion;
            return applicationRowVersion.ConvertByteArrayToString();
        }

        public VBLContactDTO GetContactDto(int contactId)
        {
            var contact = GetContact(contactId);
            var contactDto = Mapper.Map<VBLContactDTO>(contact);
            foreach (var incomeDetail in contactDto.IncomeDetails)
            {
                incomeDetail.Contact = null;
            }
            foreach (var supportDetail in contactDto.ReceivingSupportDetails)
            {
                supportDetail.Contact = null;
            }
            foreach (var supportDetail in contactDto.RequestedSupportDetails)
            {
                supportDetail.Contact = null;
            }
            return contactDto;
        }

        public VBLContact GetContact(int contactId)
        {
            var contact = _unitOfWork.VBLContacts()
                            .Select(
                                    includeProperties: _includeProperties)
                                .FirstOrDefault(x => x.ContactId == contactId);
            if (contact?.GlobalIdentityKey != null)
            {
                var person = _personApiClient.GetPerson(contact.GlobalIdentityKey.Value);
                if (person != null)
                {
                    contact.Person = Mapper.Map<Person>(person);
                }
                var crmContact = _unitOfWork.SearchContacts()
                    .Select()
                    .FirstOrDefault(x => x.ContactId == contactId);
                if (crmContact != null)
                {
                    contact.SearchContact = crmContact;
                }
            }
            return contact;

        }

        public List<VBLContact> GetContacts(ODataQueryOptions<VBLContact> options)
        {
            var contacts =
                options.ApplyTo(_unitOfWork.VBLContacts().Select(includeProperties: _includeProperties)
                .AsNoTracking()
                .AsQueryable());
            var contactList = Mapper.Map<List<VBLContact>>(contacts);

            foreach (var contact in contactList)
            {
                if (contact.GlobalIdentityKey != null)
                {
                    var person = _personApiClient.GetPerson(contact.GlobalIdentityKey.Value);
                    if (person != null)
                    {
                        contact.Person = Mapper.Map<Person>(person);
                    }
                    var crmContact = _unitOfWork.SearchContacts()
                        .Select()
                        .FirstOrDefault(x => x.ContactId == contact.ContactId);
                    if (crmContact != null)
                    {
                        contact.SearchContact = crmContact;
                    }
                }
            }



            return contactList;
        }

        public List<SearchContact> GetContactsForSearch(ODataQueryOptions<SearchContact> options)
        {
            var contacts =
                options.ApplyTo(_unitOfWork.SearchContacts().Select()
                .AsNoTracking()
                .AsQueryable());

            return Mapper.Map<List<SearchContact>>(contacts);
        }

        public VBLContactDTO Create(VBLContactDTO contact)
        {
            var changeDescription = string.Empty;
            if (contact.ApplicationId == 0)
            {
                var application = new VBLApplication { ApplicationDate = DateTime.Now, ApplicationStatusID = 4, CreatedBy = contact.CreatedBy, CreatedDate = DateTime.Now, UserIPAddress = contact.UserIPAddress, UserId = contact.UserId };
                _unitOfWork.VBLApplications().Insert(application);
                _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
                contact.ApplicationId = application.ApplicationId;

            }
            else if (contact.Application == null)
            {
                contact.Application = Mapper.Map<VBLApplicationDTO>(_unitOfWork.VBLApplications().Select().AsNoTracking()
                    .FirstOrDefault(x => x.ApplicationId == contact.ApplicationId));
            }
            contact.GlobalIdentityKey = Guid.NewGuid();
            contact.CreatedDate = DateTime.Now;
            contact.MainTenantOnTenancy = contact.ContactTypeId == 1;
            contact.Active = true;

            var entity = Mapper.Map<VBLContact>(contact);
            _unitOfWork.VBLContacts().Insert(entity);
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            contact.ContactId = entity.ContactId;
            contact.RowVersion = entity.RowVersion;
            if (!contact.MainTenantOnTenancy)
            {
                var mainTenant = _unitOfWork.SearchContacts().Select().FirstOrDefault(x => x.ApplicationId == entity.ApplicationId && x.ContactTypeName == "Applicant");
                if (mainTenant?.AddressId != null)
                {
                    contact.Person.PersonAddresses.Add(new PersonAddressDto { AddressId = mainTenant?.AddressId ?? 0, AddressTypeId = 1 });
                }
            }
            contact.Person.Applications.Add(new PersonApplicationLinkDto(entity.ContactId));
            var person = CreateCRMPerson(contact);

            var lookup = _lookupApiClient.GetCRMLookup();

            var title = lookup.Titles.FirstOrDefault(x => x.Id == contact.Person.TitleId);
            var gender = lookup.Genders.FirstOrDefault(x => x.Id == contact.Person.GenderId);
            var ethnicity = lookup.Ethnicities.FirstOrDefault(x => x.Id == contact.Person.EthnicityId);
            var nationality = lookup.Nationalities.FirstOrDefault(x => x.Id == contact.Person.NationalityTypeId);
            var language = lookup.Languages.FirstOrDefault(x => x.Id == contact.Person.PreferredLanguageId);
            //contact = Mapper.Map<VBLContactDTO>(GetContact(contact.ContactId));

            changeDescription = string.Format("New Household member added with values:<br />" +
                                              "Name: <span class=\"newvalue\">" + title?.Name + " " + person.Forename + " " +
                                              person.Surname + "</span><br />" +
                                              "Date of Birth: <span class=\"newvalue\">" + person.DateOfBirth.Value.ToShortDateString() + "</span><br /> " +
                                              "Gender: <span class=\"newvalue\">" + gender?.Name + "</span><br/>" +
                                              "Nationality: <span class=\"newvalue\">" + nationality?.Name + "</span><br /> " +
                                              "Ethnicity: <span class=\"newvalue\">" + ethnicity?.Name + "</span><br/>" +
                                              "Preferred Language: <span class=\"newvalue\">" + language?.Name + "</span><br />" +
                                              "Subject to Immigration Controls: <span class=\"newvalue\">" + contact.ImmigrationControl +
                                              "</span><br /> " +
                                              "In UK for 5 Years?: <span class=\"newvalue\">" + contact.LivedInUKForFiveYears + "</span><br/>" +
                                              "Eligible for public funds?: <span class=\"newvalue\">" + contact.PublicFunds) + "</span>";
            if (person.GenderId == 1)
            {
                changeDescription = changeDescription +
                                    string.Format("<br /> Pregnant?: <span class=\"newvalue\">" + contact.PregnancyDueDate.HasValue + "</span>");
            }
            if (contact.PregnancyDueDate.HasValue)
            {
                changeDescription = changeDescription +
                                    string.Format("<br /> Pregnancy Due Date: <span class=\"newvalue\">" + contact.PregnancyDueDate.Value.ToShortDateString() + "</span>");
            }
            if (!string.IsNullOrWhiteSpace(contact.Person.NationalInsuranceNumber))
            {
                changeDescription = changeDescription +
                                    string.Format("<br /> NI Number: <span class=\"newvalue\">" + contact.Person.NationalInsuranceNumber + "</span>");
            }
            SetApplicationEligibility(entity);
            if (changeDescription != "")
            {
                _applicationHistoryBLL.Create(entity.ApplicationId, contact.UserId, contact.UserIPAddress,
                    ApplicationActivity.NewDetails, ApplicationChangeType.KeyDetails, changeDescription);
            }
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            return contact;
        }

        private PersonDto CreateCRMPerson(VBLContactDTO contact)
        {
            var person = contact.Person;
            person.GlobalIdentityKey = contact.GlobalIdentityKey;
            person = _personApiClient.PostPerson(person);
            return person;
        }

        public VBLContactDTO Update(VBLContactDTO contact)
        {
            switch (contact.SaveContact)
            {
                case SaveContact.KeyDetails:
                    contact = UpdateKeyDetails(contact);
                    break;
                case SaveContact.ContactByDetails:
                    contact = UpdateContactByDetailsForContact(contact);
                    break;
                case SaveContact.IncomeDetails:
                    contact = UpdateIncomeDetailsForContact(contact);
                    break;
                case SaveContact.DisabilitiesDetails:
                    contact = UpdateDisabilityTypesForContact(contact);
                    break;
                case SaveContact.SupportDetails:
                    contact = UpdateSupportForContact(contact);
                    break;
                case SaveContact.PropertyDetails:
                    break;
                case SaveContact.PreferenceDetails:
                    break;
                case SaveContact.HousingBenefits:
                    contact = UpdateHousingBenifits(contact);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return contact;
        }

        public void Delete(int contactId, string userId, string userIPAddress)
        {
            var changeDescription = string.Empty;
            var person = _unitOfWork.SearchContacts().Select()
                .FirstOrDefault(x => x.ContactId == contactId);
            var contactsToDelete = _unitOfWork.VBLContacts().Select().Where(x => x.ContactId == contactId).ToList(); //to handle duplicates
            //will need to delete incom, contactbys, support
            var incomesToDelete = _unitOfWork.VBLIncomeDetails().Select().Where(x => x.ContactId == contactId).ToList();
            //var contactBysToDelete =
            //    _unitOfWork.VBLContactByDetails().Select().Where(x => x.ContactId == contactId).ToList();
            var supportToDelete =
                _unitOfWork.VBLReceivingSupportDetails().Select().Where(x => x.ContactId == contactId).ToList();
            var supportids = supportToDelete.Select((x => x.ReceivingSupportDetailId)).ToList();
            var supportContactByDetailsToDelete =
                _unitOfWork.VBLSupportContactByDetails()
                    .Select()
                    .Where(
                        y =>
                            (supportids).Contains(
                                (int)y.ReceivingSupportDetailId))
                    .ToList();
            //supportcontactby
            for (var ctr = 0; ctr < supportContactByDetailsToDelete.Count; ctr++)
            {
                var contact = supportContactByDetailsToDelete[ctr];
                _unitOfWork.VBLSupportContactByDetails().Delete(contact);
                _unitOfWork.Commit(userId, userIPAddress);
            }
            //support
            for (var ctr = 0; ctr < supportToDelete.Count; ctr++)
            {
                var contact = supportToDelete[ctr];
                _unitOfWork.VBLReceivingSupportDetails().Delete(contact);
                _unitOfWork.Commit(userId, userIPAddress);
            }

            //contactby
            //for (var ctr = 0; ctr < contactBysToDelete.Count; ctr++)
            //{
            //    var contact = contactBysToDelete[ctr];
            //    _unitOfWork.VBLContactByDetails().Delete(contact);
            //    _unitOfWork.Commit(userId, userIPAddress);
            //}


            //income
            for (var ctr = 0; ctr < incomesToDelete.Count; ctr++)
            {
                var contact = incomesToDelete[ctr];
                _unitOfWork.VBLIncomeDetails().Delete(contact);
                _unitOfWork.Commit(userId, userIPAddress);
            }


            //contact
            for (var ctr = 0; ctr < contactsToDelete.Count; ctr++)
            {
                var contact = contactsToDelete[ctr];
                _unitOfWork.VBLContacts().Delete(contact);
                _unitOfWork.Commit(userId, userIPAddress);
            }
            changeDescription = changeDescription +
                                            $"Household Member <span class=\"oldvalue\">" + person.Forename + " " + person.Surname + "</span> deleted" +
                                            "<br>";
            _applicationHistoryBLL.Create(contactsToDelete.First().ApplicationId, userId, userIPAddress,
                    ApplicationActivity.Ammendment, ApplicationChangeType.KeyDetails, changeDescription);
        }

        public IList<VBLContact> GetContacts(IList<int> applicationIds)
        {
            var contacts =
                _unitOfWork.VBLContacts().Select(c => applicationIds.Contains(c.ApplicationId)).ToList();
            return Mapper.Map<List<VBLContact>>(contacts);
        }

        private VBLContactDTO UpdateHousingBenifits(VBLContactDTO contact)
        {
            var persistedContact = _unitOfWork.VBLContacts().Select().FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (persistedContact==null)
            {
                contact.ErrorMessage = "The contact has been deleted." ;
                return contact;
            }
            if (persistedContact.ClaimHousingBenefitAtNewProperty != contact.ClaimHousingBenefitAtNewProperty)
            {
                persistedContact.ClaimHousingBenefitAtNewProperty = contact.ClaimHousingBenefitAtNewProperty;
            }
            if (persistedContact.ClaimingHousingBenefitAtCurrentProperty != contact.ClaimingHousingBenefitAtCurrentProperty)
            {
                persistedContact.ClaimingHousingBenefitAtCurrentProperty = contact.ClaimingHousingBenefitAtCurrentProperty;
            }
            _unitOfWork.VBLContacts().Update(persistedContact);
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            return contact;
        }
        private VBLContactDTO UpdateKeyDetails(VBLContactDTO contact)
        {
            var persistedContact = _unitOfWork.VBLContacts().Select(includeProperties: "Application").FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (persistedContact == null)
            {
                contact.ErrorMessage = "The contact has been deleted.";
                return contact;
            }
            var searchContact = _unitOfWork.SearchContacts().Select().FirstOrDefault(x => x.ContactId == contact.ContactId);

            bool updatePerson = false;
            var person = _personApiClient.GetPerson(searchContact.GlobalIdentityKey.Value);
            persistedContact.Person = Mapper.Map<Person>(person) ;
           
            var lookup = _lookupApiClient.GetCRMLookup();
            var changeDescription = string.Empty;
            if (person.EthnicityId != contact.Person.EthnicityId && contact.Person.EthnicityId > 0)
            {

                var ethnicities = lookup.Ethnicities.Where(x => x.IsActive).ToList();
                var originalValue = ethnicities.FirstOrDefault(x => x.Id == person.EthnicityId);
                var currentValue = ethnicities.FirstOrDefault(x => x.Id == contact.Person.EthnicityId);
                changeDescription += $"Ethnicity changed from  <span class=\"oldvalue\"> {(originalValue == null ? string.Empty : originalValue.Name)} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" + "<br>";
                person.EthnicityId = contact.Person.EthnicityId;
                updatePerson = true;
            }
            if (person.Forename != contact.Person.Forename)
            {
                changeDescription += $"Forename changed from  <span class=\"oldvalue\"> {person.Forename} </span> to <span class=\"newvalue\"> {contact.Person.Forename} </span>" + "<br>";
                person.Forename = contact.Person.Forename;
                updatePerson = true;
            }

            if (person.Surname != contact.Person.Surname)
            {
                changeDescription += $"Surname changed from  <span class=\"oldvalue\"> {person.Surname} </span> to <span class=\"newvalue\"> {contact.Person.Surname} </span>" + "<br>";
                person.Surname = contact.Person.Surname;
                updatePerson = true;
            }
            if (person.DateOfBirth != contact.Person.DateOfBirth)
            {
                changeDescription += $" Date Of Birth changed from  <span class=\"oldvalue\"> {person.DateOfBirth} </span> to <span class=\"newvalue\"> {contact.Person.DateOfBirth} </span>" + "<br>";
                person.DateOfBirth = contact.Person.DateOfBirth;
                updatePerson = true;
            }
            if (contact.Person.GenderId != 1)// If Gender is not female PregnancyDueDate must be NULL.
            {
                persistedContact.PregnancyDueDate = null;
                persistedContact.IsPregnant = false;
            }
            else if (persistedContact.PregnancyDueDate != contact.PregnancyDueDate)
            {
                changeDescription += $"Pregnancy Due Date changed from  <span class=\"oldvalue\"> {persistedContact.PregnancyDueDate} </span> to <span class=\"newvalue\"> {contact.PregnancyDueDate} </span>" + "<br>";
                persistedContact.PregnancyDueDate = contact.PregnancyDueDate;
            }
            if (persistedContact.Person.RelationshipId != contact.Person.RelationshipId && contact.Person.RelationshipId > 0)
            {

                var relationships = _unitOfWork.Relationships().Select().Where(x => x.Active).ToList();
                var originalValue = relationships.FirstOrDefault(x => x.RelationshipId == persistedContact.RelationshipId);
                var currentValue = relationships.FirstOrDefault(x => x.RelationshipId == contact.RelationshipId);
                changeDescription += $"Relationship changed from  <span class=\"oldvalue\"> {(originalValue == null ? string.Empty : originalValue.Name)} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" + "<br>";
                person.RelationshipId = contact.Person.RelationshipId;
                updatePerson = true;
            }
            if (person.GenderId != contact.Person.GenderId && contact.Person.GenderId > 0)
            {

                var genders = lookup.Genders.Where(x => x.IsActive).ToList();
                var originalValue = genders.FirstOrDefault(x => x.Id == person.GenderId);
                var currentValue = genders.FirstOrDefault(x => x.Id == contact.Person.GenderId);
                changeDescription += $"Gender changed from  <span class=\"oldvalue\"> {(originalValue == null ? string.Empty : originalValue.Name)} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" + "<br>";
                person.GenderId = contact.Person.GenderId;
                updatePerson = true;
            }
            var niNumber = person.NationalInsuranceNumber?.Replace(" ", "");
            if (niNumber != contact.Person.NationalInsuranceNumber)
            {
                changeDescription += $"National Insurance Number changed from  <span class=\"oldvalue\"> {person.NationalInsuranceNumber} </span> to <span class=\"newvalue\"> {contact.Person.NationalInsuranceNumber} </span>" + "<br>";
                person.NationalInsuranceNumber = contact.Person.NationalInsuranceNumber;
                updatePerson = true;
            }
            if (person.NationalityTypeId != contact.Person.NationalityTypeId && contact.Person.NationalityTypeId > 0)
            {
                var nationalityTypes = _unitOfWork.NationalityTypes().Select().Where(x => x.Active).ToList();
                var originalValue = nationalityTypes.FirstOrDefault(x => x.NationalityTypeId == person.NationalityTypeId);
                var currentValue = nationalityTypes.FirstOrDefault(x => x.NationalityTypeId == contact.Person.NationalityTypeId);
                changeDescription += $"Nationality changed from  <span class=\"oldvalue\"> {(originalValue == null ? string.Empty : originalValue.Name)} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" + "<br>";
                person.NationalityTypeId = contact.Person.NationalityTypeId;
                updatePerson = true;
            }
            if (person.PreferredLanguageId != contact.Person.PreferredLanguageId && contact.Person.PreferredLanguageId > 0)
            {

                var preferredLanguages = lookup.Languages.Where(x => x.IsActive).ToList();
                var originalValue = preferredLanguages.FirstOrDefault(x => x.Id == person.PreferredLanguageId);
                var currentValue = preferredLanguages.FirstOrDefault(x => x.Id == contact.PreferredLanguageId);
                changeDescription += $"Preferred Language changed from  <span class=\"oldvalue\"> {(originalValue == null ? string.Empty : originalValue.Name)} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" + "<br>";
                person.PreferredLanguageId = contact.Person.PreferredLanguageId;
                updatePerson = true;
            }
            if (person.TitleId != contact.Person.TitleId && contact.Person.TitleId > 0)
            {

                var titles = lookup.Titles.Where(x => x.IsActive).ToList();
                var originalValue = titles.FirstOrDefault(x => x.Id == person.TitleId);
                var currentValue = titles.FirstOrDefault(x => x.Id == contact.Person.TitleId);
                changeDescription += $"Title changed from <span class=\"oldvalue\"> {(originalValue == null ? string.Empty : originalValue.Name)} </span> to  <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" + "<br>";
                person.TitleId = contact.Person.TitleId;
                updatePerson = true;
            }

            if (updatePerson)
            {
                _personApiClient.PutPerson(persistedContact.GlobalIdentityKey.Value, person);
            }

            if (persistedContact.ImmigrationControl != contact.ImmigrationControl)
            {
                changeDescription += $"Subject to Immigration Control answer changed from  <span class=\"oldvalue\"> {persistedContact.ImmigrationControl} </span> to <span class=\"newvalue\"> {contact.ImmigrationControl} </span>" + "<br>";
                persistedContact.ImmigrationControl = contact.ImmigrationControl;
            }
            if (persistedContact.PublicFunds != contact.PublicFunds)
            {
                changeDescription += $"Public Funds answer changed from  <span class=\"oldvalue\"> {persistedContact.ImmigrationControl} </span> to <span class=\"newvalue\"> {contact.ImmigrationControl} </span>" + "<br>";
                persistedContact.PublicFunds = contact.PublicFunds;
            }
            if (persistedContact.TenancyReference != contact.TenancyReference)
            {
                changeDescription += $"Tenancy Reference changed from  <span class=\"oldvalue\"> {persistedContact.ImmigrationControl} </span> to <span class=\"newvalue\"> {contact.ImmigrationControl} </span>" + "<br>";
                persistedContact.TenancyReference = contact.TenancyReference;
            }
            if (persistedContact.IsMovingIn != contact.IsMovingIn)
            {
                changeDescription += $"Is Moving In changed from  <span class=\"oldvalue\"> {persistedContact.IsMovingIn} </span> to <span class=\"newvalue\"> {contact.IsMovingIn} </span>" + "<br>";
                persistedContact.IsMovingIn = contact.IsMovingIn;
            }
            if (persistedContact.IsPregnant != contact.IsPregnant && contact.Person.GenderId == 1)
            {
                changeDescription += $"Is Pregnant changed from  <span class=\"oldvalue\"> {persistedContact.IsPregnant} </span> to <span class=\"newvalue\"> {contact.IsPregnant} </span>" + "<br>";
                persistedContact.IsPregnant = contact.IsPregnant;
            }
            if (persistedContact.LivedInUKForFiveYears != contact.LivedInUKForFiveYears)
            {
                changeDescription += $"Lived In UK For Five Years answer changed from  <span class=\"oldvalue\"> {persistedContact.LivedInUKForFiveYears} </span> to <span class=\"newvalue\"> {contact.LivedInUKForFiveYears} </span>" + "<br>";
                persistedContact.LivedInUKForFiveYears = contact.LivedInUKForFiveYears;
            }
            if (persistedContact.MainTenantOnTenancy != contact.MainTenantOnTenancy)
            {

                changeDescription = $" Main Tenant On Tenancy changed from  <span class=\"oldvalue\"> {persistedContact.MainTenantOnTenancy} </span> to <span class=\"newvalue\"> {contact.MainTenantOnTenancy} </span>" + "<br>";
                persistedContact.MainTenantOnTenancy = contact.MainTenantOnTenancy;
            }
            if (changeDescription != "")
            {
                _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                    ApplicationActivity.Ammendment, ApplicationChangeType.KeyDetails, changeDescription);
            }

            SetApplicationEligibility(persistedContact);
            _unitOfWork.VBLContacts().Update(persistedContact);
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            contact.SuccessMessage = "The key details of the contact is updated successfully.";
            return contact;
        }

        private static void SetApplicationEligibility(VBLContact persistedObject)
        {
            if (persistedObject.ImmigrationControl || !persistedObject.LivedInUKForFiveYears || !persistedObject.PublicFunds)
            {
                persistedObject.Application.ApplicationEligible = false;
            }
            else
            {
                persistedObject.Application.ApplicationEligible = true;
            }
        }

        private VBLContactDTO UpdateContactByDetailsForContact(VBLContactDTO contact)
        {
            var persistedContact = _unitOfWork.VBLContacts().Select().FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (persistedContact == null)
            {
                contact.ErrorMessage = "The contact has been deleted.";
                return contact;
            }
            var changeDescription = string.Empty;
            var searchContact = _unitOfWork.SearchContacts().Select().FirstOrDefault(x => x.ContactId == contact.ContactId);
            var person = _personApiClient.GetPerson(searchContact.GlobalIdentityKey.Value);

            persistedContact.PreferredContactTime = contact.PreferredContactTime;
             bool amend = person.PersonContactDetails.Count > 0;
            if (person.PersonContactDetails != null)
            {
                var updatedContactByDetails = contact.ContactByDetails.Where(
                    a =>
                        person.PersonContactDetails.Any(x => x.ContactByOptionId == a.ContactById)).ToList();
                var addedContactByDetails = contact.ContactByDetails.Where(
                    a =>
                        person.PersonContactDetails.All(
                            x => x.ContactByOptionId != a.ContactById )).ToList();
                if (addedContactByDetails.Count > 0)
                {
                    if (addedContactByDetails.Count == 1)
                    {
                        changeDescription = changeDescription +
                                            $"Contact method <span class=\"newvalue\">{string.Join(", ", addedContactByDetails.Select(x => x.ContactValue))}</span> added" +
                                            "<br>";
                    }
                    else
                    {
                        changeDescription = changeDescription +
                                            $"Contact methods <span class=\"newvalue\">{string.Join(", ", addedContactByDetails.Select(x => x.ContactValue))}</span> added" +
                                            "<br>";
                    }
                }
                foreach (var updatedDetail in updatedContactByDetails)
                {
                    var updatedDetails = person.PersonContactDetails.FirstOrDefault(
                        x => x.ContactByOptionId == updatedDetail.ContactById);
                    if (updatedDetails == null) continue;
                    if ((updatedDetails.Comment != updatedDetail.ContactText) ||
                        (updatedDetails.ContactValue != updatedDetail.ContactValue))
                    {
                        updatedDetails.Comment = updatedDetail.ContactText;
                        updatedDetails.ContactValue = updatedDetail.ContactValue;
                        changeDescription = changeDescription +
                                            $"Contact method updated from  <span class=\"oldvalue\"> {string.Join(", ", updatedDetail.ContactValue)} </span> to <span class=\"newvalue\"> {string.Join(", ", persistedContact.ContactByDetails.Where(a => updatedContactByDetails.Select(c => c.ContactById).Contains(a.ContactById)).Select(x => x.ContactValue))} </span>" + "<br>";
                       // _unitOfWork.VBLContactByDetails().Update(updatedDetails);

                    }
                }
            }
            var deletedContactByDetails = person.PersonContactDetails.Where(
                a => contact.ContactByDetails.All(x => x.ContactById != a.ContactByOptionId)).ToList();
            if (deletedContactByDetails.Count > 0)
            {
                if (deletedContactByDetails.Count == 1)
                {
                    changeDescription = changeDescription +
                                        $"Contact method <br> <span class=\"oldvalue\"> {string.Join(", ", deletedContactByDetails.Select(x => x.ContactValue))} </span> removed" +
                                        "<br>";
                }
                else
                {
                    changeDescription = changeDescription +
                                        $"Contact methods <br> <span class=\"oldvalue\"> {string.Join(", ", deletedContactByDetails.Select(x => x.ContactValue))} </span> removed" +
                                        "<br>";
                }
            }
            //foreach (var deletedIncomeDetail in deletedContactByDetails)
            //{
            //    _unitOfWork.VBLContactByDetails().Delete(deletedIncomeDetail);
            //}
            if (changeDescription != "")
            {
                if (amend)
                {
                    _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                        ApplicationActivity.Ammendment, ApplicationChangeType.ContactByDetails, changeDescription);
                }
                else
                {
                    _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                         ApplicationActivity.NewDetails, ApplicationChangeType.ContactByDetails, changeDescription);
                }
            }
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            person.PersonContactDetails.Clear();
            foreach (var contactContactByDetail in contact.ContactByDetails)
            {
                person.PersonContactDetails.Add(Mapper.Map<PersonContactDetailDto>(contactContactByDetail));
            }
            var result= _personApiClient.PutPerson(person.GlobalIdentityKey.Value, person);
            contact.SuccessMessage = "The contact by details of the contact is updated successfully.";
            return contact;
        }

        private VBLContactDTO UpdateDisabilityTypesForContact(VBLContactDTO contact)
        {
            var persistedContact = _unitOfWork.VBLContacts().Select(includeProperties: "DisabilityDetails").FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (persistedContact == null)
            {
                contact.ErrorMessage = "The contact has been deleted.";
                return contact;
            }
            var changeDescription = string.Empty;
            var amend = contact.DisabilityDetails != null;
            if (contact.DisabilityDetails != null)
            {

                var updatedDisabilityDetails = contact.DisabilityDetails.Where(
                    a =>
                        persistedContact.DisabilityDetails.Any(
                            x => x.DisabilityTypeId == a.DisabilityTypeId && x.ContactId == a.ContactId)).ToList();
                var addedDisabilityDetails = contact.DisabilityDetails.Where(
                    a =>
                        persistedContact.DisabilityDetails.All(
                            x => !(x.DisabilityTypeId == a.DisabilityTypeId && x.ContactId == a.ContactId))).ToList();
                foreach (var addedDisabilityDetail in addedDisabilityDetails)
                {
                    _unitOfWork.DisabilityDetails().Insert(addedDisabilityDetail);

                }
                changeDescription = changeDescription +
                                    $"Disability <span class=\"newvalue\">{string.Join(", ", addedDisabilityDetails.Select(x => x.DisabilityType.Name))}</span> added" + "<br>";

                foreach (var updatedDisabilityDetail in updatedDisabilityDetails)
                {
                    var updatedDetails = persistedContact.DisabilityDetails.FirstOrDefault(
                        x => x.DisabilityDetailId == updatedDisabilityDetail.DisabilityDetailId);
                    if (updatedDetails == null) continue;
                    updatedDetails.DisabilityType = updatedDisabilityDetail.DisabilityType;
                    changeDescription = changeDescription +
                                        $"Disability updated from  <span class=\"oldvalue\"> {string.Join(", ", updatedDisabilityDetails.Select(x => x.DisabilityType.Name))} </span> to <span class=\"newvalue\"> {string.Join(", ", persistedContact.DisabilityDetails.Where(a => updatedDisabilityDetails.Select(c => c.DisabilityDetailId).Contains(a.DisabilityDetailId)).Select(x => x.DisabilityType.Name))} </span>" + "<br>";
                    _unitOfWork.DisabilityDetails().Update(updatedDetails);
                }
            }
            var deletedDisabilityDetails = persistedContact.DisabilityDetails.Where(
                a => contact.DisabilityDetails.All(x => !(x.DisabilityDetailId == a.DisabilityDetailId && x.ContactId == a.ContactId))).ToList();

            changeDescription = changeDescription +
                                $"Disability <br> <span class=\"oldvalue\"> {string.Join("", deletedDisabilityDetails.Select(x => x.DisabilityType.Name))} </span> removed" + "<br>";
            foreach (var deletedDisabilityDetail in deletedDisabilityDetails)
            {
                _unitOfWork.DisabilityDetails().Delete(deletedDisabilityDetail);
            }
            if (amend)
            {
                _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                    ApplicationActivity.Ammendment, ApplicationChangeType.ContactByDetails, changeDescription);
            }
            else
            {
                _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                    ApplicationActivity.NewDetails, ApplicationChangeType.ContactByDetails, changeDescription);
            }
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            contact.SuccessMessage = "The disability details of the contact is updated successfully.";
            return contact;
        }

        private VBLContactDTO UpdateIncomeDetailsForContact(VBLContactDTO contact)
        {
            var persistedContact = _unitOfWork.VBLContacts().Select(includeProperties: "IncomeDetails").FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (persistedContact == null)
            {
                contact.ErrorMessage = "The contact has been deleted.";
                return contact;
            }
            var changeDescription = string.Empty;
            var amend = persistedContact.IncomeDetails != null && !string.IsNullOrWhiteSpace(persistedContact.NoIncomeReason);
            var incomeFreqs = _unitOfWork.IncomeFrequencies().Select().ToList();
            var incomeTypes = _unitOfWork.IncomeTypes().Select().Where(x => x.Active).ToList();

            if (contact.IncomeDetails != null)
            {

                #region Deleted Income Details

                var deletedIncomeDetails = persistedContact.IncomeDetails?.Where(
                    a => contact.IncomeDetails.All(x => x.IncomeTypeId != a.IncomeTypeId))
                    .ToList();
                if (deletedIncomeDetails != null)
                {
                    foreach (var deletedIncomeDetail in deletedIncomeDetails)
                    {
                        _unitOfWork.VBLIncomeDetails().Delete(deletedIncomeDetail);
                        var incomeFreq =
                            incomeFreqs
                                .Single(x => x.IncomeFrequencyId == deletedIncomeDetail.IncomeFrequencyId);
                        var incomeType = incomeTypes.Single(x => x.IncomeTypeId == deletedIncomeDetail.IncomeTypeId);
                        changeDescription = changeDescription +
                                            $"Income <span class=\"oldvalue\">{incomeType.Name}</span>, <span class=\"oldvalue\">{incomeFreq.Name}</span>, <span class=\"oldvalue\">{deletedIncomeDetail.Amount}</span> deleted" + "<br>";

                    }
                }
                #endregion

                #region Update Income Details
                var updatedIncomeDetails = contact.IncomeDetails.Where(
                    a => persistedContact.IncomeDetails.Any(
                        x => x.IncomeTypeId == a.IncomeTypeId && x.ContactId == a.ContactId)).ToList();
                foreach (var updatedIncomeDetail in updatedIncomeDetails)
                {
                    var updatedDetails = persistedContact.IncomeDetails?.FirstOrDefault(
                        x => x.IncomeTypeId == updatedIncomeDetail.IncomeTypeId);
                    if (updatedDetails == null) continue;
                    if ((updatedDetails.IncomeFrequencyId != updatedIncomeDetail.IncomeFrequencyId ||
                         updatedDetails.Amount != updatedIncomeDetail.Amount))
                    {

                        var incomeFreq =
                            incomeFreqs
                                .Single(x => x.IncomeFrequencyId == updatedDetails.IncomeFrequencyId);
                        var oldIncomeFreq =
                            incomeFreqs
                                .Single(x => x.IncomeFrequencyId == updatedIncomeDetail.IncomeFrequencyId);
                        var incomeType = incomeTypes.Single(x => x.IncomeTypeId == updatedDetails.IncomeTypeId);

                        updatedDetails.UserId = contact.UserId;
                        updatedDetails.UserIPAddress = contact.UserIPAddress;
                        updatedDetails.ModifiedBy = contact.UserId;
                        updatedDetails.ModifiedDate = DateTime.Now;
                        updatedDetails.Amount = updatedIncomeDetail.Amount;
                        updatedDetails.IncomeFrequencyId = updatedIncomeDetail.IncomeFrequencyId;

                        changeDescription = changeDescription +
                                            $"Income {incomeType.Name} updated from  <span class=\"oldvalue\"> {oldIncomeFreq.Name}</span>, <span class=\"oldvalue\">{updatedDetails.Amount} </span> to <span class=\"newvalue\"> {incomeFreq.Name}, {updatedIncomeDetail.Amount} </span>" + "<br>";
                        _unitOfWork.VBLIncomeDetails().Update(updatedDetails);
                    }
                }

                #endregion

                #region Added Income Details
                var addedIncomeDetails = contact.IncomeDetails.Where(a => persistedContact.IncomeDetails.All(
                    x => !(x.IncomeTypeId == a.IncomeTypeId && x.ContactId == a.ContactId))).ToList();
                foreach (var addedIncomeDetail in addedIncomeDetails)
                {

                    addedIncomeDetail.UserId = contact.UserId;
                    addedIncomeDetail.UserIPAddress = contact.UserIPAddress;
                    addedIncomeDetail.CreatedBy = contact.UserId;
                    addedIncomeDetail.CreatedDate = DateTime.Now;
                    var entity = Mapper.Map<VBLIncomeDetail>(addedIncomeDetail);
                    _unitOfWork.VBLIncomeDetails().Insert(entity);

                    var incomeFreq =
                        incomeFreqs
                            .Single(x => x.IncomeFrequencyId == addedIncomeDetail.IncomeFrequencyId);
                    var incomeType = incomeTypes.Single(x => x.IncomeTypeId == addedIncomeDetail.IncomeTypeId);
                    changeDescription = changeDescription +
                                        $"Income {incomeType.Name} added with Frequency: <span class=\"newvalue\"> {incomeFreq.Name}</span>, and Amount: <span class=\"newvalue\"> {addedIncomeDetail.Amount} </span>" + "<br>";
                }
                #endregion
            }
            else
            {
                if (persistedContact.IncomeDetails != null)
                {
                    foreach (var incomeDetail in persistedContact.IncomeDetails)
                    {
                        var incomeFreq =
                            incomeFreqs
                                .Single(x => x.IncomeFrequencyId == incomeDetail.IncomeFrequencyId);
                        var incomeType = incomeTypes.Single(x => x.IncomeTypeId == incomeDetail.IncomeTypeId);
                        changeDescription = changeDescription +
                                            $"Income <span class=\"oldvalue\">{incomeType.Name}</span>, <span class=\"oldvalue\">{incomeFreq.Name}</span>, <span class=\"oldvalue\">{incomeDetail.Amount}</span> deleted" +
                                            "<br>";

                    }
                }
                _unitOfWork.VBLIncomeDetails().DeleteRange(persistedContact.IncomeDetails);
                persistedContact.NoIncomeReason = contact.NoIncomeReason;
                changeDescription = changeDescription +
                                          $"No Income Reason: <span class=\"newvalue\"> {contact.NoIncomeReason} </span> added" + "<br>";
            }

            if (changeDescription != "")
            {
                _applicationHistoryBLL.Create(persistedContact.ApplicationId, contact.UserId, contact.UserIPAddress,
                    amend ? ApplicationActivity.Ammendment : ApplicationActivity.NewDetails,
                    ApplicationChangeType.IncomeDetails, changeDescription);
            }
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            contact.SuccessMessage = "The income details of the contact is updated successfully.";
            return contact;
        }

        private VBLContactDTO UpdateSupportForContact(VBLContactDTO contact)
        {
            var persistedContact = _unitOfWork.VBLContacts().Select(includeProperties: "DisabilityDetails").FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (persistedContact == null)
            {
                contact.ErrorMessage = "The contact is deleted.";
                return contact;
            }
            var changeDescription = string.Empty;
            var amend = persistedContact.DisabilityDetails.Count > 0;
            var detailsList = contact.SelectedDisabilitiesIds.Select(id => new VBLDisabilityDetails
            {
                DisabilityTypeId = id,
                ContactId = contact.ContactId,
                CreatedBy = contact.CreatedBy,
                CreatedDate = DateTime.Now,
                UserIPAddress = contact.UserIPAddress,
                UserId = contact.UserId
            }).Where(x => x.DisabilityTypeId > 0).ToList();
            if (detailsList.Count > 0 || persistedContact.DisabilityDetails.Count > 0)
            {
                var deletedDisabilities =
                    persistedContact.DisabilityDetails.Where(
                        x => !contact.SelectedDisabilitiesIds.Contains(x.DisabilityTypeId)).ToList();
                var deletedDisabilityIds = deletedDisabilities.Select(a => a.DisabilityTypeId);
                var disabilityTypes =
                    _unitOfWork.DisabilityTypes()
                        .Select()
                        .Where(x => x.Active && deletedDisabilityIds.Contains(x.DisabilityTypeId))
                        .ToList();
                if (disabilityTypes.Count > 0)
                {
                    if (disabilityTypes.Count == 1)
                    {
                        changeDescription = changeDescription +
                                            $"Disability Type <span class=\"oldvalue\">{string.Join(", ", disabilityTypes.Select(x => x.Name))}</span> deleted" + "<br>";
                    }
                    else
                    {
                        changeDescription = changeDescription +
                                            $"Disability Types <span class=\"oldvalue\">{string.Join(", ", disabilityTypes.Select(x => x.Name))}</span> deleted" + "<br>";
                    }
                }
                var addedDisabilities =
                    detailsList.Where(
                        x =>
                            !persistedContact.DisabilityDetails.Select(a => a.DisabilityTypeId)
                                .Contains(x.DisabilityTypeId)).ToList();
                var addedDisabilityIds = addedDisabilities.Select(a => a.DisabilityTypeId);
                var addeddisabilityTypes =
                    _unitOfWork.DisabilityTypes()
                        .Select()
                        .Where(x => x.Active && addedDisabilityIds.Contains(x.DisabilityTypeId))
                        .ToList();
                if (addeddisabilityTypes.Count > 0)
                {
                    if (addeddisabilityTypes.Count == 1)
                    {
                        changeDescription = changeDescription +
                                            $"Disability Type <span class=\"newvalue\">{string.Join(", ", addeddisabilityTypes.Select(x => x.Name))}</span> added" + "<br>";
                    }
                    else
                    {
                        changeDescription = changeDescription +
                                            $"Disability Types <span class=\"newvalue\">{string.Join(", ", addeddisabilityTypes.Select(x => x.Name))}</span> added" + "<br>";
                    }
                }
                for (var ctr = 0; ctr < deletedDisabilities.Count; ctr++)
                {
                    deletedDisabilities[ctr].ModifiedDate = DateTime.Now;
                    deletedDisabilities[ctr].ModifiedBy = contact.UserId;
                    _unitOfWork.DisabilityDetails().Delete(deletedDisabilities[ctr]);
                }
                _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
                _unitOfWork.DisabilityDetails().AddRange(addedDisabilities);
            }
            if (contact.DisabilityImpactOnHousingNeed != persistedContact.DisabilityImpactOnHousingNeed)
            {
                if (persistedContact.DisabilityImpactOnHousingNeed == null)
                {
                    changeDescription = changeDescription +
                                        $"Disability Impact On Housing Need set to <span class=\"newvalue\"> {contact.DisabilityImpactOnHousingNeed} </span>" + "<br>";

                }
                else
                {
                    if (contact.DisabilityImpactOnHousingNeed != null)
                    {
                        changeDescription = changeDescription +
                                            $"Disability Impact On Housing Need altered from  <span class=\"oldvalue\"> {persistedContact.DisabilityImpactOnHousingNeed} </span> to <span class=\"newvalue\"> {contact.DisabilityImpactOnHousingNeed} </span>" + "<br>";
                    }
                    else
                    {
                        changeDescription = changeDescription +
                                            $"Disability Impact On Housing Need cleared from <span class=\"oldvalue\"> {persistedContact.DisabilityImpactOnHousingNeed} </span>" + "<br>";
                    }
                }
                persistedContact.ModifiedDate = DateTime.Now;
                persistedContact.ModifiedBy = contact.UserId;
                persistedContact.DisabilityImpactOnHousingNeed = contact.DisabilityImpactOnHousingNeed;
                _unitOfWork.VBLContacts().Update(persistedContact);
            }

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
            _unitOfWork.Commit(contact.UserId, contact.UserIPAddress);
            contact.SuccessMessage = "The support is updated successfully.";
            return contact;
        }

        public TransferCheck GetTransferCheck(int contactId)
        {
            return _unitOfWork.TransferChecks()
                                .Select(t => t.ContactId == contactId)
                                .SingleOrDefault();
        }

        public bool SaveTransferCheck(TransferCheck transferCheck)
        {
            if (!_unitOfWork.TransferChecks().Select(t => t.ContactId == transferCheck.ContactId).Any())
            {
                transferCheck.CreatedDate = DateTime.Now;
                transferCheck.ModifiedDate = transferCheck.CreatedDate;
                transferCheck.CreatedBy = transferCheck.UserId;
                transferCheck.ModifiedBy = transferCheck.UserId;

                _unitOfWork.TransferChecks().Insert(transferCheck);
                _unitOfWork.Commit(transferCheck.UserId, transferCheck.UserIPAddress);

                return true;
            }

            var dbTransferCheck = _unitOfWork.TransferChecks()
                                        .Select(t => t.ContactId == transferCheck.ContactId)
                                        .Single();

            if (!dbTransferCheck.RowVersion.SequenceEqual(transferCheck.RowVersion))
            {
                throw new DBConcurrencyException($"Transfer Check for contact {transferCheck.ContactId} was modified by other person.");
            }

            dbTransferCheck.IsAsbCheckOk = transferCheck.IsAsbCheckOk;
            dbTransferCheck.IsDebtCheckOk = transferCheck.IsDebtCheckOk;
            dbTransferCheck.IsOtherTenancyBreachesCheckOk = transferCheck.IsOtherTenancyBreachesCheckOk;
            dbTransferCheck.ModifiedDate = DateTime.Now;
            dbTransferCheck.ModifiedBy = transferCheck.UserId;

            _unitOfWork.TransferChecks().Update(dbTransferCheck);
            _unitOfWork.Commit(transferCheck.UserId, transferCheck.UserIPAddress);

            return true;
        }

        public VBLContact GetMainContactForApplication(int applicationId)
        {
            var mainContact = _unitOfWork
                    .VBLContacts()
                    .Select()
                    .FirstOrDefault(x => x.ApplicationId == applicationId && x.ContactTypeId == 1);
            return GetContact(mainContact.ContactId);
        }
    }
}