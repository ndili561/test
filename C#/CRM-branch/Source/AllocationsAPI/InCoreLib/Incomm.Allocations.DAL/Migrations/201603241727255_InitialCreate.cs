namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantEligibility",
                c => new
                {
                    ApplicantEligibilityId = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(nullable: false),
                    ContactId = c.Int(nullable: false),
                    IsSubjectToImmigrationControl = c.Boolean(),
                    IsReturnedToUKInLast5Years = c.Boolean(),
                    WhenEnteredInUk = c.DateTime(),
                    IsEligibleToClaimPublicFunds = c.Boolean(),
                    LastUpdatedUserName = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.ApplicantEligibilityId);

            CreateTable(
                "dbo.ApplicationSelections",
                c => new
                {
                    SessionID = c.String(nullable: false, maxLength: 255),
                    SelectionID = c.Int(nullable: false),
                    SelectedLocations = c.String(nullable: false, maxLength: 255),
                    Created = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.SessionID);

            CreateTable(
                "dbo.ApplicationStatus",
                c => new
                {
                    ApplicationStatusID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                    StatusIsOpen = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ApplicationStatusID);

            CreateTable(
                "dbo.AuditApplicantEligibility",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    ApplicantEligibilityId = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    ContactId = c.Int(nullable: false),
                    IsSubjectToImmigrationControl = c.Boolean(),
                    IsReturnedToUKInLast5Years = c.Boolean(),
                    WhenEnteredInUk = c.DateTime(),
                    IsEligibleToClaimPublicFunds = c.Boolean(),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.AuditID, t.ApplicantEligibilityId });

            CreateTable(
                "dbo.AuditContactIncome",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    ContactIncomeID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    ContactID = c.Int(nullable: false),
                    IncomeTypeID = c.Int(nullable: false),
                    IncomeAmount = c.Decimal(nullable: false, precision: 28, scale: 4, storeType: "numeric"),
                    IncomeFrequencyID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.AuditID, t.ContactIncomeID });

            CreateTable(
                "dbo.AuditContact",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    ContactID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    ContactTypeID = c.Int(nullable: false),
                    TitleId = c.Int(nullable: false),
                    Forename = c.String(nullable: false, maxLength: 50),
                    Surname = c.String(nullable: false, maxLength: 50),
                    LivedInUkForFiveYears = c.Boolean(nullable: false),
                    DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                    NationalityID = c.Int(nullable: false),
                    IsMovingIn = c.Boolean(nullable: false),
                    GenderID = c.Int(nullable: false),
                    RelationshipID = c.Int(nullable: false),
                    IsPregnant = c.Boolean(nullable: false),
                    PregnancyDueDate = c.DateTime(storeType: "date"),
                    Active = c.Boolean(nullable: false),
                    IsDisabled = c.Boolean(nullable: false),
                    DisabledDetails = c.String(nullable: false),
                    IsWheelChairUser = c.Boolean(nullable: false),
                    UsesWheelChairInside = c.Boolean(nullable: false),
                    HasIncommunitiesRelationship = c.Boolean(nullable: false),
                    IncommunitiesRelationshipDescription = c.String(nullable: false, maxLength: 1000),
                    EthnicityId = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.AuditID, t.ContactID });

            CreateTable(
                "dbo.AuditCustomerApplication",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    CustomerApplicationId = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                    ApplicationStatusID = c.Int(nullable: false),
                    ApplicationStatusReason = c.String(maxLength: 1000),
                    ApplicationDate = c.DateTime(nullable: false),
                    ApplicationEligable = c.Boolean(),
                    HOALevelOfNeedDate = c.DateTime(),
                    ApplicationLevelOfNeedID = c.Int(),
                    HOACaseRef = c.Int(),
                    HOAOutcome = c.String(maxLength: 1000),
                    HOAOutcomeDate = c.DateTime(),
                    HOACaseIsOpen = c.Boolean(),
                    HOAEligabilitySet = c.Boolean(),
                    ApplicationClosedDate = c.DateTime(),
                    DataProtectionIsPrinted = c.Boolean(),
                    DataProtectionIsSigned = c.Boolean(),
                    DataProtectionConsented = c.Boolean(),
                    IsSignedDeclarationUploaded = c.Boolean(),
                })
                .PrimaryKey(t => new { t.AuditID, t.CustomerApplicationId });

            CreateTable(
                "dbo.AuditCustomerCircumstances",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                    LivedAtAddress = c.Int(),
                    LivedAtAddressMonths = c.Int(),
                    ResidencyTypeCode = c.String(maxLength: 50),
                    LandLordName = c.String(maxLength: 255),
                    MoveReasonID = c.Int(),
                    RecievingSupport = c.Boolean(),
                    RequiresSupport = c.Boolean(),
                    SupportRequiredFor = c.String(maxLength: 1000),
                    TenancyTypeCode = c.String(maxLength: 50),
                    LandLordCode = c.String(maxLength: 50),
                    IncomesComments = c.String(maxLength: 1000),
                    HasIncome = c.Boolean(),
                    MainTenantOnTenancy = c.Boolean(),
                    LeaveVacantProperty = c.Boolean(),
                    PropertyCode = c.String(maxLength: 50, unicode: false),
                    TenancyCode = c.String(maxLength: 50, unicode: false),
                    PropertyType = c.String(maxLength: 20, unicode: false),
                    Rent = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    ServiceCharges = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    OtherCharges = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    PropertyNumBedrooms = c.Int(),
                    AgeCriteria = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    HeatingType = c.String(maxLength: 50),
                    FlatFloorLevel = c.Int(),
                    HasStepsToAccess = c.Boolean(),
                    NumStepsToAccess = c.Int(),
                    HasGarden = c.Boolean(),
                    HasLift = c.Boolean(),
                    HasTrustcare = c.Boolean(),
                    IsWheelChairAdapted = c.Boolean(),
                    HasRampedAccess = c.Boolean(),
                    IsLevelAccessProperty = c.Boolean(),
                    HasStairlift = c.Boolean(),
                    HasWalkInShower = c.Boolean(),
                    HasStepInShower = c.Boolean(),
                    LivingAddress1 = c.String(maxLength: 255),
                    LivingAddress2 = c.String(maxLength: 255),
                    LivingAddress3 = c.String(maxLength: 255),
                    LivingAddress4 = c.String(maxLength: 255),
                    LivingPostCode = c.String(maxLength: 16),
                    LivedAtAddressDays = c.Int(),
                })
                .PrimaryKey(t => new { t.AuditID, t.CustomerApplicationID });

            CreateTable(
                "dbo.AuditCustomerContactDetails",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                    TelNum = c.String(maxLength: 25),
                    ContactByPhone = c.Boolean(),
                    MobileNum = c.String(maxLength: 25),
                    ContactByMobile = c.Boolean(),
                    ContactByMobileText = c.Boolean(),
                    Email = c.String(maxLength: 255),
                    ContactByEmail = c.Boolean(),
                    ContactByMail = c.Boolean(),
                    WillVisitTheOffices = c.Boolean(),
                    ContactAddress1 = c.String(maxLength: 255),
                    ContactAddress2 = c.String(maxLength: 255),
                    ContactAddress3 = c.String(maxLength: 255),
                    ContactAddress4 = c.String(maxLength: 255),
                    ContactPostCode = c.String(maxLength: 16),
                })
                .PrimaryKey(t => new { t.AuditID, t.CustomerApplicationID });

            CreateTable(
                "dbo.AuditCustomerInterest",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    CustomerInterestID = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                    CustomerApplicationID = c.Int(nullable: false),
                    PropertyCode = c.String(nullable: false, maxLength: 50),
                    CustomerInterestStatusID = c.Int(nullable: false),
                    CustomerInterestStatusReasonsID = c.Int(nullable: false),
                    VoidContactID = c.Int(),
                })
                .PrimaryKey(t => new { t.AuditID, t.CustomerInterestID });

            CreateTable(
                "dbo.AuditCustomerInterestStatusReasons",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    CustomerInterestStatusReasonsID = c.Int(nullable: false),
                    StatusReasonsDate = c.DateTime(nullable: false),
                    CustomerInterestID = c.Int(nullable: false),
                    CustomerInterestStatusID = c.Int(nullable: false),
                    CustomerDecision = c.Boolean(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    OutcomeNotes = c.String(maxLength: 1000),
                    ActivityID = c.Int(),
                    ChangeType = c.String(maxLength: 100),
                    HasNotes = c.Boolean(),
                    Notes = c.String(maxLength: 1000),
                })
                .PrimaryKey(t => new { t.AuditID, t.CustomerInterestStatusReasonsID, t.StatusReasonsDate, t.CustomerInterestID, t.CustomerInterestStatusID, t.CustomerDecision, t.UserName, t.ChangeDate });

            CreateTable(
                "dbo.AuditCustomerPet",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    PetId = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    NumberOfPet = c.Int(nullable: false),
                    PetIsMoving = c.Boolean(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.AuditID, t.PetId, t.CustomerApplicationID });

            CreateTable(
                "dbo.AuditCustomerValues",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                    MatchingPropertyTypes = c.String(maxLength: 255),
                    MatchingNumBedrooms = c.String(maxLength: 255),
                    MatchingLocations = c.String(maxLength: 500),
                    MatchingSchemes = c.String(maxLength: 255),
                    MatchingHeatingTypes = c.String(maxLength: 255),
                    MatchingEarliestMoveDate = c.DateTime(storeType: "date"),
                    MatchingLatestMoveDate = c.DateTime(storeType: "date"),
                    MatchToMutualExhanges = c.Boolean(),
                    MatchingFloorlevel = c.Int(),
                    MatchingLiftServed = c.Boolean(),
                    MatchingTrustCare = c.Boolean(),
                    MatchingSheltered = c.Boolean(),
                    MatchingGarden = c.Boolean(),
                    MatchingWheelChairAdapted = c.Boolean(),
                    MatchingRampedAccess = c.Boolean(),
                    MatchingLevelAccessProperty = c.Boolean(),
                    MatchingStairlift = c.Boolean(),
                    MatchingWalkInShower = c.Boolean(),
                    MatchingStepInShower = c.Boolean(),
                    MatchingPropertyTypesNames = c.String(maxLength: 1000),
                    MatchingNumBedroomsNames = c.String(maxLength: 1000),
                    MatchingLocationsNames = c.String(maxLength: 1000),
                    MatchingSchemesNames = c.String(maxLength: 1000),
                    MatchingHeatingTypesNames = c.String(maxLength: 1000),
                    URIReferrer = c.String(maxLength: 500),
                })
                .PrimaryKey(t => new { t.AuditID, t.CustomerApplicationID });

            CreateTable(
                "dbo.AuditLogDetails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ColumnName = c.String(),
                    OriginalValue = c.String(),
                    NewValue = c.String(),
                    AuditLogId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLogs", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);

            CreateTable(
                "dbo.AuditLogs",
                c => new
                {
                    AuditLogId = c.Int(nullable: false, identity: true),
                    UserName = c.String(),
                    UserIPAddress = c.String(),
                    AuditDescription = c.String(),
                    EventDateUTC = c.DateTime(nullable: false),
                    EventType = c.Int(nullable: false),
                    TableName = c.String(),
                    RecordId = c.String(),
                })
                .PrimaryKey(t => t.AuditLogId);

            CreateTable(
                "dbo.AuditMainAddress",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    CustomerApplicationID = c.Int(),
                    Address1 = c.String(maxLength: 255),
                    Address2 = c.String(maxLength: 255),
                    Address3 = c.String(maxLength: 255),
                    Address4 = c.String(maxLength: 255),
                    PostCode = c.String(maxLength: 16),
                    ChangeType = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.AuditID, t.UserName, t.ChangeDate });

            CreateTable(
                "dbo.AuditMatchResults",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(),
                    ApplicationLevelOfNeedID = c.Int(),
                    ApplicationDate = c.DateTime(),
                    PropertyRef = c.String(maxLength: 50),
                    MatchPass = c.Int(),
                    dtStamp = c.DateTime(),
                    whoBy = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.AuditSupportWorker",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    SupportWorkerID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    SupportWorkerReason = c.String(nullable: false, maxLength: 1000),
                    SupportWorkerName = c.String(nullable: false, maxLength: 100),
                    SupportWorkerContact = c.String(nullable: false, maxLength: 255),
                    Active = c.Boolean(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    ChangeDate = c.DateTime(nullable: false),
                    ChangeType = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.AuditID, t.SupportWorkerID });

            CreateTable(
                "dbo.bkp_CustomerNote_Note_Audit",
                c => new
                {
                    AuditID = c.Int(nullable: false),
                    Username = c.String(nullable: false, maxLength: 128),
                    CustomerApplicationId = c.Int(),
                    ChangeType = c.String(maxLength: 10, unicode: false),
                    ChangeDate = c.String(maxLength: 30, unicode: false),
                    FieldName = c.String(maxLength: 500, unicode: false),
                    FromValue = c.String(maxLength: 4000, unicode: false),
                    ToVaue = c.String(maxLength: 4000, unicode: false),
                })
                .PrimaryKey(t => new { t.AuditID, t.Username });

            CreateTable(
                "dbo.ContactIncome",
                c => new
                {
                    ContactIncomeID = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(nullable: false),
                    ContactID = c.Int(nullable: false),
                    IncomeTypeID = c.Int(nullable: false),
                    IncomeAmount = c.Decimal(nullable: false, precision: 28, scale: 4, storeType: "numeric"),
                    IncomeFrequencyID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    LastUpdatedUserName = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.ContactIncomeID);

            CreateTable(
                "dbo.Contact",
                c => new
                {
                    ContactID = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(nullable: false),
                    ContactTypeID = c.Int(nullable: false),
                    TitleId = c.Int(nullable: false),
                    Forename = c.String(nullable: false, maxLength: 50),
                    Surname = c.String(nullable: false, maxLength: 50),
                    LivedInUkForFiveYears = c.Boolean(nullable: false),
                    DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                    NationalityID = c.Int(nullable: false),
                    IsMovingIn = c.Boolean(nullable: false),
                    GenderID = c.Int(nullable: false),
                    RelationshipID = c.Int(nullable: false),
                    IsPregnant = c.Boolean(nullable: false),
                    PregnancyDueDate = c.DateTime(storeType: "date"),
                    Active = c.Boolean(nullable: false),
                    IsDisabled = c.Boolean(nullable: false),
                    DisabledDetails = c.String(nullable: false),
                    IsWheelChairUser = c.Boolean(nullable: false),
                    UsesWheelChairInside = c.Boolean(nullable: false),
                    HasIncommunitiesRelationship = c.Boolean(nullable: false),
                    IncommunitiesRelationshipDescription = c.String(nullable: false, maxLength: 1000),
                    EthnicityId = c.Int(nullable: false),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    MainTenant = c.Boolean(),
                    TitleName = c.String(maxLength: 20),
                    GenderName = c.String(maxLength: 20),
                    RelationshipName = c.String(maxLength: 20),
                    NationalityTypeName = c.String(maxLength: 50),
                    EthnicityCode = c.String(maxLength: 50),
                    IsIncommunitiesTenant = c.Boolean(),
                })
                .PrimaryKey(t => t.ContactID);

            CreateTable(
                "dbo.ContactType",
                c => new
                {
                    ContactTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 100),
                    Active = c.Boolean(),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.ContactTypeId);

            CreateTable(
                "dbo.CustomerApplication_AL0143",
                c => new
                {
                    CustomerApplicationId = c.Int(nullable: false),
                    ApplicationDate = c.DateTime(nullable: false),
                    DateTimeUpdated = c.DateTime(name: "DateTime Updated", nullable: false),
                    OldMoveDate = c.DateTime(name: "Old Move Date", storeType: "date"),
                    NewMoveDate = c.DateTime(name: "New Move Date", storeType: "date"),
                })
                .PrimaryKey(t => new { t.CustomerApplicationId, t.ApplicationDate, t.DateTimeUpdated });

            CreateTable(
                "dbo.CustomerApplication",
                c => new
                {
                    CustomerApplicationId = c.Int(nullable: false, identity: true),
                    ApplicationStatusID = c.Int(nullable: false),
                    ApplicationStatusReason = c.String(maxLength: 1000),
                    ApplicationDate = c.DateTime(nullable: false),
                    ApplicationEligable = c.Boolean(),
                    HOALevelOfNeedDate = c.DateTime(),
                    ApplicationLevelOfNeedID = c.Int(),
                    DataProtectionIsPrinted = c.Boolean(),
                    DataProtectionIsSigned = c.Boolean(),
                    DataProtectionConsented = c.Boolean(),
                    HOACaseRef = c.Int(),
                    HOAOutcome = c.String(maxLength: 1000),
                    HOAOutcomeDate = c.DateTime(),
                    HOACaseIsOpen = c.Boolean(),
                    HOAEligabilitySet = c.Boolean(),
                    HOAAppointmentActivityID = c.Int(),
                    HOAAppointmentScheduledStart = c.DateTime(),
                    HOAAppointmentStatusID = c.Int(),
                    HOAAppointmentIsAssessor = c.Boolean(),
                    VBLSatisfationActivityID = c.Int(),
                    ApplicationClosedDate = c.DateTime(),
                    MatchingPropertyTypes = c.String(maxLength: 255),
                    MatchingNumBedrooms = c.String(maxLength: 255),
                    MatchingLocations = c.String(maxLength: 500),
                    MatchingSchemes = c.String(maxLength: 255),
                    MatchingHeatingTypes = c.String(maxLength: 255),
                    MatchingEarliestMoveDate = c.DateTime(storeType: "date"),
                    MatchingLatestMoveDate = c.DateTime(storeType: "date"),
                    MatchingApplicantsAge = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    ApplicantsUnderEighteen = c.Boolean(),
                    MatchToMutualExhanges = c.Boolean(),
                    MatchingFloorlevel = c.Int(),
                    MatchingLiftServed = c.Boolean(),
                    MatchingTrustCare = c.Boolean(),
                    MatchingSheltered = c.Boolean(),
                    MatchingGarden = c.Boolean(),
                    MatchingWheelChairAdapted = c.Boolean(),
                    MatchingRampedAccess = c.Boolean(),
                    MatchingLevelAccessProperty = c.Boolean(),
                    MatchingStairlift = c.Boolean(),
                    MatchingWalkInShower = c.Boolean(),
                    MatchingStepInShower = c.Boolean(),
                    MatchingPropertyTypesNames = c.String(maxLength: 1000),
                    MatchingNumBedroomsNames = c.String(maxLength: 1000),
                    MatchingLocationsNames = c.String(maxLength: 1000),
                    MatchingSchemesNames = c.String(maxLength: 1000),
                    MatchingHeatingTypesNames = c.String(maxLength: 1000),
                    URIReferrer = c.String(maxLength: 500),
                    LivedAtAddress = c.Int(),
                    LivedAtAddressMonths = c.Int(),
                    ResidencyTypeCode = c.String(maxLength: 50),
                    LandLordName = c.String(maxLength: 255),
                    MoveReasonID = c.Int(),
                    RecievingSupport = c.Boolean(),
                    RequiresSupport = c.Boolean(),
                    SupportRequiredFor = c.String(maxLength: 1000),
                    TenancyTypeCode = c.String(maxLength: 50),
                    LandLordCode = c.String(maxLength: 50),
                    IncomesComments = c.String(maxLength: 1000),
                    HasIncome = c.Boolean(),
                    MainTenantOnTenancy = c.Boolean(),
                    LeaveVacantProperty = c.Boolean(),
                    PropertyCode = c.String(maxLength: 50, unicode: false),
                    TenancyCode = c.String(maxLength: 50, unicode: false),
                    PropertyisTerminating = c.Boolean(),
                    PropertyType = c.String(maxLength: 20, unicode: false),
                    Rent = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    ServiceCharges = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    OtherCharges = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    PropertyNumBedrooms = c.Int(),
                    AgeCriteria = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    HeatingType = c.String(maxLength: 50),
                    FlatFloorLevel = c.Int(),
                    HasStepsToAccess = c.Boolean(),
                    NumStepsToAccess = c.Int(),
                    HasGarden = c.Boolean(),
                    HasLift = c.Boolean(),
                    HasTrustcare = c.Boolean(),
                    IsWheelChairAdapted = c.Boolean(),
                    HasRampedAccess = c.Boolean(),
                    IsLevelAccessProperty = c.Boolean(),
                    HasStairlift = c.Boolean(),
                    HasWalkInShower = c.Boolean(),
                    HasStepInShower = c.Boolean(),
                    MoveReason = c.String(maxLength: 255, unicode: false),
                    TelNum = c.String(maxLength: 25),
                    ContactByPhone = c.Boolean(),
                    MobileNum = c.String(maxLength: 25),
                    ContactByMobile = c.Boolean(),
                    ContactByMobileText = c.Boolean(),
                    Email = c.String(maxLength: 255),
                    ContactByEmail = c.Boolean(),
                    ContactByMail = c.Boolean(),
                    WillVisitTheOffices = c.Boolean(),
                    MainAddress1 = c.String(maxLength: 255),
                    MainAddress2 = c.String(maxLength: 255),
                    MainAddress3 = c.String(maxLength: 255),
                    MainAddress4 = c.String(maxLength: 255),
                    MainPostCode = c.String(maxLength: 16),
                    ContactAddress1 = c.String(maxLength: 255),
                    ContactAddress2 = c.String(maxLength: 255),
                    ContactAddress3 = c.String(maxLength: 255),
                    ContactAddress4 = c.String(maxLength: 255),
                    ContactPostCode = c.String(maxLength: 16),
                    LivingAddress1 = c.String(maxLength: 255),
                    LivingAddress2 = c.String(maxLength: 255),
                    LivingAddress3 = c.String(maxLength: 255),
                    LivingAddress4 = c.String(maxLength: 255),
                    LivingPostCode = c.String(maxLength: 16),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    LivedAtAddressDays = c.Int(),
                    LastUpdatedUsernameLevelOfNeed = c.String(maxLength: 150),
                    LastUpdatedPersonIDLevelOfNeed = c.Int(),
                    ContactBySecondaryNum = c.Boolean(),
                    SecondaryPhoneNum = c.String(maxLength: 25),
                    ActivityLocationID = c.Int(),
                    IsSignedDeclarationUploaded = c.Boolean(),
                })
                .PrimaryKey(t => t.CustomerApplicationId);

            CreateTable(
                "dbo.CustomerInterest",
                c => new
                {
                    CustomerInterestID = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(nullable: false),
                    PropertyCode = c.String(nullable: false, maxLength: 50),
                    CustomerInterestStatusID = c.Int(nullable: false),
                    CustomerInterestStatusReasonsID = c.Int(nullable: false),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    VoidContactID = c.Int(nullable: false),
                    UserId = c.String(maxLength: 40),
                    IsPreViewingUndertaken = c.Boolean(),
                    EventId = c.Guid(),
                })
                .PrimaryKey(t => t.CustomerInterestID);

            CreateTable(
                "dbo.CustomerInterestStatusReasons",
                c => new
                {
                    CustomerInterestStatusReasonsID = c.Int(nullable: false, identity: true),
                    StatusReasonsDate = c.DateTime(nullable: false),
                    CustomerInterestID = c.Int(nullable: false),
                    CustomerInterestStatusID = c.Int(nullable: false),
                    OutcomeNotes = c.String(maxLength: 1000),
                    ActivityID = c.Int(),
                    CustomerDecision = c.Boolean(nullable: false),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    HasNotes = c.Boolean(nullable: false),
                    Notes = c.String(maxLength: 1000),
                })
                .PrimaryKey(t => t.CustomerInterestStatusReasonsID)
                .ForeignKey("dbo.CustomerInterest", t => t.CustomerInterestID, cascadeDelete: true)
                .Index(t => t.CustomerInterestID);

            CreateTable(
                "dbo.CustomerInterestStatus",
                c => new
                {
                    CustomerInterestStatusID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(nullable: false),
                    StatusIsOpen = c.Boolean(nullable: false),
                    StatusOnlyShowProperty = c.Boolean(nullable: false),
                    StatusHideProperty = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.CustomerInterestStatusID);

            CreateTable(
                "dbo.CustomerNote",
                c => new
                {
                    CustomerNoteID = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(nullable: false),
                    VoidContactID = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 100),
                    NoteDate = c.String(nullable: false, maxLength: 100),
                    Note = c.String(nullable: false, maxLength: 1000),
                    NoteActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.CustomerNoteID);

            CreateTable(
                "dbo.CustomerPet",
                c => new
                {
                    PetId = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    NumberOfPet = c.Int(nullable: false),
                    PetIsMoving = c.Boolean(nullable: false),
                    LastUpdatedUserName = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.PetId, t.CustomerApplicationID });

            CreateTable(
                "dbo.Ethnicity",
                c => new
                {
                    EthnicityId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(nullable: false),
                    IBSCode = c.Int(nullable: false),
                    HOACode = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.EthnicityId);

            CreateTable(
                "dbo.Gender",
                c => new
                {
                    GenderId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.GenderId);

            CreateTable(
                "dbo.HeatingType",
                c => new
                {
                    HeatingTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.HeatingTypeId);

            CreateTable(
                "dbo.HOAAppointmentLocation",
                c => new
                {
                    HOAAppointmentLocationID = c.Int(nullable: false, identity: true),
                    HOAAppointmentLocation = c.String(maxLength: 50),
                    Active = c.Boolean(),
                })
                .PrimaryKey(t => t.HOAAppointmentLocationID);

            CreateTable(
                "dbo.IncomeFrequency",
                c => new
                {
                    IncomeFrequencyId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.IncomeFrequencyId);

            CreateTable(
                "dbo.IncomeType",
                c => new
                {
                    IncomeTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                    AllowMultiple = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.IncomeTypeId);

            CreateTable(
                "dbo.Landlord",
                c => new
                {
                    LandlordId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.LandlordId);

            CreateTable(
                "dbo.LevelOfNeed",
                c => new
                {
                    LevelOfNeedId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.LevelOfNeedId);

            CreateTable(
                "dbo.Logos",
                c => new
                {
                    LogoFile = c.String(nullable: false, maxLength: 50),
                    LogoImage = c.Binary(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LogoFile, t.LogoImage });

            CreateTable(
                "dbo.lst198213Sources",
                c => new
                {
                    SourceID = c.Int(nullable: false, identity: true),
                    SourceDesc = c.String(nullable: false, maxLength: 150),
                    Active = c.Boolean(nullable: false),
                    AppliesTo198 = c.Boolean(nullable: false),
                    AppliesTo213 = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.SourceID);

            CreateTable(
                "dbo.lstAccommodationTypeAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AccommodationType = c.String(maxLength: 50),
                    OriginalAccommodationTypeDesc = c.String(maxLength: 50),
                    RevisedAccommodationTypeDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstAccommodationType",
                c => new
                {
                    AccommodationType = c.String(nullable: false, maxLength: 50),
                    AccommodationTypeDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.AccommodationType);

            CreateTable(
                "dbo.lstAccomodationProvider",
                c => new
                {
                    AccomProviderID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    TakingNewBookings = c.Boolean(nullable: false),
                    Name = c.String(maxLength: 150),
                    Addr1 = c.String(maxLength: 150),
                    Addr2 = c.String(maxLength: 150),
                    Addr3 = c.String(maxLength: 150),
                    Addr4 = c.String(maxLength: 150),
                    PCode = c.String(maxLength: 12),
                    EMailAddrs1 = c.String(maxLength: 150),
                    EMailAddrs2 = c.String(maxLength: 150),
                    BookingsCanStartFrom = c.DateTime(storeType: "date"),
                    BookingsToStop = c.Boolean(),
                    BookingsToStopDate = c.DateTime(storeType: "date"),
                    MaxStay = c.Int(),
                    MinStay = c.Int(),
                    Telno = c.String(maxLength: 20),
                    FaxNo = c.String(maxLength: 50),
                    MobileNo = c.String(maxLength: 20),
                    Notes = c.String(),
                    BnBOffered = c.Boolean(),
                    IsHostel = c.Boolean(),
                    HavePreferences = c.Boolean(),
                    WillAcceptIfChildInHH = c.Boolean(),
                    WillAcceptIfSingleMale = c.Boolean(),
                    WillAcceptIfSingleFemale = c.Boolean(),
                    WillAcceptIf16To25 = c.Boolean(),
                })
                .PrimaryKey(t => new { t.AccomProviderID, t.Active, t.TakingNewBookings });

            CreateTable(
                "dbo.lstAdviceItem",
                c => new
                {
                    AdviceItemID = c.Int(nullable: false, identity: true),
                    AdviceItemTypeID = c.Int(),
                    AddDate = c.DateTime(),
                    Active = c.Boolean(),
                    Heading = c.String(maxLength: 50),
                    AdviceSpoken = c.String(),
                    AdvicePrinted = c.String(),
                    Note = c.String(),
                    DocLink = c.String(),
                    DocURL = c.String(),
                    EmbedDocInPrint = c.Boolean(),
                    ThemeID = c.Int(),
                    PrintedIsSameAsSpoken = c.Boolean(),
                    DefaultResponsibilityOwner = c.String(maxLength: 50),
                    ConfirmAdviceDelivered = c.Boolean(),
                })
                .PrimaryKey(t => t.AdviceItemID);

            CreateTable(
                "dbo.lstAdviceItemType",
                c => new
                {
                    AdviceItemTypeID = c.Int(nullable: false, identity: true),
                    Description = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.AdviceItemTypeID);

            CreateTable(
                "dbo.lstAdviceReason",
                c => new
                {
                    AdviceReasonID = c.Int(nullable: false, identity: true),
                    QstnID = c.Int(nullable: false),
                    QstnairID = c.Int(nullable: false),
                    AdviceItemID = c.Int(),
                    AdviceItemTypeID = c.Int(),
                    AdviceHeading = c.String(maxLength: 50),
                    AdviceReason = c.String(maxLength: 50, fixedLength: true),
                    AdviceReason1 = c.String(maxLength: 50),
                    AdviceReaso2 = c.String(maxLength: 50),
                    AdviceReason3 = c.String(maxLength: 50),
                    AdviceReason4 = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.AdviceReasonID);

            CreateTable(
                "dbo.lstAgeGroupAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AgeGroup = c.String(maxLength: 20),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstAgeGroup",
                c => new
                {
                    AgeGroup = c.String(nullable: false, maxLength: 20),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.AgeGroup);

            CreateTable(
                "dbo.lstAgeToAgeGroupAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AgeValue = c.Int(),
                    OriginalAgeGroup = c.String(maxLength: 50),
                    RevisedAgeGroup = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstAgeToAgeGroup",
                c => new
                {
                    AgeValue = c.Int(nullable: false),
                    AgeGroup = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.AgeValue);

            CreateTable(
                "dbo.lstAnswerType",
                c => new
                {
                    AnswerTypeID = c.Int(nullable: false),
                    TypeDesc = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => new { t.AnswerTypeID, t.TypeDesc });

            CreateTable(
                "dbo.lstApproachReasonAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    ApproachReasonCode = c.String(maxLength: 50),
                    OriginalApproachReasonDesc = c.String(maxLength: 50),
                    RevisedApproachReasonDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstApproachReason",
                c => new
                {
                    ApproachReasonCode = c.String(nullable: false, maxLength: 50),
                    ApproachReasonDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.ApproachReasonCode);

            CreateTable(
                "dbo.lstAreaAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    Area = c.String(maxLength: 8),
                    OriginalIncommunitiesLMT = c.String(maxLength: 50),
                    RevisedIncommunitiesLMT = c.String(maxLength: 50),
                    OriginalSortorder = c.Short(),
                    RevisedSortorder = c.Short(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstArea",
                c => new
                {
                    Area = c.String(nullable: false, maxLength: 8),
                    IncommunitiesLMT = c.String(maxLength: 50),
                    Sortorder = c.Short(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.Area);

            CreateTable(
                "dbo.lstBnBReasons",
                c => new
                {
                    BnBReasonID = c.Int(nullable: false),
                    Description = c.String(nullable: false, maxLength: 150),
                    Active = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => new { t.BnBReasonID, t.Description, t.Active });

            CreateTable(
                "dbo.lstCallOutcome",
                c => new
                {
                    OutcomeID = c.Int(nullable: false),
                    OutcomeDesc = c.String(nullable: false, maxLength: 250),
                    Active = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => new { t.OutcomeID, t.OutcomeDesc, t.Active });

            CreateTable(
                "dbo.lstCaseNoteTypeAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    CaseNoteType = c.String(maxLength: 50),
                    OriginalCaseNoteTypeDesc = c.String(maxLength: 50),
                    RevisedCaseNoteTypeDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstCaseNoteType",
                c => new
                {
                    CaseNoteType = c.String(nullable: false, maxLength: 50),
                    CaseNoteTypeDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CaseNoteType);

            CreateTable(
                "dbo.lstCaseStatus",
                c => new
                {
                    CaseStatus = c.Int(nullable: false, identity: true),
                    CaseStatusDescription = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CaseStatus);

            CreateTable(
                "dbo.lstCaseStatusAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    CaseStatus = c.Int(),
                    OriginalCaseStatusDescription = c.String(maxLength: 50),
                    RevisedCaseStatusDescription = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstCBLBandAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    CBLBand = c.String(maxLength: 50),
                    OriginalCBLBandDesc = c.String(maxLength: 50),
                    RevisedCBLBandDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstCBLBand",
                c => new
                {
                    CBLBand = c.String(nullable: false, maxLength: 50),
                    CBLBandDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CBLBand);

            CreateTable(
                "dbo.lstContactTypeAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    ContactPref = c.String(maxLength: 50),
                    OriginalContactPrefDesc = c.String(maxLength: 50),
                    RevisedContactPrefDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstContactType",
                c => new
                {
                    ContactPref = c.String(nullable: false, maxLength: 50),
                    ContactPrefDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.ContactPref);

            CreateTable(
                "dbo.lstEligibilityRights",
                c => new
                {
                    EligibilityRights = c.String(nullable: false, maxLength: 50),
                    EligibilityRightsDesc = c.String(maxLength: 100),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.EligibilityRights);

            CreateTable(
                "dbo.lstEligibilityRightsAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    EligibilityRights = c.String(maxLength: 50),
                    OriginalEligibilityRightsDesc = c.String(maxLength: 100),
                    RevisedEligibilityRightsDesc = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstEthnicity",
                c => new
                {
                    EthnicityCode = c.String(nullable: false, maxLength: 50),
                    Ethnicity = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.EthnicityCode);

            CreateTable(
                "dbo.lstEthnicityAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    EthnicityCode = c.String(maxLength: 50),
                    OriginalEthnicity = c.String(maxLength: 50),
                    RevisedEthnicity = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstEvent",
                c => new
                {
                    EventID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    EventDesc = c.String(nullable: false, maxLength: 250),
                    IsADefault = c.Boolean(nullable: false),
                    DefaultPriority = c.Int(nullable: false),
                    IsCheckpoint = c.Boolean(nullable: false),
                    SyncWithCalendar = c.Boolean(nullable: false),
                    ShowCompletionCheckbox = c.Boolean(nullable: false),
                    EventDesc2 = c.String(),
                    ParentID = c.Int(),
                    IsSystemGenerated = c.Boolean(),
                    ExpectedDurnDays = c.Int(),
                    ExpectedDurnMins = c.Int(),
                    PreventUnableToComplete = c.Boolean(),
                    PreventNotNeeded = c.Boolean(),
                })
                .PrimaryKey(t => new { t.EventID, t.Active, t.EventDesc, t.IsADefault, t.DefaultPriority, t.IsCheckpoint, t.SyncWithCalendar, t.ShowCompletionCheckbox });

            CreateTable(
                "dbo.lstFamilyCompositionAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    FamilyComposition = c.String(maxLength: 50),
                    OriginalP1Egrouping = c.String(maxLength: 50),
                    RevisedP1Egrouping = c.String(maxLength: 50),
                    OriginalNumberdependantchildren = c.String(maxLength: 50),
                    RevisedNumberdependantchildren = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstFamilyComposition",
                c => new
                {
                    FamilyComposition = c.String(nullable: false, maxLength: 50),
                    P1Egrouping = c.String(maxLength: 50),
                    Numberdependantchildren = c.String(name: "Number dependant children", maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.FamilyComposition);

            CreateTable(
                "dbo.lstFloorLevelAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    FloorLevel = c.String(maxLength: 50),
                    OriginalFloorLevelDescription = c.String(maxLength: 50),
                    RevisedFloorLevelDescription = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstFloorLevel",
                c => new
                {
                    FloorLevel = c.String(nullable: false, maxLength: 50),
                    FloorLevelDescription = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.FloorLevel);

            CreateTable(
                "dbo.lstGenderAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    Gender = c.String(maxLength: 1),
                    OriginalGenderDesc = c.String(maxLength: 50),
                    RevisedGenderDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstGender",
                c => new
                {
                    Gender = c.String(nullable: false, maxLength: 1),
                    GenderDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.Gender);

            CreateTable(
                "dbo.lstHomelessDecisionAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    HomelessDecision = c.String(maxLength: 50),
                    OriginalHomelessDecisionDesc = c.String(maxLength: 50),
                    RevisedHomelessDecisionDesc = c.String(maxLength: 50),
                    OriginalP1Eindex = c.Int(),
                    RevisedP1Eindex = c.Int(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstHomelessDecision",
                c => new
                {
                    HomelessDecision = c.String(nullable: false, maxLength: 50),
                    HomelessDecisionDesc = c.String(maxLength: 50),
                    P1Eindex = c.Int(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.HomelessDecision);

            CreateTable(
                "dbo.lstHomelessnessEligibilityResponseAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    HomelessnessEligibilityResponse = c.String(maxLength: 50),
                    OriginalHomelessnessEligibilityResponseDesc = c.String(maxLength: 50),
                    RevisedHomelessnessEligibilityResponseDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstHomelessnessEligibilityResponse",
                c => new
                {
                    HomelessnessEligibilityResponse = c.String(nullable: false, maxLength: 50),
                    HomelessnessEligibilityResponseDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.HomelessnessEligibilityResponse);

            CreateTable(
                "dbo.lstHomelessOutcomeResultAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    HomelessOutcomeResult = c.String(maxLength: 50),
                    OriginalHomelessOutcomeResultDesc = c.String(maxLength: 50),
                    RevisedHomelessOutcomeResultDesc = c.String(maxLength: 50),
                    OriginalHOR_P1eCategoriesHavingTempAccom = c.String(maxLength: 50),
                    RevisedHOR_P1eCategoriesHavingTempAccom = c.String(maxLength: 50),
                    OriginalHOR_P1eCategoriesNotHavingTempAccom = c.String(maxLength: 50),
                    RevisedHOR_P1eCategoriesNotHavingTempAccom = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstHomelessOutcomeResult",
                c => new
                {
                    HomelessOutcomeResult = c.String(nullable: false, maxLength: 50),
                    HomelessOutcomeResultDesc = c.String(maxLength: 50),
                    HOR_P1eCategoriesHavingTempAccom = c.String(maxLength: 50),
                    HOR_P1eCategoriesNotHavingTempAccom = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.HomelessOutcomeResult);

            CreateTable(
                "dbo.lstHomelessP1eCategoriesHavingTempAccom",
                c => new
                {
                    P1eCHTAcode = c.Int(nullable: false),
                    HOR_P1eCategoriesHavingTempAccom = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.P1eCHTAcode);

            CreateTable(
                "dbo.lstHomelessP1eCategoriesHavingTempAccomAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    P1eCHTAcode = c.Int(),
                    OriginalHOR_P1eCategoriesHavingTempAccom = c.String(maxLength: 50),
                    RevisedHOR_P1eCategoriesHavingTempAccom = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstHomelessP1eCategoriesNotHavingTempAccom",
                c => new
                {
                    P1eCNHTAcode = c.Int(nullable: false),
                    HOR_P1eCategoriesNotHavingTempAccom = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.P1eCNHTAcode);

            CreateTable(
                "dbo.lstHomelessP1eCategoriesNotHavingTempAccomAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    P1eCNHTAcode = c.Int(),
                    OriginalHOR_P1eCategoriesNotHavingTempAccom = c.String(maxLength: 50),
                    RevisedHOR_P1eCategoriesNotHavingTempAccom = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstHomelessReasonAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    HomelessReason = c.String(maxLength: 50),
                    OriginalHomelessReasonDesc = c.String(maxLength: 100),
                    RevisedHomelessReasonDesc = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstHomelessReason",
                c => new
                {
                    HomelessReason = c.String(nullable: false, maxLength: 50),
                    HomelessReasonDesc = c.String(maxLength: 100),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.HomelessReason);

            CreateTable(
                "dbo.lstHomelessWhereStayingNowAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    HomelessWhereStayingNow = c.String(maxLength: 50),
                    OriginalHomelessWhereStayingNowDesc = c.String(maxLength: 100),
                    RevisedHomelessWhereStayingNowDesc = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstHomelessWhereStayingNow",
                c => new
                {
                    HomelessWhereStayingNow = c.String(nullable: false, maxLength: 50),
                    HomelessWhereStayingNowDesc = c.String(maxLength: 100),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.HomelessWhereStayingNow);

            CreateTable(
                "dbo.lstLevelOfNeedAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    LevelOfNeed = c.String(maxLength: 1),
                    OriginalLevelOfNeedDesc = c.String(maxLength: 50),
                    RevisedLevelOfNeedDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstLevelOfNeed",
                c => new
                {
                    LevelOfNeed = c.String(nullable: false, maxLength: 1),
                    LevelOfNeedDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.LevelOfNeed);

            CreateTable(
                "dbo.lstLocalAuthority",
                c => new
                {
                    LocalAuthorityID = c.Int(nullable: false, identity: true),
                    LocalAuthorityName = c.String(maxLength: 250),
                    CreatedDate = c.DateTime(),
                    Active = c.Boolean(),
                })
                .PrimaryKey(t => t.LocalAuthorityID);

            CreateTable(
                "dbo.lstMaritalStatus",
                c => new
                {
                    MaritalStatus = c.String(nullable: false, maxLength: 50),
                    MaritalStatusDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.MaritalStatus);

            CreateTable(
                "dbo.lstMaritalStatusAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    MaritalStatus = c.String(maxLength: 50),
                    OriginalMaritalStatusDesc = c.String(maxLength: 50),
                    RevisedMaritalStatusDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstNationalityTypeAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    NationalityType = c.String(maxLength: 50),
                    OriginalNationalityTypeDesc = c.String(maxLength: 50),
                    RevisedNationalityTypeDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstNationalityType",
                c => new
                {
                    NationalityType = c.String(nullable: false, maxLength: 50),
                    NationalityTypeDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.NationalityType);

            CreateTable(
                "dbo.lstNumberBedrooms",
                c => new
                {
                    NumberBedrooms = c.String(name: "Number Bedrooms", nullable: false, maxLength: 50),
                    NumberBedroomsDesc = c.String(name: "Number Bedrooms Desc", maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.NumberBedrooms);

            CreateTable(
                "dbo.lstNumberBedroomsAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    NumberBedrooms = c.String(maxLength: 50),
                    OriginalNumberBedroomsDesc = c.String(maxLength: 50),
                    RevisedNumberBedroomsDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstOutcomeCategory",
                c => new
                {
                    OutcomeCategoryId = c.Int(nullable: false, identity: true),
                    Deleted = c.Boolean(nullable: false),
                    OutcomeCategoryDec = c.String(maxLength: 100),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.OutcomeCategoryId);

            CreateTable(
                "dbo.lstOutcomeCategoryAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    OutcomeCategoryId = c.Int(),
                    OriginalDeleted = c.Boolean(),
                    RevisedDeleted = c.Boolean(),
                    OriginalOutcomeCategoryDec = c.String(maxLength: 100),
                    RevisedOutcomeCategoryDec = c.String(maxLength: 100),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstOutcomeResultAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    OutcomeResult = c.String(maxLength: 50),
                    OriginalOutcomeResultDec = c.String(maxLength: 100),
                    RevisedOutcomeResultDec = c.String(maxLength: 100),
                    OriginalOutcomeCategoryId = c.Int(),
                    RevisedOutcomeCategoryId = c.Int(),
                    OriginalOutcomeOtherField = c.Boolean(),
                    RevisedOutcomeOtherField = c.Boolean(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstOutcomeResult",
                c => new
                {
                    OutcomeResult = c.String(nullable: false, maxLength: 50),
                    OutcomeResultDec = c.String(maxLength: 100),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    OutcomeCategoryId = c.Int(),
                    OutcomeOtherField = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.OutcomeResult);

            CreateTable(
                "dbo.lstPlacementReasons",
                c => new
                {
                    ReasonID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    PlacementReason = c.String(maxLength: 150),
                })
                .PrimaryKey(t => new { t.ReasonID, t.Active });

            CreateTable(
                "dbo.lstPriorityNeedsReasonAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    PriorityNeedsReason = c.String(maxLength: 50),
                    OriginalPriorityNeedsReasonDesc = c.String(maxLength: 50),
                    RevisedPriorityNeedsReasonDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstPriorityNeedsReason",
                c => new
                {
                    PriorityNeedsReason = c.String(nullable: false, maxLength: 50),
                    PriorityNeedsReasonDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.PriorityNeedsReason);

            CreateTable(
                "dbo.lstQuestionAdviceItem",
                c => new
                {
                    QstnAdviceItemID = c.Int(nullable: false),
                    QstnID = c.Int(nullable: false),
                    QstnAltID = c.Int(nullable: false),
                    AdviceItemID = c.Int(nullable: false),
                    IfAll = c.Boolean(),
                    IfYes = c.Boolean(),
                    IfNo = c.Boolean(),
                    IfNeither = c.Boolean(),
                })
                .PrimaryKey(t => new { t.QstnAdviceItemID, t.QstnID, t.QstnAltID, t.AdviceItemID });

            CreateTable(
                "dbo.lstQuestionAltText",
                c => new
                {
                    QstnAltID = c.Int(nullable: false),
                    QstnID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Seqno = c.Int(nullable: false),
                    ItemText = c.String(nullable: false, maxLength: 150),
                    AddDate = c.DateTime(nullable: false, storeType: "date"),
                    OtherYes = c.Boolean(nullable: false),
                    OtherNote = c.Boolean(nullable: false),
                    ShowCheckBox = c.Boolean(nullable: false),
                    ShowNote = c.Boolean(nullable: false),
                    UpdateDate = c.DateTime(storeType: "date"),
                    NextQstnID = c.Int(),
                })
                .PrimaryKey(t => new { t.QstnAltID, t.QstnID, t.Active, t.Seqno, t.ItemText, t.AddDate, t.OtherYes, t.OtherNote, t.ShowCheckBox, t.ShowNote });

            CreateTable(
                "dbo.lstQuestionChangeType",
                c => new
                {
                    QstnChangeTypeID = c.Int(nullable: false),
                    ChangeType = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(),
                })
                .PrimaryKey(t => new { t.QstnChangeTypeID, t.ChangeType });

            CreateTable(
                "dbo.lstQuestionEvent",
                c => new
                {
                    QstnEventID = c.Int(nullable: false),
                    QstnID = c.Int(nullable: false),
                    QstnAltID = c.Int(nullable: false),
                    EventID = c.Int(nullable: false),
                    IfAll = c.Boolean(),
                    IfYes = c.Boolean(),
                    IfNo = c.Boolean(),
                    IfNeither = c.Boolean(),
                })
                .PrimaryKey(t => new { t.QstnEventID, t.QstnID, t.QstnAltID, t.EventID });

            CreateTable(
                "dbo.lstQuestionnaire",
                c => new
                {
                    QstnairID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    QstnairDesc = c.String(maxLength: 150),
                    QstnairShortDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.QstnairID, t.Active });

            CreateTable(
                "dbo.lstQuestionnaireSection",
                c => new
                {
                    QstnairSectionID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    SectionDesc = c.String(nullable: false, maxLength: 150),
                    QstnairID = c.Int(),
                    SectionHeadingText = c.String(maxLength: 250),
                })
                .PrimaryKey(t => new { t.QstnairSectionID, t.Active, t.SectionDesc });

            CreateTable(
                "dbo.lstQuestionnaireSubSection",
                c => new
                {
                    QstnairSubSectionID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    SubSectionDesc = c.String(nullable: false, maxLength: 150),
                    QstnairSectionID = c.Int(),
                    QstnairID = c.Int(),
                    SubSectionHeadingText = c.String(maxLength: 250),
                })
                .PrimaryKey(t => new { t.QstnairSubSectionID, t.Active, t.SubSectionDesc });

            CreateTable(
                "dbo.lstQuestion",
                c => new
                {
                    QstnID = c.Int(nullable: false),
                    QstnairID = c.Int(nullable: false),
                    Seqno = c.Int(nullable: false),
                    QstnText = c.String(nullable: false, maxLength: 250),
                    AnswerTypeID = c.Int(nullable: false),
                    PrevQstnID = c.Int(),
                    NextQstnID = c.Int(),
                    NextQstnIDYes = c.Int(),
                    NextQstnIDNo = c.Int(),
                    QstnairSectionID = c.Int(),
                    QstnairSubSectionID = c.Int(),
                    NoteAllowed = c.Boolean(),
                    NoteAllowedYes = c.Boolean(),
                    NoteAllowedNo = c.Boolean(),
                    NoteRequired = c.Boolean(),
                    LookupTableName = c.String(maxLength: 50),
                    LookupIDFieldName = c.String(maxLength: 50),
                    LookupValueFieldName = c.String(maxLength: 150),
                    AllowMultiSelect = c.Boolean(),
                    HintText = c.String(),
                    AllowYNAndNeither = c.Boolean(),
                    YesText = c.String(maxLength: 150),
                    NoText = c.String(maxLength: 150),
                    EventIDOnAnswer = c.Int(),
                    EventIDOnYes = c.Int(),
                    EventIDOnNo = c.Int(),
                    AllowMultipleEventsOnAnswer = c.Boolean(),
                    RefTable = c.String(maxLength: 150),
                    RefColumn = c.String(maxLength: 150),
                    NeitherText = c.String(maxLength: 150),
                    NoteAllowedNeither = c.Boolean(),
                    ListOther = c.Boolean(),
                    ListDTA = c.Boolean(),
                    ListOtherNoteAllowed = c.Boolean(),
                    ListDTANoteAllowed = c.Boolean(),
                    NextForm = c.String(maxLength: 50),
                    NextFormYes = c.String(maxLength: 50),
                    NextFormNo = c.String(maxLength: 50),
                    NextFormNeither = c.String(maxLength: 50),
                    ConfirmAdviceDelivered = c.Boolean(),
                    RelatedRAQstnairID = c.Int(),
                    RelatedRAQstnID = c.Int(),
                })
                .PrimaryKey(t => new { t.QstnID, t.QstnairID, t.Seqno, t.QstnText, t.AnswerTypeID });

            CreateTable(
                "dbo.lstRelationshipAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    RelationshipID = c.String(maxLength: 50),
                    OriginalRelationshipDesc = c.String(maxLength: 50),
                    RevisedRelationshipDesc = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstRelationship",
                c => new
                {
                    RelationshipID = c.String(nullable: false, maxLength: 50),
                    RelationshipDesc = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.RelationshipID);

            CreateTable(
                "dbo.lstReviewAgainst",
                c => new
                {
                    ReviewAgainstID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    ReviewAgainstDescription = c.String(maxLength: 150),
                })
                .PrimaryKey(t => new { t.ReviewAgainstID, t.Active });

            CreateTable(
                "dbo.lstReviewDecOut",
                c => new
                {
                    DecOutID = c.Int(nullable: false, identity: true),
                    Active = c.Boolean(nullable: false),
                    Description = c.String(maxLength: 50),
                    DecOut = c.String(nullable: false, maxLength: 3),
                })
                .PrimaryKey(t => t.DecOutID);

            CreateTable(
                "dbo.lstReviewTypes",
                c => new
                {
                    ReviewTypeID = c.Int(nullable: false, identity: true),
                    Active = c.Boolean(nullable: false),
                    ReviewDesc = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.ReviewTypeID);

            CreateTable(
                "dbo.lstRevisitReason",
                c => new
                {
                    RevReasonID = c.Int(nullable: false, identity: true),
                    RevDesc = c.String(maxLength: 150),
                    Active = c.Boolean(),
                })
                .PrimaryKey(t => t.RevReasonID);

            CreateTable(
                "dbo.lstTACancelReason",
                c => new
                {
                    CancReasonID = c.Int(nullable: false),
                    ReasonDesc = c.String(nullable: false, maxLength: 250),
                    Active = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => new { t.CancReasonID, t.ReasonDesc, t.Active });

            CreateTable(
                "dbo.lstTAPlacementTransType",
                c => new
                {
                    TransactionTypeID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    TransDesc = c.String(maxLength: 150),
                })
                .PrimaryKey(t => new { t.TransactionTypeID, t.Active });

            CreateTable(
                "dbo.lstTitleAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    Title = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstTitle",
                c => new
                {
                    Title = c.String(nullable: false, maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.Title);

            CreateTable(
                "dbo.lstUserLocationAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    UserLocation = c.String(maxLength: 3),
                    OriginalUserLocationDescription = c.String(maxLength: 50),
                    RevisedUserLocationDescription = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.lstUserLocation",
                c => new
                {
                    UserLocation = c.String(nullable: false, maxLength: 3),
                    UserLocationDescription = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    UserLocationAddress = c.String(),
                })
                .PrimaryKey(t => t.UserLocation);

            CreateTable(
                "dbo.MatchingHeatingTypes",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    SelectedValue = c.String(nullable: false, maxLength: 50),
                    MatchingCode = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.SelectedValue });

            CreateTable(
                "dbo.MatchingLocations",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    SelectedValue = c.Int(nullable: false),
                    MatchingCode = c.String(maxLength: 20, unicode: false),
                    Ward = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.SelectedValue });

            CreateTable(
                "dbo.MatchingNumBeds",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    SelectedValue = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.SelectedValue });

            CreateTable(
                "dbo.MatchingPropertyTypes",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    MatchingCode = c.String(nullable: false, maxLength: 20, unicode: false),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.MatchingCode });

            CreateTable(
                "dbo.MatchingSchemes",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    SelectedValue = c.Int(nullable: false),
                    MatchingValue = c.Int(),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.SelectedValue });

            CreateTable(
                "dbo.MoveReason",
                c => new
                {
                    MoveReasonId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                    LevelOfNeedID = c.Int(nullable: false),
                    ReferToHousingsOptionsOfficer = c.Boolean(nullable: false),
                    ReferToNeighbourhoodOfficer = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.MoveReasonId);

            CreateTable(
                "dbo.NationalityType",
                c => new
                {
                    NationalityTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.NationalityTypeId);

            CreateTable(
                "dbo.Pet",
                c => new
                {
                    PetId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.PetId);

            CreateTable(
                "dbo.PropertyFloorLevel",
                c => new
                {
                    PropertyFloorLevelId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.PropertyFloorLevelId);

            CreateTable(
                "dbo.PropertySize",
                c => new
                {
                    PropertySizeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.PropertySizeId);

            CreateTable(
                "dbo.PropertyType",
                c => new
                {
                    PropertyTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.PropertyTypeId);

            CreateTable(
                "dbo.qrpt_TempAccomodationUse",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false, identity: true),
                    AssessorUserID = c.String(maxLength: 50),
                    HasHomelessnessAssessment = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    FamilyComposition = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    Age = c.Double(),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.Relationship",
                c => new
                {
                    RelationshipId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.RelationshipId);

            CreateTable(
                "dbo.ResidencyType",
                c => new
                {
                    ResidencyTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.ResidencyTypeId);

            CreateTable(
                "dbo.SupportWorker",
                c => new
                {
                    SupportWorkerID = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(nullable: false),
                    SupportWorkerReason = c.String(nullable: false, maxLength: 1000),
                    SupportWorkerName = c.String(nullable: false, maxLength: 100),
                    SupportWorkerContact = c.String(nullable: false, maxLength: 255),
                    Active = c.Boolean(nullable: false),
                    LastUpdatedUserName = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.SupportWorkerID);

            CreateTable(
                "dbo.sysdiagrams",
                c => new
                {
                    diagram_id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false, maxLength: 128),
                    principal_id = c.Int(nullable: false),
                    version = c.Int(),
                    definition = c.Binary(),
                })
                .PrimaryKey(t => t.diagram_id);

            CreateTable(
                "dbo.tbl_ActiveManagementAreas",
                c => new
                {
                    MANAGEMENT_AREA = c.String(nullable: false, maxLength: 5),
                    MANAGEMENT_AREA_DESCRIPTION = c.String(maxLength: 50),
                    Status = c.Int(),
                })
                .PrimaryKey(t => t.MANAGEMENT_AREA);

            CreateTable(
                "dbo.tbl_Audit_CustomerApplication",
                c => new
                {
                    AuditID = c.Int(nullable: false, identity: true),
                    CustomerApplicationId = c.Int(),
                    ChangeType = c.String(maxLength: 10, unicode: false),
                    Username = c.String(nullable: false, maxLength: 128),
                    ChangeDate = c.String(maxLength: 30, unicode: false),
                    FieldName = c.String(maxLength: 500, unicode: false),
                    FromValue = c.String(maxLength: 4000, unicode: false),
                    ToVaue = c.String(maxLength: 4000, unicode: false),
                })
                .PrimaryKey(t => t.AuditID);

            CreateTable(
                "dbo.tbl_AudRejections",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Occured = c.DateTime(nullable: false),
                    ChangedBy = c.String(maxLength: 100),
                    ChangeType = c.String(maxLength: 100),
                    PropertyCode = c.String(maxLength: 50),
                    CustomerApplicationID = c.Int(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.tbl_CustomerFeedback",
                c => new
                {
                    CustomerFeedbackID = c.Int(nullable: false, identity: true),
                    CustomerApplicationID = c.Int(nullable: false),
                    MarketingInitiative = c.Boolean(nullable: false),
                    Banner = c.Boolean(nullable: false),
                    BannerLocation = c.String(maxLength: 1000),
                    Rightmove = c.Boolean(nullable: false),
                    IsVanAdvert = c.Boolean(nullable: false),
                    Other = c.Boolean(nullable: false),
                    OtherText = c.String(maxLength: 1000),
                })
                .PrimaryKey(t => t.CustomerFeedbackID);

            CreateTable(
                "dbo.tbl_KeyFeature",
                c => new
                {
                    PropertyReference = c.String(nullable: false, maxLength: 32),
                    KeyFeature = c.String(maxLength: 300),
                })
                .PrimaryKey(t => t.PropertyReference);

            CreateTable(
                "dbo.tbl_LookupData",
                c => new
                {
                    GroupID = c.Int(nullable: false),
                    Code = c.String(nullable: false, maxLength: 50),
                    Description = c.String(nullable: false, maxLength: 50),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.GroupID, t.Code });

            CreateTable(
                "dbo.tbl_Messages",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    MessageType = c.String(maxLength: 50),
                    MessageLevel = c.Int(),
                    Message = c.String(maxLength: 2000),
                    DTStamp = c.DateTime(),
                    User = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.tbl_Property",
                c => new
                {
                    PropertyId = c.Int(nullable: false, identity: true),
                    PropertyCode = c.String(nullable: false, maxLength: 50, unicode: false),
                    RSL = c.String(maxLength: 50),
                    PropertyType = c.String(maxLength: 20, unicode: false),
                    HasDriveway = c.Boolean(),
                    HasParking = c.Boolean(),
                    HasBin = c.Boolean(),
                    HasOutbuildings = c.Boolean(),
                    HasStepsToAccess = c.Boolean(),
                    NumStepsToAccess = c.Int(),
                    HasGarden = c.Boolean(),
                    PropertyNumFloors = c.Int(),
                    PropertyNumBedrooms = c.Int(),
                    PropertyNumReceptionRooms = c.Int(),
                    PropertyNumBathrooms = c.Int(),
                    BathroomType = c.String(maxLength: 50),
                    WCType = c.String(maxLength: 50),
                    WCIsSeperate = c.Boolean(),
                    AgeCriteria = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    Careline = c.Boolean(),
                    FlatFloorLevel = c.Int(),
                    HasConcierge = c.Boolean(),
                    HasDoorEntry = c.Boolean(),
                    HasLift = c.Boolean(),
                    HasWasherSpace = c.Boolean(),
                    HasDryerSpace = c.Boolean(),
                    HasCommunalLaundry = c.Boolean(),
                    HasFurnishings = c.Boolean(),
                    FurnishingDetails = c.String(maxLength: 255),
                    IsWheelChairAdapted = c.Boolean(),
                    HasRampedAccess = c.Boolean(),
                    IsLevelAccessProperty = c.Boolean(),
                    HasStairlift = c.Boolean(),
                    HasWalkInShower = c.Boolean(),
                    HasStepInShower = c.Boolean(),
                    OtherAdaptationsDescription = c.String(maxLength: 255),
                    HeatingType = c.String(maxLength: 50),
                    ElectricMeterType = c.String(maxLength: 50),
                    ElectricSupplier = c.String(maxLength: 255),
                    ElectricMeterLocation = c.String(maxLength: 255),
                    HasGas = c.Boolean(),
                    GasMeterType = c.String(maxLength: 50),
                    GasSupplier = c.String(maxLength: 255),
                    GasMeterLocation = c.String(maxLength: 255),
                    HasOutstandingRepairs = c.Boolean(),
                    OutstandingRepairComments = c.String(maxLength: 1000),
                    OutstandingRepairsReason = c.String(maxLength: 1000),
                    PropertyStatusID = c.Int(),
                    LandLord = c.String(maxLength: 50),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    HasSecurity = c.Boolean(),
                    SecurityType = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 100),
                    AddressLine2 = c.String(maxLength: 100),
                    AddressLine3 = c.String(maxLength: 100),
                    AddressLine4 = c.String(maxLength: 100),
                    Postcode = c.String(maxLength: 10),
                    Ward = c.String(maxLength: 50),
                    AdvertDetails = c.String(),
                    Status = c.String(maxLength: 50),
                    SubNeighbourhood = c.String(maxLength: 50),
                    VoidDate = c.DateTime(),
                    Rent = c.Decimal(precision: 9, scale: 2),
                    ServiceCharge = c.Decimal(precision: 9, scale: 2),
                    OtherCharge = c.Decimal(precision: 9, scale: 2),
                    PaymentCycle = c.String(maxLength: 50),
                    PropertyShopStatus = c.Int(),
                })
                .PrimaryKey(t => t.PropertyId);

            CreateTable(
                "dbo.tbl_PropertyAudit",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    PropertyId = c.Int(nullable: false),
                    PropertyCode = c.String(nullable: false, maxLength: 50, unicode: false),
                    RSL = c.String(maxLength: 50),
                    PropertyType = c.String(maxLength: 20, unicode: false),
                    HasDriveway = c.Boolean(),
                    HasParking = c.Boolean(),
                    HasBin = c.Boolean(),
                    HasOutbuildings = c.Boolean(),
                    HasStepsToAccess = c.Boolean(),
                    NumStepsToAccess = c.Int(),
                    HasGarden = c.Boolean(),
                    PropertyNumFloors = c.Int(),
                    PropertyNumBedrooms = c.Int(),
                    PropertyNumReceptionRooms = c.Int(),
                    PropertyNumBathrooms = c.Int(),
                    BathroomType = c.String(maxLength: 50),
                    WCType = c.String(maxLength: 50),
                    WCIsSeperate = c.Boolean(),
                    AgeCriteria = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    Careline = c.Boolean(),
                    FlatFloorLevel = c.Int(),
                    HasConcierge = c.Boolean(),
                    HasDoorEntry = c.Boolean(),
                    HasLift = c.Boolean(),
                    HasWasherSpace = c.Boolean(),
                    HasDryerSpace = c.Boolean(),
                    HasCommunalLaundry = c.Boolean(),
                    HasFurnishings = c.Boolean(),
                    FurnishingDetails = c.String(maxLength: 255),
                    IsWheelChairAdapted = c.Boolean(),
                    HasRampedAccess = c.Boolean(),
                    IsLevelAccessProperty = c.Boolean(),
                    HasStairlift = c.Boolean(),
                    HasWalkInShower = c.Boolean(),
                    HasStepInShower = c.Boolean(),
                    OtherAdaptationsDescription = c.String(maxLength: 255),
                    HeatingType = c.String(maxLength: 50),
                    ElectricMeterType = c.String(maxLength: 50),
                    ElectricSupplier = c.String(maxLength: 255),
                    ElectricMeterLocation = c.String(maxLength: 255),
                    HasGas = c.Boolean(),
                    GasMeterType = c.String(maxLength: 50),
                    GasSupplier = c.String(maxLength: 255),
                    GasMeterLocation = c.String(maxLength: 255),
                    HasOutstandingRepairs = c.Boolean(),
                    OutstandingRepairComments = c.String(maxLength: 1000),
                    OutstandingRepairsReason = c.String(maxLength: 1000),
                    PropertyStatusID = c.Int(),
                    LandLord = c.String(maxLength: 50),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    HasSecurity = c.Boolean(),
                    SecurityType = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 100),
                    AddressLine2 = c.String(maxLength: 100),
                    AddressLine3 = c.String(maxLength: 100),
                    AddressLine4 = c.String(maxLength: 100),
                    Postcode = c.String(maxLength: 10),
                    Ward = c.String(maxLength: 50),
                    AdvertDetails = c.String(),
                    ChangedBy = c.String(nullable: false, maxLength: 100, unicode: false),
                    ChangeType = c.String(nullable: false, maxLength: 100, unicode: false),
                    Occured = c.DateTime(nullable: false),
                    Status = c.String(maxLength: 50),
                    SubNeighbourhood = c.String(maxLength: 50),
                    Rent = c.Decimal(precision: 9, scale: 2),
                    ServiceCharge = c.Decimal(precision: 9, scale: 2),
                    OtherCharge = c.Decimal(precision: 9, scale: 2),
                    PaymentCycle = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.tbl_PropertyMigratedAccent",
                c => new
                {
                    PropertyId = c.Int(nullable: false, identity: true),
                    PropertyCode = c.String(nullable: false, maxLength: 50, unicode: false),
                    RSL = c.String(maxLength: 50),
                    PropertyType = c.String(maxLength: 20, unicode: false),
                    HasDriveway = c.Boolean(),
                    HasParking = c.Boolean(),
                    HasBin = c.Boolean(),
                    HasOutbuildings = c.Boolean(),
                    HasStepsToAccess = c.Boolean(),
                    NumStepsToAccess = c.Int(),
                    HasGarden = c.Boolean(),
                    PropertyNumFloors = c.Int(),
                    PropertyNumBedrooms = c.Int(),
                    PropertyNumReceptionRooms = c.Int(),
                    PropertyNumBathrooms = c.Int(),
                    BathroomType = c.String(maxLength: 50),
                    WCType = c.String(maxLength: 50),
                    WCIsSeperate = c.Boolean(),
                    AgeCriteria = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    Careline = c.Boolean(),
                    FlatFloorLevel = c.Int(),
                    HasConcierge = c.Boolean(),
                    HasDoorEntry = c.Boolean(),
                    HasLift = c.Boolean(),
                    HasWasherSpace = c.Boolean(),
                    HasDryerSpace = c.Boolean(),
                    HasCommunalLaundry = c.Boolean(),
                    HasFurnishings = c.Boolean(),
                    FurnishingDetails = c.String(maxLength: 255),
                    IsWheelChairAdapted = c.Boolean(),
                    HasRampedAccess = c.Boolean(),
                    IsLevelAccessProperty = c.Boolean(),
                    HasStairlift = c.Boolean(),
                    HasWalkInShower = c.Boolean(),
                    HasStepInShower = c.Boolean(),
                    OtherAdaptationsDescription = c.String(maxLength: 255),
                    HeatingType = c.String(maxLength: 50),
                    ElectricMeterType = c.String(maxLength: 50),
                    ElectricSupplier = c.String(maxLength: 255),
                    ElectricMeterLocation = c.String(maxLength: 255),
                    HasGas = c.Boolean(),
                    GasMeterType = c.String(maxLength: 50),
                    GasSupplier = c.String(maxLength: 255),
                    GasMeterLocation = c.String(maxLength: 255),
                    HasOutstandingRepairs = c.Boolean(),
                    OutstandingRepairComments = c.String(maxLength: 1000),
                    OutstandingRepairsReason = c.String(maxLength: 1000),
                    PropertyStatusID = c.Int(),
                    LandLord = c.String(maxLength: 50),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    HasSecurity = c.Boolean(),
                    SecurityType = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 100),
                    AddressLine2 = c.String(maxLength: 100),
                    AddressLine3 = c.String(maxLength: 100),
                    AddressLine4 = c.String(maxLength: 100),
                    Postcode = c.String(maxLength: 10),
                    Ward = c.String(maxLength: 50),
                    AdvertDetails = c.String(),
                    Status = c.String(maxLength: 50),
                    SubNeighbourhood = c.String(maxLength: 50),
                    VoidDate = c.DateTime(),
                    Rent = c.Decimal(precision: 9, scale: 2),
                    ServiceCharge = c.Decimal(precision: 9, scale: 2),
                    OtherCharge = c.Decimal(precision: 9, scale: 2),
                    PaymentCycle = c.String(maxLength: 50),
                    PropertyShopStatus = c.Int(),
                })
                .PrimaryKey(t => t.PropertyId);

            CreateTable(
                "dbo.tblBnBDataBK2",
                c => new
                {
                    RowID = c.Int(nullable: false),
                    Sent = c.Boolean(nullable: false),
                    SendDate = c.DateTime(),
                    LogID = c.Int(),
                    OrderNo = c.Int(),
                    FollowOnYes = c.String(maxLength: 6),
                    FollowOnNo = c.String(maxLength: 6),
                    OrderNo2 = c.String(maxLength: 50),
                    AccomProvider = c.String(),
                    ProvidersAddress = c.String(),
                    OrderedFrom = c.String(),
                    ConfirmedWith = c.String(maxLength: 50),
                    DateTimeOfOrder = c.DateTime(),
                    DateFrom = c.DateTime(storeType: "date"),
                    DateTo = c.DateTime(storeType: "date"),
                    NoOfNights = c.Int(),
                    PlacementReason = c.String(),
                    ReasonWhyPlaced = c.String(),
                    AgenciesApproached = c.String(),
                    AnyBarriers = c.String(),
                    FirstName1 = c.String(),
                    SurName1 = c.String(),
                    DoBMainAppl = c.DateTime(storeType: "date"),
                    FirstName2 = c.String(),
                    SurName2 = c.String(),
                    PartnerPregnantYes = c.String(maxLength: 6),
                    PartnerPregnantNo = c.String(maxLength: 6),
                    Appl1617Yes = c.String(maxLength: 6),
                    Appl1617No = c.String(maxLength: 6),
                    OFMFirstName1 = c.String(),
                    OFMSurName1 = c.String(),
                    OFMSon1 = c.String(maxLength: 6),
                    OFMDaughter1 = c.String(maxLength: 6),
                    OFMOther1 = c.String(maxLength: 6),
                    OFMFirstName2 = c.String(),
                    OFMSurName2 = c.String(),
                    OFMSon2 = c.String(maxLength: 6),
                    OFMDaughter2 = c.String(maxLength: 6),
                    OFMOther2 = c.String(maxLength: 6),
                    OFMFirstName3 = c.String(),
                    OFMSurName3 = c.String(),
                    OFMSon3 = c.String(maxLength: 6),
                    OFMDaughter3 = c.String(maxLength: 6),
                    OFMOther3 = c.String(maxLength: 6),
                    OFMFirstName4 = c.String(),
                    OFMSurName4 = c.String(),
                    OFMSon4 = c.String(maxLength: 6),
                    OFMDaughter4 = c.String(maxLength: 6),
                    OFMOther4 = c.String(maxLength: 6),
                    OFMFirstName5 = c.String(),
                    OFMSurName5 = c.String(),
                    OFMSon5 = c.String(maxLength: 6),
                    OFMDaughter5 = c.String(maxLength: 6),
                    OFMOther5 = c.String(maxLength: 6),
                    Notes = c.String(),
                    CaseRef = c.Int(),
                })
                .PrimaryKey(t => new { t.RowID, t.Sent });

            CreateTable(
                "dbo.tblBnBDataBK",
                c => new
                {
                    RowID = c.Int(nullable: false),
                    Sent = c.Boolean(nullable: false),
                    SendDate = c.DateTime(),
                    LogID = c.Int(),
                    OrderNo = c.Int(),
                    FollowOnYes = c.String(maxLength: 6),
                    FollowOnNo = c.String(maxLength: 6),
                    OrderNo2 = c.String(maxLength: 50),
                    AccomProvider = c.String(),
                    ProvidersAddress = c.String(),
                    OrderedFrom = c.String(),
                    ConfirmedWith = c.String(maxLength: 50),
                    DateTimeOfOrder = c.DateTime(),
                    DateFrom = c.DateTime(storeType: "date"),
                    DateTo = c.DateTime(storeType: "date"),
                    NoOfNights = c.Int(),
                    PlacementReason = c.String(),
                    ReasonWhyPlaced = c.String(),
                    AgenciesApproached = c.String(),
                    AnyBarriers = c.String(),
                    FirstName1 = c.String(),
                    SurName1 = c.String(),
                    DoBMainAppl = c.DateTime(storeType: "date"),
                    FirstName2 = c.String(),
                    SurName2 = c.String(),
                    PartnerPregnantYes = c.String(maxLength: 6),
                    PartnerPregnantNo = c.String(maxLength: 6),
                    Appl1617Yes = c.String(maxLength: 6),
                    Appl1617No = c.String(maxLength: 6),
                    OFMFirstName1 = c.String(),
                    OFMSurName1 = c.String(),
                    OFMSon1 = c.String(maxLength: 6),
                    OFMDaughter1 = c.String(maxLength: 6),
                    OFMOther1 = c.String(maxLength: 6),
                    OFMFirstName2 = c.String(),
                    OFMSurName2 = c.String(),
                    OFMSon2 = c.String(maxLength: 6),
                    OFMDaughter2 = c.String(maxLength: 6),
                    OFMOther2 = c.String(maxLength: 6),
                    OFMFirstName3 = c.String(),
                    OFMSurName3 = c.String(),
                    OFMSon3 = c.String(maxLength: 6),
                    OFMDaughter3 = c.String(maxLength: 6),
                    OFMOther3 = c.String(maxLength: 6),
                    OFMFirstName4 = c.String(),
                    OFMSurName4 = c.String(),
                    OFMSon4 = c.String(maxLength: 6),
                    OFMDaughter4 = c.String(maxLength: 6),
                    OFMOther4 = c.String(maxLength: 6),
                    OFMFirstName5 = c.String(),
                    OFMSurName5 = c.String(),
                    OFMSon5 = c.String(maxLength: 6),
                    OFMDaughter5 = c.String(maxLength: 6),
                    OFMOther5 = c.String(maxLength: 6),
                    Notes = c.String(),
                    CaseRef = c.Int(),
                })
                .PrimaryKey(t => new { t.RowID, t.Sent });

            CreateTable(
                "dbo.tblBnBData",
                c => new
                {
                    RowID = c.Int(nullable: false),
                    Sent = c.Boolean(nullable: false),
                    SendDate = c.DateTime(),
                    LogID = c.Int(),
                    OrderNo = c.Int(),
                    FollowOnYes = c.String(maxLength: 6),
                    FollowOnNo = c.String(maxLength: 6),
                    OrderNo2 = c.String(maxLength: 50),
                    AccomProvider = c.String(),
                    ProvidersAddress = c.String(),
                    OrderedFrom = c.String(),
                    ConfirmedWith = c.String(maxLength: 50),
                    DateTimeOfOrder = c.DateTime(),
                    DateFrom = c.DateTime(storeType: "date"),
                    DateTo = c.DateTime(storeType: "date"),
                    NoOfNights = c.Int(),
                    PlacementReason = c.String(),
                    ReasonWhyPlaced = c.String(),
                    AgenciesApproached = c.String(),
                    AnyBarriers = c.String(),
                    FirstName1 = c.String(),
                    SurName1 = c.String(),
                    DoBMainAppl = c.DateTime(storeType: "date"),
                    FirstName2 = c.String(),
                    SurName2 = c.String(),
                    PartnerPregnantYes = c.String(maxLength: 6),
                    PartnerPregnantNo = c.String(maxLength: 6),
                    Appl1617Yes = c.String(maxLength: 6),
                    Appl1617No = c.String(maxLength: 6),
                    OFMFirstName1 = c.String(),
                    OFMSurName1 = c.String(),
                    OFMSon1 = c.String(maxLength: 6),
                    OFMDaughter1 = c.String(maxLength: 6),
                    OFMOther1 = c.String(maxLength: 6),
                    OFMFirstName2 = c.String(),
                    OFMSurName2 = c.String(),
                    OFMSon2 = c.String(maxLength: 6),
                    OFMDaughter2 = c.String(maxLength: 6),
                    OFMOther2 = c.String(maxLength: 6),
                    OFMFirstName3 = c.String(),
                    OFMSurName3 = c.String(),
                    OFMSon3 = c.String(maxLength: 6),
                    OFMDaughter3 = c.String(maxLength: 6),
                    OFMOther3 = c.String(maxLength: 6),
                    OFMFirstName4 = c.String(),
                    OFMSurName4 = c.String(),
                    OFMSon4 = c.String(maxLength: 6),
                    OFMDaughter4 = c.String(maxLength: 6),
                    OFMOther4 = c.String(maxLength: 6),
                    OFMFirstName5 = c.String(),
                    OFMSurName5 = c.String(),
                    OFMSon5 = c.String(maxLength: 6),
                    OFMDaughter5 = c.String(maxLength: 6),
                    OFMOther5 = c.String(maxLength: 6),
                    Notes = c.String(),
                    CaseRef = c.Int(),
                })
                .PrimaryKey(t => new { t.RowID, t.Sent });

            CreateTable(
                "dbo.tblBnBDataSendLog",
                c => new
                {
                    LogID = c.Int(nullable: false),
                    SendDate = c.DateTime(nullable: false),
                    DestEMailAddrs = c.String(maxLength: 250),
                    FileNameAndPath = c.String(),
                    SenderUserID = c.String(maxLength: 250),
                })
                .PrimaryKey(t => new { t.LogID, t.SendDate });

            CreateTable(
                "dbo.tblCaseNotes",
                c => new
                {
                    CaseNoteIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    CaseNoteDate = c.DateTime(),
                    CaseNoteUserID = c.String(maxLength: 50),
                    CaseNoteType = c.String(maxLength: 50),
                    CaseNote = c.String(storeType: "ntext"),
                    CaseNoteConfidentialFlag = c.Boolean(),
                    CaseNoteConfidentialFlagUserID = c.String(maxLength: 50),
                    CaseNoteConfidentialFlagDateSet = c.DateTime(),
                    CaseNoteLastEditedDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    QstnrSectionID = c.Int(),
                    QstnrSubSectionID = c.Int(),
                    QstnID = c.Int(),
                })
                .PrimaryKey(t => t.CaseNoteIndex)
                .ForeignKey("dbo.tblHOAssessment", t => t.CaseRefNumber)
                .Index(t => t.CaseRefNumber);

            CreateTable(
                "dbo.tblHOAssessment",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false, identity: true),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    ParentCaseRefNumber = c.Int(),
                    SupportWorkerDetails = c.String(),
                    Allocations_CustomerApplicationID = c.Int(),
                    Allocations_LevelOfNeed = c.Int(),
                    Allocations_EligibleViaVBLService = c.Boolean(),
                    HL_S198DateIn = c.DateTime(storeType: "date"),
                    HL_S198DateOut = c.DateTime(storeType: "date"),
                    HL_S213DateIn = c.DateTime(storeType: "date"),
                    HL_S213DateOut = c.DateTime(storeType: "date"),
                    HL_198SourceIn = c.Int(),
                    HL_198SourceOut = c.Int(),
                    HL_213SourceIn = c.Int(),
                    HL_213SourceOut = c.Int(),
                    CustomerSatisfactionScore2 = c.Int(),
                    CustomerSatisfactionComments2 = c.String(),
                    CaseNoteIDEligible = c.Int(),
                    CaseNoteIDHomeless = c.Int(),
                    CaseNoteIDPriority = c.Int(),
                    CaseNoteIDIntentionally = c.Int(),
                    CaseNoteIDLocal = c.Int(),
                    CaseNoteIDOutcome = c.Int(),
                    CaseNoteIDExclusion = c.Int(),
                    HighlySensitive = c.Boolean(),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.tblCaseNotes_BKDelDel",
                c => new
                {
                    CaseNoteIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    CaseNoteDate = c.DateTime(),
                    CaseNoteUserID = c.String(maxLength: 50),
                    CaseNoteType = c.String(maxLength: 50),
                    CaseNote = c.String(storeType: "ntext"),
                    CaseNoteConfidentialFlag = c.Boolean(),
                    CaseNoteConfidentialFlagUserID = c.String(maxLength: 50),
                    CaseNoteConfidentialFlagDateSet = c.DateTime(),
                    CaseNoteLastEditedDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CaseNoteIndex);

            CreateTable(
                "dbo.tblCaseNotesAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    OriginalCaseRefNumber = c.Int(),
                    RevisedCaseRefNumber = c.Int(),
                    CaseNoteIndex = c.Int(),
                    OriginalCaseNoteDate = c.DateTime(),
                    RevisedCaseNoteDate = c.DateTime(),
                    OriginalCaseNoteUserID = c.String(maxLength: 50),
                    RevisedCaseNoteUserID = c.String(maxLength: 50),
                    OriginalCaseNoteType = c.String(maxLength: 50),
                    RevisedCaseNoteType = c.String(maxLength: 50),
                    OriginalCaseNote = c.String(),
                    RevisedCaseNote = c.String(),
                    OriginalCaseNoteConfidentialFlag = c.Boolean(),
                    RevisedCaseNoteConfidentialFlag = c.Boolean(),
                    OriginalCaseNoteConfidentialFlagUserID = c.String(maxLength: 50),
                    RevisedCaseNoteConfidentialFlagUserID = c.String(maxLength: 50),
                    OriginalCaseNoteConfidentialFlagDateSet = c.DateTime(),
                    RevisedCaseNoteConfidentialFlagDateSet = c.DateTime(),
                    OriginalCaseNoteLastEditedDateTime = c.DateTime(),
                    RevisedCaseNoteLastEditedDateTime = c.DateTime(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblCaseNotesBK2",
                c => new
                {
                    CaseNoteIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    CaseNoteDate = c.DateTime(),
                    CaseNoteUserID = c.String(maxLength: 50),
                    CaseNoteType = c.String(maxLength: 50),
                    CaseNote = c.String(storeType: "ntext"),
                    CaseNoteConfidentialFlag = c.Boolean(),
                    CaseNoteConfidentialFlagUserID = c.String(maxLength: 50),
                    CaseNoteConfidentialFlagDateSet = c.DateTime(),
                    CaseNoteLastEditedDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CaseNoteIndex);

            CreateTable(
                "dbo.tblCaseNotesBK",
                c => new
                {
                    CaseNoteIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    CaseNoteDate = c.DateTime(),
                    CaseNoteUserID = c.String(maxLength: 50),
                    CaseNoteType = c.String(maxLength: 50),
                    CaseNote = c.String(storeType: "ntext"),
                    CaseNoteConfidentialFlag = c.Boolean(),
                    CaseNoteConfidentialFlagUserID = c.String(maxLength: 50),
                    CaseNoteConfidentialFlagDateSet = c.DateTime(),
                    CaseNoteLastEditedDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CaseNoteIndex);

            CreateTable(
                "dbo.tblCaseNotesWK",
                c => new
                {
                    CaseNoteIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    CaseNoteDate = c.DateTime(),
                    CaseNoteUserID = c.String(maxLength: 50),
                    CaseNoteType = c.String(maxLength: 50),
                    CaseNote = c.String(storeType: "ntext"),
                    CaseNoteConfidentialFlag = c.Boolean(),
                    CaseNoteConfidentialFlagUserID = c.String(maxLength: 50),
                    CaseNoteConfidentialFlagDateSet = c.DateTime(),
                    CaseNoteLastEditedDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CaseNoteIndex);

            CreateTable(
                "dbo.tblDependants",
                c => new
                {
                    DependantsIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    DependantsForename = c.String(maxLength: 50),
                    DependantsSurname = c.String(maxLength: 50),
                    DependantsDOB = c.DateTime(),
                    DependantsRelationship = c.String(maxLength: 50),
                    DependantsGender = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    Active = c.Boolean(),
                    AddDate = c.DateTime(storeType: "date"),
                    DeletedDate = c.DateTime(storeType: "date"),
                    Note = c.String(),
                    Pregnancy = c.Boolean(),
                    DueDate = c.DateTime(storeType: "date"),
                    Ethnicity = c.String(maxLength: 50),
                    Mobile = c.String(maxLength: 50),
                    Phone = c.String(maxLength: 50),
                    EMail = c.String(maxLength: 50),
                    SecondApplicant = c.Boolean(),
                    ExcludeFromBnB = c.Boolean(),
                    CaseNoteID = c.Int(),
                })
                .PrimaryKey(t => t.DependantsIndex);

            CreateTable(
                "dbo.tblDependants_BKDelDel",
                c => new
                {
                    DependantsIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    DependantsForename = c.String(maxLength: 50),
                    DependantsSurname = c.String(maxLength: 50),
                    DependantsDOB = c.DateTime(),
                    DependantsRelationship = c.String(maxLength: 50),
                    DependantsGender = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    Active = c.Boolean(),
                    AddDate = c.DateTime(storeType: "date"),
                    DeletedDate = c.DateTime(storeType: "date"),
                    Note = c.String(),
                    Pregnancy = c.Boolean(),
                    DueDate = c.DateTime(storeType: "date"),
                    Ethnicity = c.String(maxLength: 50),
                    Mobile = c.String(maxLength: 50),
                    Phone = c.String(maxLength: 50),
                    EMail = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.DependantsIndex);

            CreateTable(
                "dbo.tblDependantsAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    OriginalCaseRefNumber = c.Int(),
                    RevisedCaseRefNumber = c.Int(),
                    DependantsIndex = c.Int(),
                    OriginalDependantsForename = c.String(maxLength: 50),
                    RevisedDependantsForename = c.String(maxLength: 50),
                    OriginalDependantsSurname = c.String(maxLength: 50),
                    RevisedDependantsSurname = c.String(maxLength: 50),
                    OriginalDependantsDOB = c.DateTime(),
                    RevisedDependantsDOB = c.DateTime(),
                    OriginalDependantsRelationship = c.String(maxLength: 50),
                    RevisedDependantsRelationship = c.String(maxLength: 50),
                    OriginalDependantsGender = c.String(maxLength: 50),
                    RevisedDependantsGender = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblEmailSetting",
                c => new
                {
                    EmailSettingID = c.Int(nullable: false, identity: true),
                    smtp_Host = c.String(maxLength: 20, fixedLength: true),
                    smtp_Port = c.Int(),
                    smtp_User = c.String(maxLength: 20, fixedLength: true),
                    smtp_Password = c.String(maxLength: 20, fixedLength: true),
                })
                .PrimaryKey(t => t.EmailSettingID);

            CreateTable(
                "dbo.tblErrorMessages",
                c => new
                {
                    RecID = c.Int(nullable: false, identity: true),
                    MsgDate = c.DateTime(),
                    RecType = c.String(maxLength: 50),
                    ErrorMsg = c.String(),
                    UserID = c.String(maxLength: 50),
                    AppName = c.String(maxLength: 50),
                    AppForm = c.String(maxLength: 50),
                    AppModule = c.String(maxLength: 50),
                    Note = c.String(),
                })
                .PrimaryKey(t => t.RecID);

            CreateTable(
                "dbo.tblHOAbk2",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    ParentCaseRefNumber = c.Int(),
                    SupportWorkerDetails = c.String(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.tblHOAbk3",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    ParentCaseRefNumber = c.Int(),
                    SupportWorkerDetails = c.String(),
                    Allocations_CustomerApplicationID = c.Int(),
                    Allocations_LevelOfNeed = c.Int(),
                    Allocations_EligibleViaVBLService = c.Boolean(),
                    HL_S198DateIn = c.DateTime(storeType: "date"),
                    HL_S198DateOut = c.DateTime(storeType: "date"),
                    HL_S213DateIn = c.DateTime(storeType: "date"),
                    HL_S213DateOut = c.DateTime(storeType: "date"),
                    HL_198SourceIn = c.Int(),
                    HL_198SourceOut = c.Int(),
                    HL_213SourceIn = c.Int(),
                    HL_213SourceOut = c.Int(),
                    CustomerSatisfactionScore2 = c.Int(),
                    CustomerSatisfactionComments2 = c.String(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.tblHOAbk4",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    ParentCaseRefNumber = c.Int(),
                    SupportWorkerDetails = c.String(),
                    Allocations_CustomerApplicationID = c.Int(),
                    Allocations_LevelOfNeed = c.Int(),
                    Allocations_EligibleViaVBLService = c.Boolean(),
                    HL_S198DateIn = c.DateTime(storeType: "date"),
                    HL_S198DateOut = c.DateTime(storeType: "date"),
                    HL_S213DateIn = c.DateTime(storeType: "date"),
                    HL_S213DateOut = c.DateTime(storeType: "date"),
                    HL_198SourceIn = c.Int(),
                    HL_198SourceOut = c.Int(),
                    HL_213SourceIn = c.Int(),
                    HL_213SourceOut = c.Int(),
                    CustomerSatisfactionScore2 = c.Int(),
                    CustomerSatisfactionComments2 = c.String(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.tblHOAbk",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(maxLength: 50),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.tblHOAssessment_BKDelDel",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    ParentCaseRefNumber = c.Int(),
                    SupportWorkerDetails = c.String(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.tblHOAssessmentAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    CaseRefNumber = c.Int(),
                    OriginalReceptionIndex = c.Int(),
                    RevisedReceptionIndex = c.Int(),
                    OriginalReceptionUserID = c.String(maxLength: 50),
                    RevisedReceptionUserID = c.String(maxLength: 50),
                    OriginalReceptionDateTime = c.DateTime(),
                    RevisedReceptionDateTime = c.DateTime(),
                    OriginalAllocatedFlag = c.Boolean(),
                    RevisedAllocatedFlag = c.Boolean(),
                    OriginalAllocatedUserID = c.String(maxLength: 50),
                    RevisedAllocatedUserID = c.String(maxLength: 50),
                    OriginalAllocatedDateTime = c.DateTime(),
                    RevisedAllocatedDateTime = c.DateTime(),
                    OriginalCaseLocked = c.Boolean(),
                    RevisedCaseLocked = c.Boolean(),
                    OriginalCaseLockedUserID = c.String(maxLength: 50),
                    RevisedCaseLockedUserID = c.String(maxLength: 50),
                    OriginalCaseLockedDateTime = c.DateTime(),
                    RevisedCaseLockedDateTime = c.DateTime(),
                    OriginalAssessorUserID = c.String(maxLength: 50),
                    RevisedAssessorUserID = c.String(maxLength: 50),
                    OriginalAssessmentDateTime = c.DateTime(),
                    RevisedAssessmentDateTime = c.DateTime(),
                    OriginalAssessmentInterviewDateTime = c.DateTime(),
                    RevisedAssessmentInterviewDateTime = c.DateTime(),
                    OriginalAssessmentApproachReason = c.String(maxLength: 50),
                    RevisedAssessmentApproachReason = c.String(maxLength: 50),
                    OriginalAssessmentContactType = c.String(maxLength: 50),
                    RevisedAssessmentContactType = c.String(maxLength: 50),
                    OriginalCBLRefNumber = c.String(maxLength: 50),
                    RevisedCBLRefNumber = c.String(maxLength: 50),
                    OriginalNeedsJointApplicationAssessment = c.Boolean(),
                    RevisedNeedsJointApplicationAssessment = c.Boolean(),
                    OriginalNeedsDependantsAssessment = c.Boolean(),
                    RevisedNeedsDependantsAssessment = c.Boolean(),
                    OriginalNeedsMedicalAssessment = c.Boolean(),
                    RevisedNeedsMedicalAssessment = c.Boolean(),
                    OriginalNeedsHomelessnessAssessment = c.Boolean(),
                    RevisedNeedsHomelessnessAssessment = c.Boolean(),
                    OriginalHasJointApplicationAssessment = c.Boolean(),
                    RevisedHasJointApplicationAssessment = c.Boolean(),
                    OriginalHasDependantsAssessment = c.Boolean(),
                    RevisedHasDependantsAssessment = c.Boolean(),
                    OriginalHasMedicalAssessment = c.Boolean(),
                    RevisedHasMedicalAssessment = c.Boolean(),
                    OriginalHasHomelessnessAssessment = c.Boolean(),
                    RevisedHasHomelessnessAssessment = c.Boolean(),
                    OriginalAssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    RevisedAssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    OriginalAssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    RevisedAssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    OriginalAssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    RevisedAssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    OriginalAssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    RevisedAssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    OriginalDateJointApplicationAssessment = c.DateTime(),
                    RevisedDateJointApplicationAssessment = c.DateTime(),
                    OriginalDateDependantsAssessment = c.DateTime(),
                    RevisedDateDependantsAssessment = c.DateTime(),
                    OriginalDateMedicalAssessment = c.DateTime(),
                    RevisedDateMedicalAssessment = c.DateTime(),
                    OriginalDateHomelessnessAssessment = c.DateTime(),
                    RevisedDateHomelessnessAssessment = c.DateTime(),
                    OriginalIncommunitiesTenant = c.Boolean(),
                    RevisedIncommunitiesTenant = c.Boolean(),
                    OriginalIncommunitiesTenancyRef = c.Int(),
                    RevisedIncommunitiesTenancyRef = c.Int(),
                    OriginalTitle = c.String(maxLength: 50),
                    RevisedTitle = c.String(maxLength: 50),
                    OriginalFirstName = c.String(maxLength: 50),
                    RevisedFirstName = c.String(maxLength: 50),
                    OriginalLastName = c.String(maxLength: 50),
                    RevisedLastName = c.String(maxLength: 50),
                    OriginalDOB = c.DateTime(),
                    RevisedDOB = c.DateTime(),
                    OriginalMaritalStatus = c.String(maxLength: 50),
                    RevisedMaritalStatus = c.String(maxLength: 50),
                    OriginalGender = c.String(maxLength: 1),
                    RevisedGender = c.String(maxLength: 1),
                    OriginalPregnant = c.Boolean(),
                    RevisedPregnant = c.Boolean(),
                    OriginalPregnancyDueDate = c.DateTime(),
                    RevisedPregnancyDueDate = c.DateTime(),
                    OriginalEthnicity = c.String(maxLength: 50),
                    RevisedEthnicity = c.String(maxLength: 50),
                    OriginalNINumber = c.String(maxLength: 50),
                    RevisedNINumber = c.String(maxLength: 50),
                    OriginalAddressLine1 = c.String(maxLength: 50),
                    RevisedAddressLine1 = c.String(maxLength: 50),
                    OriginalAddressLine2 = c.String(maxLength: 50),
                    RevisedAddressLine2 = c.String(maxLength: 50),
                    OriginalAddressLine3 = c.String(maxLength: 50),
                    RevisedAddressLine3 = c.String(maxLength: 50),
                    OriginalAddressLine4 = c.String(maxLength: 50),
                    RevisedAddressLine4 = c.String(maxLength: 50),
                    OriginalPostcode = c.String(maxLength: 50),
                    RevisedPostcode = c.String(maxLength: 50),
                    OriginalContactPreference = c.String(maxLength: 50),
                    RevisedContactPreference = c.String(maxLength: 50),
                    OriginalPhoneLandline = c.String(maxLength: 50),
                    RevisedPhoneLandline = c.String(maxLength: 50),
                    OriginalMobilePhone = c.String(maxLength: 50),
                    RevisedMobilePhone = c.String(maxLength: 50),
                    OriginalEmail = c.String(maxLength: 50),
                    RevisedEmail = c.String(maxLength: 50),
                    OriginalFamilyComposition = c.String(maxLength: 50),
                    RevisedFamilyComposition = c.String(maxLength: 50),
                    OriginalNumberBedrooms = c.Short(),
                    RevisedNumberBedrooms = c.Short(),
                    OriginalRTANationality = c.String(maxLength: 50),
                    RevisedRTANationality = c.String(maxLength: 50),
                    OriginalRTAEligibilityRights = c.String(maxLength: 50),
                    RevisedRTAEligibilityRights = c.String(maxLength: 50),
                    OriginalRTAIncomeProvided = c.Boolean(),
                    RevisedRTAIncomeProvided = c.Boolean(),
                    OriginalRTAValidVisa = c.Boolean(),
                    RevisedRTAValidVisa = c.Boolean(),
                    OriginalRTAWorkingPermitted = c.Boolean(),
                    RevisedRTAWorkingPermitted = c.Boolean(),
                    OriginalDPAAccepted = c.Boolean(),
                    RevisedDPAAccepted = c.Boolean(),
                    OriginalDPADataSharingAllowed = c.Boolean(),
                    RevisedDPADataSharingAllowed = c.Boolean(),
                    OriginalPA_UrgencyDate = c.DateTime(),
                    RevisedPA_UrgencyDate = c.DateTime(),
                    OriginalPA_RehousingRequired = c.Boolean(),
                    RevisedPA_RehousingRequired = c.Boolean(),
                    OriginalPA_NumberBedrooms = c.Short(),
                    RevisedPA_NumberBedrooms = c.Short(),
                    OriginalPA_PrivateRentedInterest = c.Boolean(),
                    RevisedPA_PrivateRentedInterest = c.Boolean(),
                    OriginalPA_LevelOfNeed = c.String(maxLength: 50),
                    RevisedPA_LevelOfNeed = c.String(maxLength: 50),
                    OriginalPA_CBLBand = c.String(maxLength: 50),
                    RevisedPA_CBLBand = c.String(maxLength: 50),
                    OriginalPA_Area1 = c.String(maxLength: 50),
                    RevisedPA_Area1 = c.String(maxLength: 50),
                    OriginalPA_Area2 = c.String(maxLength: 50),
                    RevisedPA_Area2 = c.String(maxLength: 50),
                    OriginalPA_Area3 = c.String(maxLength: 50),
                    RevisedPA_Area3 = c.String(maxLength: 50),
                    OriginalPA_Area4 = c.String(maxLength: 50),
                    RevisedPA_Area4 = c.String(maxLength: 50),
                    OriginalPA_EstateCodes = c.String(),
                    RevisedPA_EstateCodes = c.String(),
                    OriginalPA_PropertyTypeID = c.String(maxLength: 50),
                    RevisedPA_PropertyTypeID = c.String(maxLength: 50),
                    OriginalPA_FloorLevel = c.String(maxLength: 50),
                    RevisedPA_FloorLevel = c.String(maxLength: 50),
                    OriginalPA_GroupFloorExtension = c.Boolean(),
                    RevisedPA_GroupFloorExtension = c.Boolean(),
                    OriginalPA_KitchenPartFullyConverted = c.Boolean(),
                    RevisedPA_KitchenPartFullyConverted = c.Boolean(),
                    OriginalPA_ManageableSteppedAccess = c.Boolean(),
                    RevisedPA_ManageableSteppedAccess = c.Boolean(),
                    OriginalPA_Ramped = c.Boolean(),
                    RevisedPA_Ramped = c.Boolean(),
                    OriginalPA_Stairlift = c.Boolean(),
                    RevisedPA_Stairlift = c.Boolean(),
                    OriginalPA_StepInShowerTray = c.Boolean(),
                    RevisedPA_StepInShowerTray = c.Boolean(),
                    OriginalPA_ThroughFloorLift = c.Boolean(),
                    RevisedPA_ThroughFloorLift = c.Boolean(),
                    OriginalPA_WetRoom = c.Boolean(),
                    RevisedPA_WetRoom = c.Boolean(),
                    OriginalPA_Outcome = c.String(maxLength: 50),
                    RevisedPA_Outcome = c.String(maxLength: 50),
                    OriginalPA_Sent = c.Boolean(),
                    RevisedPA_Sent = c.Boolean(),
                    OriginalPA_Related = c.Boolean(),
                    RevisedPA_Related = c.Boolean(),
                    OriginalPA_Important = c.String(),
                    RevisedPA_Important = c.String(),
                    OriginalPA_NoGo = c.String(),
                    RevisedPA_NoGo = c.String(),
                    OriginalMEDICAL_PracticeName = c.String(maxLength: 255),
                    RevisedMEDICAL_PracticeName = c.String(maxLength: 255),
                    OriginalMEDICAL_GPName = c.String(maxLength: 50),
                    RevisedMEDICAL_GPName = c.String(maxLength: 50),
                    OriginalMEDICAL_Address = c.String(),
                    RevisedMEDICAL_Address = c.String(),
                    OriginalMEDICAL_Postcode = c.String(maxLength: 50),
                    RevisedMEDICAL_Postcode = c.String(maxLength: 50),
                    OriginalMEDICAL_GPPhone = c.String(maxLength: 50),
                    RevisedMEDICAL_GPPhone = c.String(maxLength: 50),
                    OriginalMEDICAL_GPFax = c.String(maxLength: 50),
                    RevisedMEDICAL_GPFax = c.String(maxLength: 50),
                    OriginalDOCSlocation = c.String(),
                    RevisedDOCSlocation = c.String(),
                    OriginalOutcomeDate = c.DateTime(),
                    RevisedOutcomeDate = c.DateTime(),
                    OriginalOutcomeResult = c.String(maxLength: 255),
                    RevisedOutcomeResult = c.String(maxLength: 255),
                    OriginalOutcomeOther = c.String(),
                    RevisedOutcomeOther = c.String(),
                    OriginalSystemHLUserID = c.String(maxLength: 50),
                    RevisedSystemHLUserID = c.String(maxLength: 50),
                    OriginalSystemHLDateTime = c.DateTime(),
                    RevisedSystemHLDateTime = c.DateTime(),
                    OriginalHL_InterviewDate = c.DateTime(),
                    RevisedHL_InterviewDate = c.DateTime(),
                    OriginalHL_IsEligible1 = c.String(maxLength: 50),
                    RevisedHL_IsEligible1 = c.String(maxLength: 50),
                    OriginalHL_IsEligibleNotes = c.String(),
                    RevisedHL_IsEligibleNotes = c.String(),
                    OriginalHL_IsHomeless2 = c.String(maxLength: 50),
                    RevisedHL_IsHomeless2 = c.String(maxLength: 50),
                    OriginalHL_IsHomelessNotes = c.String(),
                    RevisedHL_IsHomelessNotes = c.String(),
                    OriginalHL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    RevisedHL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    OriginalHL_IsInPriorityNeedNotes = c.String(),
                    RevisedHL_IsInPriorityNeedNotes = c.String(),
                    OriginalHL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    RevisedHL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    OriginalHL_IsIntentionallyHomeless_Notes = c.String(),
                    RevisedHL_IsIntentionallyHomeless_Notes = c.String(),
                    OriginalHL_HasLocalConnection5 = c.String(maxLength: 50),
                    RevisedHL_HasLocalConnection5 = c.String(maxLength: 50),
                    OriginalHL_HasLocalConnectionNotes = c.String(),
                    RevisedHL_HasLocalConnectionNotes = c.String(),
                    OriginalHL_HomelessDecision = c.String(maxLength: 50),
                    RevisedHL_HomelessDecision = c.String(maxLength: 50),
                    OriginalHL_HomelessDecisionDate = c.DateTime(),
                    RevisedHL_HomelessDecisionDate = c.DateTime(),
                    OriginalHL_DutyOwed = c.Boolean(),
                    RevisedHL_DutyOwed = c.Boolean(),
                    OriginalHL_S198Duty = c.Boolean(),
                    RevisedHL_S198Duty = c.Boolean(),
                    OriginalHL_S213Duty = c.Boolean(),
                    RevisedHL_S213Duty = c.Boolean(),
                    OriginalHL_RepeatHomelessCase = c.Boolean(),
                    RevisedHL_RepeatHomelessCase = c.Boolean(),
                    OriginalHL_PriorityNeedReason = c.String(maxLength: 50),
                    RevisedHL_PriorityNeedReason = c.String(maxLength: 50),
                    OriginalHL_HomelessReason = c.String(maxLength: 50),
                    RevisedHL_HomelessReason = c.String(maxLength: 50),
                    OriginalHL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    RevisedHL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    OriginalHL_AgeAtHomelessDecisionDate = c.Int(),
                    RevisedHL_AgeAtHomelessDecisionDate = c.Int(),
                    OriginalHL_AgeGroup = c.String(maxLength: 50),
                    RevisedHL_AgeGroup = c.String(maxLength: 50),
                    OriginalHL_TempAccommodation = c.Boolean(),
                    RevisedHL_TempAccommodation = c.Boolean(),
                    OriginalHL_TempAccommodationType = c.String(maxLength: 255),
                    RevisedHL_TempAccommodationType = c.String(maxLength: 255),
                    OriginalHL_TADateIn = c.DateTime(),
                    RevisedHL_TADateIn = c.DateTime(),
                    OriginalHL_TADateOut = c.DateTime(),
                    RevisedHL_TADateOut = c.DateTime(),
                    OriginalHL_TotalTimeResidentInWeeks = c.Int(),
                    RevisedHL_TotalTimeResidentInWeeks = c.Int(),
                    OriginalHL_Outcome = c.String(maxLength: 255),
                    RevisedHL_Outcome = c.String(maxLength: 255),
                    OriginalHL_OutcomeOther = c.String(),
                    RevisedHL_OutcomeOther = c.String(),
                    OriginalHL_OutcomeDate = c.DateTime(),
                    RevisedHL_OutcomeDate = c.DateTime(),
                    OriginalWarningFlag = c.Boolean(),
                    RevisedWarningFlag = c.Boolean(),
                    OriginalWarningNotes = c.String(),
                    RevisedWarningNotes = c.String(),
                    OriginalWarningNotesUserID = c.String(maxLength: 50),
                    RevisedWarningNotesUserID = c.String(maxLength: 50),
                    OriginalWarningNotesDateTime = c.DateTime(),
                    RevisedWarningNotesDateTime = c.DateTime(),
                    OriginalCareLeaver = c.Boolean(),
                    RevisedCareLeaver = c.Boolean(),
                    OriginalChildInNeedAssessmentRequired = c.Boolean(),
                    RevisedChildInNeedAssessmentRequired = c.Boolean(),
                    OriginalAssessmentUserLocation = c.String(maxLength: 3),
                    RevisedAssessmentUserLocation = c.String(maxLength: 3),
                    OriginalCaseStatus = c.Short(),
                    RevisedCaseStatus = c.Short(),
                    OriginalEndOfInterviewDateTime = c.DateTime(),
                    RevisedEndOfInterviewDateTime = c.DateTime(),
                    OriginalCustomerSatisfactionScore = c.Int(),
                    RevisedCustomerSatisfactionScore = c.Int(),
                    OriginalAdaptionsRequired = c.Boolean(),
                    RevisedAdaptionsRequired = c.Boolean(),
                    OriginalPetsAccepted = c.Boolean(),
                    RevisedPetsAccepted = c.Boolean(),
                    OriginalLiftRequired = c.Boolean(),
                    RevisedLiftRequired = c.Boolean(),
                    OriginalCaseClosed = c.Boolean(),
                    RevisedCaseClosed = c.Boolean(),
                    OriginalHomelessFrozen = c.Boolean(),
                    RevisedHomelessFrozen = c.Boolean(),
                    OriginalRelevantContacts = c.String(),
                    RevisedRelevantContacts = c.String(),
                    OriginalCustomerSatisfactionComments = c.String(),
                    RevisedCustomerSatisfactionComments = c.String(),
                    OriginalHL_S198DutyOut = c.Boolean(),
                    RevisedHL_S198DutyOut = c.Boolean(),
                    OriginalHL_S213DutyOut = c.Boolean(),
                    RevisedHL_S213DutyOut = c.Boolean(),
                    OriginalParentCaseRefNumber = c.Int(),
                    RevisedParentCaseRefNumber = c.Int(),
                    OriginalSupportWorkerDetails = c.String(),
                    RevisedSupportWorkerDetails = c.String(),
                    OriginalAllocations_CustomerApplicationID = c.Int(),
                    RevisedAllocations_CustomerApplicationID = c.Int(),
                    OriginalAllocations_LevelOfNeed = c.Int(),
                    RevisedAllocations_LevelOfNeed = c.Int(),
                    OriginalAllocations_EligibleViaVBLService = c.Boolean(),
                    RevisedAllocations_EligibleViaVBLService = c.Boolean(),
                    OriginalHL_S198DateIn = c.DateTime(storeType: "date"),
                    RevisedHL_S198DateIn = c.DateTime(storeType: "date"),
                    OriginalHL_S198DateOut = c.DateTime(storeType: "date"),
                    RevisedHL_S198DateOut = c.DateTime(storeType: "date"),
                    OriginalHL_S213DateIn = c.DateTime(storeType: "date"),
                    RevisedHL_S213DateIn = c.DateTime(storeType: "date"),
                    OriginalHL_S213DateOut = c.DateTime(storeType: "date"),
                    RevisedHL_S213DateOut = c.DateTime(storeType: "date"),
                    OriginalHL_198SourceIn = c.Int(),
                    RevisedHL_198SourceIn = c.Int(),
                    OriginalHL_198SourceOut = c.Int(),
                    RevisedHL_198SourceOut = c.Int(),
                    OriginalHL_213SourceIn = c.Int(),
                    RevisedHL_213SourceIn = c.Int(),
                    OriginalHL_213SourceOut = c.Int(),
                    RevisedHL_213SourceOut = c.Int(),
                    OriginalCustomerSatisfactionScore2 = c.Int(),
                    RevisedCustomerSatisfactionScore2 = c.Int(),
                    OriginalCustomerSatisfactionComments2 = c.String(),
                    RevisedCustomerSatisfactionComments2 = c.String(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblHOAssessmentBK_DelDel",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    ParentCaseRefNumber = c.Int(),
                    SupportWorkerDetails = c.String(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.tblHOAssessmentbk4",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    AllocatedFlag = c.Boolean(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedDateTime = c.DateTime(),
                    CaseLocked = c.Boolean(),
                    CaseLockedUserID = c.String(maxLength: 50),
                    CaseLockedDateTime = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessmentDateTime = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    AssessmentApproachReason = c.String(maxLength: 50),
                    AssessmentContactType = c.String(maxLength: 50),
                    CBLRefNumber = c.String(maxLength: 50),
                    NeedsJointApplicationAssessment = c.Boolean(),
                    NeedsDependantsAssessment = c.Boolean(),
                    NeedsMedicalAssessment = c.Boolean(),
                    NeedsHomelessnessAssessment = c.Boolean(),
                    HasJointApplicationAssessment = c.Boolean(),
                    HasDependantsAssessment = c.Boolean(),
                    HasMedicalAssessment = c.Boolean(),
                    HasHomelessnessAssessment = c.Boolean(),
                    AssessorUserIDJointApplicationAssessment = c.String(maxLength: 50),
                    AssessorUserIDDependantsAssessment = c.String(maxLength: 50),
                    AssessorUserIDMedicalAssessment = c.String(maxLength: 50),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    DateJointApplicationAssessment = c.DateTime(),
                    DateDependantsAssessment = c.DateTime(),
                    DateMedicalAssessment = c.DateTime(),
                    DateHomelessnessAssessment = c.DateTime(),
                    IncommunitiesTenant = c.Boolean(),
                    IncommunitiesTenancyRef = c.Int(),
                    Title = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    DOB = c.DateTime(),
                    MaritalStatus = c.String(maxLength: 50),
                    Gender = c.String(maxLength: 1),
                    Pregnant = c.Boolean(),
                    PregnancyDueDate = c.DateTime(),
                    Ethnicity = c.String(maxLength: 50),
                    NINumber = c.String(maxLength: 50),
                    AddressLine1 = c.String(maxLength: 50),
                    AddressLine2 = c.String(maxLength: 50),
                    AddressLine3 = c.String(maxLength: 50),
                    AddressLine4 = c.String(maxLength: 50),
                    Postcode = c.String(maxLength: 50),
                    ContactPreference = c.String(maxLength: 50),
                    PhoneLandline = c.String(maxLength: 50),
                    MobilePhone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FamilyComposition = c.String(maxLength: 50),
                    NumberBedrooms = c.Short(),
                    RTANationality = c.String(maxLength: 50),
                    RTAEligibilityRights = c.String(maxLength: 50),
                    RTAIncomeProvided = c.Boolean(),
                    RTAValidVisa = c.Boolean(),
                    RTAWorkingPermitted = c.Boolean(),
                    DPAAccepted = c.Boolean(),
                    DPADataSharingAllowed = c.Boolean(),
                    PA_UrgencyDate = c.DateTime(),
                    PA_RehousingRequired = c.Boolean(),
                    PA_NumberBedrooms = c.Short(),
                    PA_PrivateRentedInterest = c.Boolean(),
                    PA_LevelOfNeed = c.String(maxLength: 50),
                    PA_CBLBand = c.String(maxLength: 50),
                    PA_Area1 = c.String(maxLength: 50),
                    PA_Area2 = c.String(maxLength: 50),
                    PA_Area3 = c.String(maxLength: 50),
                    PA_Area4 = c.String(maxLength: 50),
                    PA_EstateCodes = c.String(),
                    PA_PropertyTypeID = c.String(maxLength: 50),
                    PA_FloorLevel = c.String(maxLength: 50),
                    PA_GroupFloorExtension = c.Boolean(),
                    PA_KitchenPartFullyConverted = c.Boolean(),
                    PA_ManageableSteppedAccess = c.Boolean(),
                    PA_Ramped = c.Boolean(),
                    PA_Stairlift = c.Boolean(),
                    PA_StepInShowerTray = c.Boolean(),
                    PA_ThroughFloorLift = c.Boolean(),
                    PA_WetRoom = c.Boolean(),
                    PA_Outcome = c.String(maxLength: 50),
                    PA_Sent = c.Boolean(),
                    PA_Related = c.Boolean(),
                    PA_Important = c.String(),
                    PA_NoGo = c.String(),
                    MEDICAL_PracticeName = c.String(maxLength: 255),
                    MEDICAL_GPName = c.String(maxLength: 50),
                    MEDICAL_Address = c.String(storeType: "ntext"),
                    MEDICAL_Postcode = c.String(maxLength: 50),
                    MEDICAL_GPPhone = c.String(maxLength: 50),
                    MEDICAL_GPFax = c.String(maxLength: 50),
                    DOCSlocation = c.String(storeType: "ntext"),
                    OutcomeDate = c.DateTime(),
                    OutcomeResult = c.String(maxLength: 255),
                    OutcomeOther = c.String(),
                    SystemHLUserID = c.String(maxLength: 50),
                    SystemHLDateTime = c.DateTime(),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    WarningFlag = c.Boolean(),
                    WarningNotes = c.String(storeType: "ntext"),
                    WarningNotesUserID = c.String(maxLength: 50),
                    WarningNotesDateTime = c.DateTime(),
                    CareLeaver = c.Boolean(),
                    ChildInNeedAssessmentRequired = c.Boolean(),
                    AssessmentUserLocation = c.String(maxLength: 3),
                    CaseStatus = c.Short(),
                    EndOfInterviewDateTime = c.DateTime(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    CustomerSatisfactionScore = c.Int(),
                    AdaptionsRequired = c.Boolean(),
                    PetsAccepted = c.Boolean(),
                    LiftRequired = c.Boolean(),
                    CaseClosed = c.Boolean(),
                    HomelessFrozen = c.Boolean(),
                    RelevantContacts = c.String(),
                    CustomerSatisfactionComments = c.String(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    ParentCaseRefNumber = c.Int(),
                    SupportWorkerDetails = c.String(),
                    Allocations_CustomerApplicationID = c.Int(),
                    Allocations_LevelOfNeed = c.Int(),
                    Allocations_EligibleViaVBLService = c.Boolean(),
                    HL_S198DateIn = c.DateTime(storeType: "date"),
                    HL_S198DateOut = c.DateTime(storeType: "date"),
                    HL_S213DateIn = c.DateTime(storeType: "date"),
                    HL_S213DateOut = c.DateTime(storeType: "date"),
                    HL_198SourceIn = c.Int(),
                    HL_198SourceOut = c.Int(),
                    HL_213SourceIn = c.Int(),
                    HL_213SourceOut = c.Int(),
                    CustomerSatisfactionScore2 = c.Int(),
                    CustomerSatisfactionComments2 = c.String(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.tblLinkedTables",
                c => new
                {
                    LinkedTableID = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 255),
                    ForeignName = c.String(maxLength: 255),
                    Connect = c.String(maxLength: 255),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.LinkedTableID);

            CreateTable(
                "dbo.tblLinkedTablesAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    LinkedTableID = c.Int(),
                    OriginalName = c.String(maxLength: 255),
                    RevisedName = c.String(maxLength: 255),
                    OriginalForeignName = c.String(maxLength: 255),
                    RevisedForeignName = c.String(maxLength: 255),
                    OriginalConnect = c.String(maxLength: 255),
                    RevisedConnect = c.String(maxLength: 255),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblPropertyAllocationAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    PropertyAllocationOutcomeID = c.Int(),
                    OriginalPropertyID = c.Int(),
                    RevisedPropertyID = c.Int(),
                    OriginalCaseRefNumber = c.Int(),
                    RevisedCaseRefNumber = c.Int(),
                    OriginalFullName = c.String(maxLength: 255),
                    RevisedFullName = c.String(maxLength: 255),
                    OriginalAssessorUserID = c.String(maxLength: 50),
                    RevisedAssessorUserID = c.String(maxLength: 50),
                    OriginalAllocationOutcome = c.String(maxLength: 50),
                    RevisedAllocationOutcome = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblPropertyAllocation",
                c => new
                {
                    PropertyAllocationOutcomeID = c.Int(nullable: false, identity: true),
                    PropertyID = c.Int(),
                    CaseRefNumber = c.Int(),
                    FullName = c.String(maxLength: 255),
                    AssessorUserID = c.String(maxLength: 50),
                    AllocationOutcome = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.PropertyAllocationOutcomeID);

            CreateTable(
                "dbo.tblReceptionAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    ReceptionIndex = c.Int(),
                    OriginalReceptionUserID = c.String(maxLength: 50),
                    RevisedReceptionUserID = c.String(maxLength: 50),
                    OriginalReceptionDateTime = c.DateTime(),
                    RevisedReceptionDateTime = c.DateTime(),
                    OriginalReceptionTitle = c.String(maxLength: 50),
                    RevisedReceptionTitle = c.String(maxLength: 50),
                    OriginalReceptionFirstName = c.String(maxLength: 50),
                    RevisedReceptionFirstName = c.String(maxLength: 50),
                    OriginalReceptionLastName = c.String(maxLength: 50),
                    RevisedReceptionLastName = c.String(maxLength: 50),
                    OriginalReceptionDOB = c.DateTime(),
                    RevisedReceptionDOB = c.DateTime(),
                    OriginalReceptionAddressLine1 = c.String(maxLength: 255),
                    RevisedReceptionAddressLine1 = c.String(maxLength: 255),
                    OriginalReceptionApproachReason = c.String(maxLength: 50),
                    RevisedReceptionApproachReason = c.String(maxLength: 50),
                    OriginalReceptionContactType = c.String(maxLength: 50),
                    RevisedReceptionContactType = c.String(maxLength: 50),
                    OriginalReceptionContactDetails = c.String(),
                    RevisedReceptionContactDetails = c.String(),
                    OriginalReceptionNotes = c.String(),
                    RevisedReceptionNotes = c.String(),
                    OriginalReceptionAllocatedToHOA = c.Boolean(),
                    RevisedReceptionAllocatedToHOA = c.Boolean(),
                    OriginalCaseRefNumber = c.Int(),
                    RevisedCaseRefNumber = c.Int(),
                    OriginalWarningFlag = c.Boolean(),
                    RevisedWarningFlag = c.Boolean(),
                    OriginalLeftReceptionUserID = c.String(maxLength: 50),
                    RevisedLeftReceptionUserID = c.String(maxLength: 50),
                    OriginalLeftReceptionDateTime = c.DateTime(),
                    RevisedLeftReceptionDateTime = c.DateTime(),
                    OriginalLeftReceptionNotes = c.String(),
                    RevisedLeftReceptionNotes = c.String(),
                    OriginalReceptionUserLocation = c.String(maxLength: 3),
                    RevisedReceptionUserLocation = c.String(maxLength: 3),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblReception",
                c => new
                {
                    ReceptionIndex = c.Int(nullable: false, identity: true),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(),
                    ReceptionTitle = c.String(maxLength: 50),
                    ReceptionFirstName = c.String(maxLength: 50),
                    ReceptionLastName = c.String(maxLength: 50),
                    ReceptionDOB = c.DateTime(),
                    ReceptionAddressLine1 = c.String(maxLength: 255),
                    ReceptionApproachReason = c.String(maxLength: 50),
                    ReceptionContactType = c.String(maxLength: 50),
                    ReceptionContactDetails = c.String(storeType: "ntext"),
                    ReceptionNotes = c.String(storeType: "ntext"),
                    ReceptionAllocatedToHOA = c.Boolean(),
                    CaseRefNumber = c.Int(),
                    WarningFlag = c.Boolean(),
                    LeftReceptionUserID = c.String(maxLength: 50),
                    LeftReceptionDateTime = c.DateTime(),
                    LeftReceptionNotes = c.String(storeType: "ntext"),
                    ReceptionUserLocation = c.String(maxLength: 3),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    Application_VBL = c.String(maxLength: 5),
                    WarningNote = c.String(),
                })
                .PrimaryKey(t => t.ReceptionIndex);

            CreateTable(
                "dbo.tblRehousedCustomers",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    OutcomeDate = c.DateTime(),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.tblRehousedCustomersAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    CaseRefNumber = c.Int(),
                    OriginalOutcomeDate = c.DateTime(),
                    RevisedOutcomeDate = c.DateTime(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblReportsTempAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    ReportID = c.Int(),
                    OriginalReportName = c.String(maxLength: 50),
                    RevisedReportName = c.String(maxLength: 50),
                    OriginalOfficerID = c.String(maxLength: 50),
                    RevisedOfficerID = c.String(maxLength: 50),
                    OriginalParameter1 = c.String(maxLength: 50),
                    RevisedParameter1 = c.String(maxLength: 50),
                    OriginalParameter2 = c.String(maxLength: 50),
                    RevisedParameter2 = c.String(maxLength: 50),
                    OriginalParameter3 = c.String(maxLength: 50),
                    RevisedParameter3 = c.String(maxLength: 50),
                    OriginalParameter4 = c.String(maxLength: 50),
                    RevisedParameter4 = c.String(maxLength: 50),
                    OriginalParameter5 = c.String(maxLength: 50),
                    RevisedParameter5 = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblReportsTemp",
                c => new
                {
                    ReportID = c.Int(nullable: false, identity: true),
                    ReportName = c.String(maxLength: 50),
                    OfficerID = c.String(maxLength: 50),
                    Parameter1 = c.String(maxLength: 50),
                    Parameter2 = c.String(maxLength: 50),
                    Parameter3 = c.String(maxLength: 50),
                    Parameter4 = c.String(maxLength: 50),
                    Parameter5 = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.ReportID);

            CreateTable(
                "dbo.tblSelectedColumns",
                c => new
                {
                    RecID = c.Int(nullable: false),
                    UserID = c.String(nullable: false, maxLength: 150),
                    ColumnName = c.String(nullable: false, maxLength: 250),
                    DateSelected = c.DateTime(nullable: false),
                    TableName = c.String(maxLength: 150),
                    QueryName = c.String(maxLength: 150),
                    WorksheetName = c.String(maxLength: 150),
                    Editing = c.String(maxLength: 150),
                })
                .PrimaryKey(t => new { t.RecID, t.UserID, t.ColumnName, t.DateSelected });

            CreateTable(
                "dbo.tblTempAccommodation_BKDelDel",
                c => new
                {
                    TempAccomodationIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    TempAccommodationType = c.String(maxLength: 255),
                    TempAccommodationDateIn = c.DateTime(),
                    TempAccommodationDateOut = c.DateTime(),
                    TotalTimeResidentInWeeks = c.Int(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    Note = c.String(),
                })
                .PrimaryKey(t => t.TempAccomodationIndex);

            CreateTable(
                "dbo.tblTempAccommodationAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    TempAccomodationIndex = c.Int(),
                    OriginalCaseRefNumber = c.Int(),
                    RevisedCaseRefNumber = c.Int(),
                    OriginalTempAccommodationType = c.String(maxLength: 255),
                    RevisedTempAccommodationType = c.String(maxLength: 255),
                    OriginalTempAccommodationDateIn = c.DateTime(),
                    RevisedTempAccommodationDateIn = c.DateTime(),
                    OriginalTempAccommodationDateOut = c.DateTime(),
                    RevisedTempAccommodationDateOut = c.DateTime(),
                    OriginalTotalTimeResidentInWeeks = c.Int(),
                    RevisedTotalTimeResidentInWeeks = c.Int(),
                    OriginalNote = c.String(),
                    RevisedNote = c.String(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblTempAccommodation",
                c => new
                {
                    TempAccomodationIndex = c.Int(nullable: false, identity: true),
                    CaseRefNumber = c.Int(),
                    TempAccommodationType = c.String(maxLength: 255),
                    TempAccommodationDateIn = c.DateTime(),
                    TempAccommodationDateOut = c.DateTime(),
                    TotalTimeResidentInWeeks = c.Int(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    Note = c.String(),
                    AccomProviderID = c.Int(),
                    PlacementReasonID = c.Int(),
                    ColdWeather = c.Boolean(),
                    Cancelled = c.Boolean(),
                    CancelledDateTime = c.DateTime(),
                    AmenityChargeLevied = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    AmenityChargePaid = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    TACost = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    PaidByCreditCard = c.Boolean(),
                    InvoiceRcvdDate = c.DateTime(storeType: "date"),
                    InvoiceValue = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    AmenityChargePaymentExpected = c.Boolean(),
                    NightsToBeBilled = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    CaseNoteID = c.Int(),
                    LocalAuthorityID = c.Int(),
                })
                .PrimaryKey(t => t.TempAccomodationIndex);

            CreateTable(
                "dbo.tblUserAdminAudit",
                c => new
                {
                    RevisionDate = c.DateTime(nullable: false),
                    RevisionUserId = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    AuditAction = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    OriginalSystemUserIndex = c.Int(),
                    RevisedSystemUserIndex = c.Int(),
                    UserID = c.String(maxLength: 50),
                    OriginalUserFullName = c.String(maxLength: 50),
                    RevisedUserFullName = c.String(maxLength: 50),
                    OriginalUserPostTitle = c.String(maxLength: 50),
                    RevisedUserPostTitle = c.String(maxLength: 50),
                    OriginalUserRoles = c.String(maxLength: 255),
                    RevisedUserRoles = c.String(maxLength: 255),
                    OriginalApprovedUser = c.Boolean(),
                    RevisedApprovedUser = c.Boolean(),
                    OriginalViewInLists = c.Boolean(),
                    RevisedViewInLists = c.Boolean(),
                    OriginalUserLocation = c.String(maxLength: 50),
                    RevisedUserLocation = c.String(maxLength: 50),
                    OriginalUserPassword = c.String(maxLength: 50),
                    RevisedUserPassword = c.String(maxLength: 50),
                    OriginalAdmin = c.Boolean(),
                    RevisedAdmin = c.Boolean(),
                })
                .PrimaryKey(t => new { t.RevisionDate, t.RevisionUserId, t.AuditAction });

            CreateTable(
                "dbo.tblUserAdminbk",
                c => new
                {
                    SystemUserIndex = c.Int(nullable: false),
                    UserID = c.String(nullable: false, maxLength: 50),
                    UserFullName = c.String(maxLength: 50),
                    UserPostTitle = c.String(maxLength: 50),
                    UserRoles = c.String(maxLength: 255),
                    ApprovedUser = c.Boolean(),
                    UserPhoto = c.Binary(storeType: "image"),
                    ViewInLists = c.Boolean(),
                    UserLocation = c.String(maxLength: 50),
                    UserPassword = c.String(maxLength: 50),
                    Admin = c.Boolean(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => new { t.SystemUserIndex, t.UserID });

            CreateTable(
                "dbo.tblUserAdmin",
                c => new
                {
                    UserID = c.String(nullable: false, maxLength: 50),
                    SystemUserIndex = c.Int(nullable: false, identity: true),
                    UserFullName = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    UserPostTitle = c.String(maxLength: 50),
                    UserRoles = c.String(maxLength: 255),
                    ApprovedUser = c.Boolean(),
                    UserPhoto = c.Binary(storeType: "image"),
                    ViewInLists = c.Boolean(),
                    UserLocation = c.String(maxLength: 50),
                    UserPassword = c.String(maxLength: 50),
                    Admin = c.Boolean(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    HasAccessToHighlySensitive = c.Boolean(),
                })
                .PrimaryKey(t => t.UserID);

            CreateTable(
                "dbo.tblUserChangeRequests",
                c => new
                {
                    ChangeRequestRef = c.Int(nullable: false, identity: true),
                    DateLogged = c.DateTime(),
                    LoggedBy = c.String(maxLength: 50),
                    RequestCategory = c.String(maxLength: 50),
                    RequestDetails = c.String(storeType: "ntext"),
                    ApprovedBy = c.String(maxLength: 50),
                    ApprovedDate = c.DateTime(),
                    DeveloperName = c.String(maxLength: 50),
                    DeveloperDueDate = c.DateTime(),
                    DeveloperStatus = c.String(maxLength: 50),
                    DeveloperDoneDate = c.DateTime(),
                    DeveloperNotes = c.String(storeType: "ntext"),
                    Locked = c.Boolean(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.ChangeRequestRef);

            CreateTable(
                "dbo.tblUserExtraScanLocn",
                c => new
                {
                    RecID = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 50),
                    ScanLocn = c.String(nullable: false),
                    LocnShortCode = c.String(nullable: false, maxLength: 3),
                    Active = c.Boolean(nullable: false),
                    DateAdded = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.RecID);

            CreateTable(
                "dbo.tblUserUpdates",
                c => new
                {
                    UserUpdateIndex = c.Int(nullable: false, identity: true),
                    UserUpdateDateTime = c.DateTime(),
                    UserUpdateNote = c.String(storeType: "ntext"),
                    UserUpdateUserID = c.String(maxLength: 50),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.UserUpdateIndex);

            CreateTable(
                "dbo.TenancyType",
                c => new
                {
                    TenancyTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                })
                .PrimaryKey(t => t.TenancyTypeId);

            CreateTable(
                "dbo.Title",
                c => new
                {
                    TitleId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                    DefaultGenderID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.TitleId);

            CreateTable(
                "dbo.tsubCaseFileLocn",
                c => new
                {
                    CaseRefLocnID = c.Int(nullable: false, identity: true),
                    CaseRef = c.Int(nullable: false),
                    Locn = c.String(),
                    Active = c.Boolean(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CaseRefLocnID);

            CreateTable(
                "dbo.tsubCheque",
                c => new
                {
                    ChequeID = c.Int(nullable: false),
                    CaseRef = c.Int(nullable: false),
                    ChequeNo = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    ChequeDate = c.DateTime(nullable: false, storeType: "date"),
                    ChequeValue = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                    AllocatedValue = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                    RefNo = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                    AccountNo = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                    DateFrom = c.DateTime(storeType: "date"),
                    DateTo = c.DateTime(storeType: "date"),
                    Note = c.String(maxLength: 250),
                })
                .PrimaryKey(t => new { t.ChequeID, t.CaseRef, t.ChequeNo, t.ChequeDate, t.ChequeValue, t.AllocatedValue });

            CreateTable(
                "dbo.tsubFamilyComposition",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    SystemFCIndex = c.Int(nullable: false, identity: true),
                    SystemFCDate = c.DateTime(),
                    SystemFCUserID = c.String(maxLength: 50),
                    FC_Title = c.String(maxLength: 50),
                    FC_Forename = c.String(maxLength: 50),
                    FC_Surname = c.String(maxLength: 50),
                    FC_DOB = c.DateTime(),
                    FC_Relationship = c.String(name: "FC_ Relationship", maxLength: 50),
                    FC_Gender = c.String(maxLength: 1),
                    FC_HasDisability = c.Boolean(),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.tsubHOAEvents",
                c => new
                {
                    CaseEventID = c.Int(nullable: false),
                    EventID = c.Int(nullable: false),
                    Seqno = c.Int(nullable: false),
                    CaseRef = c.Int(),
                    EntityID = c.Int(),
                    Priority = c.Int(),
                    ForecastStartDate = c.DateTime(),
                    ForecastCompletionDate = c.DateTime(),
                    ActualStartDate = c.DateTime(),
                    ActualCompletionDate = c.DateTime(),
                    RequiredStartDate = c.DateTime(),
                    RequiredCompletionDate = c.DateTime(),
                    Note = c.String(),
                    Completed = c.Boolean(),
                    CompletedUserID = c.String(maxLength: 50),
                    AssignedTo = c.String(maxLength: 50),
                    UserID = c.String(maxLength: 50),
                    NotNeeded = c.Boolean(),
                    NotNeededDate = c.DateTime(),
                    NotNeededUserID = c.String(maxLength: 50),
                    UnableToComplete = c.Boolean(),
                    UnableToCompleteDate = c.DateTime(),
                    UnableToCompleteUserID = c.String(maxLength: 50),
                    QstnID = c.Int(),
                })
                .PrimaryKey(t => new { t.CaseEventID, t.EventID, t.Seqno });

            CreateTable(
                "dbo.tsubHOAExclusion",
                c => new
                {
                    CaseExclusionID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    AddDate = c.DateTime(nullable: false),
                    AddUserID = c.String(nullable: false, maxLength: 50),
                    CaseRef = c.Int(nullable: false),
                    NotHomeless = c.Boolean(),
                    NotPriorityNeed = c.Boolean(),
                    DutyCeased = c.Boolean(),
                    FailureToCoop = c.Boolean(),
                    NotEligible = c.Boolean(),
                    WaiveDueToCWP = c.Boolean(),
                    WaiveDueToManager = c.Boolean(),
                    RiskNote = c.String(),
                    ExcludedByTAProvider = c.Boolean(),
                })
                .PrimaryKey(t => new { t.CaseExclusionID, t.Active, t.AddDate, t.AddUserID, t.CaseRef });

            CreateTable(
                "dbo.tsubHOAQstnAdviceItem",
                c => new
                {
                    CaseQstnAdviceItemID = c.Int(nullable: false),
                    CaseRef = c.Int(nullable: false),
                    QstnairID = c.Int(),
                    QstnID = c.Int(),
                    QstnAltID = c.Int(),
                    QstnAdviceItemID = c.Int(),
                    AdviceItemID = c.Int(),
                    AddDate = c.DateTime(),
                    Completed = c.Boolean(),
                    CompletionDate = c.DateTime(),
                    CompletedUserID = c.String(maxLength: 50),
                    AssignedTo = c.String(maxLength: 50),
                    ShownToClient = c.Boolean(),
                    ShownToClientDate = c.DateTime(),
                    NotNeeded = c.Boolean(),
                    NotNeededDate = c.DateTime(),
                    NotNeededUserID = c.String(maxLength: 50),
                    UnableToComplete = c.Boolean(),
                    UnableToCompleteDate = c.DateTime(),
                    UnableToCompleteUserID = c.String(maxLength: 50),
                    ClientResponseID = c.Int(),
                    ClientResponseText = c.String(),
                    AdviceDocPrinted = c.Boolean(),
                    AdviceDocPrintDate = c.DateTime(),
                })
                .PrimaryKey(t => new { t.CaseQstnAdviceItemID, t.CaseRef });

            CreateTable(
                "dbo.tsubHOAQuestionAnswers",
                c => new
                {
                    AnswerID = c.Int(nullable: false),
                    QstnairID = c.Int(nullable: false),
                    QstnID = c.Int(nullable: false),
                    CaseRef = c.Int(nullable: false),
                    Seqno = c.Int(nullable: false),
                    AnswerTypeID = c.Int(nullable: false),
                    AddDate = c.DateTime(nullable: false, storeType: "date"),
                    PrevQstnID = c.Int(nullable: false),
                    NextQstnID = c.Int(nullable: false),
                    AnswerValue = c.String(),
                    QstnAltID = c.Int(),
                    UpdateDate = c.DateTime(storeType: "date"),
                    Note = c.String(),
                    YesNote = c.String(),
                    NoNote = c.String(),
                    QstnAltChecked = c.Boolean(),
                    OtherChecked = c.Boolean(),
                    OtherNote = c.String(),
                    AdviceDelivered = c.Boolean(),
                    AdviceDeliveredDate = c.DateTime(),
                    QstnChangeTypeID = c.Int(),
                    CaseNoteID = c.Int(),
                    CommonQstn = c.Boolean(),
                })
                .PrimaryKey(t => new { t.AnswerID, t.QstnairID, t.QstnID, t.CaseRef, t.Seqno, t.AnswerTypeID, t.AddDate, t.PrevQstnID, t.NextQstnID });

            CreateTable(
                "dbo.tsubHomelessness_BKDelDel",
                c => new
                {
                    HLIndex = c.Int(nullable: false),
                    CaseRef = c.Int(nullable: false),
                    HLSeqno = c.Int(nullable: false),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                })
                .PrimaryKey(t => new { t.HLIndex, t.CaseRef, t.HLSeqno });

            CreateTable(
                "dbo.tsubHomelessness",
                c => new
                {
                    HLIndex = c.Int(nullable: false, identity: true),
                    CaseRef = c.Int(nullable: false),
                    HLSeqno = c.Int(nullable: false),
                    HL_InterviewDate = c.DateTime(),
                    HL_IsEligible1 = c.String(maxLength: 50),
                    HL_IsEligibleNotes = c.String(storeType: "ntext"),
                    HL_IsHomeless2 = c.String(maxLength: 50),
                    HL_IsHomelessNotes = c.String(storeType: "ntext"),
                    HL_IsInPriorityNeed3 = c.String(maxLength: 50),
                    HL_IsInPriorityNeedNotes = c.String(storeType: "ntext"),
                    HL_IsIntentionallyHomeless4 = c.String(maxLength: 50),
                    HL_IsIntentionallyHomeless_Notes = c.String(storeType: "ntext"),
                    HL_HasLocalConnection5 = c.String(maxLength: 50),
                    HL_HasLocalConnectionNotes = c.String(storeType: "ntext"),
                    HL_HomelessDecision = c.String(maxLength: 50),
                    HL_HomelessDecisionDate = c.DateTime(),
                    HL_DutyOwed = c.Boolean(),
                    HL_S198Duty = c.Boolean(),
                    HL_S213Duty = c.Boolean(),
                    HL_S198DutyOut = c.Boolean(),
                    HL_S213DutyOut = c.Boolean(),
                    HL_RepeatHomelessCase = c.Boolean(),
                    HL_PriorityNeedReason = c.String(maxLength: 50),
                    HL_HomelessReason = c.String(maxLength: 50),
                    HL_HomelessWhereStayingNow = c.String(maxLength: 50),
                    HL_AgeAtHomelessDecisionDate = c.Int(),
                    HL_AgeGroup = c.String(maxLength: 50),
                    HL_TempAccommodation = c.Boolean(),
                    HL_TempAccommodationType = c.String(maxLength: 255),
                    HL_TADateIn = c.DateTime(),
                    HL_TADateOut = c.DateTime(),
                    HL_TotalTimeResidentInWeeks = c.Int(),
                    HL_Outcome = c.String(maxLength: 255),
                    HL_OutcomeOther = c.String(storeType: "ntext"),
                    HL_OutcomeDate = c.DateTime(),
                    AssessorUserIDHomelessnessAssessment = c.String(maxLength: 50),
                    HL_S198DateIn = c.DateTime(storeType: "date"),
                    HL_S198DateOut = c.DateTime(storeType: "date"),
                    HL_S213DateIn = c.DateTime(storeType: "date"),
                    HL_S213DateOut = c.DateTime(storeType: "date"),
                    HL_198SourceIn = c.Int(),
                    HL_198SourceOut = c.Int(),
                    HL_213SourceIn = c.Int(),
                    HL_213SourceOut = c.Int(),
                })
                .PrimaryKey(t => t.HLIndex);

            CreateTable(
                "dbo.tsubHomelessnessReviews",
                c => new
                {
                    HLReviewIndex = c.Int(nullable: false, identity: true),
                    CaseRef = c.Int(nullable: false),
                    HLReviewSeqno = c.Int(nullable: false),
                    ReviewRequestedDate = c.DateTime(storeType: "date"),
                    MeansOfNotify = c.String(maxLength: 100),
                    SentToCouncilDate = c.DateTime(storeType: "date"),
                    ForecastReturnDecisionDate = c.DateTime(storeType: "date"),
                    ReturnDecisionDate = c.DateTime(storeType: "date"),
                    CouncilsDecision = c.String(maxLength: 100),
                    NewDecision = c.String(maxLength: 100),
                    OutcomeReview = c.Boolean(),
                    DecisionReview = c.Boolean(),
                    ReturnDecisionText = c.String(),
                    Notes = c.String(),
                    ReviewAgainst = c.Int(),
                })
                .PrimaryKey(t => t.HLReviewIndex);

            CreateTable(
                "dbo.tsubRevisits",
                c => new
                {
                    RevisitIndex = c.Int(nullable: false, identity: true),
                    ReceptionIndex = c.Int(),
                    CaseRefNumber = c.Int(),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionNotes = c.String(storeType: "ntext"),
                    ReceptionDateTime = c.DateTime(),
                    LeftReceptionUserID = c.String(maxLength: 50),
                    LeftReceptionDateTime = c.DateTime(),
                    LeftReceptionNotes = c.String(storeType: "ntext"),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    RevReasonID = c.Int(),
                    CaseNoteID = c.Int(),
                })
                .PrimaryKey(t => t.RevisitIndex);

            CreateTable(
                "dbo.tsubRevisits_BKDelDel",
                c => new
                {
                    RevisitIndex = c.Int(nullable: false, identity: true),
                    ReceptionIndex = c.Int(),
                    CaseRefNumber = c.Int(),
                    ReceptionUserID = c.String(maxLength: 50),
                    ReceptionNotes = c.String(storeType: "ntext"),
                    ReceptionDateTime = c.DateTime(),
                    LeftReceptionUserID = c.String(maxLength: 50),
                    LeftReceptionDateTime = c.DateTime(),
                    LeftReceptionNotes = c.String(storeType: "ntext"),
                    upsize_ts = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    RevReasonID = c.Int(),
                })
                .PrimaryKey(t => t.RevisitIndex);

            CreateTable(
                "dbo.tsubTABookingCall",
                c => new
                {
                    CallID = c.Int(nullable: false),
                    CaseRef = c.Int(nullable: false),
                    CallDateTime = c.DateTime(nullable: false),
                    ProviderID = c.Int(nullable: false),
                    UserID = c.String(nullable: false, maxLength: 50),
                    CallStart = c.DateTime(nullable: false),
                    TAID = c.Int(),
                    CallEnd = c.DateTime(),
                    OutcomeID = c.Int(),
                    Note = c.String(maxLength: 250),
                    BookingType = c.Int(),
                    SuccessfulOutcome = c.Boolean(),
                })
                .PrimaryKey(t => new { t.CallID, t.CaseRef, t.CallDateTime, t.ProviderID, t.UserID, t.CallStart });

            CreateTable(
                "dbo.tsubTACancellationNight",
                c => new
                {
                    TACancNightID = c.Int(nullable: false),
                    CancellationID = c.Int(nullable: false),
                    DateCancelled = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => new { t.TACancNightID, t.CancellationID, t.DateCancelled });

            CreateTable(
                "dbo.tsubTACancellation",
                c => new
                {
                    CancellationID = c.Int(nullable: false),
                    TAPlacementID = c.Int(nullable: false),
                    CancDate = c.DateTime(),
                    CancReasonID = c.Int(),
                    UserID = c.String(maxLength: 50),
                    NoOfNightsCancelled = c.Int(),
                })
                .PrimaryKey(t => new { t.CancellationID, t.TAPlacementID });

            CreateTable(
                "dbo.tsubTAPlacementPerson",
                c => new
                {
                    TAPlacementPersonID = c.Int(nullable: false),
                    TAPlacementID = c.Int(nullable: false),
                    Forename = c.String(maxLength: 150),
                    Surname = c.String(maxLength: 150),
                    Relationship = c.String(maxLength: 150),
                    DoB = c.DateTime(storeType: "date"),
                    Note = c.String(),
                })
                .PrimaryKey(t => new { t.TAPlacementPersonID, t.TAPlacementID });

            CreateTable(
                "dbo.tsubTAPlacement",
                c => new
                {
                    TAPlacementID = c.Int(nullable: false),
                    CaseRef = c.Int(nullable: false),
                    TempAccomodationIndex = c.Int(nullable: false),
                    DateFrom = c.DateTime(storeType: "date"),
                    DateTo = c.DateTime(storeType: "date"),
                    AdjustedDateTo = c.DateTime(storeType: "date"),
                    AccomProviderID = c.Int(),
                    Note = c.String(),
                    AccomProviderPhoned = c.Boolean(),
                    AccomProviderPhnDate = c.DateTime(),
                    AccomProviderConfSent = c.Boolean(),
                    AccomProviderConfSentDate = c.DateTime(),
                    FollowOnOrder = c.Boolean(),
                    FollowOnOrderTAPlacementID = c.Int(),
                    NoOfNights = c.Int(),
                    ReasonID = c.Int(),
                    BnBReasonID = c.Int(),
                    AgenciesApproached = c.String(),
                    Barriers = c.String(),
                    CouncilRefNo = c.Int(),
                    Pregnant = c.Boolean(),
                    MainApp16or17 = c.Boolean(),
                    OrderLocnID = c.String(maxLength: 3),
                    DateOfOrder = c.DateTime(),
                    BookingUserID = c.String(maxLength: 50),
                    InvMatched = c.Boolean(),
                    InvMatchDate = c.DateTime(),
                    SuppInvID = c.Int(),
                    ChqMatched = c.Boolean(),
                    ChqMatchDate = c.DateTime(),
                    ChqID = c.Int(),
                    LocalAuthorityID = c.Int(),
                })
                .PrimaryKey(t => new { t.TAPlacementID, t.CaseRef, t.TempAccomodationIndex });

            CreateTable(
                "dbo.tsubTASuppInvoices",
                c => new
                {
                    SuppInvID = c.Int(nullable: false),
                    AccomProviderID = c.Int(nullable: false),
                    CaseRef = c.Int(nullable: false),
                    SuppInvNo = c.String(maxLength: 50),
                    SuppInvDate = c.DateTime(storeType: "date"),
                    AddDate = c.DateTime(storeType: "date"),
                    Note = c.String(),
                    NetValue = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    VATValue = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    NoOfDaysPaid = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    NoOfDaysUnallocated = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    ValueMatched = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    MatchDateStart = c.DateTime(),
                    MatchDateComplete = c.DateTime(),
                })
                .PrimaryKey(t => new { t.SuppInvID, t.AccomProviderID, t.CaseRef });

            CreateTable(
                "dbo.v_ApplicationMatchCustomerInterests",
                c => new
                {
                    CustomerInterestID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    PropertyCode = c.String(nullable: false, maxLength: 50),
                    CustomerInterestStatusID = c.Int(nullable: false),
                    StatusIsOpen = c.Boolean(nullable: false),
                    StatusHideProperty = c.Boolean(nullable: false),
                    StatusOnlyShowProperty = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => new { t.CustomerInterestID, t.CustomerApplicationID, t.PropertyCode, t.CustomerInterestStatusID, t.StatusIsOpen, t.StatusHideProperty, t.StatusOnlyShowProperty });

            CreateTable(
                "dbo.v_ApplicationMatchCustomerInterestsVoids",
                c => new
                {
                    CustomerInterestID = c.Int(nullable: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    VoidContactID = c.Int(nullable: false),
                    PropertyCode = c.String(nullable: false, maxLength: 50),
                    CustomerInterestStatusID = c.Int(nullable: false),
                    StatusIsOpen = c.Boolean(nullable: false),
                    StatusHideProperty = c.Boolean(nullable: false),
                    StatusOnlyShowProperty = c.Boolean(nullable: false),
                    ActivityID = c.Int(),
                })
                .PrimaryKey(t => new { t.CustomerInterestID, t.CustomerApplicationID, t.VoidContactID, t.PropertyCode, t.CustomerInterestStatusID, t.StatusIsOpen, t.StatusHideProperty, t.StatusOnlyShowProperty });

            CreateTable(
                "dbo.v_ApplicationMatchFilters",
                c => new
                {
                    CustomerApplicationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CustomerApplicationId);

            CreateTable(
                "dbo.v_Applications",
                c => new
                {
                    CustomerApplicationId = c.Int(nullable: false),
                    ApplicationStatusID = c.Int(nullable: false),
                    OriginalApplicationDate = c.DateTime(nullable: false),
                    ApplicationDate = c.DateTime(nullable: false),
                    ApplicationBanding = c.String(maxLength: 50),
                    VoidID = c.Int(nullable: false),
                    TitleId = c.Int(nullable: false),
                    Forename = c.String(maxLength: 50),
                    Surname = c.String(maxLength: 50),
                    Email = c.String(maxLength: 255),
                    MobileNum = c.String(maxLength: 25),
                    TelNum = c.String(maxLength: 25),
                    OriginalApplicationStatusReason = c.String(maxLength: 1000),
                    ApplicationStatusReason = c.String(maxLength: 1000),
                    ApplicationEligability = c.Boolean(),
                    HOALevelOfNeedDate = c.DateTime(),
                    LevelOfNeed = c.Int(),
                    CaseRefNumber = c.Int(),
                    HOAOutcome = c.String(maxLength: 1000),
                    HOAOutcomeDate = c.DateTime(),
                    HOACaseIsOpen = c.Boolean(),
                    HOAEligabilitySet = c.Boolean(),
                    VBLSatisfationActivityID = c.Int(),
                    LastUpdatedUserName = c.String(maxLength: 100),
                    ApplicationClosedDate = c.DateTime(),
                    MatchingPropertyTypes = c.String(maxLength: 255),
                    MatchingNumBedrooms = c.String(maxLength: 255),
                    MatchingLocations = c.String(maxLength: 500),
                    MatchingSchemes = c.String(maxLength: 255),
                    MatchingHeatingTypes = c.String(maxLength: 255),
                    MatchingEarliestMoveDate = c.DateTime(storeType: "date"),
                    MatchingLatestMoveDate = c.DateTime(storeType: "date"),
                    MatchingApplicantsAge = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    MutualExchange = c.Boolean(),
                    MatchingFloorlevel = c.Int(),
                    MatchingLiftServed = c.Boolean(),
                    MatchingTrustCare = c.Boolean(),
                    MatchingSheltered = c.Boolean(),
                    MatchingGarden = c.Boolean(),
                    MatchingWheelChairAdapted = c.Boolean(),
                    MatchingRampedAccess = c.Boolean(),
                    MatchingLevelAccessProperty = c.Boolean(),
                    MatchingStairlift = c.Boolean(),
                    MatchingWalkInShower = c.Boolean(),
                    MatchingStepInShower = c.Boolean(),
                    MatchingPropertyTypesNames = c.String(maxLength: 1000),
                    MatchingNumBedroomsNames = c.String(maxLength: 1000),
                    MatchingLocationsNames = c.String(maxLength: 1000),
                    MatchingSchemesNames = c.String(maxLength: 1000),
                    MatchingHeatingTypesNames = c.String(maxLength: 1000),
                    MutualExchangePropertyCode = c.String(maxLength: 50, unicode: false),
                    DataProtectionIsPrinted = c.Boolean(),
                    DataProtectionIsSigned = c.Boolean(),
                    DataProtectionConsented = c.Boolean(),
                })
                .PrimaryKey(t => new { t.CustomerApplicationId, t.ApplicationStatusID, t.VoidID });

            CreateTable(
                "dbo.v_HOAInterface",
                c => new
                {
                    CustomerApplicationId = c.Int(nullable: false),
                    ApplicationStatusID = c.Int(nullable: false),
                    ApplicationDate = c.DateTime(nullable: false),
                    ActivityID = c.Int(nullable: false),
                    ApplicationStatusReason = c.String(maxLength: 1000),
                    ApplicationEligible = c.Boolean(),
                    HOALevelOfNeedDate = c.DateTime(),
                    ApplicationLevelOfNeedID = c.Int(),
                    HOACaseRef = c.Int(),
                    HOAOutcome = c.String(maxLength: 1000),
                    HOAOutcomeDate = c.DateTime(),
                    HOACaseIsOpen = c.Boolean(),
                    HOAEligabilitySet = c.Boolean(),
                    ApplicationClosedDate = c.DateTime(),
                    HOAEligible = c.Boolean(),
                    HOALevelOfNeedID = c.Int(),
                    MoveReason = c.String(maxLength: 255, unicode: false),
                    AppointmentDate = c.DateTime(),
                    ActivityStatusID = c.Int(),
                })
                .PrimaryKey(t => new { t.CustomerApplicationId, t.ApplicationStatusID, t.ApplicationDate, t.ActivityID });

            CreateTable(
                "dbo.v_HOAInterfaceContacts",
                c => new
                {
                    CustomerApplicationId = c.Int(nullable: false),
                    ApplicationStatusID = c.Int(nullable: false),
                    ApplicationDate = c.DateTime(nullable: false),
                    ActivityID = c.Int(nullable: false),
                    Forename = c.String(nullable: false, maxLength: 50),
                    Surname = c.String(nullable: false, maxLength: 50),
                    DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                    NationalityID = c.Int(nullable: false),
                    ContactTypeID = c.Int(nullable: false),
                    IsPregnant = c.Boolean(nullable: false),
                    ApplicationStatusReason = c.String(maxLength: 1000),
                    ApplicationEligible = c.Boolean(),
                    HOALevelOfNeedDate = c.DateTime(),
                    ApplicationLevelOfNeedID = c.Int(),
                    HOACaseRef = c.Int(),
                    HOAOutcome = c.String(maxLength: 1000),
                    HOAOutcomeDate = c.DateTime(),
                    HOACaseIsOpen = c.Boolean(),
                    HOAEligabilitySet = c.Boolean(),
                    ApplicationClosedDate = c.DateTime(),
                    LatestMoveDate = c.DateTime(storeType: "date"),
                    HOAEligible = c.Boolean(),
                    HOALevelOfNeedID = c.Int(),
                    MoveReason = c.String(maxLength: 255, unicode: false),
                    AppointmentDate = c.DateTime(),
                    ActivityStatusID = c.Int(),
                    NAME = c.String(maxLength: 20),
                    Gender = c.String(maxLength: 20),
                    Address1 = c.String(maxLength: 255),
                    Address2 = c.String(maxLength: 255),
                    Address3 = c.String(maxLength: 255),
                    Address4 = c.String(maxLength: 255),
                    PostCode = c.String(maxLength: 16),
                    Relationship = c.String(maxLength: 20),
                    Nationality = c.String(maxLength: 50),
                    Ethnicity = c.String(maxLength: 50),
                    TelNum = c.String(maxLength: 25),
                    MobileNum = c.String(maxLength: 25),
                    Email = c.String(maxLength: 255),
                    PregnancyDueDate = c.DateTime(storeType: "date"),
                    ActivityLocationID = c.Int(),
                })
                .PrimaryKey(t => new { t.CustomerApplicationId, t.ApplicationStatusID, t.ApplicationDate, t.ActivityID, t.Forename, t.Surname, t.DateOfBirth, t.NationalityID, t.ContactTypeID, t.IsPregnant });

            CreateTable(
                "dbo.v_HOAOutcomes",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    ApplicationDate = c.DateTime(nullable: false),
                    CaseRefNumber = c.Int(nullable: false),
                    ApplicationLevelOfNeedID = c.Int(),
                    ApplicationEligable = c.Boolean(),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.ApplicationDate, t.CaseRefNumber });

            CreateTable(
                "dbo.v_HouseholdComposition",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    HouseholdComposition = c.String(nullable: false, maxLength: 31, unicode: false),
                    LevelOfNeed = c.String(nullable: false, maxLength: 50),
                    ApplicantAgeBand = c.String(maxLength: 15, unicode: false),
                    ApplicantAge = c.Int(),
                    ApplicantEthnicity = c.String(maxLength: 50),
                    TenureBand = c.String(maxLength: 14, unicode: false),
                    TenureLengthMonths = c.Int(),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.HouseholdComposition, t.LevelOfNeed });

            CreateTable(
                "dbo.v_MutualExchangeProperties",
                c => new
                {
                    CustomerApplicationID = c.Int(nullable: false),
                    ApplicationDate = c.DateTime(nullable: false),
                    SchemeID = c.Int(nullable: false),
                    PaymentCycle = c.String(nullable: false, maxLength: 17, unicode: false),
                    VoidDate = c.DateTime(nullable: false),
                    MarketingInformationWeb = c.String(nullable: false, maxLength: 1, unicode: false),
                    MutualExchangeProperty = c.Int(nullable: false),
                    ApplicationLevelOfNeedID = c.Int(),
                    MatchingEarliestMoveDate = c.DateTime(storeType: "date"),
                    PropertyCode = c.String(maxLength: 50, unicode: false),
                    AgeCriteria = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    PropertyType = c.String(maxLength: 20, unicode: false),
                    PropertyNumBedrooms = c.Int(),
                    SubNeighbourhoodCode = c.String(maxLength: 30, unicode: false),
                    FlatFloorLevel = c.Int(),
                    LiftAccess = c.Boolean(),
                    Careline = c.Boolean(),
                    HeatingType = c.String(maxLength: 50),
                    Garden = c.Boolean(),
                    HasStepsToAccess = c.Boolean(),
                    NumStepsToAccess = c.Int(),
                    IsWheelChairAdapted = c.Boolean(),
                    HasRampedAccess = c.Boolean(),
                    IsLevelAccessProperty = c.Boolean(),
                    HasStairlift = c.Boolean(),
                    HasWalkInShower = c.Boolean(),
                    HasStepInShower = c.Boolean(),
                    Rent = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    ServiceCharges = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    OtherCharges = c.Decimal(precision: 28, scale: 4, storeType: "numeric"),
                    TotalRent = c.Decimal(precision: 30, scale: 4, storeType: "numeric"),
                    MatchingTrustCare = c.Boolean(),
                    MatchingGarden = c.Boolean(),
                    MatchingWheelChairAdapted = c.Boolean(),
                    MatchingRampedAccess = c.Boolean(),
                    MatchingLevelAccessProperty = c.Boolean(),
                    MatchingStairlift = c.Boolean(),
                    MatchingWalkInShower = c.Boolean(),
                    MatchingStepInShower = c.Boolean(),
                    MatchingLiftServed = c.Boolean(),
                    MatchingFloorlevel = c.Int(),
                    MatchingApplicantsAge = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                    Address1 = c.String(maxLength: 255),
                    Address2 = c.String(maxLength: 255),
                    Address3 = c.String(maxLength: 255),
                    Address4 = c.String(maxLength: 255),
                    PostCode = c.String(maxLength: 16),
                    LandLord = c.String(maxLength: 50),
                    Longitude = c.Double(),
                    Latitude = c.Double(),
                    Title = c.String(maxLength: 50, unicode: false),
                    Description = c.String(maxLength: 538),
                })
                .PrimaryKey(t => new { t.CustomerApplicationID, t.ApplicationDate, t.SchemeID, t.PaymentCycle, t.VoidDate, t.MarketingInformationWeb, t.MutualExchangeProperty });

            CreateTable(
                "dbo.v_ShapePostcodes",
                c => new
                {
                    ShapeId = c.Int(nullable: false),
                    LocalId = c.Int(nullable: false),
                    PostCode = c.String(maxLength: 10),
                })
                .PrimaryKey(t => new { t.ShapeId, t.LocalId });

            CreateTable(
                "dbo.v_SubNeighbourhood",
                c => new
                {
                    SubNeighbourhoodId = c.Int(nullable: false),
                    SubNeighbourhoodCode = c.String(nullable: false, maxLength: 15),
                    SubNeighbourhoodName = c.String(nullable: false, maxLength: 50),
                    NeighbourhoodCode = c.String(nullable: false, maxLength: 15),
                    NeighbourhoodName = c.String(nullable: false, maxLength: 50),
                    ManagementAreaCode = c.String(nullable: false, maxLength: 15),
                    ManagementAreaDescription = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                    ShapeId = c.Int(),
                    SubNeighbourhoodCodeComb = c.String(maxLength: 30, unicode: false),
                })
                .PrimaryKey(t => new { t.SubNeighbourhoodId, t.SubNeighbourhoodCode, t.SubNeighbourhoodName, t.NeighbourhoodCode, t.NeighbourhoodName, t.ManagementAreaCode, t.ManagementAreaDescription, t.Active });

            CreateTable(
                "dbo.v_VBLTenancySearch",
                c => new
                {
                    PropertyCode = c.String(nullable: false, maxLength: 32, unicode: false),
                    IBSPropertyType = c.String(maxLength: 100),
                    SchemeID = c.Int(nullable: false),
                    SubNeighbourhoodId = c.Int(nullable: false),
                    SubNeighbourhoodCode = c.String(maxLength: 15),
                    SubNeighbourhoodName = c.String(maxLength: 50),
                    NeighbourhoodCode = c.String(maxLength: 15),
                    NeighbourhoodName = c.String(maxLength: 50),
                    LiftAccess = c.Int(nullable: false),
                    Careline = c.Int(nullable: false),
                    HeatingTypeID = c.Int(nullable: false),
                    Garden = c.Int(nullable: false),
                    StepsToAccess = c.Int(nullable: false),
                    IsWheelChairAdapted = c.Int(nullable: false),
                    HasRampedAccess = c.Int(nullable: false),
                    IsLevelAccessProperty = c.Int(nullable: false),
                    HasStairlift = c.Int(nullable: false),
                    HasWalkInShower = c.Int(nullable: false),
                    HasStepInShower = c.Int(nullable: false),
                    IBSTypeCode = c.String(maxLength: 4, unicode: false),
                    IBSCatCode = c.String(maxLength: 4, unicode: false),
                    TenancyEnd = c.DateTime(nullable: false),
                    DateOfBirth = c.DateTime(nullable: false),
                    MainTenant = c.Int(nullable: false),
                    VoidId = c.Int(nullable: false),
                    TerminationTypeID = c.Int(nullable: false),
                    IBSTerminating = c.Int(nullable: false),
                    TenancyType = c.String(maxLength: 9, unicode: false),
                    CustomerApplicationID = c.Int(nullable: false),
                    Address1 = c.String(maxLength: 100, unicode: false),
                    Address2 = c.String(maxLength: 100, unicode: false),
                    Address3 = c.String(maxLength: 100, unicode: false),
                    Address4 = c.String(maxLength: 100, unicode: false),
                    Postcode = c.String(maxLength: 16, unicode: false),
                    AgeCriteria = c.Decimal(precision: 10, scale: 2),
                    PetsAllowed = c.String(maxLength: 1, unicode: false),
                    PropertyNumBedrooms = c.Int(),
                    FlatFloorLevel = c.Int(),
                    BlockID = c.Int(),
                    TenancyStart = c.DateTime(),
                    Forename = c.String(maxLength: 80, unicode: false),
                    Surname = c.String(maxLength: 80, unicode: false),
                    TenancyRef = c.String(maxLength: 19, unicode: false),
                    TenantCode = c.String(maxLength: 32, unicode: false),
                })
                .PrimaryKey(t => new { t.PropertyCode, t.VoidId, t.CustomerApplicationID });

            CreateTable(
                "dbo.vAdviceEndToEndTimes",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    E2EDays = c.Int(),
                    ReceptionVisitDate = c.DateTime(),
                    AdviceOutcome = c.String(maxLength: 100),
                    AdviceOutcomeDate = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessingOfficer = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.vCaseStatus",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    RehousingRequired = c.Boolean(nullable: false),
                    AllocatedDateTime = c.DateTime(),
                    AllocatedOfficer = c.String(maxLength: 50),
                    CaseStatusDescription = c.String(maxLength: 50),
                    CaseClosed = c.Boolean(),
                    CustomerName = c.String(maxLength: 152),
                    Address = c.String(maxLength: 258),
                    ContactDetails = c.String(maxLength: 152),
                    DOB = c.DateTime(),
                    ApproachReason = c.String(maxLength: 50),
                    Area1 = c.String(maxLength: 50),
                    Area2 = c.String(maxLength: 50),
                    Area3 = c.String(maxLength: 50),
                    Area4 = c.String(maxLength: 50),
                    BedroomNeed = c.Short(),
                })
                .PrimaryKey(t => new { t.CaseRefNumber, t.RehousingRequired });

            CreateTable(
                "dbo.vHomelessEndToEndTimes",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    E2EDays = c.Int(),
                    ReceptionDate = c.DateTime(),
                    AdviceOutcome = c.String(maxLength: 100),
                    AdviceOutcomeDate = c.DateTime(),
                    HomelessOutcome = c.String(maxLength: 50),
                    HomelessOutcomeDate = c.DateTime(),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessingOfficer = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.vInterviewLength",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    AssessorUserID = c.String(maxLength: 50),
                    AssessingOfficer = c.String(maxLength: 50),
                    CustomerName = c.String(maxLength: 152),
                    AssessmentInterviewDate = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    EndOfInterviewDateTime = c.DateTime(),
                    InterviewTime = c.Int(),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.vOpenAssessments",
                c => new
                {
                    ReceptionIndex = c.Int(nullable: false),
                    CaseOpen = c.Int(nullable: false),
                    CaseClosed = c.Int(nullable: false),
                    CaseRefNumber = c.Int(),
                    LocationId = c.String(maxLength: 3),
                    AssessorUserID = c.String(maxLength: 50),
                    ReceptionDateTime = c.DateTime(storeType: "date"),
                })
                .PrimaryKey(t => new { t.ReceptionIndex, t.CaseOpen, t.CaseClosed });

            CreateTable(
                "dbo.vPropertyMatching",
                c => new
                {
                    PropertyID = c.Int(nullable: false),
                    MinimumClientAge = c.Int(nullable: false),
                    DateImported = c.DateTime(),
                    LandlordDescription = c.String(maxLength: 50),
                    LandlordPropertyRef = c.String(maxLength: 50),
                    Address = c.String(maxLength: 291),
                    PostCode = c.String(maxLength: 10),
                    PostCodeArea = c.String(maxLength: 10),
                    Status = c.String(maxLength: 50),
                    NumberBedrooms = c.Int(),
                    AllocatedCustomerID = c.Int(),
                    AllocatedDateTime = c.DateTime(),
                    AllocationsOfficerID = c.String(maxLength: 50),
                    HousingOfficerID = c.String(maxLength: 50),
                    OptionsOfficerID = c.String(maxLength: 50),
                    StatusID = c.Int(),
                    UnderOffer = c.Boolean(),
                    LastUpdatedDateTime = c.DateTime(),
                    CaseRefNumber = c.Int(),
                    AllocatedCustomer = c.String(maxLength: 154),
                })
                .PrimaryKey(t => new { t.PropertyID, t.MinimumClientAge });

            CreateTable(
                "dbo.vReceptionSearch",
                c => new
                {
                    PACustomerID = c.Int(nullable: false),
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionIndex = c.Int(nullable: false),
                    Title = c.String(maxLength: 50),
                    Forename = c.String(maxLength: 50),
                    Surname = c.String(maxLength: 50),
                    Address = c.String(maxLength: 255),
                    DoB = c.DateTime(),
                    Warning = c.Boolean(),
                    CaseClosed = c.Int(),
                    HighlySensitive = c.Int(),
                })
                .PrimaryKey(t => new { t.PACustomerID, t.CaseRefNumber, t.ReceptionIndex });

            CreateTable(
                "dbo.vReceptionWaitingTimes",
                c => new
                {
                    CaseRefNumber = c.Int(nullable: false),
                    ReceptionDateTime = c.DateTime(),
                    ReceptionDate = c.DateTime(),
                    AssessmentInterviewDateTime = c.DateTime(),
                    ReceptionWaitingTime = c.Int(),
                    ReceptionDay = c.String(maxLength: 10, unicode: false),
                    ReceptionHour = c.Int(),
                    AllocatedUserID = c.String(maxLength: 50),
                    AllocatedUser = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.CaseRefNumber);

            CreateTable(
                "dbo.vWaitingList",
                c => new
                {
                    CustomerRef = c.Int(nullable: false),
                    CustomerName = c.String(maxLength: 152),
                    Area1 = c.String(maxLength: 50),
                    Area2 = c.String(maxLength: 50),
                    Area3 = c.String(maxLength: 50),
                    Area4 = c.String(maxLength: 50),
                    NumberOfBedrooms = c.Short(),
                    AssessmentInterviewDate = c.DateTime(),
                    DaysSinceInterview = c.Int(),
                })
                .PrimaryKey(t => t.CustomerRef);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCaseNotes", "CaseRefNumber", "dbo.tblHOAssessment");
            DropForeignKey("dbo.CustomerInterestStatusReasons", "CustomerInterestID", "dbo.CustomerInterest");
            DropForeignKey("dbo.AuditLogDetails", "AuditLogId", "dbo.AuditLogs");
            DropIndex("dbo.tblCaseNotes", new[] { "CaseRefNumber" });
            DropIndex("dbo.CustomerInterestStatusReasons", new[] { "CustomerInterestID" });
            DropIndex("dbo.AuditLogDetails", new[] { "AuditLogId" });
            DropTable("dbo.vWaitingList");
            DropTable("dbo.vReceptionWaitingTimes");
            DropTable("dbo.vReceptionSearch");
            DropTable("dbo.vPropertyMatching");
            DropTable("dbo.vOpenAssessments");
            DropTable("dbo.vInterviewLength");
            DropTable("dbo.vHomelessEndToEndTimes");
            DropTable("dbo.vCaseStatus");
            DropTable("dbo.vAdviceEndToEndTimes");
            DropTable("dbo.v_VBLTenancySearch");
            DropTable("dbo.v_SubNeighbourhood");
            DropTable("dbo.v_ShapePostcodes");
            DropTable("dbo.v_MutualExchangeProperties");
            DropTable("dbo.v_HouseholdComposition");
            DropTable("dbo.v_HOAOutcomes");
            DropTable("dbo.v_HOAInterfaceContacts");
            DropTable("dbo.v_HOAInterface");
            DropTable("dbo.v_Applications");
            DropTable("dbo.v_ApplicationMatchFilters");
            DropTable("dbo.v_ApplicationMatchCustomerInterestsVoids");
            DropTable("dbo.v_ApplicationMatchCustomerInterests");
            DropTable("dbo.tsubTASuppInvoices");
            DropTable("dbo.tsubTAPlacement");
            DropTable("dbo.tsubTAPlacementPerson");
            DropTable("dbo.tsubTACancellation");
            DropTable("dbo.tsubTACancellationNight");
            DropTable("dbo.tsubTABookingCall");
            DropTable("dbo.tsubRevisits_BKDelDel");
            DropTable("dbo.tsubRevisits");
            DropTable("dbo.tsubHomelessnessReviews");
            DropTable("dbo.tsubHomelessness");
            DropTable("dbo.tsubHomelessness_BKDelDel");
            DropTable("dbo.tsubHOAQuestionAnswers");
            DropTable("dbo.tsubHOAQstnAdviceItem");
            DropTable("dbo.tsubHOAExclusion");
            DropTable("dbo.tsubHOAEvents");
            DropTable("dbo.tsubFamilyComposition");
            DropTable("dbo.tsubCheque");
            DropTable("dbo.tsubCaseFileLocn");
            DropTable("dbo.Title");
            DropTable("dbo.TenancyType");
            DropTable("dbo.tblUserUpdates");
            DropTable("dbo.tblUserExtraScanLocn");
            DropTable("dbo.tblUserChangeRequests");
            DropTable("dbo.tblUserAdmin");
            DropTable("dbo.tblUserAdminbk");
            DropTable("dbo.tblUserAdminAudit");
            DropTable("dbo.tblTempAccommodation");
            DropTable("dbo.tblTempAccommodationAudit");
            DropTable("dbo.tblTempAccommodation_BKDelDel");
            DropTable("dbo.tblSelectedColumns");
            DropTable("dbo.tblReportsTemp");
            DropTable("dbo.tblReportsTempAudit");
            DropTable("dbo.tblRehousedCustomersAudit");
            DropTable("dbo.tblRehousedCustomers");
            DropTable("dbo.tblReception");
            DropTable("dbo.tblReceptionAudit");
            DropTable("dbo.tblPropertyAllocation");
            DropTable("dbo.tblPropertyAllocationAudit");
            DropTable("dbo.tblLinkedTablesAudit");
            DropTable("dbo.tblLinkedTables");
            DropTable("dbo.tblHOAssessmentbk4");
            DropTable("dbo.tblHOAssessmentBK_DelDel");
            DropTable("dbo.tblHOAssessmentAudit");
            DropTable("dbo.tblHOAssessment_BKDelDel");
            DropTable("dbo.tblHOAbk");
            DropTable("dbo.tblHOAbk4");
            DropTable("dbo.tblHOAbk3");
            DropTable("dbo.tblHOAbk2");
            DropTable("dbo.tblErrorMessages");
            DropTable("dbo.tblEmailSetting");
            DropTable("dbo.tblDependantsAudit");
            DropTable("dbo.tblDependants_BKDelDel");
            DropTable("dbo.tblDependants");
            DropTable("dbo.tblCaseNotesWK");
            DropTable("dbo.tblCaseNotesBK");
            DropTable("dbo.tblCaseNotesBK2");
            DropTable("dbo.tblCaseNotesAudit");
            DropTable("dbo.tblCaseNotes_BKDelDel");
            DropTable("dbo.tblHOAssessment");
            DropTable("dbo.tblCaseNotes");
            DropTable("dbo.tblBnBDataSendLog");
            DropTable("dbo.tblBnBData");
            DropTable("dbo.tblBnBDataBK");
            DropTable("dbo.tblBnBDataBK2");
            DropTable("dbo.tbl_PropertyMigratedAccent");
            DropTable("dbo.tbl_PropertyAudit");
            DropTable("dbo.tbl_Property");
            DropTable("dbo.tbl_Messages");
            DropTable("dbo.tbl_LookupData");
            DropTable("dbo.tbl_KeyFeature");
            DropTable("dbo.tbl_CustomerFeedback");
            DropTable("dbo.tbl_AudRejections");
            DropTable("dbo.tbl_Audit_CustomerApplication");
            DropTable("dbo.tbl_ActiveManagementAreas");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.SupportWorker");
            DropTable("dbo.ResidencyType");
            DropTable("dbo.Relationship");
            DropTable("dbo.qrpt_TempAccomodationUse");
            DropTable("dbo.PropertyType");
            DropTable("dbo.PropertySize");
            DropTable("dbo.PropertyFloorLevel");
            DropTable("dbo.Pet");
            DropTable("dbo.NationalityType");
            DropTable("dbo.MoveReason");
            DropTable("dbo.MatchingSchemes");
            DropTable("dbo.MatchingPropertyTypes");
            DropTable("dbo.MatchingNumBeds");
            DropTable("dbo.MatchingLocations");
            DropTable("dbo.MatchingHeatingTypes");
            DropTable("dbo.lstUserLocation");
            DropTable("dbo.lstUserLocationAudit");
            DropTable("dbo.lstTitle");
            DropTable("dbo.lstTitleAudit");
            DropTable("dbo.lstTAPlacementTransType");
            DropTable("dbo.lstTACancelReason");
            DropTable("dbo.lstRevisitReason");
            DropTable("dbo.lstReviewTypes");
            DropTable("dbo.lstReviewDecOut");
            DropTable("dbo.lstReviewAgainst");
            DropTable("dbo.lstRelationship");
            DropTable("dbo.lstRelationshipAudit");
            DropTable("dbo.lstQuestion");
            DropTable("dbo.lstQuestionnaireSubSection");
            DropTable("dbo.lstQuestionnaireSection");
            DropTable("dbo.lstQuestionnaire");
            DropTable("dbo.lstQuestionEvent");
            DropTable("dbo.lstQuestionChangeType");
            DropTable("dbo.lstQuestionAltText");
            DropTable("dbo.lstQuestionAdviceItem");
            DropTable("dbo.lstPriorityNeedsReason");
            DropTable("dbo.lstPriorityNeedsReasonAudit");
            DropTable("dbo.lstPlacementReasons");
            DropTable("dbo.lstOutcomeResult");
            DropTable("dbo.lstOutcomeResultAudit");
            DropTable("dbo.lstOutcomeCategoryAudit");
            DropTable("dbo.lstOutcomeCategory");
            DropTable("dbo.lstNumberBedroomsAudit");
            DropTable("dbo.lstNumberBedrooms");
            DropTable("dbo.lstNationalityType");
            DropTable("dbo.lstNationalityTypeAudit");
            DropTable("dbo.lstMaritalStatusAudit");
            DropTable("dbo.lstMaritalStatus");
            DropTable("dbo.lstLocalAuthority");
            DropTable("dbo.lstLevelOfNeed");
            DropTable("dbo.lstLevelOfNeedAudit");
            DropTable("dbo.lstHomelessWhereStayingNow");
            DropTable("dbo.lstHomelessWhereStayingNowAudit");
            DropTable("dbo.lstHomelessReason");
            DropTable("dbo.lstHomelessReasonAudit");
            DropTable("dbo.lstHomelessP1eCategoriesNotHavingTempAccomAudit");
            DropTable("dbo.lstHomelessP1eCategoriesNotHavingTempAccom");
            DropTable("dbo.lstHomelessP1eCategoriesHavingTempAccomAudit");
            DropTable("dbo.lstHomelessP1eCategoriesHavingTempAccom");
            DropTable("dbo.lstHomelessOutcomeResult");
            DropTable("dbo.lstHomelessOutcomeResultAudit");
            DropTable("dbo.lstHomelessnessEligibilityResponse");
            DropTable("dbo.lstHomelessnessEligibilityResponseAudit");
            DropTable("dbo.lstHomelessDecision");
            DropTable("dbo.lstHomelessDecisionAudit");
            DropTable("dbo.lstGender");
            DropTable("dbo.lstGenderAudit");
            DropTable("dbo.lstFloorLevel");
            DropTable("dbo.lstFloorLevelAudit");
            DropTable("dbo.lstFamilyComposition");
            DropTable("dbo.lstFamilyCompositionAudit");
            DropTable("dbo.lstEvent");
            DropTable("dbo.lstEthnicityAudit");
            DropTable("dbo.lstEthnicity");
            DropTable("dbo.lstEligibilityRightsAudit");
            DropTable("dbo.lstEligibilityRights");
            DropTable("dbo.lstContactType");
            DropTable("dbo.lstContactTypeAudit");
            DropTable("dbo.lstCBLBand");
            DropTable("dbo.lstCBLBandAudit");
            DropTable("dbo.lstCaseStatusAudit");
            DropTable("dbo.lstCaseStatus");
            DropTable("dbo.lstCaseNoteType");
            DropTable("dbo.lstCaseNoteTypeAudit");
            DropTable("dbo.lstCallOutcome");
            DropTable("dbo.lstBnBReasons");
            DropTable("dbo.lstArea");
            DropTable("dbo.lstAreaAudit");
            DropTable("dbo.lstApproachReason");
            DropTable("dbo.lstApproachReasonAudit");
            DropTable("dbo.lstAnswerType");
            DropTable("dbo.lstAgeToAgeGroup");
            DropTable("dbo.lstAgeToAgeGroupAudit");
            DropTable("dbo.lstAgeGroup");
            DropTable("dbo.lstAgeGroupAudit");
            DropTable("dbo.lstAdviceReason");
            DropTable("dbo.lstAdviceItemType");
            DropTable("dbo.lstAdviceItem");
            DropTable("dbo.lstAccomodationProvider");
            DropTable("dbo.lstAccommodationType");
            DropTable("dbo.lstAccommodationTypeAudit");
            DropTable("dbo.lst198213Sources");
            DropTable("dbo.Logos");
            DropTable("dbo.LevelOfNeed");
            DropTable("dbo.Landlord");
            DropTable("dbo.IncomeType");
            DropTable("dbo.IncomeFrequency");
            DropTable("dbo.HOAAppointmentLocation");
            DropTable("dbo.HeatingType");
            DropTable("dbo.Gender");
            DropTable("dbo.Ethnicity");
            DropTable("dbo.CustomerPet");
            DropTable("dbo.CustomerNote");
            DropTable("dbo.CustomerInterestStatus");
            DropTable("dbo.CustomerInterestStatusReasons");
            DropTable("dbo.CustomerInterest");
            DropTable("dbo.CustomerApplication");
            DropTable("dbo.CustomerApplication_AL0143");
            DropTable("dbo.ContactType");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactIncome");
            DropTable("dbo.bkp_CustomerNote_Note_Audit");
            DropTable("dbo.AuditSupportWorker");
            DropTable("dbo.AuditMatchResults");
            DropTable("dbo.AuditMainAddress");
            DropTable("dbo.AuditLogs");
            DropTable("dbo.AuditLogDetails");
            DropTable("dbo.AuditCustomerValues");
            DropTable("dbo.AuditCustomerPet");
            DropTable("dbo.AuditCustomerInterestStatusReasons");
            DropTable("dbo.AuditCustomerInterest");
            DropTable("dbo.AuditCustomerContactDetails");
            DropTable("dbo.AuditCustomerCircumstances");
            DropTable("dbo.AuditCustomerApplication");
            DropTable("dbo.AuditContact");
            DropTable("dbo.AuditContactIncome");
            DropTable("dbo.AuditApplicantEligibility");
            DropTable("dbo.ApplicationStatus");
            DropTable("dbo.ApplicationSelections");
            DropTable("dbo.ApplicantEligibility");
        }
    }
}
