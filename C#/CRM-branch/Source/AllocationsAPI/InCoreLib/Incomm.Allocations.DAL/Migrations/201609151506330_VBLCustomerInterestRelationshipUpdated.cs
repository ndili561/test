namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VBLCustomerInterestRelationshipUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VBLApplications", "CustomerInterestId", "dbo.VBLCustomerInterests");
            DropIndex("dbo.VBLApplications", new[] { "CustomerInterestId" });
            AddColumn("dbo.VBLCustomerInterests", "ApplicationId", c => c.Int(nullable: false));
            CreateIndex("dbo.VBLCustomerInterests", "ApplicationId");
            //AddForeignKey("dbo.VBLCustomerInterests", "ApplicationId", "dbo.VBLApplications", "ApplicationId", cascadeDelete: true);
            DropColumn("dbo.VBLApplications", "CustomerInterestId");
            DropColumn("dbo.VBLCustomerInterests", "CustomerApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VBLCustomerInterests", "CustomerApplicationId", c => c.Int(nullable: false));
            AddColumn("dbo.VBLApplications", "CustomerInterestId", c => c.Int());
            DropForeignKey("dbo.VBLCustomerInterests", "ApplicationId", "dbo.VBLApplications");
            DropIndex("dbo.VBLCustomerInterests", new[] { "ApplicationId" });
            DropColumn("dbo.VBLCustomerInterests", "ApplicationId");
            CreateIndex("dbo.VBLApplications", "CustomerInterestId");
            AddForeignKey("dbo.VBLApplications", "CustomerInterestId", "dbo.VBLCustomerInterests", "CustomerInterestId");
        }
    }
}
