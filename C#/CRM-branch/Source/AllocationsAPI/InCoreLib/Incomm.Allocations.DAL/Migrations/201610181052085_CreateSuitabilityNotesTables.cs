namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSuitabilityNotesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuitabilityNotes",
                c => new
                    {
                        SuitabilityNoteId = c.Int(nullable: false, identity: true),
                        SuitabilityNoteTypeId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        CreatedBy = c.String(maxLength: 40),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SuitabilityNoteId)
                .ForeignKey("dbo.SuitabilityNoteTypes", t => t.SuitabilityNoteTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.SuitabilityNoteTypeId)
                .Index(t => t.ContactId, name: "IX_SuitabilityNotes_ContactId");
            
            CreateTable(
                "dbo.SuitabilityNoteTypes",
                c => new
                    {
                        SuitabilityNoteTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SuitabilityNoteTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuitabilityNotes", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.SuitabilityNotes", "SuitabilityNoteTypeId", "dbo.SuitabilityNoteTypes");
            DropIndex("dbo.SuitabilityNotes", "IX_SuitabilityNotes_ContactId");
            DropIndex("dbo.SuitabilityNotes", new[] { "SuitabilityNoteTypeId" });
            DropTable("dbo.SuitabilityNoteTypes");
            DropTable("dbo.SuitabilityNotes");
        }
    }
}
