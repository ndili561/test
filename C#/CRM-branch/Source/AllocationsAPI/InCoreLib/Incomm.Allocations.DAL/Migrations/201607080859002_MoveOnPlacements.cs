namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveOnPlacements : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HRSPlacements", "MoveOnPlacement", c => c.Boolean(nullable: false));
            AddColumn("dbo.HRSQuestionAnswers", "PlacementId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HRSQuestionAnswers", "PlacementId");
            DropColumn("dbo.HRSPlacements", "MoveOnPlacement");
        }
    }
}
