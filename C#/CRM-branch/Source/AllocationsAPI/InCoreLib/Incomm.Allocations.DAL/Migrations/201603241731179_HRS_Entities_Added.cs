namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRS_Entities_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hostels",
                c => new
                    {
                        HostelId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        HRSProviderId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.HostelId)
                .ForeignKey("dbo.HRSProviders", t => t.HRSProviderId, cascadeDelete: true)
                .Index(t => t.HRSProviderId);
            
            CreateTable(
                "dbo.HRSProviders",
                c => new
                    {
                        HRSProviderId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        RegisteredCouncilCode = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.HRSProviderId);
            
           
            CreateTable(
                "dbo.HRSCustomerMoveOptions",
                c => new
                    {
                        HRSCustomerMoveOptionId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        ConcurrencyCheck = c.Binary(),
                    })
                .PrimaryKey(t => t.HRSCustomerMoveOptionId);
            
            CreateTable(
                "dbo.HRSCustomers",
                c => new
                    {
                        HRSCustomerId = c.Int(nullable: false, identity: true),
                        HOACaseReference = c.Int(nullable: false),
                        Name = c.String(),
                        DoB = c.DateTime(nullable: false),
                        GatewayOfficer = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        MinBedroomSize = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.HRSCustomerId);
            
            CreateTable(
                "dbo.HRSPlacementMatchedForCustomers",
                c => new
                    {
                        HRSPlacementMatchedForCustomerId = c.Int(nullable: false, identity: true),
                        PlacementId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        RejectionReason = c.Int(nullable: false),
                        Notes = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.HRSPlacementMatchedForCustomerId)
                .ForeignKey("dbo.HRSPlacements", t => t.PlacementId, cascadeDelete: true)
                .ForeignKey("dbo.HRSCustomers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.PlacementId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.HRSPlacements",
                c => new
                    {
                        PlacementId = c.Int(nullable: false, identity: true),
                        HRSProviderId = c.Int(nullable: false),
                        ContactName = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        Comments = c.String(),
                        MinimumBedroom = c.Int(nullable: false),
                        SupportTypeId = c.Int(nullable: false),
                        HostelId = c.Int(),
                        PlacementStatus = c.Int(nullable: false),
                        PlacementGender = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PlacementId)
                .ForeignKey("dbo.Hostels", t => t.HostelId)
                .ForeignKey("dbo.HRSProviders", t => t.HRSProviderId, cascadeDelete: true)
                .ForeignKey("dbo.SupportTypes", t => t.SupportTypeId, cascadeDelete: true)
                .Index(t => t.HRSProviderId)
                .Index(t => t.SupportTypeId)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        ConcurrencyCheck = c.Binary(),
                    })
                .PrimaryKey(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.SupportTypes",
                c => new
                    {
                        SupportTypeId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        ConcurrencyCheck = c.Binary(),
                    })
                .PrimaryKey(t => t.SupportTypeId);
            
            CreateTable(
                "dbo.HRSEvictionReasons",
                c => new
                    {
                        HRSCustomerMoveOptionId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        ConcurrencyCheck = c.Binary(),
                    })
                .PrimaryKey(t => t.HRSCustomerMoveOptionId);
            
            CreateTable(
                "dbo.HRSFloatingSupportServiceEndReasons",
                c => new
                    {
                        HRSFloatingSupportServiceEndReasonId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        ConcurrencyCheck = c.Binary(),
                    })
                .PrimaryKey(t => t.HRSFloatingSupportServiceEndReasonId);
            
            CreateTable(
                "dbo.HRSMatchHistory",
                c => new
                    {
                        MatchHistoryId = c.Int(nullable: false, identity: true),
                        Outcome = c.Int(nullable: false),
                        Reason = c.Int(nullable: false),
                        DecisionDate = c.DateTime(nullable: false),
                        Reconsidered = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                        Customer_HRSCustomerId = c.Int(),
                        Placement_PlacementId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchHistoryId)
                .ForeignKey("dbo.HRSCustomers", t => t.Customer_HRSCustomerId)
                .ForeignKey("dbo.HRSPlacements", t => t.Placement_PlacementId)
                .Index(t => t.Customer_HRSCustomerId)
                .Index(t => t.Placement_PlacementId);
            
            CreateTable(
                "dbo.HRSQuestionAnswers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        QstnairID = c.Int(nullable: false),
                        QstnID = c.Int(nullable: false),
                        CaseRef = c.Int(nullable: false),
                        Seqno = c.Int(nullable: false),
                        AnswerTypeID = c.Int(nullable: false),
                        AnswerValue = c.String(),
                        QstnAltID = c.Int(),
                        AddDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        Note = c.String(),
                        YesNote = c.String(),
                        NoNote = c.String(),
                        PrevQstnID = c.Int(nullable: false),
                        NextQstnID = c.Int(nullable: false),
                        QstnAltChecked = c.Boolean(),
                        OtherChecked = c.Boolean(),
                        OtherNote = c.String(),
                        AdviceDelivered = c.Boolean(),
                        AdviceDeliveredDate = c.DateTime(),
                        QstnChangeTypeID = c.Int(),
                        CaseNoteID = c.Int(),
                        CommonQstn = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AnswerID);
            
            CreateTable(
                "dbo.ServiceTypeHRSPlacements",
                c => new
                    {
                        HRSPlacementId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HRSPlacementId, t.ServiceTypeId })
                .ForeignKey("dbo.HRSPlacements", t => t.HRSPlacementId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.HRSPlacementId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.ServiceTypeHRSCustomers",
                c => new
                    {
                        HRSCustomerId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HRSCustomerId, t.ServiceTypeId })
                .ForeignKey("dbo.HRSCustomers", t => t.HRSCustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.HRSCustomerId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.SupportTypeHRSCustomers",
                c => new
                    {
                        HRSCustomerId = c.Int(nullable: false),
                        SupportTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HRSCustomerId, t.SupportTypeId })
                .ForeignKey("dbo.HRSCustomers", t => t.HRSCustomerId, cascadeDelete: true)
                .ForeignKey("dbo.SupportTypes", t => t.SupportTypeId, cascadeDelete: true)
                .Index(t => t.HRSCustomerId)
                .Index(t => t.SupportTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HRSMatchHistory", "Placement_PlacementId", "dbo.HRSPlacements");
            DropForeignKey("dbo.HRSMatchHistory", "Customer_HRSCustomerId", "dbo.HRSCustomers");
            DropForeignKey("dbo.SupportTypeHRSCustomers", "SupportTypeId", "dbo.SupportTypes");
            DropForeignKey("dbo.SupportTypeHRSCustomers", "HRSCustomerId", "dbo.HRSCustomers");
            DropForeignKey("dbo.ServiceTypeHRSCustomers", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.ServiceTypeHRSCustomers", "HRSCustomerId", "dbo.HRSCustomers");
            DropForeignKey("dbo.HRSPlacementMatchedForCustomers", "CustomerId", "dbo.HRSCustomers");
            DropForeignKey("dbo.HRSPlacements", "SupportTypeId", "dbo.SupportTypes");
            DropForeignKey("dbo.ServiceTypeHRSPlacements", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.ServiceTypeHRSPlacements", "HRSPlacementId", "dbo.HRSPlacements");
            DropForeignKey("dbo.HRSPlacements", "HRSProviderId", "dbo.HRSProviders");
            DropForeignKey("dbo.HRSPlacementMatchedForCustomers", "PlacementId", "dbo.HRSPlacements");
            DropForeignKey("dbo.HRSPlacements", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Hostels", "HRSProviderId", "dbo.HRSProviders");
            DropIndex("dbo.SupportTypeHRSCustomers", new[] { "SupportTypeId" });
            DropIndex("dbo.SupportTypeHRSCustomers", new[] { "HRSCustomerId" });
            DropIndex("dbo.ServiceTypeHRSCustomers", new[] { "ServiceTypeId" });
            DropIndex("dbo.ServiceTypeHRSCustomers", new[] { "HRSCustomerId" });
            DropIndex("dbo.ServiceTypeHRSPlacements", new[] { "ServiceTypeId" });
            DropIndex("dbo.ServiceTypeHRSPlacements", new[] { "HRSPlacementId" });
            DropIndex("dbo.HRSMatchHistory", new[] { "Placement_PlacementId" });
            DropIndex("dbo.HRSMatchHistory", new[] { "Customer_HRSCustomerId" });
            DropIndex("dbo.HRSPlacements", new[] { "HostelId" });
            DropIndex("dbo.HRSPlacements", new[] { "SupportTypeId" });
            DropIndex("dbo.HRSPlacements", new[] { "HRSProviderId" });
            DropIndex("dbo.HRSPlacementMatchedForCustomers", new[] { "CustomerId" });
            DropIndex("dbo.HRSPlacementMatchedForCustomers", new[] { "PlacementId" });
            DropIndex("dbo.Hostels", new[] { "HRSProviderId" });
            DropTable("dbo.SupportTypeHRSCustomers");
            DropTable("dbo.ServiceTypeHRSCustomers");
            DropTable("dbo.ServiceTypeHRSPlacements");
            DropTable("dbo.HRSQuestionAnswers");
            DropTable("dbo.HRSMatchHistory");
            DropTable("dbo.HRSFloatingSupportServiceEndReasons");
            DropTable("dbo.HRSEvictionReasons");
            DropTable("dbo.SupportTypes");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.HRSPlacements");
            DropTable("dbo.HRSPlacementMatchedForCustomers");
            DropTable("dbo.HRSCustomers");
            DropTable("dbo.HRSCustomerMoveOptions");
            DropTable("dbo.HRSProviders");
            DropTable("dbo.Hostels");
        }
    }
}
