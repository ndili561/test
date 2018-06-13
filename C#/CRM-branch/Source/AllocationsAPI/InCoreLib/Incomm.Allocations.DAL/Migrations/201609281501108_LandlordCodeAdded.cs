namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LandlordCodeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Landlord", "LandlordCode", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Landlord", "LandlordCode");
        }
    }
}
