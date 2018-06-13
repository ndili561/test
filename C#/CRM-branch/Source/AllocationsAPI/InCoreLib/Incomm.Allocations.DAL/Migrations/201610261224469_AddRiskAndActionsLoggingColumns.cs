namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRiskAndActionsLoggingColumns : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SuitabilityCheckActions");
            DropPrimaryKey("dbo.SuitabilityCheckRisks");
            AddColumn("dbo.SuitabilityCheckActions", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SuitabilityCheckActions", "DisplayTabName", c => c.String());
            AddColumn("dbo.SuitabilityCheckActions", "ActionLoggedById", c => c.String(maxLength: 40));
            AddColumn("dbo.SuitabilityCheckRisks", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SuitabilityCheckRisks", "DisplayTabName", c => c.String());
            AddColumn("dbo.SuitabilityCheckRisks", "LoggedById", c => c.String());
            AddPrimaryKey("dbo.SuitabilityCheckActions", "Id");
            AddPrimaryKey("dbo.SuitabilityCheckRisks", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SuitabilityCheckRisks");
            DropPrimaryKey("dbo.SuitabilityCheckActions");
            DropColumn("dbo.SuitabilityCheckRisks", "LoggedById");
            DropColumn("dbo.SuitabilityCheckRisks", "DisplayTabName");
            DropColumn("dbo.SuitabilityCheckRisks", "Id");
            DropColumn("dbo.SuitabilityCheckActions", "ActionLoggedById");
            DropColumn("dbo.SuitabilityCheckActions", "DisplayTabName");
            DropColumn("dbo.SuitabilityCheckActions", "Id");
            AddPrimaryKey("dbo.SuitabilityCheckRisks", new[] { "ContactId", "RiskThemeId", "RiskCategoryId" });
            AddPrimaryKey("dbo.SuitabilityCheckActions", new[] { "ContactId", "ActionCategoryId", "ActionTypeId" });
        }
    }
}
