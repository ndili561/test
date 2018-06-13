namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuitabiltyCheckActionLoggedDateAndNotesColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuitabilityCheckActions", "ActionLoggedDate", c => c.DateTime());
            AddColumn("dbo.SuitabilityCheckActions", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuitabilityCheckActions", "Notes");
            DropColumn("dbo.SuitabilityCheckActions", "ActionLoggedDate");
        }
    }
}
