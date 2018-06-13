namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActiveToHostel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hostels", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hostels", "Active");
        }
    }
}
