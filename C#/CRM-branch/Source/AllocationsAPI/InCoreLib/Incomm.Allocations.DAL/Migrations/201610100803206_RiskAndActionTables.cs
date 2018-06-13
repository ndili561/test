namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RiskAndActionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActionResponsibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuitabilityCheckActions",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        ActionCategoryId = c.Int(nullable: false),
                        ActionTypeId = c.Int(nullable: false),
                        DateToComplete = c.DateTime(),
                        ActionResponsibilityId = c.Int(nullable: false),
                        ActionCompletedDate = c.DateTime(),
                        ConcurrencyCheck = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        LastModifiedById = c.String(maxLength: 40),
                        ModifiedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactId, t.ActionCategoryId, t.ActionTypeId })
                .ForeignKey("dbo.ActionCategories", t => t.ActionCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ActionTypes", t => t.ActionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ActionResponsibilities", t => t.ActionResponsibilityId, cascadeDelete: true)
                .Index(t => t.ActionCategoryId)
                .Index(t => t.ActionTypeId)
                .Index(t => t.ActionResponsibilityId);
            
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionCategoryId = c.Int(nullable: false),
                        Action = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RiskCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RiskThemeId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuitabilityCheckRisks",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        RiskThemeId = c.Int(nullable: false),
                        RiskCategoryId = c.Int(nullable: false),
                        LoggedDate = c.DateTime(),
                        RiskDetail = c.String(),
                        LastReviewedDate = c.DateTime(),
                        ConcurrencyCheck = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        LastModifiedById = c.String(maxLength: 40),
                        ModifiedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactId, t.RiskThemeId, t.RiskCategoryId })
                .ForeignKey("dbo.RiskCategories", t => t.RiskCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.RiskThemes", t => t.RiskThemeId, cascadeDelete: true)
                .Index(t => t.RiskThemeId)
                .Index(t => t.RiskCategoryId);
            
            CreateTable(
                "dbo.RiskThemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuitabilityCheckRisks", "RiskThemeId", "dbo.RiskThemes");
            DropForeignKey("dbo.SuitabilityCheckRisks", "RiskCategoryId", "dbo.RiskCategories");
            DropForeignKey("dbo.SuitabilityCheckActions", "ActionResponsibilityId", "dbo.ActionResponsibilities");
            DropForeignKey("dbo.SuitabilityCheckActions", "ActionTypeId", "dbo.ActionTypes");
            DropForeignKey("dbo.SuitabilityCheckActions", "ActionCategoryId", "dbo.ActionCategories");
            DropIndex("dbo.SuitabilityCheckRisks", new[] { "RiskCategoryId" });
            DropIndex("dbo.SuitabilityCheckRisks", new[] { "RiskThemeId" });
            DropIndex("dbo.SuitabilityCheckActions", new[] { "ActionResponsibilityId" });
            DropIndex("dbo.SuitabilityCheckActions", new[] { "ActionTypeId" });
            DropIndex("dbo.SuitabilityCheckActions", new[] { "ActionCategoryId" });
            DropTable("dbo.RiskThemes");
            DropTable("dbo.SuitabilityCheckRisks");
            DropTable("dbo.RiskCategories");
            DropTable("dbo.ActionTypes");
            DropTable("dbo.SuitabilityCheckActions");
            DropTable("dbo.ActionResponsibilities");
            DropTable("dbo.ActionCategories");
        }
    }
}
