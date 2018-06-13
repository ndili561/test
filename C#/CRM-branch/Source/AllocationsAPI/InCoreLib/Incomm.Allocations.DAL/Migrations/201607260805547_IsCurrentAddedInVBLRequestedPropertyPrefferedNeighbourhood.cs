namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCurrentAddedInVBLRequestedPropertyPrefferedNeighbourhood : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLRequestedPropertyPrefferedNeighbourhoods", "IsCurrent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLRequestedPropertyPrefferedNeighbourhoods", "IsCurrent");
        }
    }
}
