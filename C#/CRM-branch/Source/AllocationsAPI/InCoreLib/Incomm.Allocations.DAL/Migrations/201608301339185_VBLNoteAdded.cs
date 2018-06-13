namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VBLNoteAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VBLNotes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        NoteType = c.Int(nullable: false),
                        Description = c.String(),
                        ContactId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 60),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VBLNotes", "ContactId", "dbo.VBLContacts");
            DropIndex("dbo.VBLNotes", new[] { "ContactId" });
            DropTable("dbo.VBLNotes");
        }
    }
}
