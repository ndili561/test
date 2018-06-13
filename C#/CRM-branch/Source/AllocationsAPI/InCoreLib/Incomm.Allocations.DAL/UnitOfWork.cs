using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;
using InCoreLib.Domain.StoreProcedure;

namespace InCoreLib.DAL
{
    public class UnitOfWork : TrackedUnitOfWork, IUnitOfWork
    {
        private bool _disposed;

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            base.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public IRepository<SearchContact> SearchContacts()
        {
            return _searchContact ??
                   (_searchContact = new Repository<SearchContact>(Context));
        }

        public IRepository<CustomerInterestStatu> CustomerInterestStatus()
        {
            return _customerInterestStatus ??
                  (_customerInterestStatus = new Repository<CustomerInterestStatu>(Context));
        }

        public IRepository<ServiceType> ServiceType()
        {
            return _serviceType ??
                   (_serviceType = new Repository<ServiceType>(Context));
        }

        public IRepository<HRSPlacement> Placement()
        {
            return _hrsPlacement ??
                   (_hrsPlacement = new Repository<HRSPlacement>(Context));
        }

        public IRepository<HRSPlacementMatchedForCustomer> HRSPlacementMatchedForCustomer()
        {
            return _hrsPlacementMatchedForCustomer ??
                   (_hrsPlacementMatchedForCustomer = new Repository<HRSPlacementMatchedForCustomer>(Context));
        }

        public IRepository<SupportType> SupportType()
        {
            return _supportType ??
                   (_supportType = new Repository<SupportType>(Context));
        }

        public IRepository<HRSAlert> HRSAlert()
        {
            return _hrsAlert ??
                   (_hrsAlert = new Repository<HRSAlert>(Context));
        }

        public IRepository<tsubHOAEvent> tsubHOAEvent()
        {
            return _tsubHoaEvent ??
                   (_tsubHoaEvent = new Repository<tsubHOAEvent>(Context));
        }

        public IRepository<HRSCustomer> HRSCustomer()
        {
            return _hrsCustomer ??
                   (_hrsCustomer = new Repository<HRSCustomer>(Context));
        }

        public IRepository<HRSMatchHistory> HRSMatchHistory()
        {
            return _hrsMatchHistory ?? (_hrsMatchHistory = new Repository<HRSMatchHistory>(Context));
        }

        public IRepository<Gender> Genders()
        {
            return _genders ??
                   (_genders = new Repository<Gender>(Context));
        }

        public IRepository<Title> Titles()
        {
            return _titles ??
                   (_titles = new Repository<Title>(Context));
        }

        public IRepository<Contact> Contacts()
        {
            return _contacts ??
                   (_contacts = new Repository<Contact>(Context));
        }

        public IRepository<tblCaseNote> CaseNotes()
        {
            return _casenotes ??
                   (_casenotes = new Repository<tblCaseNote>(Context));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IRepository<CustomerInterest> CustomerInterests()
        {
            return _customerInterests ??
                   (_customerInterests = new Repository<CustomerInterest>(Context));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IRepository<CustomerInterestStatusReason> CustomerInterestStatusReasons()
        {
            return _customerInterestStatusReasons ??
                   (_customerInterestStatusReasons = new Repository<CustomerInterestStatusReason>());
        }

        public IRepository<Hostel> Hostel()
        {
            return _hostel ??
                   (_hostel = new Repository<Hostel>(Context));
        }

        public IRepository<HRSProvider> HRSProvider()
        {
            return _hrsProvider ??
                   (_hrsProvider = new Repository<HRSProvider>(Context));
        }

        public IList<HOAQuestionsAndAnswers> GetHOAQuestionsAndAnswers(int hoaCaseId)
        {
            var hoaCaseIdParameter = new SqlParameter("@CaseReference", hoaCaseId);
            var result = Context.Database
                .SqlQuery<HOAQuestionsAndAnswers>("GetHOAQuestionsAndAnswers @CaseReference", hoaCaseIdParameter)
                .ToList();
            return result;
        }

        public IRepository<lstQuestion> Questions()
        {
            return _questionnaire ??
                   (_questionnaire = new Repository<lstQuestion>(Context));
        }

        public IRepository<HRSEvictionReason> HRSEvictionReasons()
        {
            return _hrsEvictionReasons ??
                   (_hrsEvictionReasons = new Repository<HRSEvictionReason>(Context));
        }

        public IRepository<HRSFloatingSupportServiceEndReason> HRSFloatingSupportServiceEndReasons()
        {
            return _hrsFloatingSupportServiceEndReasons ??
                   (_hrsFloatingSupportServiceEndReasons = new Repository<HRSFloatingSupportServiceEndReason>(Context));
        }

        public IRepository<HRSCustomerMoveOption> HRSCustomerMoveOptions()
        {
            return _hrsCustomerMoveOptions ??
                   (_hrsCustomerMoveOptions = new Repository<HRSCustomerMoveOption>(Context));
        }

        public IRepository<HRSQuestionAnswer> HRSQuestionAnswers()
        {
            return _hoaQuestionAnswer ??
                   (_hoaQuestionAnswer = new Repository<HRSQuestionAnswer>(Context));
        }

        public void Commit(string userId = "", string userIPAddress = "")
        {
            Context.SaveChanges(userId, userIPAddress);
        }

        public IRepository<VBLApplication> VBLApplications()
        {
            return _vblApplications ??
                   (_vblApplications = new Repository<VBLApplication>(Context));
        }

        public IRepository<VBLApplicationHistory> VBLApplicationHistory()
        {
            return _vblApplicationHistory ??
                   (_vblApplicationHistory = new Repository<VBLApplicationHistory>(Context));
        }

        public IRepository<VBLContact> VBLContacts()
        {
            return _vblContacts ??
                   (_vblContacts = new Repository<VBLContact>(Context));
        }

        public IRepository<NationalityType> NationalityTypes()
        {
            return _nationalityTypes ??
                   (_nationalityTypes = new Repository<NationalityType>(Context));
        }

        public IRepository<Ethnicity> Ethnicities()
        {
            return _ethnicities ??
                   (_ethnicities = new Repository<Ethnicity>(Context));
        }

        public IRepository<PreferredLanguage> PreferredLanguages()
        {
            return _languages ??
                   (_languages = new Repository<PreferredLanguage>(Context));
        }

        public IRepository<ContactBy> ContactBy()
        {
            return _contactBy ??
                   (_contactBy = new Repository<ContactBy>(Context));
        }

        public IRepository<IncomeType> IncomeTypes()
        {
            return _incomeTypes ??
                   (_incomeTypes = new Repository<IncomeType>(Context));
        }

        public IRepository<ExpenditureType> ExpenditureTypes()
        {
            return _expenditureTypes ??
                   (_expenditureTypes = new Repository<ExpenditureType>(Context));
        }

        public IRepository<IncomeFrequency> IncomeFrequencies()
        {
            return _incomeFrequencies ??
                   (_incomeFrequencies = new Repository<IncomeFrequency>(Context));
        }

        public IRepository<VBLDisabilityType> DisabilityTypes()
        {
            return _disabilityTypes ??
                   (_disabilityTypes = new Repository<VBLDisabilityType>(Context));
        }

        public IRepository<VBLDisabilityDetails> DisabilityDetails()
        {
            return _disabilityDetails ??
                   (_disabilityDetails = new Repository<VBLDisabilityDetails>(Context));
        }

        //public IRepository<VBLAddress> VBLAddresses()
        //{
        //    return _vblAddresses ??
        //           (_vblAddresses = new Repository<VBLAddress>(Context));
        //}

        public IRepository<VBLIncomeDetail> VBLIncomeDetails()
        {
            return _vblIncomeDetails ??
                   (_vblIncomeDetails = new Repository<VBLIncomeDetail>(Context));
        }

        public IRepository<VBLExpenditureDetail> VBLExpenditureDetails()
        {
            return _vblExpenditureDetails ??
                   (_vblExpenditureDetails = new Repository<VBLExpenditureDetail>(Context));
        }

        public IRepository<AuditVBLIncomeDetails> AuditVBLIncomeDetails()
        {
            return _auditVblIncomeDetails ??
                   (_auditVblIncomeDetails = new Repository<AuditVBLIncomeDetails>(Context));
        }

        public IRepository<AuditVblExpenditureDetails> AuditVBLExpenditureDetails()
        {
            return _auditVblExpenditureDetails ??
                   (_auditVblExpenditureDetails = new Repository<AuditVblExpenditureDetails>(Context));
        }

        public IRepository<VBLSupportType> VBLSupportTypes()
        {
            return _vblSupportTypes ??
                   (_vblSupportTypes = new Repository<VBLSupportType>(Context));
        }

        public IRepository<VBLReceivingSupportDetails> VBLReceivingSupportDetails()
        {
            return _vblReceivingSupportDetails ??
                   (_vblReceivingSupportDetails = new Repository<VBLReceivingSupportDetails>(Context));
        }

        public IRepository<VBLRequestedSupportDetails> VBLRequestedSupportDetails()
        {
            return _vblRequestedSupportDetails ??
                   (_vblRequestedSupportDetails = new Repository<VBLRequestedSupportDetails>(Context));
        }

        public IRepository<VBLSupportContactByDetails> VBLSupportContactByDetails()
        {
            return _vblSupportContactByDetails ??
                   (_vblSupportContactByDetails = new Repository<VBLSupportContactByDetails>(Context));
        }

        //public IRepository<VBLContactByDetails> VBLContactByDetails()
        //{
        //    return _vblContactByDetails ??
        //           (_vblContactByDetails = new Repository<VBLContactByDetails>(Context));
        //}

        //

        public IRepository<VBLSupportProvider> VBLSupportProviders()
        {
            return _vblSupportProviders ??
                   (_vblSupportProviders = new Repository<VBLSupportProvider>(Context));
        }

        public IRepository<ResidencyType> ResidencyTypes()
        {
            return _residencyTypes ??
                   (_residencyTypes = new Repository<ResidencyType>(Context));
        }

        public IRepository<TenancyType> TenancyTypes()
        {
            return _tenancyTypes ??
                   (_tenancyTypes = new Repository<TenancyType>(Context));
        }

        public IRepository<VBLTenantDetail> TenantDetails()
        {
            return _tenantDetails ??
                   (_tenantDetails = new Repository<VBLTenantDetail>(Context));
        }

        public IRepository<PropertyType> PropertyTypes()
        {
            return _propertyType ??
                   (_propertyType = new Repository<PropertyType>(Context));
        }


        public IRepository<Landlord> Landlords()
        {
            return _landlords ??
                   (_landlords = new Repository<Landlord>(Context));
        }

        public IRepository<MoveReason> MoveReasons()
        {
            return _moveReasons ??
                   (_moveReasons = new Repository<MoveReason>(Context));
        }

        public IRepository<LevelOfNeed> LeveOfNeeds()
        {
            return _levelOfNeeds ??
                   (_levelOfNeeds = new Repository<LevelOfNeed>(Context));
        }

        public IRepository<PropertySize> PropertySize()
        {
            return _propertySize ??
                   (_propertySize = new Repository<PropertySize>(Context));
        }

        public IRepository<PropertyEntranceType> PropertyEntranceTypes()
        {
            return _propertyEntrances ??
                   (_propertyEntrances = new Repository<PropertyEntranceType>(Context));
        }

        public IRepository<PropertyBlockType> PropertyBlockTypes()
        {
            return _propertyBlocks ??
                   (_propertyBlocks = new Repository<PropertyBlockType>(Context));
        }

        public IRepository<Adaptation> Adaptations()
        {
            return _adaptations ??
                   (_adaptations = new Repository<Adaptation>(Context));
        }


        public IRepository<VBLMutualExchagePropertyDetail> VblMutualExchagePropertyDetail()
        {
            return _vblMutualExchagePropertyDetail ??
                   (_vblMutualExchagePropertyDetail = new Repository<VBLMutualExchagePropertyDetail>(Context));
        }

        public IRepository<VBLRequestedPropertyAgeRestriction> RequestedPropertyAgeRestriction()
        {
            return _vblRequestedPropertyAgeRestriction ??
                   (_vblRequestedPropertyAgeRestriction = new Repository<VBLRequestedPropertyAgeRestriction>(Context));
        }

        public IRepository<VBLRequestedPropertyPropertySize> RequestedPropertyPropertySize()
        {
            return _vblRequestedPropertyPropertySize ??
                   (_vblRequestedPropertyPropertySize = new Repository<VBLRequestedPropertyPropertySize>(Context));
        }

        public IRepository<VBLRequestedPropertyPropertyType> RequestedPropertyPropertyType()
        {
            return _vblRequestedPropertyPropertyType ??
                   (_vblRequestedPropertyPropertyType = new Repository<VBLRequestedPropertyPropertyType>(Context));
        }

        public IRepository<VBLRequestedPropertyHeatingType> RequestedPropertyHeatingType()
        {
            return _vblRequestedPropertyHeatingType ??
                   (_vblRequestedPropertyHeatingType = new Repository<VBLRequestedPropertyHeatingType>(Context));
        }

        public IRepository<VBLRequestedPropertyPrefferedNeighbourhood> RequestedPropertyPrefferedNeighbourhood()
        {
            return _vblRequestedPropertyPrefferedNeighbourhood ??
                   (_vblRequestedPropertyPrefferedNeighbourhood =
                       new Repository<VBLRequestedPropertyPrefferedNeighbourhood>(Context));
        }

        public IRepository<VBLRequestedPropertyPrefferedNeighbourhoodDetail>
            RequestedPropertyPrefferedNeighbourhoodDetail()
        {
            return _vblRequestedPropertyPrefferedNeighbourhoodDetail ??
                   (_vblRequestedPropertyPrefferedNeighbourhoodDetail =
                       new Repository<VBLRequestedPropertyPrefferedNeighbourhoodDetail>(Context));
        }

        public IRepository<VBLRequestedPropertyScheme> RequestedPropertyScheme()
        {
            return _vblRequestedPropertyScheme ??
                   (_vblRequestedPropertyScheme = new Repository<VBLRequestedPropertyScheme>(Context));
        }

        public IRepository<VBLRequestedPropertyAdaptationDetails> RequestedPropertyAdaptationDetails()
        {
            return _requestedPropertyAdaptationDetails ??
                   (_requestedPropertyAdaptationDetails = new Repository<VBLRequestedPropertyAdaptationDetails>(Context));
        }

        public IRepository<VBLMutualExchangeAdaptationDetails> MutualExchangeAdaptationDetails()
        {
            return _mutualExchangeAdaptationDetails ??
                   (_mutualExchangeAdaptationDetails = new Repository<VBLMutualExchangeAdaptationDetails>(Context));
        }

        public IRepository<AgeRestriction> AgeRestrictions()
        {
            return _ageRestrictions ??
                   (_ageRestrictions = new Repository<AgeRestriction>(Context));
        }

        public IRepository<VBLTenancySearch> VBLTenancySearches()
        {
            return _tenancySearch ??
                   (_tenancySearch = new Repository<VBLTenancySearch>(Context));
        }

        public IRepository<HeatingType> HeatingTypes()
        {
            return _heatingType ??
                   (_heatingType = new Repository<HeatingType>(Context));
        }

        public IRepository<VBLRequestedPropertymatchDetail> VBLRequestedPropertymatchDetail()
        {
            return _propertyMatchDetail ??
                   (_propertyMatchDetail = new Repository<VBLRequestedPropertymatchDetail>(Context));
        }

        public IRepository<VBLDocument> VBLDocuments()
        {
            return _vblDocument ??
                   (_vblDocument = new Repository<VBLDocument>(Context));
        }

        public IRepository<tblHOAssessment> TblHOAssessments()
        {
            return _tblHOAssessment ??
                   (_tblHOAssessment = new Repository<tblHOAssessment>(Context));
        }

        public IRepository<tblUserAdmin> TblUserAdmins()
        {
            return _tblUserAdmin ??
                   (_tblUserAdmin = new Repository<tblUserAdmin>(Context));
        }

        public IRepository<lstContactType> LstContactTypes()
        {
            return _lstContactType ??
                   (_lstContactType = new Repository<lstContactType>(Context));
        }

        public IRepository<lstEthnicity> LstEthnicities()
        {
            return _lstEthnicity ??
                   (_lstEthnicity = new Repository<lstEthnicity>(Context));
        }

        public IRepository<lstApproachReason> LstApproachReasons()
        {
            return _lstApproachReason ??
                   (_lstApproachReason = new Repository<lstApproachReason>(Context));
        }

        public IRepository<lstNationalityType> LstNationalityTypes()
        {
            return _lstNationalityType ??
                   (_lstNationalityType = new Repository<lstNationalityType>(Context));
        }

        public IRepository<lstEligibilityRight> LstEligibilityRights()
        {
            return _lstEligibilityRight ??
                   (_lstEligibilityRight = new Repository<lstEligibilityRight>(Context));
        }

        public IRepository<tblCaseNote> TblCaseNotes()
        {
            return _tblCaseNote ??
                   (_tblCaseNote = new Repository<tblCaseNote>(Context));
        }

        public IRepository<lstCaseNoteType> LstCaseNoteTypes()
        {
            return _lstCaseNoteType ??
                   (_lstCaseNoteType = new Repository<lstCaseNoteType>(Context));
        }

        public IRepository<tsubHOAExclusion> TsubHOAExclusions()
        {
            return _tsubHOAExclusion ??
                   (_tsubHOAExclusion = new Repository<tsubHOAExclusion>(Context));
        }

        public IRepository<lstQuestion> LstQuestions()
        {
            return _lstQuestion ??
                   (_lstQuestion = new Repository<lstQuestion>(Context));
        }

        public IRepository<lstAnswerType> LstAnswerTypes()
        {
            return _lstAnswerType ??
                   (_lstAnswerType = new Repository<lstAnswerType>(Context));
        }

        public IRepository<tsubHOAQuestionAnswer> TsubHOAQuestionAnswers()
        {
            return _tsubHOAQuestionAnswer ??
                   (_tsubHOAQuestionAnswer = new Repository<tsubHOAQuestionAnswer>(Context));
        }

        public IRepository<Relationship> Relationships()
        {
            return _relationship ??
                   (_relationship = new Repository<Relationship>(Context));
        }


        public IRepository<VBLCustomerInterest> VBLCustomerInterests()
        {
            return _vblCustomerInterest ??
                   (_vblCustomerInterest = new Repository<VBLCustomerInterest>(Context));
        }


        public IRepository<tbl_Property> tblProperties()
        {
            return _tblProperties ?? (_tblProperties = new Repository<tbl_Property>(Context));
        }

        public IRepository<VBLNote> VBLNotes()
        {
            return _vblNotes ?? (_vblNotes = new Repository<VBLNote>(Context));
        }

        public IRepository<ApplicationCloseReason> ApplicationCloseReasons()
        {
            return _applicationCloseReasons ??
                   (_applicationCloseReasons = new Repository<ApplicationCloseReason>(Context));
        }

        public IRepository<NotInterestedReason> NotInterestedReasons()
        {

            return _notInterestedReasons ?? (_notInterestedReasons = new Repository<NotInterestedReason>(Context));
        }

        public IRepository<ActionResponsibility> ActionResponsibilities()
        {
            return _actionReponsibilities ?? (_actionReponsibilities = new Repository<ActionResponsibility>(Context));
        }

        public IRepository<ActionType> ActionTypes()
        {
            return _actionTypes ?? (_actionTypes = new Repository<ActionType>(Context));
        }
        
        public IRepository<RiskCategory> RiskCategories()
        {
            return _riskCategories ?? (_riskCategories = new Repository<RiskCategory>(Context));
        }

        public IRepository<RiskTheme> RiskThemes()
        {
            return _riskThemes ?? (_riskThemes = new Repository<RiskTheme>(Context));
        }

        public IRepository<SuitabilityCheckAction> Actions()
        {
            return _actions ?? (_actions = new Repository<SuitabilityCheckAction>(Context));
        }

        public IRepository<SuitabilityCheckRisk> Risks()
        {
            return _risks ?? (_risks = new Repository<SuitabilityCheckRisk>(Context));
        }

        public IRepository<ActionCategory> ActionCategories()
        {
            return _actionCategories ?? (_actionCategories = new Repository<ActionCategory>(Context));
        }

        public IRepository<SuitabilityNote> SuitabilityNotes()
        {
            return _suitabilityNotes ?? (_suitabilityNotes = new Repository<SuitabilityNote>(Context));
        }

        public IRepository<SuitabilityNoteType> SuitabilityNoteTypes()
        {
            return _suitabilityNoteTypes ?? (_suitabilityNoteTypes = new Repository<SuitabilityNoteType>(Context));
        }

        public IList<VoidPropertyMatchForApplication> VoidPropertyMatchForApplication(int applicationId)
        {
            var applicationIdParameter = new SqlParameter("@ApplicationId", applicationId);
            var result = Context.Database
                .SqlQuery<VoidPropertyMatchForApplication>("PropertyMatchForApplicationId @ApplicationId", applicationIdParameter)
                .ToList();
            return result;
        }

        public IRepository<VBLIncommunitiesRelationship> VBLIncommunitiesRelationships()
        {
            return _vblIncommunitiesRelationships ?? (_vblIncommunitiesRelationships = new Repository<VBLIncommunitiesRelationship>(Context));
        }

        public IRepository<TransferCheck> TransferChecks()
        {
            return _transferChecks ?? (_transferChecks = new Repository<TransferCheck>(Context));
        }

        public VoidPropertyMatchForApplication GetPropertyDetails(string propertyCode)
        {
            var propertyCodeParameter = new SqlParameter("@PropertyCode", propertyCode);
            var result = Context.Database
                .SqlQuery<VoidPropertyMatchForApplication>("GetPropertyDetail @PropertyCode", propertyCodeParameter)
                .FirstOrDefault();
            var propertyCodeForImageParameter = new SqlParameter("@PropertyCode", propertyCode);
            var images = Context.Database
              .SqlQuery<VoidPropertyImages>("GetPropertyImage @PropertyCode", propertyCodeForImageParameter)
              .ToList();
            if (result != null && result.Images != null)
                result.Images.AddRange(images.Select(x => x.ImageContent).ToList());
            return result;
        }

        public VoidPropertyMatchForApplication GetPropertyDetails(string propertyCode, int landlordId)
        {
            //var propertyCodeParameter = new SqlParameter("@PropertyCode", propertyCode);
            //var LandlordIdParameter = new SqlParameter("@LandlordId", landlordId);
            //var result =
            //    Context.Database.SqlQuery<VoidPropertyMatchForApplication>(
            //        "GetPropertyDetail @PropertyCode @LandlordId", propertyCode, landlordId).FirstOrDefault();
            //var propertyCodeForImageParameter = new SqlParameter("@PropertyCode", propertyCode);
            var sqlParameter = landlordId + "|" + propertyCode;
            var propertyCodeParameter = new SqlParameter("@LandlordIdsAndPropertyCodes", sqlParameter);
            var result =  Context.Database
                .SqlQuery<VoidPropertyMatchForApplication>(
                    "GetPropertyDetailsByLandlordIdsAndPropertyCodes @LandlordIdsAndPropertyCodes",
                    propertyCodeParameter).FirstOrDefault();
            return result;
        }

        public List<VBLPropertyShopDTO> GetPropertyDetailsByPropertyCodeList(List<SearchPropertyDTO> searchPropertyList)//for available properties
        {
            var sqlParameter = string.Empty;
            foreach (var searchPropertyDto in searchPropertyList)
            {
                if (string.IsNullOrWhiteSpace(sqlParameter))
                    sqlParameter += searchPropertyDto.LandlordId + "|" + searchPropertyDto.PropertyCode;
                else
                    sqlParameter += "&" + searchPropertyDto.LandlordId + "|" + searchPropertyDto.PropertyCode;
            }
            var propertyCodeParameter = new SqlParameter("@LandlordIdsAndPropertyCodes", sqlParameter);
            return Context.Database
               .SqlQuery<VBLPropertyShopDTO>("GetPropertyDetailsByLandlordIdsAndPropertyCodes @LandlordIdsAndPropertyCodes", propertyCodeParameter)
               .ToList();
        }

        public void CreateSuitabilityCheckTask(VBLCustomerInterestDTO customerInterest)
        {
            var applicationIdParameter = new SqlParameter("@ApplicationId", customerInterest.ApplicationId);
            var voidIdParameter = new SqlParameter("@VoidId", customerInterest.VoidId);
            var createdByParameter = new SqlParameter("@CreatedBy", customerInterest.CreatedBy);
             Context.Database.SqlQuery<int>(
                "CreateSuitabilityCheckTask @ApplicationId,@VoidId,@CreatedBy", applicationIdParameter,voidIdParameter,createdByParameter).FirstOrDefault();
        }

        public void CreateMutexTask(MutualExchangeDTO mutexNotification)
        {
            //todo - call the sproc that creates the task
        }
        public List<VoidPropertyMatchForApplication> GetVoidPropertyAvailableForRent()
        {
            return Context.Database
               .SqlQuery<VoidPropertyMatchForApplication>("GetVoidPropertyAvailableForRent")
               .ToList();
        }

        #region ctor

        public UnitOfWork()
            : this(new AllocationsContext())
        {
        }

        public UnitOfWork(AllocationsContext dbContext)
            : base(dbContext)
        {
        }

        #endregion ctor

        #region private fields
        private IRepository<SearchContact> _searchContact;
        private IRepository<CustomerInterestStatu> _customerInterestStatus;
        private IRepository<Gender> _genders;
        private IRepository<Title> _titles;
        private IRepository<Contact> _contacts;
        private IRepository<HRSAlert> _hrsAlert;
        private IRepository<tsubHOAEvent> _tsubHoaEvent;
        private IRepository<HRSCustomer> _hrsCustomer;
        private IRepository<HRSMatchHistory> _hrsMatchHistory;
        private IRepository<ServiceType> _serviceType;
        private IRepository<SupportType> _supportType;
        private IRepository<HRSPlacement> _hrsPlacement;
        private IRepository<HRSPlacementMatchedForCustomer> _hrsPlacementMatchedForCustomer;
        private IRepository<tblCaseNote> _casenotes;
        private IRepository<CustomerInterest> _customerInterests;
        private IRepository<CustomerInterestStatusReason> _customerInterestStatusReasons;
        private IRepository<Hostel> _hostel;
        private IRepository<HRSProvider> _hrsProvider;
        private IRepository<lstQuestion> _questionnaire;
        private IRepository<HRSQuestionAnswer> _hoaQuestionAnswer;
        private IRepository<HRSFloatingSupportServiceEndReason> _hrsFloatingSupportServiceEndReasons;
        private IRepository<HRSCustomerMoveOption> _hrsCustomerMoveOptions;
        private IRepository<HRSEvictionReason> _hrsEvictionReasons;
        private IRepository<VBLContact> _vblContacts;
        private IRepository<VBLApplication> _vblApplications;
        private IRepository<VBLApplicationHistory> _vblApplicationHistory;
        private IRepository<NationalityType> _nationalityTypes;
        private IRepository<Ethnicity> _ethnicities;
        private IRepository<PreferredLanguage> _languages;
        private IRepository<ContactBy> _contactBy;
        private IRepository<IncomeFrequency> _incomeFrequencies;
        private IRepository<IncomeType> _incomeTypes;
        private IRepository<ExpenditureType> _expenditureTypes;
        private IRepository<VBLDisabilityType> _disabilityTypes;
        private IRepository<VBLDisabilityDetails> _disabilityDetails;
        //private IRepository<VBLAddress> _vblAddresses;
        private IRepository<VBLIncomeDetail> _vblIncomeDetails;
        private IRepository<VBLExpenditureDetail> _vblExpenditureDetails;
        private IRepository<AuditVBLIncomeDetails> _auditVblIncomeDetails;
        private IRepository<AuditVblExpenditureDetails> _auditVblExpenditureDetails;
        private IRepository<VBLSupportType> _vblSupportTypes;
        //private IRepository<VBLContactByDetails> _vblContactByDetails;
        private IRepository<VBLReceivingSupportDetails> _vblReceivingSupportDetails;
        private IRepository<VBLRequestedSupportDetails> _vblRequestedSupportDetails;
        private IRepository<VBLSupportContactByDetails> _vblSupportContactByDetails;
        private IRepository<VBLSupportProvider> _vblSupportProviders;
        private IRepository<ResidencyType> _residencyTypes;
        private IRepository<TenancyType> _tenancyTypes;
        private IRepository<VBLTenantDetail> _tenantDetails;
        private IRepository<PropertyType> _propertyType;

        private IRepository<Landlord> _landlords;
        private IRepository<MoveReason> _moveReasons;
        private IRepository<LevelOfNeed> _levelOfNeeds;
        private IRepository<PropertySize> _propertySize;
        private IRepository<PropertyEntranceType> _propertyEntrances;
        private IRepository<PropertyBlockType> _propertyBlocks;
        private IRepository<AgeRestriction> _ageRestrictions;
        private IRepository<Adaptation> _adaptations;
        private IRepository<VBLTenancySearch> _tenancySearch;
        private IRepository<HeatingType> _heatingType;
        private IRepository<VBLMutualExchangeAdaptationDetails> _mutualExchangeAdaptationDetails;
        private IRepository<VBLRequestedPropertyAdaptationDetails> _requestedPropertyAdaptationDetails;
        private IRepository<VBLMutualExchagePropertyDetail> _vblMutualExchagePropertyDetail;
        private IRepository<VBLRequestedPropertymatchDetail> _propertyMatchDetail;
        private IRepository<VBLRequestedPropertyAgeRestriction> _vblRequestedPropertyAgeRestriction;
        private IRepository<VBLRequestedPropertyPropertySize> _vblRequestedPropertyPropertySize;
        private IRepository<VBLRequestedPropertyPropertyType> _vblRequestedPropertyPropertyType;
        private IRepository<VBLRequestedPropertyPrefferedNeighbourhood> _vblRequestedPropertyPrefferedNeighbourhood;

        private IRepository<VBLRequestedPropertyPrefferedNeighbourhoodDetail>
            _vblRequestedPropertyPrefferedNeighbourhoodDetail;

        private IRepository<VBLRequestedPropertyHeatingType> _vblRequestedPropertyHeatingType;
        private IRepository<VBLRequestedPropertyScheme> _vblRequestedPropertyScheme;
        private IRepository<VBLDocument> _vblDocument;
        private IRepository<VBLCustomerInterest> _vblCustomerInterest;
        private IRepository<Relationship> _relationship;

        private IRepository<tblHOAssessment> _tblHOAssessment;
        private IRepository<tblUserAdmin> _tblUserAdmin;
        private IRepository<lstContactType> _lstContactType;
        private IRepository<lstEthnicity> _lstEthnicity;
        private IRepository<lstApproachReason> _lstApproachReason;
        private IRepository<lstNationalityType> _lstNationalityType;
        private IRepository<lstEligibilityRight> _lstEligibilityRight;
        private IRepository<tblCaseNote> _tblCaseNote;
        private IRepository<lstCaseNoteType> _lstCaseNoteType;
        private IRepository<tsubHOAExclusion> _tsubHOAExclusion;
        private IRepository<lstQuestion> _lstQuestion;
        private IRepository<lstAnswerType> _lstAnswerType;
        private IRepository<tsubHOAQuestionAnswer> _tsubHOAQuestionAnswer;
        private IRepository<tbl_Property> _tblProperties;
        private IRepository<VBLNote> _vblNotes;
        private IRepository<NotInterestedReason> _notInterestedReasons;
        private IRepository<ApplicationCloseReason> _applicationCloseReasons;
        private IRepository<VoidPropertyMatchForApplication> _voidPropertyMatchForApplication;

        private IRepository<ActionCategory> _actionCategories;
        private IRepository<ActionResponsibility> _actionReponsibilities;
        private IRepository<ActionType> _actionTypes;
        private IRepository<RiskCategory> _riskCategories;
        private IRepository<RiskTheme> _riskThemes;
        private IRepository<SuitabilityCheckAction> _actions;
        private IRepository<SuitabilityCheckRisk> _risks;

        private IRepository<SuitabilityNote> _suitabilityNotes;
        private IRepository<SuitabilityNoteType> _suitabilityNoteTypes;
        private IRepository<TransferCheck> _transferChecks;
        private IRepository<VBLIncommunitiesRelationship> _vblIncommunitiesRelationships;

        #endregion private fields
    }
}