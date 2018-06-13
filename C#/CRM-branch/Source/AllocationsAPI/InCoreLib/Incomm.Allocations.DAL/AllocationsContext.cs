using System.Data.Entity;
using System.Data.Entity.SqlServer;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;

namespace InCoreLib.DAL
{
    public class AllocationsContext : TrackedContext
    {
        public AllocationsContext()
            : base("Allocations")
        {
            var dependency = SqlProviderServices.Instance;
            Configuration.LazyLoadingEnabled = false;
        }

        //public AllocationsModel(string connectionString = "name=Allocations")
        //    : base(connectionString)
        //{
        //    var dependency = SqlProviderServices.Instance;
        //    Configuration.LazyLoadingEnabled = false;
        //}

        //public AllocationsModel(DbConnection connection)
        //    : base(connection, true)
        //{
        //    Configuration.LazyLoadingEnabled = false;
        //}
        #region VBL

        public virtual DbSet<AuditVBLIncomeDetails> AuditVBLIncomeDetails { get; set; }

        public virtual DbSet<AuditVblExpenditureDetails> AuditVBLExpenditureDetails { get; set; }

       // public virtual DbSet<VBLAddress> VBLAddresses { get; set; }
        public virtual DbSet<VBLTenantDetail> VBLTenantDetails { get; set; }
        public virtual DbSet<VBLApplication> VBLApplications { get; set; }
        public virtual DbSet<VBLApplicationHistory> VBLApplicationHistories { get; set; }
        public virtual DbSet<VBLContact> VBLContacts { get; set; }
        public virtual DbSet<VBLDocument> VBLDocuments { get; set; }

        public virtual DbSet<ContactBy> ContactBy { get; set; }

        public virtual DbSet<VBLDisabilityType> VBLDisabilityTypes { get; set; }

        public virtual DbSet<VBLIncomeDetail> VBLIncomeDetails { get; set; }

        public virtual DbSet<VBLExpenditureDetail> VBLExpenditureDetails { get; set; }

        public virtual DbSet<VBLIncommunitiesRelationshipType> VBLIncommunitiesRelationshipTypes { get; set; }

        public virtual DbSet<VBLIncommunitiesRelationship> VBLIncommunitiesRelationships { get; set; }

        public virtual DbSet<VBLSupportType> VBLSupportTypes { get; set; }
        public virtual DbSet<VBLCustomerInterest> VBLCustomerInterests { get; set; }
        public virtual DbSet<VBLMutualExchagePropertyDetail> VBLMutualExchagePropertyDetails { get; set; }
        public virtual DbSet<VBLRequestedPropertymatchDetail> VBLRequestedPropertymatchDetails { get; set; }
        public virtual DbSet<VBLMutualExchangeAdaptationDetails> VBLMutualExchangeAdaptationDetails { get; set; }
        public virtual DbSet<VBLRequestedPropertyAdaptationDetails> VBLRequestedPropertyAdaptationDetails { get; set; }
        public virtual DbSet<VBLRequestedPropertyAgeRestriction> VBLRequestedPropertyAgeRestrictions { get; set; }
        public virtual DbSet<VBLRequestedPropertyPropertyType> VBLRequestedPropertyPropertyTypes { get; set; }
        public virtual DbSet<VBLRequestedPropertyPropertySize> VBLRequestedPropertyPropertySizes { get; set; }
        public virtual DbSet<VBLRequestedPropertyPrefferedNeighbourhood> VBLRequestedPropertyPrefferedNeighbourhood { get; set; }
        public virtual DbSet<VBLRequestedPropertyPrefferedNeighbourhoodDetail> VBLRequestedPropertyPrefferedNeighbourhoodDetails { get; set; }
        public virtual DbSet<VBLRequestedPropertyScheme> VBLRequestedPropertySchemes { get; set; }
        public virtual DbSet<VBLRequestedPropertyHeatingType> VBLRequestedPropertyHeatingTypes { get; set; }
        public virtual DbSet<SubNeighbourhood> SubNeighbourhoods { get; set; }
        public virtual DbSet<Scheme> Scheme { get; set; }
        public virtual DbSet<SchemeBlock> SchemeBlock { get; set; }
        public virtual DbSet<VBLTenancySearch> VBLTenancySearch { get; set; }

        public virtual DbSet<VBLNote> VBLNote { get; set; }

        public virtual DbSet<ApplicationCloseReason> ApplicationCLoseReason { get; set; }
        public virtual DbSet<NotInterestedReason> NotInterestedReason { get; set; }

        public virtual DbSet<ActionCategory> ActionCategories { get; set; }

        public virtual DbSet<ActionType> ActionTypes { get; set; }

        public virtual DbSet<ActionResponsibility> ActionResponsibilities { get; set; }

        public virtual DbSet<RiskCategory> RiskCategories { get; set; }

        public virtual DbSet<RiskTheme> RiskThemes { get; set; }

        public virtual DbSet<SuitabilityCheckAction> Actions { get; set; }

        public virtual DbSet<SuitabilityCheckRisk> Risks { get; set; }

        public virtual DbSet<SearchContact> SearchContacts { get; set; }
        #endregion

        #region HRS
        public virtual DbSet<HRSEvictionReason> HRSEvictionReasons { get; set; }

        public virtual DbSet<HRSFloatingSupportServiceEndReason> HRSFloatingSupportServiceEndReasons { get; set; }
        public virtual DbSet<HRSCustomerMoveOption> HRSCustomerMoveOptions { get; set; }

        public virtual DbSet<HRSQuestionAnswer> HRSQuestionAnswers { get; set; }

        public virtual DbSet<Hostel> Hostels { get; set; }

        public virtual DbSet<HRSProvider> HRSProviders { get; set; }

        public virtual DbSet<HRSPlacementMatchedForCustomer> HRSPlacementsMatchedForCustomer { get; set; }

        public virtual DbSet<SupportType> SupportTypes { get; set; }

        public virtual DbSet<ServiceType> PlacementTypes { get; set; }
        public virtual DbSet<HRSPlacement> HrsPlacements { get; set; }
        public virtual DbSet<HRSCustomer> HrsCustomers { get; set; }
        public virtual DbSet<HRSMatchHistory> HrsMatchHistory { get; set; }
        public virtual DbSet<HRSAlert> HrsAlerts { get; set; }
        #endregion

        #region IH
        public virtual DbSet<SuitabilityNote> SuitabilityNotes { get; set; }
        public virtual DbSet<SuitabilityNoteType> SuitabilityNoteTypes { get; set; }
        public virtual DbSet<TransferCheck> TransferChecks { get; set; }
        #endregion

        public virtual DbSet<ApplicantEligibility> ApplicantEligibilities { get; set; }
        public virtual DbSet<ApplicationSelection> ApplicationSelections { get; set; }
        public virtual DbSet<ApplicationStatu> ApplicationStatus { get; set; }
        public virtual DbSet<AuditApplicantEligibility> AuditApplicantEligibilities { get; set; }
        public virtual DbSet<AuditContact> AuditContacts { get; set; }
        public virtual DbSet<AuditContactIncome> AuditContactIncomes { get; set; }
        public virtual DbSet<AuditCustomerApplication> AuditCustomerApplications { get; set; }
        public virtual DbSet<AuditCustomerCircumstance> AuditCustomerCircumstances { get; set; }
        public virtual DbSet<AuditCustomerContactDetail> AuditCustomerContactDetails { get; set; }
        public virtual DbSet<AuditCustomerInterest> AuditCustomerInterests { get; set; }
        public virtual DbSet<AuditCustomerPet> AuditCustomerPets { get; set; }
        public virtual DbSet<AuditCustomerValue> AuditCustomerValues { get; set; }
        public virtual DbSet<AuditMatchResult> AuditMatchResults { get; set; }
        public virtual DbSet<AuditSupportWorker> AuditSupportWorkers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactIncome> ContactIncomes { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<CustomerApplication> CustomerApplications { get; set; }
        public virtual DbSet<CustomerInterest> CustomerInterests { get; set; }
        public virtual DbSet<CustomerInterestStatu> CustomerInterestStatus { get; set; }
        public virtual DbSet<CustomerInterestStatusReason> CustomerInterestStatusReasons { get; set; }
        public virtual DbSet<CustomerNote> CustomerNotes { get; set; }
        public virtual DbSet<CustomerPet> CustomerPets { get; set; }
        public virtual DbSet<Ethnicity> Ethnicities { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<HeatingType> HeatingTypes { get; set; }
        public virtual DbSet<HOAAppointmentLocation> HOAAppointmentLocations { get; set; }
        public virtual DbSet<IncomeFrequency> IncomeFrequencies { get; set; }
        public virtual DbSet<IncomeType> IncomeTypes { get; set; }
        public virtual DbSet<ExpenditureType> ExpenditureTypes { get; set; }
        public virtual DbSet<Landlord> Landlords { get; set; }
        public virtual DbSet<LevelOfNeed> LevelOfNeeds { get; set; }
        public virtual DbSet<lst198213Sources> lst198213Sources { get; set; }
        public virtual DbSet<lstAccommodationType> lstAccommodationTypes { get; set; }
        public virtual DbSet<lstAdviceReason> lstAdviceReasons { get; set; }
        public virtual DbSet<lstAgeGroup> lstAgeGroups { get; set; }
        public virtual DbSet<lstAgeToAgeGroup> lstAgeToAgeGroups { get; set; }
        public virtual DbSet<lstApproachReason> lstApproachReasons { get; set; }
        public virtual DbSet<lstArea> lstAreas { get; set; }
        public virtual DbSet<lstCaseNoteType> lstCaseNoteTypes { get; set; }
        public virtual DbSet<lstCaseStatu> lstCaseStatus { get; set; }
        public virtual DbSet<lstCBLBand> lstCBLBands { get; set; }
        public virtual DbSet<lstContactType> lstContactTypes { get; set; }
        public virtual DbSet<lstEligibilityRight> lstEligibilityRights { get; set; }
        public virtual DbSet<lstEthnicity> lstEthnicities { get; set; }
        public virtual DbSet<lstFamilyComposition> lstFamilyCompositions { get; set; }
        public virtual DbSet<lstFloorLevel> lstFloorLevels { get; set; }
        public virtual DbSet<lstGender> lstGenders { get; set; }
        public virtual DbSet<lstHomelessDecision> lstHomelessDecisions { get; set; }
        public virtual DbSet<lstHomelessnessEligibilityResponse> lstHomelessnessEligibilityResponses { get; set; }
        public virtual DbSet<lstHomelessOutcomeResult> lstHomelessOutcomeResults { get; set; }

        public virtual DbSet<lstHomelessP1eCategoriesHavingTempAccom> lstHomelessP1eCategoriesHavingTempAccom
        {
            get;
            set;
        }

        public virtual DbSet<lstHomelessP1eCategoriesNotHavingTempAccom> lstHomelessP1eCategoriesNotHavingTempAccom
        {
            get; set;
        }

        public virtual DbSet<lstHomelessReason> lstHomelessReasons { get; set; }
        public virtual DbSet<lstHomelessWhereStayingNow> lstHomelessWhereStayingNows { get; set; }
        public virtual DbSet<lstLevelOfNeed> lstLevelOfNeeds { get; set; }
        public virtual DbSet<lstLocalAuthority> lstLocalAuthorities { get; set; }
        public virtual DbSet<lstMaritalStatu> lstMaritalStatus { get; set; }
        public virtual DbSet<lstNationalityType> lstNationalityTypes { get; set; }
        public virtual DbSet<lstNumberBedroom> lstNumberBedrooms { get; set; }
        public virtual DbSet<lstOutcomeCategory> lstOutcomeCategories { get; set; }
        public virtual DbSet<lstOutcomeResult> lstOutcomeResults { get; set; }
        public virtual DbSet<lstPriorityNeedsReason> lstPriorityNeedsReasons { get; set; }
        public virtual DbSet<lstRelationship> lstRelationships { get; set; }
        public virtual DbSet<lstReviewDecOut> lstReviewDecOuts { get; set; }
        public virtual DbSet<lstReviewType> lstReviewTypes { get; set; }
        public virtual DbSet<lstTitle> lstTitles { get; set; }
        public virtual DbSet<lstUserLocation> lstUserLocations { get; set; }
        public virtual DbSet<MatchingHeatingType> MatchingHeatingTypes { get; set; }
        public virtual DbSet<MatchingLocation> MatchingLocations { get; set; }
        public virtual DbSet<MatchingNumBed> MatchingNumBeds { get; set; }
        public virtual DbSet<MatchingPropertyType> MatchingPropertyTypes { get; set; }
        public virtual DbSet<MatchingScheme> MatchingSchemes { get; set; }
        public virtual DbSet<MoveReason> MoveReasons { get; set; }
        public virtual DbSet<NationalityType> NationalityTypes { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PropertyFloorLevel> PropertyFloorLevels { get; set; }
        public virtual DbSet<PropertySize> PropertySizes { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<ResidencyType> ResidencyTypes { get; set; }
        public virtual DbSet<SupportWorker> SupportWorkers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_ActiveManagementAreas> tbl_ActiveManagementAreas { get; set; }
        public virtual DbSet<tbl_Audit_CustomerApplication> tbl_Audit_CustomerApplication { get; set; }
        public virtual DbSet<tbl_AudRejections> tbl_AudRejections { get; set; }
        public virtual DbSet<tbl_CustomerFeedback> tbl_CustomerFeedback { get; set; }
        public virtual DbSet<tbl_LookupData> tbl_LookupData { get; set; }
        public virtual DbSet<tbl_Messages> tbl_Messages { get; set; }
        public virtual DbSet<tbl_Property> tbl_Property { get; set; }
        public virtual DbSet<tbl_PropertyAudit> tbl_PropertyAudit { get; set; }
        public virtual DbSet<tbl_PropertyMigratedAccent> tbl_PropertyMigratedAccent { get; set; }
        public virtual DbSet<tblCaseNote> tblCaseNotes { get; set; }
        public virtual DbSet<tblDependant> tblDependants { get; set; }
        public virtual DbSet<tblEmailSetting> tblEmailSettings { get; set; }
        public virtual DbSet<tblHOAssessment> tblHOAssessments { get; set; }
        public virtual DbSet<tblLinkedTable> tblLinkedTables { get; set; }
        public virtual DbSet<tblPropertyAllocation> tblPropertyAllocations { get; set; }
        public virtual DbSet<tblReception> tblReceptions { get; set; }
        public virtual DbSet<tblRehousedCustomer> tblRehousedCustomers { get; set; }
        public virtual DbSet<tblReportsTemp> tblReportsTemps { get; set; }
        public virtual DbSet<tblTempAccommodation> tblTempAccommodations { get; set; }
        public virtual DbSet<tblUserAdmin> tblUserAdmins { get; set; }
        public virtual DbSet<tblUserChangeRequest> tblUserChangeRequests { get; set; }
        public virtual DbSet<tblUserExtraScanLocn> tblUserExtraScanLocns { get; set; }
        public virtual DbSet<tblUserUpdate> tblUserUpdates { get; set; }
        public virtual DbSet<TenancyType> TenancyTypes { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        public virtual DbSet<tsubRevisit> tsubRevisits { get; set; }
        public virtual DbSet<tsubHomelessnessReview> tsubHomelessnessReviews { get; set; }
        public virtual DbSet<tsubHomelessness> tsubHomelessnesses { get; set; }
        public virtual DbSet<tsubFamilyComposition> tsubFamilyCompositions { get; set; }
        public virtual DbSet<tsubCaseFileLocn> tsubCaseFileLocns { get; set; }

        public virtual DbSet<AuditCustomerInterestStatusReason> AuditCustomerInterestStatusReasons { get; set; }
        public virtual DbSet<AuditMainAddress> AuditMainAddresses { get; set; }
        public virtual DbSet<bkp_CustomerNote_Note_Audit> bkp_CustomerNote_Note_Audit { get; set; }
        public virtual DbSet<CustomerApplication_AL0143> CustomerApplication_AL0143 { get; set; }
        public virtual DbSet<Logo> Logos { get; set; }
        public virtual DbSet<lstAccommodationTypeAudit> lstAccommodationTypeAudits { get; set; }
        public virtual DbSet<lstAccomodationProvider> lstAccomodationProviders { get; set; }
        public virtual DbSet<lstAdviceItem> lstAdviceItems { get; set; }
        public virtual DbSet<lstAdviceItemType> lstAdviceItemTypes { get; set; }
        public virtual DbSet<lstAgeGroupAudit> lstAgeGroupAudits { get; set; }
        public virtual DbSet<lstAgeToAgeGroupAudit> lstAgeToAgeGroupAudits { get; set; }
        public virtual DbSet<lstAnswerType> lstAnswerTypes { get; set; }
        public virtual DbSet<lstApproachReasonAudit> lstApproachReasonAudits { get; set; }
        public virtual DbSet<lstAreaAudit> lstAreaAudits { get; set; }
        public virtual DbSet<lstBnBReason> lstBnBReasons { get; set; }
        public virtual DbSet<lstCallOutcome> lstCallOutcomes { get; set; }
        public virtual DbSet<lstCaseNoteTypeAudit> lstCaseNoteTypeAudits { get; set; }
        public virtual DbSet<lstCaseStatusAudit> lstCaseStatusAudits { get; set; }
        public virtual DbSet<lstCBLBandAudit> lstCBLBandAudits { get; set; }
        public virtual DbSet<lstContactTypeAudit> lstContactTypeAudits { get; set; }
        public virtual DbSet<lstEligibilityRightsAudit> lstEligibilityRightsAudits { get; set; }
        public virtual DbSet<lstEthnicityAudit> lstEthnicityAudits { get; set; }
        public virtual DbSet<lstEvent> lstEvents { get; set; }
        public virtual DbSet<lstFamilyCompositionAudit> lstFamilyCompositionAudits { get; set; }
        public virtual DbSet<lstFloorLevelAudit> lstFloorLevelAudits { get; set; }
        public virtual DbSet<lstGenderAudit> lstGenderAudits { get; set; }
        public virtual DbSet<lstHomelessDecisionAudit> lstHomelessDecisionAudits { get; set; }

        public virtual DbSet<lstHomelessnessEligibilityResponseAudit> lstHomelessnessEligibilityResponseAudits
        {
            get;
            set;
        }

        public virtual DbSet<lstHomelessOutcomeResultAudit> lstHomelessOutcomeResultAudits { get; set; }

        public virtual DbSet<lstHomelessP1eCategoriesHavingTempAccomAudit> lstHomelessP1eCategoriesHavingTempAccomAudit
        { get; set; }

        public virtual DbSet<lstHomelessP1eCategoriesNotHavingTempAccomAudit>
            lstHomelessP1eCategoriesNotHavingTempAccomAudit
        { get; set; }

        public virtual DbSet<lstHomelessReasonAudit> lstHomelessReasonAudits { get; set; }
        public virtual DbSet<lstHomelessWhereStayingNowAudit> lstHomelessWhereStayingNowAudits { get; set; }
        public virtual DbSet<lstLevelOfNeedAudit> lstLevelOfNeedAudits { get; set; }
        public virtual DbSet<lstMaritalStatusAudit> lstMaritalStatusAudits { get; set; }
        public virtual DbSet<lstNationalityTypeAudit> lstNationalityTypeAudits { get; set; }
        public virtual DbSet<lstNumberBedroomsAudit> lstNumberBedroomsAudits { get; set; }
        public virtual DbSet<lstOutcomeCategoryAudit> lstOutcomeCategoryAudits { get; set; }
        public virtual DbSet<lstOutcomeResultAudit> lstOutcomeResultAudits { get; set; }
        public virtual DbSet<lstPlacementReason> lstPlacementReasons { get; set; }
        public virtual DbSet<lstPriorityNeedsReasonAudit> lstPriorityNeedsReasonAudits { get; set; }
        public virtual DbSet<lstQuestion> lstQuestions { get; set; }
        public virtual DbSet<lstQuestionAdviceItem> lstQuestionAdviceItems { get; set; }
        public virtual DbSet<lstQuestionAltText> lstQuestionAltTexts { get; set; }
        public virtual DbSet<lstQuestionChangeType> lstQuestionChangeTypes { get; set; }
        public virtual DbSet<lstQuestionEvent> lstQuestionEvents { get; set; }
        public virtual DbSet<lstQuestionnaire> lstQuestionnaires { get; set; }
        public virtual DbSet<lstQuestionnaireSection> lstQuestionnaireSections { get; set; }
        public virtual DbSet<lstQuestionnaireSubSection> lstQuestionnaireSubSections { get; set; }
        public virtual DbSet<lstRelationshipAudit> lstRelationshipAudits { get; set; }
        public virtual DbSet<lstReviewAgainst> lstReviewAgainsts { get; set; }
        public virtual DbSet<lstRevisitReason> lstRevisitReasons { get; set; }
        public virtual DbSet<lstTACancelReason> lstTACancelReasons { get; set; }
        public virtual DbSet<lstTAPlacementTransType> lstTAPlacementTransTypes { get; set; }
        public virtual DbSet<lstTitleAudit> lstTitleAudits { get; set; }
        public virtual DbSet<lstUserLocationAudit> lstUserLocationAudits { get; set; }
        public virtual DbSet<qrpt_TempAccomodationUse> qrpt_TempAccomodationUse { get; set; }
        public virtual DbSet<tbl_KeyFeature> tbl_KeyFeature { get; set; }
        public virtual DbSet<tblBnBData> tblBnBDatas { get; set; }
        public virtual DbSet<tblBnBDataBK> tblBnBDataBKs { get; set; }
        public virtual DbSet<tblBnBDataBK2> tblBnBDataBK2 { get; set; }
        public virtual DbSet<tblBnBDataSendLog> tblBnBDataSendLogs { get; set; }
        public virtual DbSet<tblCaseNotes_BKDelDel> tblCaseNotes_BKDelDel { get; set; }
        public virtual DbSet<tblCaseNotesAudit> tblCaseNotesAudits { get; set; }
        public virtual DbSet<tblCaseNotesBK> tblCaseNotesBKs { get; set; }
        public virtual DbSet<tblCaseNotesBK2> tblCaseNotesBK2 { get; set; }
        public virtual DbSet<tblCaseNotesWK> tblCaseNotesWKs { get; set; }
        public virtual DbSet<tblDependants_BKDelDel> tblDependants_BKDelDel { get; set; }
        public virtual DbSet<tblDependantsAudit> tblDependantsAudits { get; set; }
        public virtual DbSet<tblErrorMessage> tblErrorMessages { get; set; }
        public virtual DbSet<tblHOAbk> tblHOAbks { get; set; }
        public virtual DbSet<tblHOAbk2> tblHOAbk2 { get; set; }
        public virtual DbSet<tblHOAbk3> tblHOAbk3 { get; set; }
        public virtual DbSet<tblHOAbk4> tblHOAbk4 { get; set; }
        public virtual DbSet<tblHOAssessment_BKDelDel> tblHOAssessment_BKDelDel { get; set; }
        public virtual DbSet<tblHOAssessmentAudit> tblHOAssessmentAudits { get; set; }
        public virtual DbSet<tblHOAssessmentBK_DelDel> tblHOAssessmentBK_DelDel { get; set; }
        public virtual DbSet<tblHOAssessmentbk4> tblHOAssessmentbk4 { get; set; }
        public virtual DbSet<tblLinkedTablesAudit> tblLinkedTablesAudits { get; set; }
        public virtual DbSet<tblPropertyAllocationAudit> tblPropertyAllocationAudits { get; set; }
        public virtual DbSet<tblReceptionAudit> tblReceptionAudits { get; set; }
        public virtual DbSet<tblRehousedCustomersAudit> tblRehousedCustomersAudits { get; set; }
        public virtual DbSet<tblReportsTempAudit> tblReportsTempAudits { get; set; }
        public virtual DbSet<tblSelectedColumn> tblSelectedColumns { get; set; }
        public virtual DbSet<tblTempAccommodation_BKDelDel> tblTempAccommodation_BKDelDel { get; set; }
        public virtual DbSet<tblTempAccommodationAudit> tblTempAccommodationAudits { get; set; }
        public virtual DbSet<tblUserAdminAudit> tblUserAdminAudits { get; set; }
        public virtual DbSet<tblUserAdminbk> tblUserAdminbks { get; set; }
        public virtual DbSet<tsubCheque> tsubCheques { get; set; }
        public virtual DbSet<tsubHOAEvent> tsubHOAEvents { get; set; }
        public virtual DbSet<tsubHOAExclusion> tsubHOAExclusions { get; set; }
        public virtual DbSet<tsubHOAQstnAdviceItem> tsubHOAQstnAdviceItems { get; set; }
        public virtual DbSet<tsubHOAQuestionAnswer> tsubHOAQuestionAnswers { get; set; }
        public virtual DbSet<tsubHomelessness_BKDelDel> tsubHomelessness_BKDelDel { get; set; }
        public virtual DbSet<tsubRevisits_BKDelDel> tsubRevisits_BKDelDel { get; set; }
        public virtual DbSet<tsubTABookingCall> tsubTABookingCalls { get; set; }
        public virtual DbSet<tsubTACancellation> tsubTACancellations { get; set; }
        public virtual DbSet<tsubTACancellationNight> tsubTACancellationNights { get; set; }
        public virtual DbSet<tsubTAPlacement> tsubTAPlacements { get; set; }
        public virtual DbSet<tsubTAPlacementPerson> tsubTAPlacementPersons { get; set; }
        public virtual DbSet<tsubTASuppInvoice> tsubTASuppInvoices { get; set; }
        public virtual DbSet<v_ApplicationMatchCustomerInterests> v_ApplicationMatchCustomerInterests { get; set; }

        public virtual DbSet<v_ApplicationMatchCustomerInterestsVoids> v_ApplicationMatchCustomerInterestsVoids
        {
            get;
            set;
        }

        public virtual DbSet<v_ApplicationMatchFilters> v_ApplicationMatchFilters { get; set; }
        public virtual DbSet<v_Applications> v_Applications { get; set; }
        public virtual DbSet<v_HOAInterface> v_HOAInterface { get; set; }
        public virtual DbSet<v_HOAInterfaceContacts> v_HOAInterfaceContacts { get; set; }
        public virtual DbSet<v_HOAOutcomes> v_HOAOutcomes { get; set; }
        public virtual DbSet<v_HouseholdComposition> v_HouseholdComposition { get; set; }
        public virtual DbSet<v_MutualExchangeProperties> v_MutualExchangeProperties { get; set; }
        public virtual DbSet<v_ShapePostcodes> v_ShapePostcodes { get; set; }
        public virtual DbSet<v_SubNeighbourhood> v_SubNeighbourhood { get; set; }
        public virtual DbSet<v_VBLTenancySearch> v_VBLTenancySearch { get; set; }
        public virtual DbSet<vAdviceEndToEndTime> vAdviceEndToEndTimes { get; set; }
        public virtual DbSet<vCaseStatu> vCaseStatus { get; set; }
        public virtual DbSet<vHomelessEndToEndTime> vHomelessEndToEndTimes { get; set; }
        public virtual DbSet<vInterviewLength> vInterviewLengths { get; set; }
        public virtual DbSet<vOpenAssessment> vOpenAssessments { get; set; }
        public virtual DbSet<vPropertyMatching> vPropertyMatchings { get; set; }
        public virtual DbSet<vReceptionSearch> vReceptionSearches { get; set; }
        public virtual DbSet<vReceptionWaitingTime> vReceptionWaitingTimes { get; set; }
        public virtual DbSet<vWaitingList> vWaitingLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region VBL
            modelBuilder.Entity<VBLApplication>()
               .HasMany(s => s.Contacts)
               .WithRequired(s => s.Application)
               .HasForeignKey(s => s.ApplicationId);

            modelBuilder.Entity<VBLApplication>()
           .HasOptional(t => t.VBLRequestedPropertymatchDetail);

            modelBuilder.Entity<VBLRequestedPropertymatchDetail>()
            .HasRequired(t => t.Application);

            modelBuilder.Entity<VBLMutualExchagePropertyDetail>()
           .HasRequired(t => t.Application);

            modelBuilder.Entity<VBLApplication>()
            .HasOptional(t => t.VblMutualExchagePropertyDetail);

            //modelBuilder.Entity<VBLApplication>()
            //.HasOptional(t => t.Address)
            //.WithOptionalPrincipal()
            //.Map(x => x.MapKey("ApplicationId"));

            //modelBuilder.Entity<VBLAddress>()
            //.HasOptional(t => t.Application)
            //.WithOptionalPrincipal()
            //.Map(x => x.MapKey("AddressId"));


            modelBuilder.Entity<VBLContact>()
                    .HasMany(s => s.IncomeDetails)
                    .WithRequired(s => s.Contact)
                    .HasForeignKey(s => s.ContactId);


            modelBuilder.Entity<VBLContact>()
              .HasMany(u => u.DisabilityTypes)
              .WithMany()
              .Map(m =>
              {
                  m.MapLeftKey("ContactId");
                  m.MapRightKey("DisabilityTypeId");
                  m.ToTable("VBLContactDisabilityTypesLink");
              });

            modelBuilder.Entity<VBLContact>()
           .HasMany(u => u.IncommunitiesRelationshipTypes)
           .WithMany()
           .Map(m =>
           {
               m.MapLeftKey("ContactId");
               m.MapRightKey("IncommunitiesRelationshipTypeId");
               m.ToTable("VBLIncommunitiesRelationshipTypesLink");
           });

            #endregion
            #region HRS

            modelBuilder.Entity<HRSMatchHistory>()
           .HasRequired(t => t.Customer);

            modelBuilder.Entity<HRSMatchHistory>()
            .HasRequired(t => t.Placement);

            //modelBuilder.Entity<VBLAddress>()
            //.HasOptional(t => t.Application)
            //.WithOptionalPrincipal()
            //.Map(x => x.MapKey("AddressId"));
            modelBuilder.Entity<AuditLog>()
                .HasMany(s => s.AuditLogDetails)
                .WithRequired(s => s.AuditLog)
                .HasForeignKey(s => s.AuditLogId);

            modelBuilder.Entity<HRSCustomer>()
                .HasMany(u => u.SupportTypes)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("HRSCustomerId");
                    m.MapRightKey("SupportTypeId");
                    m.ToTable("SupportTypeHRSCustomers");
                });

            modelBuilder.Entity<HRSCustomer>()
                .HasMany(u => u.ServiceTypes)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("HRSCustomerId");
                    m.MapRightKey("ServiceTypeId");
                    m.ToTable("ServiceTypeHRSCustomers");
                });

            modelBuilder.Entity<HRSPlacement>()
                .HasMany(u => u.ServiceTypes)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("HRSPlacementId");
                    m.MapRightKey("ServiceTypeId");
                    m.ToTable("ServiceTypeHRSPlacements");
                });

            modelBuilder.Entity<HRSCustomer>()
                .HasMany(s => s.HRSPlacementsMatched)
                .WithRequired(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);
            #endregion

            modelBuilder.Entity<AuditContactIncome>()
                .Property(e => e.IncomeAmount)
                .HasPrecision(28, 4);

            modelBuilder.Entity<AuditCustomerCircumstance>()
                .Property(e => e.PropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<AuditCustomerCircumstance>()
                .Property(e => e.TenancyCode)
                .IsUnicode(false);

            modelBuilder.Entity<AuditCustomerCircumstance>()
                .Property(e => e.PropertyType)
                .IsUnicode(false);

            modelBuilder.Entity<AuditCustomerCircumstance>()
                .Property(e => e.Rent)
                .HasPrecision(28, 4);

            modelBuilder.Entity<AuditCustomerCircumstance>()
                .Property(e => e.ServiceCharges)
                .HasPrecision(28, 4);

            modelBuilder.Entity<AuditCustomerCircumstance>()
                .Property(e => e.OtherCharges)
                .HasPrecision(28, 4);

            modelBuilder.Entity<AuditCustomerCircumstance>()
                .Property(e => e.AgeCriteria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ContactIncome>()
                .Property(e => e.IncomeAmount)
                .HasPrecision(28, 4);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.MatchingApplicantsAge)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.PropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.TenancyCode)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.PropertyType)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.Rent)
                .HasPrecision(28, 4);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.ServiceCharges)
                .HasPrecision(28, 4);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.OtherCharges)
                .HasPrecision(28, 4);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.AgeCriteria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CustomerApplication>()
                .Property(e => e.MoveReason)
                .IsUnicode(false);

            modelBuilder.Entity<lstAccommodationType>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstAdviceReason>()
                .Property(e => e.AdviceReason)
                .IsFixedLength();

            modelBuilder.Entity<lstAgeGroup>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstAgeToAgeGroup>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstApproachReason>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstArea>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstCaseNoteType>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstCaseStatu>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstCBLBand>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstContactType>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstEligibilityRight>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstEthnicity>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstFamilyComposition>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstFloorLevel>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstGender>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessDecision>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessnessEligibilityResponse>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessOutcomeResult>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessP1eCategoriesHavingTempAccom>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessP1eCategoriesNotHavingTempAccom>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessReason>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessWhereStayingNow>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstLevelOfNeed>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstMaritalStatu>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstNationalityType>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstNumberBedroom>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstOutcomeCategory>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstOutcomeResult>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstPriorityNeedsReason>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstRelationship>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstTitle>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<lstUserLocation>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<MatchingLocation>()
                .Property(e => e.MatchingCode)
                .IsUnicode(false);

            modelBuilder.Entity<MatchingPropertyType>()
                .Property(e => e.MatchingCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Audit_CustomerApplication>()
                .Property(e => e.ChangeType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Audit_CustomerApplication>()
                .Property(e => e.ChangeDate)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Audit_CustomerApplication>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Audit_CustomerApplication>()
                .Property(e => e.FromValue)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Audit_CustomerApplication>()
                .Property(e => e.ToVaue)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Property>()
                .Property(e => e.PropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Property>()
                .Property(e => e.PropertyType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Property>()
                .Property(e => e.AgeCriteria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbl_Property>()
                .Property(e => e.Rent)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_Property>()
                .Property(e => e.ServiceCharge)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_Property>()
                .Property(e => e.OtherCharge)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.PropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.PropertyType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.AgeCriteria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.ChangedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.ChangeType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.Rent)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.ServiceCharge)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_PropertyAudit>()
                .Property(e => e.OtherCharge)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_PropertyMigratedAccent>()
                .Property(e => e.PropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PropertyMigratedAccent>()
                .Property(e => e.PropertyType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PropertyMigratedAccent>()
                .Property(e => e.AgeCriteria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbl_PropertyMigratedAccent>()
                .Property(e => e.Rent)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_PropertyMigratedAccent>()
                .Property(e => e.ServiceCharge)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tbl_PropertyMigratedAccent>()
                .Property(e => e.OtherCharge)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tblCaseNote>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblDependant>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblEmailSetting>()
                .Property(e => e.smtp_Host)
                .IsFixedLength();

            modelBuilder.Entity<tblEmailSetting>()
                .Property(e => e.smtp_User)
                .IsFixedLength();

            modelBuilder.Entity<tblEmailSetting>()
                .Property(e => e.smtp_Password)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAssessment>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblLinkedTable>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblReception>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblTempAccommodation>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblUserAdmin>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblUserChangeRequest>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblUserUpdate>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tsubFamilyComposition>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tsubRevisit>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<bkp_CustomerNote_Note_Audit>()
                .Property(e => e.ChangeType)
                .IsUnicode(false);

            modelBuilder.Entity<bkp_CustomerNote_Note_Audit>()
                .Property(e => e.ChangeDate)
                .IsUnicode(false);

            modelBuilder.Entity<bkp_CustomerNote_Note_Audit>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<bkp_CustomerNote_Note_Audit>()
                .Property(e => e.FromValue)
                .IsUnicode(false);

            modelBuilder.Entity<bkp_CustomerNote_Note_Audit>()
                .Property(e => e.ToVaue)
                .IsUnicode(false);

            modelBuilder.Entity<lstAccommodationTypeAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstAccommodationTypeAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstAgeGroupAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstAgeGroupAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstAgeToAgeGroupAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstAgeToAgeGroupAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstApproachReasonAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstApproachReasonAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstAreaAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstAreaAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstCaseNoteTypeAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstCaseNoteTypeAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstCaseStatusAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstCaseStatusAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstCBLBandAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstCBLBandAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstContactTypeAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstContactTypeAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstEligibilityRightsAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstEligibilityRightsAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstEthnicityAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstEthnicityAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstFamilyCompositionAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstFamilyCompositionAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstFloorLevelAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstFloorLevelAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstGenderAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstGenderAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessDecisionAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessDecisionAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessnessEligibilityResponseAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessnessEligibilityResponseAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessOutcomeResultAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessOutcomeResultAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessP1eCategoriesHavingTempAccomAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessP1eCategoriesHavingTempAccomAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessP1eCategoriesNotHavingTempAccomAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessP1eCategoriesNotHavingTempAccomAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessReasonAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessReasonAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessWhereStayingNowAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstHomelessWhereStayingNowAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstLevelOfNeedAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstLevelOfNeedAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstMaritalStatusAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstMaritalStatusAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstNationalityTypeAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstNationalityTypeAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstNumberBedroomsAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstNumberBedroomsAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstOutcomeCategoryAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstOutcomeCategoryAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstOutcomeResultAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstOutcomeResultAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstPriorityNeedsReasonAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstPriorityNeedsReasonAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstRelationshipAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstRelationshipAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstTitleAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstTitleAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<lstUserLocationAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<lstUserLocationAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblCaseNotes_BKDelDel>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblCaseNotesAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblCaseNotesAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblCaseNotesBK>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblCaseNotesBK2>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblCaseNotesWK>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblDependants_BKDelDel>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblDependantsAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblDependantsAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAbk>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAbk2>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAbk3>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAbk4>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAssessment_BKDelDel>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAssessmentAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAssessmentAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAssessmentBK_DelDel>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblHOAssessmentbk4>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblLinkedTablesAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblLinkedTablesAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblPropertyAllocationAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblPropertyAllocationAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblReceptionAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblReceptionAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblRehousedCustomersAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblRehousedCustomersAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblReportsTempAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblReportsTempAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblTempAccommodation_BKDelDel>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tblTempAccommodationAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblTempAccommodationAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblUserAdminAudit>()
                .Property(e => e.RevisionUserId)
                .IsFixedLength();

            modelBuilder.Entity<tblUserAdminAudit>()
                .Property(e => e.AuditAction)
                .IsFixedLength();

            modelBuilder.Entity<tblUserAdminbk>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<tsubCheque>()
                .Property(e => e.RefNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tsubCheque>()
                .Property(e => e.ChequeNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tsubCheque>()
                .Property(e => e.AccountNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tsubRevisits_BKDelDel>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<v_Applications>()
                .Property(e => e.MatchingApplicantsAge)
                .HasPrecision(10, 2);

            modelBuilder.Entity<v_Applications>()
                .Property(e => e.MutualExchangePropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<v_HOAInterface>()
                .Property(e => e.MoveReason)
                .IsUnicode(false);

            modelBuilder.Entity<v_HOAInterfaceContacts>()
                .Property(e => e.MoveReason)
                .IsUnicode(false);

            modelBuilder.Entity<v_HouseholdComposition>()
                .Property(e => e.HouseholdComposition)
                .IsUnicode(false);

            modelBuilder.Entity<v_HouseholdComposition>()
                .Property(e => e.ApplicantAgeBand)
                .IsUnicode(false);

            modelBuilder.Entity<v_HouseholdComposition>()
                .Property(e => e.TenureBand)
                .IsUnicode(false);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.PropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.AgeCriteria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.PropertyType)
                .IsUnicode(false);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.SubNeighbourhoodCode)
                .IsUnicode(false);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.Rent)
                .HasPrecision(28, 4);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.ServiceCharges)
                .HasPrecision(28, 4);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.OtherCharges)
                .HasPrecision(28, 4);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.TotalRent)
                .HasPrecision(30, 4);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.MatchingApplicantsAge)
                .HasPrecision(10, 2);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.PaymentCycle)
                .IsUnicode(false);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.MarketingInformationWeb)
                .IsUnicode(false);

            modelBuilder.Entity<v_MutualExchangeProperties>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<v_SubNeighbourhood>()
                .Property(e => e.SubNeighbourhoodCodeComb)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.PropertyCode)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.Address4)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.Postcode)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.AgeCriteria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.PetsAllowed)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.IBSTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.IBSCatCode)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.Forename)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.TenancyRef)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.TenantCode)
                .IsUnicode(false);

            modelBuilder.Entity<v_VBLTenancySearch>()
                .Property(e => e.TenancyType)
                .IsUnicode(false);

            modelBuilder.Entity<vReceptionWaitingTime>()
                .Property(e => e.ReceptionDay)
                .IsUnicode(false);
        }
    }
}