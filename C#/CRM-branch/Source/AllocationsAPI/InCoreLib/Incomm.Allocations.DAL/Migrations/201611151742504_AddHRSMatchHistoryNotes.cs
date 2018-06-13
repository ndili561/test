namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHRSMatchHistoryNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HRSMatchHistory", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HRSMatchHistory", "Notes");
        }
    }
}
