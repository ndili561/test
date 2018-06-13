using InCoreLib.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VBLEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactBy",
                c => new
                    {
                        ContactById = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        ConcurrencyCheck = c.Binary(),
                    })
                .PrimaryKey(t => t.ContactById);
            
            CreateTable(
                "dbo.Scheme",
                c => new
                    {
                        SchemeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.SchemeId);
            
            CreateTable(
                "dbo.SchemeBlocks",
                c => new
                    {
                        SchemeId = c.Int(nullable: false),
                        BlockRef = c.String(nullable: false, maxLength: 128),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => new { t.SchemeId, t.BlockRef });
            
            CreateTable(
                "dbo.SubNeighbourhoods",
                c => new
                    {
                        SubNeighbourhoodId = c.Int(nullable: false, identity: true),
                        SubNeighbourhoodCode = c.String(),
                        SubNeighbourhoodName = c.String(),
                        NeighbourhoodCode = c.String(),
                        NeighbourhoodName = c.String(),
                        ManagementAreaCode = c.String(),
                        ManagementAreaDescription = c.String(),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        ShapeId = c.Int(),
                        SubNeighbourhoodCodeComb = c.String(),
                        OldShapeId = c.Int(),
                    })
                .PrimaryKey(t => t.SubNeighbourhoodId);
            
            CreateTable(
                "dbo.VBLAddresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        LivedAtAddressYears = c.Int(),
                        LivedAtAddressMonths = c.Int(),
                        AddressType = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        AddressLine4 = c.String(),
                        PostCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                        VBLContact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.VBLContacts", t => t.VBLContact_ContactId)
                .ForeignKey("dbo.VBLApplications", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.VBLContact_ContactId);
            
            CreateTable(
                "dbo.VBLApplications",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        ApplicationStatusID = c.Int(nullable: false),
                        ApplicationStatusReason = c.String(),
                        ApplicationDate = c.DateTime(nullable: false),
                        ApplicationEligible = c.Boolean(),
                        HOALevelOfNeedDate = c.DateTime(),
                        ApplicationLevelOfNeedID = c.Int(),
                        DataProtectionIsPrinted = c.Boolean(),
                        DataProtectionIsSigned = c.Boolean(),
                        DataProtectionConsented = c.Boolean(),
                        HOACaseRef = c.Int(),
                        HOAContact = c.String(),
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
                        EarliestMoveDate = c.DateTime(),
                        LatestMoveDate = c.DateTime(),
                        ApplicationLevelOfNeedReason = c.String(maxLength: 1000),
                        AssessmentLastModifiedInfo = c.String(),
                        ResidencyTypeId = c.Int(),
                        LandLordName = c.String(maxLength: 255),
                        MoveReasonId = c.Int(),
                        TenancyTypeId = c.Int(),
                        LandlordId = c.Int(),
                        LeaveVacantProperty = c.Boolean(),
                        IsSignedDeclarationUploaded = c.Boolean(),
                        MatchToMutualExchage = c.Boolean(),
                        MutualExchagePropertyDetailId = c.Int(),
                        CustomerInterestId = c.Int(),
                        RequestedPropertymatchDetailId = c.Int(),
                        AddressId = c.Int(),
                        LevelOfNeedId = c.Int(),
                        IsMainTenant = c.Boolean(nullable: false),
                        DateMovedIn = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.ApplicationStatus", t => t.ApplicationStatusID, cascadeDelete: true)
                .ForeignKey("dbo.VBLCustomerInterests", t => t.CustomerInterestId)
                .ForeignKey("dbo.Landlord", t => t.LandlordId)
                .ForeignKey("dbo.LevelOfNeed", t => t.LevelOfNeedId)
                .ForeignKey("dbo.MoveReason", t => t.MoveReasonId)
                .ForeignKey("dbo.ResidencyType", t => t.ResidencyTypeId)
                .ForeignKey("dbo.TenancyType", t => t.TenancyTypeId)
                .Index(t => t.ApplicationStatusID)
                .Index(t => t.ResidencyTypeId)
                .Index(t => t.MoveReasonId)
                .Index(t => t.TenancyTypeId)
                .Index(t => t.LandlordId)
                .Index(t => t.CustomerInterestId)
                .Index(t => t.LevelOfNeedId);
            
            CreateTable(
                "dbo.VBLContacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        NationalInsuranceNumber = c.String(),
                        ContactTypeId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        MainTenantOnTenancy = c.Boolean(nullable: false),
                        GenderId = c.Int(nullable: false),
                        EthnicityId = c.Int(nullable: false),
                        NationalityTypeId = c.Int(nullable: false),
                        Forename = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsPregnant = c.Boolean(nullable: false),
                        PregnancyDueDate = c.DateTime(),
                        LivedInUKForFiveYears = c.Boolean(nullable: false),
                        TenantcyReference = c.String(),
                        Active = c.Boolean(nullable: false),
                        IsMovingIn = c.Boolean(nullable: false),
                        PreferredLanguageId = c.Int(nullable: false),
                        ImmigrationControl = c.Boolean(nullable: false),
                        PublicFunds = c.Boolean(nullable: false),
                        PreferredContactTime = c.String(),
                        NoIncomeReason = c.String(),
                        DisabilityImpactOnHousingNeed = c.String(),
                        OtherSupportDetails = c.String(),
                        RelationshipId = c.Int(),
                        LanguageId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactType", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Ethnicity", t => t.EthnicityId, cascadeDelete: true)
                .ForeignKey("dbo.Gender", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.NationalityType", t => t.NationalityTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PreferredLanguages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Relationship", t => t.RelationshipId)
                .ForeignKey("dbo.Title", t => t.TitleId, cascadeDelete: true)
                .ForeignKey("dbo.VBLApplications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.ContactTypeId)
                .Index(t => t.TitleId)
                .Index(t => t.GenderId)
                .Index(t => t.EthnicityId)
                .Index(t => t.NationalityTypeId)
                .Index(t => t.RelationshipId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.VBLContactByDetails",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        ContactById = c.Int(nullable: false),
                        ContactValue = c.String(),
                        ContactText = c.String(),
                        ConcurrencyCheck = c.Binary(),
                    })
                .PrimaryKey(t => new { t.ContactId, t.ContactById })
                .ForeignKey("dbo.ContactBy", t => t.ContactById, cascadeDelete: true)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.ContactById);
            
            CreateTable(
                "dbo.VBLDisabilityDetails",
                c => new
                    {
                        DisabilityDetailId = c.Int(nullable: false, identity: true),
                        DisabilityTypeId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Comment = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DisabilityDetailId)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.VBLDisabilityTypes", t => t.DisabilityTypeId, cascadeDelete: true)
                .Index(t => t.DisabilityTypeId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.VBLDisabilityTypes",
                c => new
                    {
                        DisabilityTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DisabilityTypeId);
            
            CreateTable(
                "dbo.VBLIncomeDetails",
                c => new
                    {
                        IncomeDetailId = c.Int(nullable: false, identity: true),
                        IncomesComment = c.String(),
                        IncomeTypeId = c.Int(nullable: false),
                        IncomeFrequencyId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContactId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IncomeDetailId)
                .ForeignKey("dbo.IncomeFrequency", t => t.IncomeFrequencyId, cascadeDelete: true)
                .ForeignKey("dbo.IncomeType", t => t.IncomeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.IncomeTypeId)
                .Index(t => t.IncomeFrequencyId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.VBLIncommunitiesRelationshipTypes",
                c => new
                    {
                        IncommunitiesRelationshipTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IncommunitiesRelationshipTypeId);
            
            CreateTable(
                "dbo.PreferredLanguages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.VBLReceivingSupportDetails",
                c => new
                    {
                        ReceivingSupportDetailId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SupportTypeId = c.Int(nullable: false),
                        SupportProviderId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        ThirdPartyAuth = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReceivingSupportDetailId)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.VBLSupportProviders", t => t.SupportProviderId, cascadeDelete: true)
                .ForeignKey("dbo.VBLSupportTypes", t => t.SupportTypeId, cascadeDelete: true)
                .Index(t => t.SupportTypeId)
                .Index(t => t.SupportProviderId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.VBLSupportContactByDetails",
                c => new
                    {
                        SupportDetailId = c.Int(nullable: false),
                        ContactById = c.Int(nullable: false),
                        ContactValue = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                        VblReceivingSupportDetail_ReceivingSupportDetailId = c.Int(),
                    })
                .PrimaryKey(t => new { t.SupportDetailId, t.ContactById })
                .ForeignKey("dbo.ContactBy", t => t.ContactById, cascadeDelete: true)
                .ForeignKey("dbo.VBLReceivingSupportDetails", t => t.VblReceivingSupportDetail_ReceivingSupportDetailId)
                .Index(t => t.ContactById)
                .Index(t => t.VblReceivingSupportDetail_ReceivingSupportDetailId);
            
            CreateTable(
                "dbo.VBLSupportProviders",
                c => new
                    {
                        SupportProviderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SupportProviderId);
            
            CreateTable(
                "dbo.VBLSupportTypes",
                c => new
                    {
                        SupportTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SupportTypeId);
            
            CreateTable(
                "dbo.VBLRequestedSupportDetails",
                c => new
                    {
                        RequestedSupportDetailId = c.Int(nullable: false, identity: true),
                        SupportTypeId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.RequestedSupportDetailId)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.VBLSupportTypes", t => t.SupportTypeId, cascadeDelete: true)
                .Index(t => t.SupportTypeId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.VBLTenantDetails",
                c => new
                    {
                        TenantDetailId = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        TenantCode = c.String(),
                        TenancyReference = c.String(),
                        TenancyStartDate = c.DateTime(),
                        TenancyEndDate = c.DateTime(),
                        MainTenant = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TenantDetailId)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.VBLCustomerInterests",
                c => new
                    {
                        CustomerInterestId = c.Int(nullable: false, identity: true),
                        CustomerApplicationId = c.Int(nullable: false),
                        PropertyCode = c.Int(nullable: false),
                        VoidId = c.Int(nullable: false),
                        CustomerInterestStatusId = c.Int(nullable: false),
                        VoidContactId = c.Int(nullable: false),
                        IsPreViewingUndertaken = c.Boolean(nullable: false),
                        StatusReasonsDate = c.DateTime(nullable: false),
                        OutcomeNotes = c.String(),
                        CustomerDecision = c.Boolean(nullable: false),
                        Notes = c.String(),
                        TaskId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerInterestId)
                .ForeignKey("dbo.CustomerInterestStatus", t => t.CustomerInterestStatusId, cascadeDelete: true)
                .Index(t => t.CustomerInterestStatusId);
            
            CreateTable(
                "dbo.VBLApplicationHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationActivity = c.Int(nullable: false),
                        ApplicationChangeType = c.Int(nullable: false),
                        ApplicationChangeDescription = c.String(),
                        ApplicationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VBLApplications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.VBLDocuments",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        DocumentName = c.String(maxLength: 250),
                        DocumentType = c.Int(nullable: false),
                        DocumentPath = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.VBLApplications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.VBLMutualExchagePropertyDetails",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        PropertyCode = c.String(),
                        PropertyIsTerminating = c.Boolean(nullable: false),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PropertyNumberOfBedrooms = c.Int(nullable: false),
                        AgeCritera = c.Int(nullable: false),
                        HeatingTypeId = c.Int(nullable: false),
                        FlatFloorLevel = c.Int(nullable: false),
                        HasStepsToAccess = c.Boolean(nullable: false),
                        NumberOfStepsToAccess = c.Int(nullable: false),
                        HasGarden = c.Boolean(nullable: false),
                        HasLift = c.Boolean(nullable: false),
                        HasTrustcare = c.Boolean(nullable: false),
                        IsWheelChairAdapted = c.Boolean(nullable: false),
                        HasRampledAccess = c.Boolean(nullable: false),
                        IsLevelAccessProperty = c.Boolean(nullable: false),
                        HasStairLift = c.Boolean(nullable: false),
                        HasWalkInShower = c.Boolean(nullable: false),
                        HasStepInShower = c.Boolean(nullable: false),
                        PropertyTypeId = c.Int(),
                        PropertySizeId = c.Int(),
                        PropertyEntranceTypeId = c.Int(),
                        PropertyBlockTypeId = c.Int(),
                        AgeRestrictionId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.AgeRestrictions", t => t.AgeRestrictionId)
                .ForeignKey("dbo.HeatingType", t => t.HeatingTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyBlockTypes", t => t.PropertyBlockTypeId)
                .ForeignKey("dbo.PropertyEntranceTypes", t => t.PropertyEntranceTypeId)
                .ForeignKey("dbo.PropertySize", t => t.PropertySizeId)
                .ForeignKey("dbo.PropertyType", t => t.PropertyTypeId)
                .ForeignKey("dbo.VBLApplications", t => t.ApplicationId)
                .Index(t => t.ApplicationId)
                .Index(t => t.HeatingTypeId)
                .Index(t => t.PropertyTypeId)
                .Index(t => t.PropertySizeId)
                .Index(t => t.PropertyEntranceTypeId)
                .Index(t => t.PropertyBlockTypeId)
                .Index(t => t.AgeRestrictionId);
            
            CreateTable(
                "dbo.VBLMutualExchangeAdaptationDetails",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        AdaptationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ApplicationId, t.AdaptationId })
                .ForeignKey("dbo.Adaptations", t => t.AdaptationId, cascadeDelete: true)
                .ForeignKey("dbo.VBLMutualExchagePropertyDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.AdaptationId);
            
            CreateTable(
                "dbo.Adaptations",
                c => new
                    {
                        AdaptationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.AdaptationId);
            
            CreateTable(
                "dbo.AgeRestrictions",
                c => new
                    {
                        AgeRestrictionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.AgeRestrictionId);
            
            CreateTable(
                "dbo.PropertyBlockTypes",
                c => new
                    {
                        PropertyBlockTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.PropertyBlockTypeId);
            
            CreateTable(
                "dbo.PropertyEntranceTypes",
                c => new
                    {
                        PropertyEntranceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.PropertyEntranceTypeId);
            
            CreateTable(
                "dbo.VBLRequestedPropertymatchDetails",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        IsNewVBLApplication = c.Boolean(nullable: false),
                        CatOrDog = c.Boolean(),
                        RehousePet = c.Boolean(),
                        CommunalEntrance = c.Boolean(),
                        HighRise = c.Boolean(),
                        AgeRestricted = c.Boolean(),
                        ManageSteps = c.Boolean(),
                        RequireAdaptations = c.Boolean(),
                        FloorLevel = c.Int(),
                        LiftServed = c.Boolean(),
                        TrustCare = c.Boolean(),
                        Sheltered = c.Boolean(),
                        Garden = c.Boolean(),
                        WheelChairAdapted = c.Boolean(),
                        RampedAccess = c.Boolean(),
                        LevelAccessProperty = c.Boolean(),
                        StairLift = c.Boolean(),
                        WalkInShower = c.Boolean(),
                        StepInShower = c.Boolean(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.VBLApplications", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.VBLRequestedPropertyAdaptationDetails",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        AdaptationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ApplicationId, t.AdaptationId })
                .ForeignKey("dbo.Adaptations", t => t.AdaptationId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.AdaptationId);
            
            CreateTable(
                "dbo.VBLRequestedPropertyAgeRestrictions",
                c => new
                    {
                        VBLAgeRestrictionsOfRequestedPropertyId = c.Int(nullable: false, identity: true),
                        AgeRestrictionId = c.Int(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLAgeRestrictionsOfRequestedPropertyId)
                .ForeignKey("dbo.AgeRestrictions", t => t.AgeRestrictionId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.AgeRestrictionId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.VBLRequestedPropertyHeatingTypes",
                c => new
                    {
                        VBLRequestedPropertyHeatingTypeId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        HeatingTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLRequestedPropertyHeatingTypeId)
                .ForeignKey("dbo.HeatingType", t => t.HeatingTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.HeatingTypeId);
            
            CreateTable(
                "dbo.VBLRequestedPropertySubneighbourhoods",
                c => new
                    {
                        VBLRequestedPropertySubneighbourhoodId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        SubNeighbourhoodId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLRequestedPropertySubneighbourhoodId)
                .ForeignKey("dbo.SubNeighbourhoods", t => t.SubNeighbourhoodId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.SubNeighbourhoodId);
            
            CreateTable(
                "dbo.VBLRequestedPropertyPropertySizes",
                c => new
                    {
                        VBLPropertySizesOfRequestedPropertyId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        PropertySizeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLPropertySizesOfRequestedPropertyId)
                .ForeignKey("dbo.PropertySize", t => t.PropertySizeId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.PropertySizeId);
            
            CreateTable(
                "dbo.VBLRequestedPropertyPropertyTypes",
                c => new
                    {
                        VBLPropertyTypesOfRequestedPropertyId = c.Int(nullable: false, identity: true),
                        PropertyTypeId = c.Int(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLPropertyTypesOfRequestedPropertyId)
                .ForeignKey("dbo.PropertyType", t => t.PropertyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.PropertyTypeId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.VBLRequestedPropertySchemes",
                c => new
                    {
                        VBLRequestedPropertySchemeId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        SchemeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLRequestedPropertySchemeId)
                .ForeignKey("dbo.Scheme", t => t.SchemeId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.SchemeId);
            
            CreateTable(
                "dbo.VBLPropertyAddresses",
                c => new
                    {
                        PropertyAddressId = c.Int(nullable: false, identity: true),
                        PropertyAddress = c.String(),
                        PropertyReference = c.String(),
                        Longitude = c.Decimal(precision: 18, scale: 7),
                        Latitude = c.Decimal(precision: 18, scale: 7),
                        PostcodeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        PropertyTypeId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PropertyAddressId)
                .ForeignKey("dbo.VBLPropertyPostcodes", t => t.PostcodeId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyType", t => t.PropertyTypeId)
                .Index(t => t.PostcodeId)
                .Index(t => t.PropertyTypeId);
            
            CreateTable(
                "dbo.VBLPropertyPostcodes",
                c => new
                    {
                        PostcodeId = c.Int(nullable: false, identity: true),
                        Postcode = c.String(maxLength: 8),
                        NeighbourhoodId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PostcodeId)
                .ForeignKey("dbo.VBLPropertyNeighbourhoods", t => t.NeighbourhoodId, cascadeDelete: true)
                .Index(t => t.NeighbourhoodId);
            
            CreateTable(
                "dbo.VBLPropertyNeighbourhoods",
                c => new
                    {
                        NeighbourhoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        WardId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.NeighbourhoodId)
                .ForeignKey("dbo.VBLPropertyWards", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.VBLPropertyWards",
                c => new
                    {
                        WardId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.WardId);
            
            CreateTable(
                "dbo.VBLContactDisabilityTypesLink",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        DisabilityTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactId, t.DisabilityTypeId })
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.VBLDisabilityTypes", t => t.DisabilityTypeId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.DisabilityTypeId);
            
            CreateTable(
                "dbo.VBLIncommunitiesRelationshipTypesLink",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        IncommunitiesRelationshipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactId, t.IncommunitiesRelationshipTypeId })
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.VBLIncommunitiesRelationshipTypes", t => t.IncommunitiesRelationshipTypeId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.IncommunitiesRelationshipTypeId);
            
            AddColumn("dbo.TenancyType", "Code", c => c.String());
            AddColumn("dbo.TenancyType", "TenancyTypeAndCategoryCode", c => c.String());
            Sql(SqlProgrammability.create_VBLTenancySearchView);
            Sql(SqlProgrammability.create_VBLPropertyShopView);
            Sql(SqlProgrammability.create_VBLPropertyShopImages);
        }
        
        public override void Down()
        {
            Sql(SqlProgrammability.drop_VBLTenancySearchView);
            Sql(SqlProgrammability.drop_VBLPropertyShopView);
            Sql(SqlProgrammability.drop_VBLPropertyShopImages);
            DropForeignKey("dbo.VBLPropertyAddresses", "PropertyTypeId", "dbo.PropertyType");
            DropForeignKey("dbo.VBLPropertyNeighbourhoods", "WardId", "dbo.VBLPropertyWards");
            DropForeignKey("dbo.VBLPropertyPostcodes", "NeighbourhoodId", "dbo.VBLPropertyNeighbourhoods");
            DropForeignKey("dbo.VBLPropertyAddresses", "PostcodeId", "dbo.VBLPropertyPostcodes");
            DropForeignKey("dbo.VBLAddresses", "AddressId", "dbo.VBLApplications");
            DropForeignKey("dbo.VBLRequestedPropertymatchDetails", "ApplicationId", "dbo.VBLApplications");
            DropForeignKey("dbo.VBLRequestedPropertySchemes", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropForeignKey("dbo.VBLRequestedPropertySchemes", "SchemeId", "dbo.Scheme");
            DropForeignKey("dbo.VBLRequestedPropertyPropertyTypes", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropForeignKey("dbo.VBLRequestedPropertyPropertyTypes", "PropertyTypeId", "dbo.PropertyType");
            DropForeignKey("dbo.VBLRequestedPropertyPropertySizes", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropForeignKey("dbo.VBLRequestedPropertyPropertySizes", "PropertySizeId", "dbo.PropertySize");
            DropForeignKey("dbo.VBLRequestedPropertySubneighbourhoods", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropForeignKey("dbo.VBLRequestedPropertySubneighbourhoods", "SubNeighbourhoodId", "dbo.SubNeighbourhoods");
            DropForeignKey("dbo.VBLRequestedPropertyHeatingTypes", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropForeignKey("dbo.VBLRequestedPropertyHeatingTypes", "HeatingTypeId", "dbo.HeatingType");
            DropForeignKey("dbo.VBLRequestedPropertyAgeRestrictions", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropForeignKey("dbo.VBLRequestedPropertyAgeRestrictions", "AgeRestrictionId", "dbo.AgeRestrictions");
            DropForeignKey("dbo.VBLRequestedPropertyAdaptationDetails", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropForeignKey("dbo.VBLRequestedPropertyAdaptationDetails", "AdaptationId", "dbo.Adaptations");
            DropForeignKey("dbo.VBLMutualExchagePropertyDetails", "ApplicationId", "dbo.VBLApplications");
            DropForeignKey("dbo.VBLMutualExchagePropertyDetails", "PropertyTypeId", "dbo.PropertyType");
            DropForeignKey("dbo.VBLMutualExchagePropertyDetails", "PropertySizeId", "dbo.PropertySize");
            DropForeignKey("dbo.VBLMutualExchagePropertyDetails", "PropertyEntranceTypeId", "dbo.PropertyEntranceTypes");
            DropForeignKey("dbo.VBLMutualExchagePropertyDetails", "PropertyBlockTypeId", "dbo.PropertyBlockTypes");
            DropForeignKey("dbo.VBLMutualExchagePropertyDetails", "HeatingTypeId", "dbo.HeatingType");
            DropForeignKey("dbo.VBLMutualExchagePropertyDetails", "AgeRestrictionId", "dbo.AgeRestrictions");
            DropForeignKey("dbo.VBLMutualExchangeAdaptationDetails", "ApplicationId", "dbo.VBLMutualExchagePropertyDetails");
            DropForeignKey("dbo.VBLMutualExchangeAdaptationDetails", "AdaptationId", "dbo.Adaptations");
            DropForeignKey("dbo.VBLDocuments", "ApplicationId", "dbo.VBLApplications");
            DropForeignKey("dbo.VBLApplicationHistories", "ApplicationId", "dbo.VBLApplications");
            DropForeignKey("dbo.VBLApplications", "TenancyTypeId", "dbo.TenancyType");
            DropForeignKey("dbo.VBLApplications", "ResidencyTypeId", "dbo.ResidencyType");
            DropForeignKey("dbo.VBLApplications", "MoveReasonId", "dbo.MoveReason");
            DropForeignKey("dbo.VBLApplications", "LevelOfNeedId", "dbo.LevelOfNeed");
            DropForeignKey("dbo.VBLApplications", "LandlordId", "dbo.Landlord");
            DropForeignKey("dbo.VBLApplications", "CustomerInterestId", "dbo.VBLCustomerInterests");
            DropForeignKey("dbo.VBLCustomerInterests", "CustomerInterestStatusId", "dbo.CustomerInterestStatus");
            DropForeignKey("dbo.VBLContacts", "ApplicationId", "dbo.VBLApplications");
            DropForeignKey("dbo.VBLContacts", "TitleId", "dbo.Title");
            DropForeignKey("dbo.VBLTenantDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLRequestedSupportDetails", "SupportTypeId", "dbo.VBLSupportTypes");
            DropForeignKey("dbo.VBLRequestedSupportDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLContacts", "RelationshipId", "dbo.Relationship");
            DropForeignKey("dbo.VBLReceivingSupportDetails", "SupportTypeId", "dbo.VBLSupportTypes");
            DropForeignKey("dbo.VBLReceivingSupportDetails", "SupportProviderId", "dbo.VBLSupportProviders");
            DropForeignKey("dbo.VBLSupportContactByDetails", "VblReceivingSupportDetail_ReceivingSupportDetailId", "dbo.VBLReceivingSupportDetails");
            DropForeignKey("dbo.VBLSupportContactByDetails", "ContactById", "dbo.ContactBy");
            DropForeignKey("dbo.VBLReceivingSupportDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLContacts", "LanguageId", "dbo.PreferredLanguages");
            DropForeignKey("dbo.VBLContacts", "NationalityTypeId", "dbo.NationalityType");
            DropForeignKey("dbo.VBLIncommunitiesRelationshipTypesLink", "IncommunitiesRelationshipTypeId", "dbo.VBLIncommunitiesRelationshipTypes");
            DropForeignKey("dbo.VBLIncommunitiesRelationshipTypesLink", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLIncomeDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLIncomeDetails", "IncomeTypeId", "dbo.IncomeType");
            DropForeignKey("dbo.VBLIncomeDetails", "IncomeFrequencyId", "dbo.IncomeFrequency");
            DropForeignKey("dbo.VBLContacts", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.VBLContacts", "EthnicityId", "dbo.Ethnicity");
            DropForeignKey("dbo.VBLContactDisabilityTypesLink", "DisabilityTypeId", "dbo.VBLDisabilityTypes");
            DropForeignKey("dbo.VBLContactDisabilityTypesLink", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLDisabilityDetails", "DisabilityTypeId", "dbo.VBLDisabilityTypes");
            DropForeignKey("dbo.VBLDisabilityDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLContacts", "ContactTypeId", "dbo.ContactType");
            DropForeignKey("dbo.VBLContactByDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLContactByDetails", "ContactById", "dbo.ContactBy");
            DropForeignKey("dbo.VBLAddresses", "VBLContact_ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.VBLApplications", "ApplicationStatusID", "dbo.ApplicationStatus");
            DropIndex("dbo.VBLIncommunitiesRelationshipTypesLink", new[] { "IncommunitiesRelationshipTypeId" });
            DropIndex("dbo.VBLIncommunitiesRelationshipTypesLink", new[] { "ContactId" });
            DropIndex("dbo.VBLContactDisabilityTypesLink", new[] { "DisabilityTypeId" });
            DropIndex("dbo.VBLContactDisabilityTypesLink", new[] { "ContactId" });
            DropIndex("dbo.VBLPropertyNeighbourhoods", new[] { "WardId" });
            DropIndex("dbo.VBLPropertyPostcodes", new[] { "NeighbourhoodId" });
            DropIndex("dbo.VBLPropertyAddresses", new[] { "PropertyTypeId" });
            DropIndex("dbo.VBLPropertyAddresses", new[] { "PostcodeId" });
            DropIndex("dbo.VBLRequestedPropertySchemes", new[] { "SchemeId" });
            DropIndex("dbo.VBLRequestedPropertySchemes", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertyPropertyTypes", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertyPropertyTypes", new[] { "PropertyTypeId" });
            DropIndex("dbo.VBLRequestedPropertyPropertySizes", new[] { "PropertySizeId" });
            DropIndex("dbo.VBLRequestedPropertyPropertySizes", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertySubneighbourhoods", new[] { "SubNeighbourhoodId" });
            DropIndex("dbo.VBLRequestedPropertySubneighbourhoods", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertyHeatingTypes", new[] { "HeatingTypeId" });
            DropIndex("dbo.VBLRequestedPropertyHeatingTypes", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertyAgeRestrictions", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertyAgeRestrictions", new[] { "AgeRestrictionId" });
            DropIndex("dbo.VBLRequestedPropertyAdaptationDetails", new[] { "AdaptationId" });
            DropIndex("dbo.VBLRequestedPropertyAdaptationDetails", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertymatchDetails", new[] { "ApplicationId" });
            DropIndex("dbo.VBLMutualExchangeAdaptationDetails", new[] { "AdaptationId" });
            DropIndex("dbo.VBLMutualExchangeAdaptationDetails", new[] { "ApplicationId" });
            DropIndex("dbo.VBLMutualExchagePropertyDetails", new[] { "AgeRestrictionId" });
            DropIndex("dbo.VBLMutualExchagePropertyDetails", new[] { "PropertyBlockTypeId" });
            DropIndex("dbo.VBLMutualExchagePropertyDetails", new[] { "PropertyEntranceTypeId" });
            DropIndex("dbo.VBLMutualExchagePropertyDetails", new[] { "PropertySizeId" });
            DropIndex("dbo.VBLMutualExchagePropertyDetails", new[] { "PropertyTypeId" });
            DropIndex("dbo.VBLMutualExchagePropertyDetails", new[] { "HeatingTypeId" });
            DropIndex("dbo.VBLMutualExchagePropertyDetails", new[] { "ApplicationId" });
            DropIndex("dbo.VBLDocuments", new[] { "ApplicationId" });
            DropIndex("dbo.VBLApplicationHistories", new[] { "ApplicationId" });
            DropIndex("dbo.VBLCustomerInterests", new[] { "CustomerInterestStatusId" });
            DropIndex("dbo.VBLTenantDetails", new[] { "ContactId" });
            DropIndex("dbo.VBLRequestedSupportDetails", new[] { "ContactId" });
            DropIndex("dbo.VBLRequestedSupportDetails", new[] { "SupportTypeId" });
            DropIndex("dbo.VBLSupportContactByDetails", new[] { "VblReceivingSupportDetail_ReceivingSupportDetailId" });
            DropIndex("dbo.VBLSupportContactByDetails", new[] { "ContactById" });
            DropIndex("dbo.VBLReceivingSupportDetails", new[] { "ContactId" });
            DropIndex("dbo.VBLReceivingSupportDetails", new[] { "SupportProviderId" });
            DropIndex("dbo.VBLReceivingSupportDetails", new[] { "SupportTypeId" });
            DropIndex("dbo.VBLIncomeDetails", new[] { "ContactId" });
            DropIndex("dbo.VBLIncomeDetails", new[] { "IncomeFrequencyId" });
            DropIndex("dbo.VBLIncomeDetails", new[] { "IncomeTypeId" });
            DropIndex("dbo.VBLDisabilityDetails", new[] { "ContactId" });
            DropIndex("dbo.VBLDisabilityDetails", new[] { "DisabilityTypeId" });
            DropIndex("dbo.VBLContactByDetails", new[] { "ContactById" });
            DropIndex("dbo.VBLContactByDetails", new[] { "ContactId" });
            DropIndex("dbo.VBLContacts", new[] { "LanguageId" });
            DropIndex("dbo.VBLContacts", new[] { "RelationshipId" });
            DropIndex("dbo.VBLContacts", new[] { "NationalityTypeId" });
            DropIndex("dbo.VBLContacts", new[] { "EthnicityId" });
            DropIndex("dbo.VBLContacts", new[] { "GenderId" });
            DropIndex("dbo.VBLContacts", new[] { "TitleId" });
            DropIndex("dbo.VBLContacts", new[] { "ContactTypeId" });
            DropIndex("dbo.VBLContacts", new[] { "ApplicationId" });
            DropIndex("dbo.VBLApplications", new[] { "LevelOfNeedId" });
            DropIndex("dbo.VBLApplications", new[] { "CustomerInterestId" });
            DropIndex("dbo.VBLApplications", new[] { "LandlordId" });
            DropIndex("dbo.VBLApplications", new[] { "TenancyTypeId" });
            DropIndex("dbo.VBLApplications", new[] { "MoveReasonId" });
            DropIndex("dbo.VBLApplications", new[] { "ResidencyTypeId" });
            DropIndex("dbo.VBLApplications", new[] { "ApplicationStatusID" });
            DropIndex("dbo.VBLAddresses", new[] { "VBLContact_ContactId" });
            DropIndex("dbo.VBLAddresses", new[] { "AddressId" });
            DropColumn("dbo.TenancyType", "TenancyTypeAndCategoryCode");
            DropColumn("dbo.TenancyType", "Code");
            DropTable("dbo.VBLIncommunitiesRelationshipTypesLink");
            DropTable("dbo.VBLContactDisabilityTypesLink");
            DropTable("dbo.VBLPropertyWards");
            DropTable("dbo.VBLPropertyNeighbourhoods");
            DropTable("dbo.VBLPropertyPostcodes");
            DropTable("dbo.VBLPropertyAddresses");
            DropTable("dbo.VBLRequestedPropertySchemes");
            DropTable("dbo.VBLRequestedPropertyPropertyTypes");
            DropTable("dbo.VBLRequestedPropertyPropertySizes");
            DropTable("dbo.VBLRequestedPropertySubneighbourhoods");
            DropTable("dbo.VBLRequestedPropertyHeatingTypes");
            DropTable("dbo.VBLRequestedPropertyAgeRestrictions");
            DropTable("dbo.VBLRequestedPropertyAdaptationDetails");
            DropTable("dbo.VBLRequestedPropertymatchDetails");
            DropTable("dbo.PropertyEntranceTypes");
            DropTable("dbo.PropertyBlockTypes");
            DropTable("dbo.AgeRestrictions");
            DropTable("dbo.Adaptations");
            DropTable("dbo.VBLMutualExchangeAdaptationDetails");
            DropTable("dbo.VBLMutualExchagePropertyDetails");
            DropTable("dbo.VBLDocuments");
            DropTable("dbo.VBLApplicationHistories");
            DropTable("dbo.VBLCustomerInterests");
            DropTable("dbo.VBLTenantDetails");
            DropTable("dbo.VBLRequestedSupportDetails");
            DropTable("dbo.VBLSupportTypes");
            DropTable("dbo.VBLSupportProviders");
            DropTable("dbo.VBLSupportContactByDetails");
            DropTable("dbo.VBLReceivingSupportDetails");
            DropTable("dbo.PreferredLanguages");
            DropTable("dbo.VBLIncommunitiesRelationshipTypes");
            DropTable("dbo.VBLIncomeDetails");
            DropTable("dbo.VBLDisabilityTypes");
            DropTable("dbo.VBLDisabilityDetails");
            DropTable("dbo.VBLContactByDetails");
            DropTable("dbo.VBLContacts");
            DropTable("dbo.VBLApplications");
            DropTable("dbo.VBLAddresses");
            DropTable("dbo.SubNeighbourhoods");
            DropTable("dbo.SchemeBlocks");
            DropTable("dbo.Scheme");
            DropTable("dbo.ContactBy");
        }
    }
}
