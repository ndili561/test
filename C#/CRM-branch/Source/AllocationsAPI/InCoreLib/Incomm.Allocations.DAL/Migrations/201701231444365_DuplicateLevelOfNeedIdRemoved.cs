namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DuplicateLevelOfNeedIdRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VBLApplications", "ApplicationLevelOfNeedID");
            RenameColumn(table: "dbo.VBLApplications", name: "LevelOfNeedId", newName: "ApplicationLevelOfNeedID");
            RenameIndex(table: "dbo.VBLApplications", name: "IX_LevelOfNeedId", newName: "IX_ApplicationLevelOfNeedID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VBLApplications", name: "IX_ApplicationLevelOfNeedID", newName: "IX_LevelOfNeedId");
            RenameColumn(table: "dbo.VBLApplications", name: "ApplicationLevelOfNeedID", newName: "LevelOfNeedId");
            AddColumn("dbo.VBLApplications", "ApplicationLevelOfNeedID", c => c.Int());
        }
    }
}
