using AutoMapper;
using Incomm.Allocations.BLL.CRM.ApiClient;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO.CRM;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;
using InCoreLib.Domain.Allocations.Enumerations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.OData.Query;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.VBL
{
    public class ApplicationBLL : IApplicationBLL
    {
        private string queryString =
@"ApplicationStatus,
MoveReason,
ResidencyType,
LevelOfNeeds,
Contacts.ContactType,
Contacts.DisabilityDetails,
Contacts.DisabilityDetails,
Contacts.TenantDetails,
Contacts.IncomeDetails.IncomeType,
Contacts.IncomeDetails.IncomeFrequency,
Contacts.Relationship,
Contacts.ReceivingSupportDetails,
Contacts.RequestedSupportDetails,
Contacts.ReceivingSupportDetails.SupportType,
Contacts.RequestedSupportDetails.SupportType,
Contacts.ReceivingSupportDetails.SupportProvider,
Contacts.ReceivingSupportDetails.ContactByDetails,
VblMutualExchagePropertyDetail.AdaptationDetails,
VBLRequestedPropertymatchDetail, 
VBLRequestedPropertymatchDetail.PropertyTypes, 
VBLRequestedPropertymatchDetail.PropertyTypes.PropertyType, 
VBLRequestedPropertymatchDetail.PropertySizes,
VBLRequestedPropertymatchDetail.PropertySizes.PropertySize,
VBLRequestedPropertymatchDetail.AgeRestrictions,
VBLRequestedPropertymatchDetail.AgeRestrictions.AgeRestriction,
VBLRequestedPropertymatchDetail.AdaptationDetails,
VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.RequestedPropertyPrefferedNeighbourhoodDetails";

        private string basicQueryString =
            @"ApplicationStatus,ResidencyType,MoveReason,TenancyType,Landlord,Contacts.ContactType";

        private string contactsQueryString = @"
Contacts.ContactType,
Contacts.DisabilityDetails,
Contacts.DisabilityDetails,
Contacts.TenantDetails,
Contacts.IncomeDetails.IncomeType,
Contacts.IncomeDetails.IncomeFrequency";

        private string propertyDetailQueryString = @"
VblMutualExchagePropertyDetail,
VblMutualExchagePropertyDetail.AdaptationDetails";

        private string propertyPreferenceQueryString = @"VBLRequestedPropertymatchDetail, 
VBLRequestedPropertymatchDetail.PropertyTypes, 
VBLRequestedPropertymatchDetail.PropertyTypes.PropertyType, 
VBLRequestedPropertymatchDetail.PropertySizes,
VBLRequestedPropertymatchDetail.PropertySizes.PropertySize,
VBLRequestedPropertymatchDetail.AgeRestrictions,
VBLRequestedPropertymatchDetail.AdaptationDetails,
VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.RequestedPropertyPrefferedNeighbourhoodDetails";

        private string propertyShopQueryString = @"VBLCustomerInterests,VblMutualExchagePropertyDetail,
VblMutualExchagePropertyDetail.AdaptationDetails,VBLRequestedPropertymatchDetail, 
VBLRequestedPropertymatchDetail.PropertyTypes, 
VBLRequestedPropertymatchDetail.PropertyTypes.PropertyType, 
VBLRequestedPropertymatchDetail.PropertySizes,
VBLRequestedPropertymatchDetail.PropertySizes.PropertySize,
VBLRequestedPropertymatchDetail.AgeRestrictions,
VBLRequestedPropertymatchDetail.AdaptationDetails,
VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.RequestedPropertyPrefferedNeighbourhoodDetails";


        private IUnitOfWork _unitOfWork;
        private IPersonApiClient _personApiClient;
        private IPersonAddressApiClient _personAddressApiClient;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public ApplicationBLL() : this(new UnitOfWork(), new ApplicationHistoryBLL(), new PersonApiClient(), new PersonAddressApiClient())
        {
        }

        public ApplicationBLL(IUnitOfWork unitOfWork, IApplicationHistoryBLL applicationHistoryBLL, IPersonApiClient personApiClient, IPersonAddressApiClient personAddressApiClient)
        {
            _unitOfWork = unitOfWork;
            _applicationHistoryBLL = applicationHistoryBLL;
            _personApiClient = personApiClient;
            _personAddressApiClient = personAddressApiClient;
        }

        public string GetApplicationRowVersion(int applicationId)
        {
            var applicationRowVersion = _unitOfWork.VBLApplications()
                .Select().AsNoTracking().FirstOrDefault(x => x.ApplicationId == applicationId)?.RowVersion;
            return applicationRowVersion.ConvertByteArrayToString();

        }

        public VBLApplication GetApplication(int applicationId)
        {
            var application = _unitOfWork.VBLApplications()
                         .Select(includeProperties: queryString).FirstOrDefault(x => x.ApplicationId == applicationId);
            application.LevelOfNeeds = _unitOfWork.LeveOfNeeds().Select().FirstOrDefault(x => x.LevelOfNeedId == application.ApplicationLevelOfNeedID);
            //if (application != null)
            //{
            //    var lonId = application.ApplicationLevelOfNeedID;
            //    if (lonId != null && application.LevelOfNeeds != null)
            //    {
            //        application.LevelOfNeeds = levelofneeds.First(x => x.LevelOfNeedId == lonId.Value);
            //    }
            //}

            return CreateVBLApplicationMapping(application);
        }

        public VBLApplication GetApplicationOnly(int customerApplicationApplicationId)
        {
            var application = _unitOfWork.VBLApplications()
                .Select().FirstOrDefault(x => x.ApplicationId == customerApplicationApplicationId);
            application.LevelOfNeeds = _unitOfWork.LeveOfNeeds().Select().FirstOrDefault(x => x.LevelOfNeedId == application.ApplicationLevelOfNeedID);

            //return CreateVBLApplicationMapping(application);
            return application;
        }

        public VBLApplication GetBasicApplication(int applicationId)
        {
            var application = _unitOfWork.VBLApplications()
                         .Select(includeProperties: basicQueryString).FirstOrDefault(x => x.ApplicationId == applicationId);

            return CreateVBLApplicationMapping(application);
        }


        private SearchContact PopulateSearchResultinMain(VBLApplication application)
        {
            var mainContact = application.Contacts.FirstOrDefault(x => x.ContactTypeId == 1);

            var searchPerson = _unitOfWork.SearchContacts().Select()
                .FirstOrDefault(x => x.ContactId == mainContact.ContactId);
            //application.Contacts.FirstOrDefault(x => x.ContactTypeId == 1).SearchContact = searchPerson;
            return searchPerson;
        }

        /// <summary>
        /// </summary>
        /// <param name="customerApplication"></param>
        /// <param name="persistedApplication"></param>
        /// <returns></returns>
        public bool UpdateApplicationStatus(VBLApplication customerApplication, VBLApplication persistedApplication)
        {
            persistedApplication.ApplicationStatusID = customerApplication.ApplicationStatusID;

            if (customerApplication.ApplicationStatusID == 3)  //rehoused //todo : convert to Enum
            {
                persistedApplication.ApplicationClosedDate = customerApplication.ApplicationClosedDate;
            }

            persistedApplication.ModifiedDate = customerApplication.ModifiedDate;
            persistedApplication.ModifiedBy = customerApplication.ModifiedBy;

            try
            {
                _unitOfWork.VBLApplications().Update(persistedApplication);
                _unitOfWork.Commit();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public VBLApplication GetApplicationForContactPages(int applicationId)
        {
            var application = _unitOfWork.VBLApplications()
                         .Select(includeProperties: basicQueryString + "," + contactsQueryString).FirstOrDefault(x => x.ApplicationId == applicationId);


            VBLApplication result = CreateVBLApplicationMapping(application);
            return result;
        }

        private VBLApplication CreateVBLApplicationMapping(VBLApplication application)
        {
            var applicationDto = Mapper.Map<VBLApplication>(application);
            if (applicationDto.Contacts != null && applicationDto.Contacts.Any(x => x.ContactTypeId == 1))
            {
                applicationDto.Contacts.First(x => x.ContactTypeId == 1).SearchContact = PopulateSearchResultinMain(applicationDto);
                var mainApplicant = application.Contacts.First(x => x.ContactTypeId == 1);
                var person = _personApiClient.GetPerson(mainApplicant.GlobalIdentityKey.Value);
                var personAddress = person.PersonAddresses?.FirstOrDefault(x => x.AddressTypeId == 1);
                if (personAddress?.Address != null)
                {
                    applicationDto.Address = Mapper.Map<VBLAddress>(personAddress.Address);
                }
            }
            foreach (var contact in applicationDto.Contacts)
            {
                foreach (var incomeDetail in contact.IncomeDetails)
                {
                    incomeDetail.Contact = null;
                }
            }

            if (applicationDto.VblMutualExchagePropertyDetail != null)
            {
                foreach (var adaptationDetail in applicationDto.VblMutualExchagePropertyDetail.AdaptationDetails)
                {
                    adaptationDetail.VBLMutualExchagePropertyDetail = null;
                }
            }
            if (applicationDto.VBLRequestedPropertymatchDetail != null)
            {
                foreach (var propertyType in applicationDto.VBLRequestedPropertymatchDetail.PropertyTypes)
                {
                    propertyType.VBLRequestedPropertymatchDetail.Application = null;
                }
            }
            return applicationDto;
        }

        public VBLApplication GetApplicationForPropertyDetailPages(int applicationId)
        {
            var application = _unitOfWork.VBLApplications()
                         .Select(includeProperties: basicQueryString + "," + propertyDetailQueryString).FirstOrDefault(x => x.ApplicationId == applicationId);
            return CreateVBLApplicationMapping(application);
        }
        public VBLApplication GetApplicationForPropertyPreferencePages(int applicationId)
        {
            var application = _unitOfWork.VBLApplications()
                         .Select(includeProperties: basicQueryString + "," + propertyPreferenceQueryString).FirstOrDefault(x => x.ApplicationId == applicationId);
            return CreateVBLApplicationMapping(application);
        }
        public VBLApplication GetApplicationForPropertyShopPages(int applicationId)
        {
            var application = _unitOfWork.VBLApplications()
                         .Select(includeProperties: basicQueryString + "," + propertyShopQueryString).FirstOrDefault(x => x.ApplicationId == applicationId);

            var interestList = application.VBLCustomerInterests.Where(x => x.CustomerInterestStatusId == 11).ToList();
            List<int> activeList = new List<int>(new int[] { 1, 4, 6, 7, 8, 10 });
            for (var i = 0; i < interestList.Count; i++)
            {
                var voidid = interestList[i].VoidId;
                VBLCustomerInterest active = _unitOfWork.VBLCustomerInterests().Select().FirstOrDefault(x => x.VoidId == voidid && activeList.Contains(x.CustomerInterestStatusId));
                if (active != null)
                {
                    application.VBLCustomerInterests.Remove(interestList[i]);
                }
            }

            var applicationDto = Mapper.Map<VBLApplication>(application);
            return CreateVBLApplicationMapping(applicationDto);
        }
        public VBLPropertyShopDTO GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(VBLPropertyShopDTO voidToMatch)
        {
            voidToMatch = ValidateVoidProperty(voidToMatch);

            var matchedInterestIds = _unitOfWork.VBLCustomerInterests().Select().Where(y => y.CustomerInterestStatusId != 11 && y.VoidId == voidToMatch.VoidId).Select(x => x.ApplicationId).ToList();

            var areaNeighbourhoodIds =
                _unitOfWork.RequestedPropertyPrefferedNeighbourhoodDetail()
                   .Select()
                   .Where(x => x.NeighbourhoodId == voidToMatch.NeighbourhoodId).Select(x => x.RequestedPropertyPrefferedNeighbourhoodId).ToList();

            var areaApplicationIds = _unitOfWork.RequestedPropertyPrefferedNeighbourhood()
                    .Select()
                    .Where(x => areaNeighbourhoodIds.Contains(x.RequestedPropertyPrefferedNeighbourhoodId)).Select(x => x.ApplicationId).ToList();

            var typeApplicationIds = _unitOfWork.RequestedPropertyPropertyType()
                   .Select()
                   .Where(x => x.PropertyType.Name.ToUpper() == voidToMatch.PropertyType.ToUpper()).Select(x => x.ApplicationId).ToList();

            var sizeApplicationIds = _unitOfWork.RequestedPropertyPropertySize()
                   .Select()
                   .Where(x => x.PropertySizeId == voidToMatch.Bedrooms).Select(x => x.ApplicationId).ToList();

            var applications =
                _unitOfWork.VBLApplications()
                    .Select(includeProperties: propertyPreferenceQueryString)
                    .Where(x => x.ApplicationStatusID == 1 && !(matchedInterestIds).Contains(x.ApplicationId) && areaApplicationIds.Contains(x.ApplicationId) && typeApplicationIds.Contains(x.ApplicationId) && sizeApplicationIds.Contains(x.ApplicationId))
                    .ToList();
            var agerestriction = 0.0;
            if (Double.TryParse(voidToMatch.AgeRestriction, out agerestriction))
            {
                if (agerestriction >= 65.00)
                {
                    var agerestrictions =
                        _unitOfWork.RequestedPropertyAgeRestriction().Select().Where(x => x.AgeRestrictionId == 3).ToList();
                    var ageRestrictedAppIds = agerestrictions.Select(x => x.ApplicationId).ToList();
                    applications = applications.Where(x => ageRestrictedAppIds.Contains(x.ApplicationId)).ToList();
                }
                else if (agerestriction >= 55.00)
                {
                    var agerestrictions =
                        _unitOfWork.RequestedPropertyAgeRestriction().Select().Where(x => x.AgeRestrictionId == 2 || x.AgeRestrictionId == 3).ToList();
                    var ageRestrictedAppIds = agerestrictions.Select(x => x.ApplicationId).ToList();
                    applications = applications.Where(x => ageRestrictedAppIds.Contains(x.ApplicationId)).ToList();
                }
                else if (agerestriction >= 18.00)
                {
                    var agerestrictions =
                        _unitOfWork.RequestedPropertyAgeRestriction().Select().Where(x => x.AgeRestrictionId == 1 || x.AgeRestrictionId == 2 || x.AgeRestrictionId == 3).ToList();
                    var ageRestrictedAppIds = agerestrictions.Select(x => x.ApplicationId).ToList();
                    applications = applications.Where(x => ageRestrictedAppIds.Contains(x.ApplicationId) || x.VBLRequestedPropertymatchDetail.AgeRestricted != true).ToList();
                }
                else
                {
                    applications = applications.Where(x => x.VBLRequestedPropertymatchDetail.AgeRestricted != true).ToList();
                }
            }
            else
            {
                applications = applications.Where(x => x.VBLRequestedPropertymatchDetail.AgeRestricted != true).ToList();
            }


            //communal entrance
            //applications = applications.Where(x => (voidToMatch.CommunalEntrance != true && (!x.VBLRequestedPropertymatchDetail.CatOrDog.HasValue || x.VBLRequestedPropertymatchDetail.CatOrDog == false || x.VBLRequestedPropertymatchDetail.RehousePet == true)) || voidToMatch.CommunalEntrance == true || string.IsNullOrWhiteSpace(voidToMatch.Pets)).ToList();
            applications = applications.Where(x => (voidToMatch.Pets == "N" && (!x.VBLRequestedPropertymatchDetail.CatOrDog.HasValue || x.VBLRequestedPropertymatchDetail.CatOrDog == false || x.VBLRequestedPropertymatchDetail.RehousePet == true)) || voidToMatch.Pets == "Y" || string.IsNullOrWhiteSpace(voidToMatch.Pets)).ToList();

            if (voidToMatch.HighRise == true)
            {
                applications = applications.Where(x => x.VBLRequestedPropertymatchDetail.HighRise != false).ToList();
                if (voidToMatch.Lift == false)
                {
                    applications =
                        applications.Where(x => x.VBLRequestedPropertymatchDetail.LiftServed != true).ToList();
                }
            }
            if (voidToMatch.NumberOfSteps == null || voidToMatch.NumberOfSteps >= 20)
            {
                //20+
                applications =
                    applications.Where(x => x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.TwentyPlus)
                        .ToList();
            }
            else if (voidToMatch.NumberOfSteps < 20 && voidToMatch.NumberOfSteps >= 10)
            {
                //10 to 20 and 20 +
                applications =
                    applications.Where(x => x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.TwentyPlus || x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.TenToTwenty)
                        .ToList();
            }
            else if (voidToMatch.NumberOfSteps < 10 && voidToMatch.NumberOfSteps >= 3)
            {
                //3 to 10, 10 to 20, 20+
                applications =
                    applications.Where(x => x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.TwentyPlus || x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.TenToTwenty || x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.ThreeToTen)
                        .ToList();
            }
            else if (voidToMatch.NumberOfSteps < 3 && voidToMatch.NumberOfSteps >= 1)
            {
                //1 to 2, 3 to 10, 10 to 20, 20+
                applications =
                    applications.Where(x => x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.TwentyPlus || x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.TenToTwenty || x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.ThreeToTen || x.VBLRequestedPropertymatchDetail.NumberOfSteps == NumberOfSteps.OneToTwo)
                        .ToList();
            }
            if (voidToMatch.WheelchairAdapted == true || voidToMatch.RampedAccess == true ||
                voidToMatch.Stairlift == true || voidToMatch.StepInShower == true || voidToMatch.WalkInShower == true)
            {
                if (applications.Any(x => x.VBLRequestedPropertymatchDetail.RequireAdaptations == true))
                {
                    applications =
                        applications.Where(x => x.VBLRequestedPropertymatchDetail.RequireAdaptations == true).ToList();
                }
            }
            else
            {
                applications =
                    applications.Where(x => x.VBLRequestedPropertymatchDetail.RequireAdaptations == false).ToList();
            }
            applications = applications.OrderBy(x => x.ApplicationLevelOfNeedID).ThenBy(x => x.VBLRequestedPropertymatchDetail.StartDate).ToList();

            voidToMatch.MatchedApplicationId = applications.Any() ? applications.First().ApplicationId : 0;


            return voidToMatch;
        }

        private VBLPropertyShopDTO ValidateVoidProperty(VBLPropertyShopDTO voidToMatch)
        {
            if (string.IsNullOrWhiteSpace(voidToMatch.PropertyType))
                voidToMatch.ErrorMessage += "The Property Type cannot be null." + Environment.NewLine;
            else if (!voidToMatch.PropertyType.Contains("Bedsit") && (!voidToMatch.Bedrooms.HasValue || voidToMatch.Bedrooms.Value == 0))
                voidToMatch.ErrorMessage += "Only property type Bedsit can have 0 Bedrooms." + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(voidToMatch.AgeRestriction))
                voidToMatch.ErrorMessage += "The Age Restriction cannot be null." + Environment.NewLine;
            else if (!voidToMatch.AgeRestriction.Contains("."))
                voidToMatch.ErrorMessage += "The Age Restriction format is not correct. It must be in {00.00} format." + Environment.NewLine;
            if (voidToMatch.NeighbourhoodId == 0)
                voidToMatch.ErrorMessage += "The NeighbourhoodId cannot be 0." + Environment.NewLine;

            return voidToMatch;
        }

        public VBLApplication GetApplicationWithNeighbourhoodsDetails(int applicationId)
        {
            var application = _unitOfWork.VBLApplications()
                         .Select2(x => x.ApplicationId == applicationId, includeProperties: i =>
                    new
                    {
                        i.ApplicationStatus,
                        i.MoveReason,
                        i.ResidencyType,
                        //i.Contacts.FirstOrDefault().Gender,
                        i.Contacts.FirstOrDefault().DisabilityDetails,
                        //i.Contacts.FirstOrDefault().NationalityType,
                        i.Contacts.FirstOrDefault().ContactType,
                        //i.Contacts.FirstOrDefault().Title,
                        i.Contacts.FirstOrDefault().ContactByDetails.FirstOrDefault().ContactBy,
                        i.Contacts.FirstOrDefault().TenantDetails,
                        i.VBLRequestedPropertymatchDetail.PropertyTypes.FirstOrDefault().PropertyType,
                        i.VBLRequestedPropertymatchDetail.PropertySizes.FirstOrDefault().PropertySize,
                        i.VBLRequestedPropertymatchDetail.AgeRestrictions.First().AgeRestriction,
                        i.VblMutualExchagePropertyDetail.AdaptationDetails,

                    }).FirstOrDefault();
            var applicationDto = Mapper.Map<VBLApplication>(application);
            return applicationDto;
        }
        public List<VBLApplication> GetApplications(ODataQueryOptions<VBLApplication> options)
        {

            var applications =
                options.ApplyTo(
                    _unitOfWork.VBLApplications()
                        .Select(
                            includeProperties:
                                "ApplicationStatus,Contacts.ContactType,Contacts.ContactByDetails")
                        .AsQueryable());
            return Mapper.Map<List<VBLApplication>>(applications);
        }


        public VBLApplication Update(VBLApplication application)
        {
            var changeDescription = string.Empty;
            var persistedApplication = _unitOfWork.VBLApplications().Select()
                .FirstOrDefault(x => x.ApplicationId == application.ApplicationId);
            if (persistedApplication == null)
            {
                return new VBLApplication { ErrorMessage = "The application is deleted " };
            }
            if (application.SaveApplication == SaveApplication.Close)
            {
                if (persistedApplication.ApplicationStatusID == 1)
                {
                    persistedApplication.ApplicationStatusID = 2;
                    persistedApplication.ApplicationClosedDate = DateTime.Now;
                    persistedApplication.ApplicationStatusReasonID = application.ApplicationStatusReasonID;
                    changeDescription = string.Format("Application Status updated to <span class=\"newvalue\"> Closed</span>; Reason:<span class=\"newvalue\">  {0}", application.ApplicationStatusReason) + "</span><br />";
                    _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId, application.UserIPAddress, ApplicationActivity.CloseApplication, ApplicationChangeType.StatusChanged, changeDescription);
                    _unitOfWork.Commit();
                }
            }
            else if (application.SaveApplication == SaveApplication.Reopen)
            {
                if (persistedApplication.ApplicationStatusID == 2 || persistedApplication.ApplicationStatusID == 5 || persistedApplication.ApplicationStatusID == 4)
                {
                    persistedApplication.ApplicationStatusID = 1;
                    persistedApplication.ApplicationStatusReason = application.ApplicationStatusReason;
                    changeDescription =
                        $"Application Status updated to <span class=\"newvalue\"> Open</span>; Reason: <span class=\"newvalue\"> {application.ApplicationStatusReason}</span>";
                    _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId, application.UserIPAddress, ApplicationActivity.ReopenApplication, ApplicationChangeType.StatusChanged, changeDescription);
                    _unitOfWork.Commit();
                }
            }
            else if (application.SaveApplication == SaveApplication.Assessment)
            {
                if (application.ApplicationLevelOfNeedID == null)
                {
                    application.ApplicationLevelOfNeedID = 4;
                }
                if (persistedApplication.ApplicationLevelOfNeedID != application.ApplicationLevelOfNeedID && application.ApplicationLevelOfNeedID > 0)
                {

                    var levelOfNeed = _unitOfWork.LeveOfNeeds().Select().Where(x => x.Active).ToList();
                    var originalValue =
                        levelOfNeed.FirstOrDefault(x => x.LevelOfNeedId == persistedApplication.ApplicationLevelOfNeedID);
                    var currentValue =
                      levelOfNeed.FirstOrDefault(x => x.LevelOfNeedId == application.ApplicationLevelOfNeedID);
                    if (originalValue != null)
                    {
                        changeDescription =
                            $"Level Of Need changed from <span class=\"oldvalue\"> {originalValue.Name} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" +
                            "<br />";
                        _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId,
                        application.UserIPAddress, ApplicationActivity.Ammendment,
                        ApplicationChangeType.PropertyDetails, changeDescription);
                    }
                    else
                    {
                        changeDescription =
                            $"Level Of Need <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span> added" +
                            "<br />";
                        _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId,
                        application.UserIPAddress, ApplicationActivity.NewDetails,
                        ApplicationChangeType.PropertyDetails, changeDescription);
                    }

                    persistedApplication.LevelOfNeeds = null;
                    persistedApplication.ApplicationLevelOfNeedID = application.ApplicationLevelOfNeedID;
                    persistedApplication.AssessmentLastModifiedInfo = application.AssessmentLastModifiedInfo;
                }
                if (persistedApplication.ApplicationLevelOfNeedReason != application.ApplicationLevelOfNeedReason)
                {
                    persistedApplication.ApplicationLevelOfNeedReason = application.ApplicationLevelOfNeedReason;
                    persistedApplication.AssessmentLastModifiedInfo = application.AssessmentLastModifiedInfo;
                    changeDescription =
                           $"Level Of Need reason set as <span class=\"newvalue\"> {application.ApplicationLevelOfNeedReason} </span>" + "<br />";
                    _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId, application.UserIPAddress, ApplicationActivity.Ammendment, ApplicationChangeType.PropertyDetails, changeDescription);

                }
                _unitOfWork.Commit();
            }

            else if (application.SaveApplication == SaveApplication.ReasonForMoving)
            {
                if (persistedApplication.MoveReasonId != application.MoveReasonId)
                {

                    var moveReson = _unitOfWork.MoveReasons().Select().Where(x => x.Active).ToList();
                    var originalValue =
                        moveReson.FirstOrDefault(x => x.MoveReasonId == persistedApplication.MoveReasonId);
                    var currentValue = moveReson.FirstOrDefault(x => x.MoveReasonId == application.MoveReasonId);
                    if (originalValue != null)
                    {
                        changeDescription =
                            $"Move Reason changed from <span class=\"oldvalue\"> {originalValue.Name} </span>  to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" +
                            "<br />";
                        _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId,
                           application.UserIPAddress, ApplicationActivity.Ammendment,
                           ApplicationChangeType.PropertyDetails, changeDescription);

                    }
                    else
                    {
                        changeDescription =
                           $"Move Reason <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span> added." +
                           "<br />";
                        _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId,
                           application.UserIPAddress, ApplicationActivity.NewDetails,
                           ApplicationChangeType.PropertyDetails, changeDescription);
                    }

                    persistedApplication.MoveReasonId = application.MoveReasonId;
                }
                _unitOfWork.Commit();
            }
            else if (application.SaveApplication == SaveApplication.PropertyDetails)
            {
                bool amend = !(persistedApplication.LandlordId == null);
                var mainApplicant = _unitOfWork.SearchContacts().Select().FirstOrDefault(x => x.ApplicationId == application.ApplicationId && x.ContactTypeName == "Applicant");
                var person = _personApiClient.GetPerson(mainApplicant.GlobalIdentityKey.Value);
                UpsertAddress(application, person);
                if (application.LandlordId == 1)
                {
                    InsertTenantDetails(application, persistedApplication);
                }
                if ((persistedApplication.LandlordId != application.LandlordId) && application.LandlordId > 0)
                {

                    var landlords = _unitOfWork.Landlords().Select().Where(x => x.Active).ToList();
                    var originalValue =
                        landlords.FirstOrDefault(x => x.LandlordId == persistedApplication.LandlordId);
                    var currentValue =
                      landlords.FirstOrDefault(x => x.LandlordId == application.LandlordId);
                    if (originalValue != null)
                    {
                        changeDescription = changeDescription +
                                            $"Landlord changed from <span class=\"oldvalue\"> {originalValue.Name} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" +
                                            "<br>";


                    }
                    else
                    {
                        changeDescription = changeDescription +
                                            $"Landlord <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span> added." +
                                            "<br>";
                    }

                    persistedApplication.LandlordId = application.LandlordId;
                }
                if ((persistedApplication.ResidencyTypeId != application.ResidencyTypeId) && application.ResidencyTypeId > 0)
                {

                    var landlords = _unitOfWork.ResidencyTypes().Select().Where(x => x.Active).ToList();
                    var originalValue = landlords.FirstOrDefault(x => x.ResidencyTypeId == persistedApplication.ResidencyTypeId);
                    var currentValue = landlords.FirstOrDefault(x => x.ResidencyTypeId == application.ResidencyTypeId);
                    if (originalValue != null)
                    {
                        changeDescription = changeDescription +
                                            $"Residency Type changed from <span class=\"oldvalue\"> {originalValue.Name} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" +
                                            "<br>";
                    }
                    else
                    {
                        changeDescription = changeDescription +
                                            $"Residency Type <span class=\"newvalue\"> {currentValue.Name} </span> added" +
                                            "<br>";
                    }

                    persistedApplication.ResidencyTypeId = application.ResidencyTypeId;
                }
                if ((persistedApplication.TenancyTypeId != application.TenancyTypeId) && application.TenancyTypeId > 0)
                {
                    persistedApplication.TenancyTypeId = application.TenancyTypeId;
                    var landlords = _unitOfWork.TenancyTypes().Select().Where(x => x.Active).ToList();
                    var originalValue =
                        landlords.FirstOrDefault(x => x.TenancyTypeId == persistedApplication.TenancyTypeId);
                    var currentValue =
                      landlords.FirstOrDefault(x => x.TenancyTypeId == application.TenancyTypeId);
                    if (originalValue != null)
                    {
                        if (originalValue != currentValue)
                        {
                            changeDescription = changeDescription +
                                                $"Tenancy Type changed from <span class=\"oldvalue\"> {originalValue.Name} </span> to <span class=\"newvalue\"> {(currentValue == null ? string.Empty : currentValue.Name)} </span>" +
                                                "<br>";
                        }
                    }
                    else
                    {
                        changeDescription = changeDescription +
                                            $"Tenancy Type  <span class=\"newvalue\"> {currentValue.Name} </span> added" +
                                            "<br>";

                    }

                }
                if (persistedApplication.DateMovedIn != null)
                {
                    if (persistedApplication.DateMovedIn != application.DateMovedIn)
                    {
                        changeDescription = changeDescription +
                                            string.Format(
                                                "Date Moved In changed from <span class=\"oldvalue\"> {0} </span> to <span class=\"newvalue\"> {1} </span>",
                                                persistedApplication.DateMovedIn, application.DateMovedIn) + "<br>";
                        persistedApplication.DateMovedIn = application.DateMovedIn;
                    }
                }
                else if (persistedApplication.DateMovedIn != application.DateMovedIn)
                {
                    changeDescription = changeDescription +
                                        string.Format(
                                            "Date Moved In <span class=\"newvalue\"> {0} </span> added",
                                            application.DateMovedIn) + "<br>";
                    persistedApplication.DateMovedIn = application.DateMovedIn;
                }
                if (changeDescription != "")
                {
                    if (amend)
                    {
                        _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId,
                            application.UserIPAddress, ApplicationActivity.Ammendment,
                            ApplicationChangeType.PropertyDetails,
                            changeDescription);
                    }
                    else
                    {
                        _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId,
                            application.UserIPAddress, ApplicationActivity.NewDetails,
                            ApplicationChangeType.PropertyDetails,
                            changeDescription);
                    }
                    _unitOfWork.Commit();
                }
            }
            else if (application.SaveApplication == SaveApplication.MutexDetails)
            {
                persistedApplication.IsMainTenant = application.IsMainTenant;
                persistedApplication.LeaveVacantProperty = application.LeaveVacantProperty;
                _unitOfWork.Commit();
                if ((application.TenancyTypeId == 3 || application.TenancyTypeId == 1)
                    && (application.IsMainTenant && application.LeaveVacantProperty.HasValue && application.LeaveVacantProperty.Value))
                {
                    UpsertMutualExchangeDetails(application, persistedApplication);
                }
                else
                {
                    if (persistedApplication.VblMutualExchagePropertyDetail?.AdaptationDetails != null && persistedApplication.VblMutualExchagePropertyDetail.AdaptationDetails.Any())
                    {
                        var adaptationDetails = persistedApplication.VblMutualExchagePropertyDetail.AdaptationDetails.ToList();
                        for (int ctr = 0; ctr < adaptationDetails.Count; ctr++)
                        {
                            var deletedAdaptationDetail = adaptationDetails[ctr];
                            _unitOfWork.MutualExchangeAdaptationDetails().Delete(deletedAdaptationDetail);
                        }
                    }
                    if (persistedApplication.VblMutualExchagePropertyDetail != null)
                    {
                        _unitOfWork.VblMutualExchagePropertyDetail().Delete(persistedApplication.VblMutualExchagePropertyDetail);
                        _unitOfWork.Commit();
                    }
                }
            }
            persistedApplication = GetApplication(persistedApplication.ApplicationId);
            return persistedApplication;
        }

        public VBLApplication UpdateApplicationDate(VBLApplication application)
        {
            var changeDescription = string.Empty;
            var persistedApplication = _unitOfWork.VBLApplications().Select()
                .FirstOrDefault(x => x.ApplicationId == application.ApplicationId);
            if (persistedApplication != null)
            {
                persistedApplication.ApplicationDate = application.ApplicationDate;
                persistedApplication.UserIPAddress = application.UserIPAddress;
                persistedApplication.UserId = application.UserId;
                persistedApplication.ModifiedBy = application.UserId;
                persistedApplication.ModifiedDate = DateTime.Now;
                _unitOfWork.VBLApplications().Update(persistedApplication);

                changeDescription =
                    string.Format(
                        "Application Date updated to <span class=\"newvalue\">{0}</span>",
                        application.ApplicationDate.ToShortDateString());
                _applicationHistoryBLL.Create(persistedApplication.ApplicationId, application.UserId,
                    application.UserIPAddress, ApplicationActivity.Ammendment,
                    ApplicationChangeType.ApplicationDateChanged, changeDescription);


                _unitOfWork.Commit();
                persistedApplication = GetApplication(persistedApplication.ApplicationId);
            }
           
            return persistedApplication;
        }

        private void UpsertAddress(VBLApplication application, PersonDto person)
        {
            var personAddress = person.PersonAddresses.FirstOrDefault(x => x.AddressTypeId == 1);
            if (personAddress == null)
            {

                var address = new AddressDto
                {
                    AddressLine1 = application.Address.AddressLine1,
                    AddressLine2 = application.Address.AddressLine2,
                    AddressLine3 = application.Address.AddressLine3,
                    AddressLine4 = application.Address.AddressLine4,
                    PostCode = application.Address.PostCode,
                    CreatedBy = application.UserId,
                    CreatedDate = DateTime.Now
                };

                string fullAddress = application.Address.AddressLine1 + ",  " + application.Address.AddressLine2 + ",  " +
                                     application.Address.AddressLine3 + ",  " + application.Address.PostCode;
                var changeDescription = string.Format("Address <br> <span class= \"newvalue\">{0}</span> added", fullAddress) + "<br>";
                _applicationHistoryBLL.Create(application.ApplicationId, application.UserId, application.UserIPAddress, ApplicationActivity.NewDetails, ApplicationChangeType.PropertyDetails, changeDescription);
                var personAddressDto = new PersonAddressDto
                {
                    PersonId = person.Id,
                    Address = address,
                    AddressTypeId = 1
                };
                _personAddressApiClient.PostPersonAddress(personAddressDto);
            }
            else
            {
                var changeDescription = String.Empty;
                if (personAddress.Address.AddressLine1 != application.Address.AddressLine1)
                {
                    changeDescription = string.Format("Address Line 1 changed from {0} to {1}", personAddress.Address.AddressLine1, application.Address.AddressLine1) + "<br>";
                    personAddress.Address.AddressLine1 = application.Address.AddressLine1;
                }
                if (personAddress.Address.AddressLine2 != application.Address.AddressLine2)
                {
                    changeDescription = string.Format("Address Line 2 changed from {0} to {1}", personAddress.Address.AddressLine2, application.Address.AddressLine2) + "<br>";
                    personAddress.Address.AddressLine2 = application.Address.AddressLine2;
                }
                if (personAddress.Address.AddressLine3 != application.Address.AddressLine3)
                {
                    changeDescription = string.Format("Address Line 3 changed from {0} to {1}", personAddress.Address.AddressLine3, application.Address.AddressLine3) + "<br>";
                    personAddress.Address.AddressLine3 = application.Address.AddressLine3;
                }
                if (personAddress.Address.AddressLine4 != application.Address.AddressLine4)
                {
                    changeDescription = string.Format("Address Line 4 changed from {0} to {1}", personAddress.Address.AddressLine4, application.Address.AddressLine4) + "<br>";
                    personAddress.Address.AddressLine4 = application.Address.AddressLine4;
                }
                if (personAddress.Address.PostCode != application.Address.PostCode)
                {
                    changeDescription = string.Format("PostCode changed from {0} to {1}", personAddress.Address.PostCode, application.Address.PostCode) + "<br>";
                    personAddress.Address.PostCode = application.Address.PostCode;
                }
                if (changeDescription != String.Empty)
                {
                    _applicationHistoryBLL.Create(application.ApplicationId, application.UserId, application.UserIPAddress,
                        ApplicationActivity.Ammendment, ApplicationChangeType.PropertyDetails, changeDescription);
                    _personAddressApiClient.PutPersonAddress(personAddress.PersonId, personAddress);
                }
            }
        }
        private void InsertTenantDetails(VBLApplication application, VBLApplication persistedApplication)
        {
            if (persistedApplication.Contacts == null || application.Contacts == null) return;
            var contact = application.Contacts.FirstOrDefault();
            if (contact == null) return;

            var persistedcontact =
                _unitOfWork.VBLContacts()
                    .Select(includeProperties: "TenantDetails")
                    .First(x => x.ApplicationId == application.ApplicationId && x.ContactTypeId == 1);

            var tenantDetailsDto = persistedcontact.TenantDetails.FirstOrDefault();
            if (tenantDetailsDto == null)
            {
                tenantDetailsDto = new VBLTenantDetail
                {
                    TenancyReference = contact.TenantDetails.First().TenancyReference,
                    TenantCode = contact.TenantDetails.First().TenantCode,
                    ContactId = contact.TenantDetails.First().ContactId,
                    CreatedBy = contact.TenantDetails.First().CreatedBy,
                    CreatedDate = contact.TenantDetails.First().CreatedDate,
                    IsActive = true,
                    MainTenant = true
                };
                _unitOfWork.TenantDetails().Insert(tenantDetailsDto);
            }
            else
            {
                tenantDetailsDto.TenancyReference = contact.TenantDetails.First().TenancyReference;
                tenantDetailsDto.TenantCode = contact.TenantDetails.First().TenantCode;
                tenantDetailsDto.ModifiedBy = contact.TenantDetails.First().ModifiedBy;
                tenantDetailsDto.ModifiedDate = contact.TenantDetails.First().ModifiedDate;
                _unitOfWork.TenantDetails().Update(tenantDetailsDto);
            }
            _unitOfWork.Commit();

        }
        protected void UpsertMutualExchangeDetails(VBLApplication application, VBLApplication persistedApplication)
        {
            if (application.VblMutualExchagePropertyDetail != null)
            {
                if (application.VblMutualExchagePropertyDetail.HeatingTypeId == 0)
                {
                    application.VblMutualExchagePropertyDetail.HeatingTypeId = 1;
                }
                if (persistedApplication.VblMutualExchagePropertyDetail == null)
                {
                    persistedApplication.VblMutualExchagePropertyDetail = new VBLMutualExchagePropertyDetail
                    {
                        ApplicationId = application.ApplicationId,
                        PropertyCode = application.VblMutualExchagePropertyDetail.PropertyCode,
                        AgeCritera = application.VblMutualExchagePropertyDetail.AgeCritera,
                        PropertyTypeId = application.VblMutualExchagePropertyDetail.PropertyTypeId,
                        PropertyEntranceTypeId = application.VblMutualExchagePropertyDetail.PropertyEntranceTypeId,
                        PropertyBlockTypeId = application.VblMutualExchagePropertyDetail.PropertyBlockTypeId,
                        AgeRestrictionId = application.VblMutualExchagePropertyDetail.AgeRestrictionId,
                        PropertySizeId = application.VblMutualExchagePropertyDetail.PropertyNumberOfBedrooms,
                        PropertyNumberOfBedrooms = application.VblMutualExchagePropertyDetail.PropertyNumberOfBedrooms,
                        HasStepsToAccess = application.VblMutualExchagePropertyDetail.HasStepsToAccess,
                        NumberOfStepsToAccess = application.VblMutualExchagePropertyDetail.NumberOfStepsToAccess,
                        HeatingTypeId = application.VblMutualExchagePropertyDetail.HeatingTypeId,
                        UserIPAddress = application.UserIPAddress,
                        UserId = application.UserId,
                        CreatedBy = application.UserId,
                        CreatedDate = DateTime.Now
                    };
                }
                else
                {
                    persistedApplication.VblMutualExchagePropertyDetail.PropertyBlockTypeId = application.VblMutualExchagePropertyDetail.PropertyBlockTypeId;
                    persistedApplication.VblMutualExchagePropertyDetail.PropertyCode =
                        application.VblMutualExchagePropertyDetail.PropertyCode;
                    persistedApplication.VblMutualExchagePropertyDetail.PropertyNumberOfBedrooms = application.VblMutualExchagePropertyDetail.PropertyNumberOfBedrooms;
                    persistedApplication.VblMutualExchagePropertyDetail.PropertySizeId = application.VblMutualExchagePropertyDetail.PropertyNumberOfBedrooms;
                    persistedApplication.VblMutualExchagePropertyDetail.PropertyTypeId = application.VblMutualExchagePropertyDetail.PropertyTypeId;
                    persistedApplication.VblMutualExchagePropertyDetail.PropertyEntranceTypeId = application.VblMutualExchagePropertyDetail.PropertyEntranceTypeId;
                    persistedApplication.VblMutualExchagePropertyDetail.PropertyBlockTypeId = application.VblMutualExchagePropertyDetail.PropertyBlockTypeId;
                    persistedApplication.VblMutualExchagePropertyDetail.AgeCritera = application.VblMutualExchagePropertyDetail.AgeCritera;
                    persistedApplication.VblMutualExchagePropertyDetail.HasStepsToAccess = application.VblMutualExchagePropertyDetail.HasStepsToAccess;
                    persistedApplication.VblMutualExchagePropertyDetail.NumberOfStepsToAccess = application.VblMutualExchagePropertyDetail.NumberOfStepsToAccess;
                    persistedApplication.VblMutualExchagePropertyDetail.HeatingTypeId = application.VblMutualExchagePropertyDetail.HeatingTypeId;
                    persistedApplication.VblMutualExchagePropertyDetail.UserIPAddress = application.UserIPAddress;
                    persistedApplication.VblMutualExchagePropertyDetail.UserId = application.UserId;
                    persistedApplication.VblMutualExchagePropertyDetail.ModifiedBy = application.UserId;
                    persistedApplication.VblMutualExchagePropertyDetail.ModifiedDate = DateTime.Now;
                }
            }
            _unitOfWork.Commit();
            UpsertAdaptationForMutualExchange(application.VblMutualExchagePropertyDetail, persistedApplication.VblMutualExchagePropertyDetail);
        }

        protected void UpsertAdaptationForMutualExchange(VBLMutualExchagePropertyDetail mutualExchange, VBLMutualExchagePropertyDetail persistedMutualExchange)
        {
            if (mutualExchange.AdaptationDetails != null && mutualExchange.AdaptationDetails.Any())
            {
                if (persistedMutualExchange.AdaptationDetails != null && persistedMutualExchange.AdaptationDetails.Any())
                {
                    var deletedAdaptationDetails = persistedMutualExchange.AdaptationDetails
                        .Where(a =>
                        !mutualExchange.AdaptationDetails.All(x => x.ApplicationId == a.ApplicationId && x.AdaptationId == a.AdaptationId))
                       .ToList();
                    _unitOfWork.MutualExchangeAdaptationDetails().DeleteRange(deletedAdaptationDetails);
                    var addedAdaptationDetails =
                        mutualExchange.AdaptationDetails.Where(a =>
                        persistedMutualExchange.AdaptationDetails.All(x => x.ApplicationId == a.ApplicationId && x.AdaptationId == a.AdaptationId))
                        .ToList();
                    _unitOfWork.MutualExchangeAdaptationDetails().AddRange(addedAdaptationDetails);
                    _unitOfWork.Commit(mutualExchange.UserId, mutualExchange.UserIPAddress);
                }
                else
                {
                    _unitOfWork.MutualExchangeAdaptationDetails().AddRange(mutualExchange.AdaptationDetails);
                    _unitOfWork.Commit(mutualExchange.UserId, mutualExchange.UserIPAddress);

                }
            }
            else
            {
                if (persistedMutualExchange.AdaptationDetails != null && persistedMutualExchange.AdaptationDetails.Any())
                {
                    var adaptationDetails = persistedMutualExchange.AdaptationDetails.ToList();
                    _unitOfWork.MutualExchangeAdaptationDetails().DeleteRange(adaptationDetails);
                    _unitOfWork.Commit(mutualExchange.UserId, mutualExchange.UserIPAddress);
                }
            }
        }
    }
}