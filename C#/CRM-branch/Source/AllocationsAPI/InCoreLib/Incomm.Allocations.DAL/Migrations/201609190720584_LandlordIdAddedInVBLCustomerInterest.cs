namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LandlordIdAddedInVBLCustomerInterest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLCustomerInterests", "LandlordId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLCustomerInterests", "LandlordId");
        }
    }
}
