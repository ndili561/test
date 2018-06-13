namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationAndAddressRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VBLAddresses", "AddressId", "dbo.VBLApplications");
            DropIndex("dbo.VBLAddresses", new[] { "AddressId" });
            DropPrimaryKey("dbo.VBLAddresses");
            DropColumn("dbo.VBLAddresses", "AddressId");
            AddColumn("dbo.VBLAddresses", "AddressId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VBLAddresses", "AddressId");
            DropColumn("dbo.VBLAddresses", "ApplicationId");
            DropColumn("dbo.VBLApplications", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VBLApplications", "AddressId", c => c.Int());
            AddColumn("dbo.VBLAddresses", "ApplicationId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.VBLAddresses");
            AlterColumn("dbo.VBLAddresses", "AddressId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VBLAddresses", "AddressId");
            CreateIndex("dbo.VBLAddresses", "AddressId");
           // AddForeignKey("dbo.VBLAddresses", "AddressId", "dbo.VBLApplications", "ApplicationId");
        }
    }
}
