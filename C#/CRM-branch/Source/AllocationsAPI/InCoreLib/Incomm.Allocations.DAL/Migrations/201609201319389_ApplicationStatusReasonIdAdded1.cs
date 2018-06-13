namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationStatusReasonIdAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLApplications", "ApplicationStatusReasonID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLApplications", "ApplicationStatusReasonID");
        }
    }
}
