using System;
using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;
using InCoreLib.Domain.StoreProcedure;

namespace InCoreLib.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<SearchContact> SearchContacts();
        IRepository<CustomerInterestStatu> CustomerInterestStatus();
        IRepository<ServiceType> ServiceType();

        IRepository<HRSPlacement> Placement();

        IRepository<HRSPlacementMatchedForCustomer> HRSPlacementMatchedForCustomer();

        IRepository<SupportType> SupportType();

        IRepository<HRSAlert> HRSAlert();

        IRepository<tsubHOAEvent> tsubHOAEvent();

        IRepository<HRSCustomer> HRSCustomer();

        IRepository<Gender> Genders();

        IRepository<Title> Titles();

        IRepository<Contact> Contacts();

        IRepository<tblCaseNote> CaseNotes();

        IRepository<CustomerInterest> CustomerInterests();

        IRepository<CustomerInterestStatusReason> CustomerInterestStatusReasons();

        IRepository<Hostel> Hostel();

        IRepository<HRSProvider> HRSProvider();

        IRepository<HRSMatchHistory> HRSMatchHistory();

        IList<HOAQuestionsAndAnswers> GetHOAQuestionsAndAnswers(int hoaCaseId);

        IRepository<lstQuestion> Questions();

        IRepository<HRSEvictionReason> HRSEvictionReasons();
        IRepository<HRSFloatingSupportServiceEndReason> HRSFloatingSupportServiceEndReasons();

        IRepository<HRSCustomerMoveOption> HRSCustomerMoveOptions();

        IRepository<HRSQuestionAnswer> HRSQuestionAnswers();

        void Commit(string userId = "", string userIPAddress = "");

        IRepository<AuditLog> AuditLogs();

        IRepository<VBLApplication> VBLApplications();
        IRepository<VBLApplicationHistory> VBLApplicationHistory();

        IRepository<VBLContact> VBLContacts();

        IRepository<NationalityType> NationalityTypes();

        IRepository<Ethnicity> Ethnicities();

        IRepository<PreferredLanguage> PreferredLanguages();

        IRepository<ContactBy> ContactBy();

        IRepository<IncomeType> IncomeTypes();

        IRepository<ExpenditureType> ExpenditureTypes();

        IRepository<IncomeFrequency> IncomeFrequencies();

        IRepository<VBLDisabilityType> DisabilityTypes();

        IRepository<VBLDisabilityDetails> DisabilityDetails();

        //IRepository<VBLAddress> VBLAddresses();

        IRepository<VBLIncomeDetail> VBLIncomeDetails();

        IRepository<VBLExpenditureDetail> VBLExpenditureDetails();

        IRepository<AuditVBLIncomeDetails> AuditVBLIncomeDetails();

        IRepository<AuditVblExpenditureDetails> AuditVBLExpenditureDetails();

        IRepository<VBLSupportType> VBLSupportTypes();

        IRepository<VBLReceivingSupportDetails> VBLReceivingSupportDetails();
        IRepository<VBLRequestedSupportDetails> VBLRequestedSupportDetails();

        //IRepository<VBLContactByDetails> VBLContactByDetails();

        IRepository<VBLSupportContactByDetails> VBLSupportContactByDetails();

        IRepository<VBLSupportProvider> VBLSupportProviders();
        IRepository<ResidencyType> ResidencyTypes();
        IRepository<TenancyType> TenancyTypes();
        IRepository<VBLTenantDetail> TenantDetails();
        IRepository<PropertyType> PropertyTypes();
        IRepository<Landlord> Landlords();
        IRepository<MoveReason> MoveReasons();
        IRepository<LevelOfNeed> LeveOfNeeds();
        IRepository<PropertySize> PropertySize();
        IRepository<PropertyEntranceType> PropertyEntranceTypes();
        IRepository<PropertyBlockType> PropertyBlockTypes();
        IRepository<Adaptation> Adaptations();
        IRepository<VBLMutualExchangeAdaptationDetails> MutualExchangeAdaptationDetails();
        IRepository<VBLMutualExchagePropertyDetail> VblMutualExchagePropertyDetail();
        IRepository<VBLRequestedPropertyAdaptationDetails> RequestedPropertyAdaptationDetails();
        IRepository<VBLRequestedPropertyAgeRestriction> RequestedPropertyAgeRestriction();
        IRepository<VBLRequestedPropertyPropertySize> RequestedPropertyPropertySize();
        IRepository<VBLRequestedPropertyPropertyType> RequestedPropertyPropertyType();
        IRepository<VBLRequestedPropertyHeatingType> RequestedPropertyHeatingType();
        IRepository<VBLRequestedPropertyPrefferedNeighbourhood> RequestedPropertyPrefferedNeighbourhood();
        IRepository<VBLRequestedPropertyPrefferedNeighbourhoodDetail> RequestedPropertyPrefferedNeighbourhoodDetail();
        IRepository<VBLRequestedPropertyScheme> RequestedPropertyScheme();
        IRepository<AgeRestriction> AgeRestrictions();
        IRepository<VBLTenancySearch> VBLTenancySearches();
        IRepository<HeatingType> HeatingTypes();
        IRepository<VBLRequestedPropertymatchDetail> VBLRequestedPropertymatchDetail();
        IRepository<VBLDocument> VBLDocuments();
        IRepository<VBLCustomerInterest> VBLCustomerInterests();
        IRepository<tblHOAssessment> TblHOAssessments();
        IRepository<tblUserAdmin> TblUserAdmins();
        IRepository<lstContactType> LstContactTypes();
        IRepository<lstEthnicity> LstEthnicities();
        IRepository<lstApproachReason> LstApproachReasons();
        IRepository<lstNationalityType> LstNationalityTypes();
        IRepository<lstEligibilityRight> LstEligibilityRights();
        IRepository<tblCaseNote> TblCaseNotes();
        IRepository<lstCaseNoteType> LstCaseNoteTypes();
        IRepository<tsubHOAExclusion> TsubHOAExclusions();
        IRepository<lstQuestion> LstQuestions();
        IRepository<lstAnswerType> LstAnswerTypes();
        IRepository<tsubHOAQuestionAnswer> TsubHOAQuestionAnswers();
        IRepository<Relationship> Relationships();

        IRepository<tbl_Property> tblProperties();
        IRepository<VBLNote> VBLNotes();
        IRepository<ApplicationCloseReason> ApplicationCloseReasons();
        IRepository<NotInterestedReason> NotInterestedReasons();

        IList<VoidPropertyMatchForApplication> VoidPropertyMatchForApplication(int applicationId);

        VoidPropertyMatchForApplication GetPropertyDetails(string propertyCode);
        VoidPropertyMatchForApplication GetPropertyDetails(string propertyCode, int landlordId);
        List<VBLPropertyShopDTO> GetPropertyDetailsByPropertyCodeList(List<SearchPropertyDTO> searchPropertyList);
        void CreateSuitabilityCheckTask(VBLCustomerInterestDTO customerInterest);
        List<VoidPropertyMatchForApplication> GetVoidPropertyAvailableForRent();



        IRepository<ActionCategory> ActionCategories();

        IRepository<ActionResponsibility> ActionResponsibilities();

        IRepository<ActionType> ActionTypes();

        IRepository<RiskCategory> RiskCategories();

        IRepository<RiskTheme> RiskThemes();

        IRepository<SuitabilityCheckAction> Actions();

        IRepository<SuitabilityCheckRisk> Risks();
        IRepository<SuitabilityNote> SuitabilityNotes();
        IRepository<SuitabilityNoteType> SuitabilityNoteTypes();
        IRepository<VBLIncommunitiesRelationship> VBLIncommunitiesRelationships();
        void CreateMutexTask(MutualExchangeDTO mutexNotification);
        IRepository<TransferCheck> TransferChecks();
    }
}