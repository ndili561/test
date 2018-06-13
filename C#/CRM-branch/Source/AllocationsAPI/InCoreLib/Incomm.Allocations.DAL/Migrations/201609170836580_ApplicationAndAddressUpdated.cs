namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationAndAddressUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLAddresses", "ApplicationId", c => c.Int());
            AddColumn("dbo.VBLApplications", "AddressId", c => c.Int());
            CreateIndex("dbo.VBLAddresses", "ApplicationId");
            CreateIndex("dbo.VBLApplications", "AddressId");
            AddForeignKey("dbo.VBLAddresses", "ApplicationId", "dbo.VBLApplications", "ApplicationId");
            AddForeignKey("dbo.VBLApplications", "AddressId", "dbo.VBLAddresses", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VBLApplications", "AddressId", "dbo.VBLAddresses");
            DropForeignKey("dbo.VBLAddresses", "ApplicationId", "dbo.VBLApplications");
            DropIndex("dbo.VBLApplications", new[] { "AddressId" });
            DropIndex("dbo.VBLAddresses", new[] { "ApplicationId" });
            DropColumn("dbo.VBLApplications", "AddressId");
            DropColumn("dbo.VBLAddresses", "ApplicationId");
        }
    }
}
