namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVblIncommunitiesRelationshipTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VBLIncommunitiesRelationships",
                c => new
                    {
                        VBLIncommunitiesRelationshipId = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        HasIncommunitiesRelationship = c.Boolean(nullable: false),
                        IncommunitiesRelationshipDescription = c.String(),
                        CreatedBy = c.String(maxLength: 40),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VBLIncommunitiesRelationshipId)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId, unique: true, name: "IX_VBLIncommunitiesRelationships_ContactId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VBLIncommunitiesRelationships", "ContactId", "dbo.VBLContacts");
            DropIndex("dbo.VBLIncommunitiesRelationships", "IX_VBLIncommunitiesRelationships_ContactId");
            DropTable("dbo.VBLIncommunitiesRelationships");
        }
    }
}
