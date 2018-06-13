namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyNeighbourhoodsRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VBLPropertyAddresses", "AgeRestrictionId", "dbo.AgeRestrictions");
            DropForeignKey("dbo.VBLPropertyAddresses", "PostcodeId", "dbo.VBLPropertyPostcodes");
            DropForeignKey("dbo.VBLPropertyAddresses", "PropertySizeId", "dbo.PropertySize");
            DropForeignKey("dbo.VBLPropertyAddresses", "PropertyTypeId", "dbo.PropertyType");
            DropForeignKey("dbo.VBLPropertyPostcodes", "NeighbourhoodId", "dbo.VBLPropertyNeighbourhoods");
            DropForeignKey("dbo.VBLPropertyNeighbourhoods", "WardId", "dbo.VBLPropertyWards");
            DropForeignKey("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", "NeighbourhoodId", "dbo.VBLPropertyNeighbourhoods");
            DropIndex("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", new[] { "NeighbourhoodId" });
            DropIndex("dbo.VBLPropertyNeighbourhoods", new[] { "WardId" });
            DropIndex("dbo.VBLPropertyPostcodes", new[] { "NeighbourhoodId" });
            DropIndex("dbo.VBLPropertyAddresses", new[] { "PostcodeId" });
            DropIndex("dbo.VBLPropertyAddresses", new[] { "AgeRestrictionId" });
            DropIndex("dbo.VBLPropertyAddresses", new[] { "PropertyTypeId" });
            DropIndex("dbo.VBLPropertyAddresses", new[] { "PropertySizeId" });
            DropTable("dbo.VBLPropertyNeighbourhoods");
            DropTable("dbo.VBLPropertyPostcodes");
            DropTable("dbo.VBLPropertyAddresses");
            DropTable("dbo.VBLPropertyWards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VBLPropertyWards",
                c => new
                    {
                        WardId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.WardId);
            
            CreateTable(
                "dbo.VBLPropertyAddresses",
                c => new
                    {
                        PropertyAddressId = c.Int(nullable: false, identity: true),
                        PropertyAddress = c.String(),
                        PropertyReference = c.String(),
                        Longitude = c.Decimal(precision: 18, scale: 2),
                        Latitude = c.Decimal(precision: 18, scale: 2),
                        PostcodeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AgeRestrictionId = c.Int(),
                        PropertyTypeId = c.Int(),
                        PropertySizeId = c.Int(),
                        Highrise = c.Boolean(nullable: false),
                        CommunalEntrance = c.Boolean(nullable: false),
                        WaitingTimeInMonth = c.Decimal(precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PropertyAddressId);
            
            CreateTable(
                "dbo.VBLPropertyPostcodes",
                c => new
                    {
                        PostcodeId = c.Int(nullable: false, identity: true),
                        Postcode = c.String(maxLength: 8),
                        NeighbourhoodId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PostcodeId);
            
            CreateTable(
                "dbo.VBLPropertyNeighbourhoods",
                c => new
                    {
                        NeighbourhoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        WardId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.NeighbourhoodId);
            
            CreateIndex("dbo.VBLPropertyAddresses", "PropertySizeId");
            CreateIndex("dbo.VBLPropertyAddresses", "PropertyTypeId");
            CreateIndex("dbo.VBLPropertyAddresses", "AgeRestrictionId");
            CreateIndex("dbo.VBLPropertyAddresses", "PostcodeId");
            CreateIndex("dbo.VBLPropertyPostcodes", "NeighbourhoodId");
            CreateIndex("dbo.VBLPropertyNeighbourhoods", "WardId");
            CreateIndex("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", "NeighbourhoodId");
            AddForeignKey("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", "NeighbourhoodId", "dbo.VBLPropertyNeighbourhoods", "NeighbourhoodId", cascadeDelete: true);
            AddForeignKey("dbo.VBLPropertyNeighbourhoods", "WardId", "dbo.VBLPropertyWards", "WardId", cascadeDelete: true);
            AddForeignKey("dbo.VBLPropertyPostcodes", "NeighbourhoodId", "dbo.VBLPropertyNeighbourhoods", "NeighbourhoodId", cascadeDelete: true);
            AddForeignKey("dbo.VBLPropertyAddresses", "PropertyTypeId", "dbo.PropertyType", "PropertyTypeId");
            AddForeignKey("dbo.VBLPropertyAddresses", "PropertySizeId", "dbo.PropertySize", "PropertySizeId");
            AddForeignKey("dbo.VBLPropertyAddresses", "PostcodeId", "dbo.VBLPropertyPostcodes", "PostcodeId", cascadeDelete: true);
            AddForeignKey("dbo.VBLPropertyAddresses", "AgeRestrictionId", "dbo.AgeRestrictions", "AgeRestrictionId");
        }
    }
}
