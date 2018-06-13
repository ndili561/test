namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VBLPropertyAddressUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VBLRequestedPropertySubneighbourhoods", "SubNeighbourhoodId", "dbo.SubNeighbourhoods");
            DropForeignKey("dbo.VBLRequestedPropertySubneighbourhoods", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropIndex("dbo.VBLRequestedPropertySubneighbourhoods", new[] { "ApplicationId" });
            DropIndex("dbo.VBLRequestedPropertySubneighbourhoods", new[] { "SubNeighbourhoodId" });
            CreateTable(
                "dbo.VBLRequestedPropertyPrefferedNeighbourhoods",
                c => new
                    {
                        RequestedPropertyPrefferedNeighbourhoodId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.RequestedPropertyPrefferedNeighbourhoodId)
                .ForeignKey("dbo.VBLRequestedPropertymatchDetails", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails",
                c => new
                    {
                        RequestedPropertyPrefferedNeighbourhoodDetailId = c.Int(nullable: false, identity: true),
                        NeighbourhoodId = c.Int(nullable: false),
                        RequestedPropertyPrefferedNeighbourhoodId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.RequestedPropertyPrefferedNeighbourhoodDetailId)
                .ForeignKey("dbo.VBLPropertyNeighbourhoods", t => t.NeighbourhoodId, cascadeDelete: true)
                .ForeignKey("dbo.VBLRequestedPropertyPrefferedNeighbourhoods", t => t.RequestedPropertyPrefferedNeighbourhoodId, cascadeDelete: true)
                .Index(t => t.NeighbourhoodId)
                .Index(t => t.RequestedPropertyPrefferedNeighbourhoodId);
            
            AddColumn("dbo.VBLPropertyAddresses", "AgeRestrictionId", c => c.Int());
            AddColumn("dbo.VBLPropertyAddresses", "PropertySizeId", c => c.Int());
            AddColumn("dbo.VBLPropertyAddresses", "Highrise", c => c.Boolean(nullable: false));
            AddColumn("dbo.VBLPropertyAddresses", "CommunalEntrance", c => c.Boolean(nullable: false));
            AddColumn("dbo.VBLPropertyAddresses", "WaitingTimeInMonth", c => c.Decimal(precision: 18, scale: 11));
            CreateIndex("dbo.VBLPropertyAddresses", "AgeRestrictionId");
            CreateIndex("dbo.VBLPropertyAddresses", "PropertySizeId");
            AddForeignKey("dbo.VBLPropertyAddresses", "AgeRestrictionId", "dbo.AgeRestrictions", "AgeRestrictionId");
            AddForeignKey("dbo.VBLPropertyAddresses", "PropertySizeId", "dbo.PropertySize", "PropertySizeId");
            DropColumn("dbo.VBLContacts", "PreferredLanguageId");
            DropTable("dbo.VBLRequestedPropertySubneighbourhoods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VBLRequestedPropertySubneighbourhoods",
                c => new
                    {
                        VBLRequestedPropertySubneighbourhoodId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        SubNeighbourhoodId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLRequestedPropertySubneighbourhoodId);
            
            AddColumn("dbo.VBLContacts", "PreferredLanguageId", c => c.Int(nullable: false));
            DropForeignKey("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", "RequestedPropertyPrefferedNeighbourhoodId", "dbo.VBLRequestedPropertyPrefferedNeighbourhoods");
            DropForeignKey("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", "NeighbourhoodId", "dbo.VBLPropertyNeighbourhoods");
            DropForeignKey("dbo.VBLPropertyAddresses", "PropertySizeId", "dbo.PropertySize");
            DropForeignKey("dbo.VBLPropertyAddresses", "AgeRestrictionId", "dbo.AgeRestrictions");
            DropForeignKey("dbo.VBLRequestedPropertyPrefferedNeighbourhoods", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails");
            DropIndex("dbo.VBLPropertyAddresses", new[] { "PropertySizeId" });
            DropIndex("dbo.VBLPropertyAddresses", new[] { "AgeRestrictionId" });
            DropIndex("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", new[] { "RequestedPropertyPrefferedNeighbourhoodId" });
            DropIndex("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", new[] { "NeighbourhoodId" });
            DropIndex("dbo.VBLRequestedPropertyPrefferedNeighbourhoods", new[] { "ApplicationId" });
            DropColumn("dbo.VBLPropertyAddresses", "WaitingTimeInMonth");
            DropColumn("dbo.VBLPropertyAddresses", "CommunalEntrance");
            DropColumn("dbo.VBLPropertyAddresses", "Highrise");
            DropColumn("dbo.VBLPropertyAddresses", "PropertySizeId");
            DropColumn("dbo.VBLPropertyAddresses", "AgeRestrictionId");
            DropTable("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails");
            DropTable("dbo.VBLRequestedPropertyPrefferedNeighbourhoods");
            CreateIndex("dbo.VBLRequestedPropertySubneighbourhoods", "SubNeighbourhoodId");
            CreateIndex("dbo.VBLRequestedPropertySubneighbourhoods", "ApplicationId");
            AddForeignKey("dbo.VBLRequestedPropertySubneighbourhoods", "ApplicationId", "dbo.VBLRequestedPropertymatchDetails", "ApplicationId", cascadeDelete: true);
            AddForeignKey("dbo.VBLRequestedPropertySubneighbourhoods", "SubNeighbourhoodId", "dbo.SubNeighbourhoods", "SubNeighbourhoodId", cascadeDelete: true);
        }
    }
}
