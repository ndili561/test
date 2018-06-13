using Incomm.Allocations.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRSMatchHistoryUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HRSMatchHistory", "Customer_HRSCustomerId", "dbo.HRSCustomers");
            DropForeignKey("dbo.HRSMatchHistory", "Placement_PlacementId", "dbo.HRSPlacements");
            DropIndex("dbo.HRSMatchHistory", new[] { "Customer_HRSCustomerId" });
            DropIndex("dbo.HRSMatchHistory", new[] { "Placement_PlacementId" });
            RenameColumn(table: "dbo.HRSMatchHistory", name: "Customer_HRSCustomerId", newName: "HRSCustomerId");
            RenameColumn(table: "dbo.HRSMatchHistory", name: "Placement_PlacementId", newName: "PlacementId");
            AlterColumn("dbo.HRSMatchHistory", "HRSCustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.HRSMatchHistory", "PlacementId", c => c.Int(nullable: false));
            CreateIndex("dbo.HRSMatchHistory", "PlacementId");
            CreateIndex("dbo.HRSMatchHistory", "HRSCustomerId");
            AddForeignKey("dbo.HRSMatchHistory", "HRSCustomerId", "dbo.HRSCustomers", "HRSCustomerId", cascadeDelete: true);
            AddForeignKey("dbo.HRSMatchHistory", "PlacementId", "dbo.HRSPlacements", "PlacementId", cascadeDelete: true);
            Sql(SqlProgrammability.RemoveHRSMatchHistoryTrigger);
            Sql(SqlProgrammability.CreateHRSMatchHistoryTrigger);
        }
        
        public override void Down()
        {
            Sql(SqlProgrammability.RemoveHRSMatchHistoryTrigger);
            DropForeignKey("dbo.HRSMatchHistory", "PlacementId", "dbo.HRSPlacements");
            DropForeignKey("dbo.HRSMatchHistory", "HRSCustomerId", "dbo.HRSCustomers");
            DropIndex("dbo.HRSMatchHistory", new[] { "HRSCustomerId" });
            DropIndex("dbo.HRSMatchHistory", new[] { "PlacementId" });
            AlterColumn("dbo.HRSMatchHistory", "PlacementId", c => c.Int());
            AlterColumn("dbo.HRSMatchHistory", "HRSCustomerId", c => c.Int());
            RenameColumn(table: "dbo.HRSMatchHistory", name: "PlacementId", newName: "Placement_PlacementId");
            RenameColumn(table: "dbo.HRSMatchHistory", name: "HRSCustomerId", newName: "Customer_HRSCustomerId");
            CreateIndex("dbo.HRSMatchHistory", "Placement_PlacementId");
            CreateIndex("dbo.HRSMatchHistory", "Customer_HRSCustomerId");
            AddForeignKey("dbo.HRSMatchHistory", "Placement_PlacementId", "dbo.HRSPlacements", "PlacementId");
            AddForeignKey("dbo.HRSMatchHistory", "Customer_HRSCustomerId", "dbo.HRSCustomers", "HRSCustomerId");
        }
    }
}
