namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VblReceivingSupportDetail : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VBLSupportContactByDetails", name: "VblReceivingSupportDetail_ReceivingSupportDetailId", newName: "ReceivingSupportDetailId");
            RenameIndex(table: "dbo.VBLSupportContactByDetails", name: "IX_VblReceivingSupportDetail_ReceivingSupportDetailId", newName: "IX_ReceivingSupportDetailId");
            DropPrimaryKey("dbo.VBLSupportContactByDetails");
            AddColumn("dbo.VBLContacts", "TenancyReference", c => c.String());
            AddColumn("dbo.VBLSupportContactByDetails", "SupportContactByDetailId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VBLSupportContactByDetails", "SupportContactByDetailId");
            DropColumn("dbo.VBLContacts", "TenantcyReference");
            DropColumn("dbo.VBLSupportContactByDetails", "SupportDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VBLSupportContactByDetails", "SupportDetailId", c => c.Int(nullable: false));
            AddColumn("dbo.VBLContacts", "TenantcyReference", c => c.String());
            DropPrimaryKey("dbo.VBLSupportContactByDetails");
            DropColumn("dbo.VBLSupportContactByDetails", "SupportContactByDetailId");
            DropColumn("dbo.VBLContacts", "TenancyReference");
            AddPrimaryKey("dbo.VBLSupportContactByDetails", new[] { "SupportDetailId", "ContactById" });
            RenameIndex(table: "dbo.VBLSupportContactByDetails", name: "IX_ReceivingSupportDetailId", newName: "IX_VblReceivingSupportDetail_ReceivingSupportDetailId");
            RenameColumn(table: "dbo.VBLSupportContactByDetails", name: "ReceivingSupportDetailId", newName: "VblReceivingSupportDetail_ReceivingSupportDetailId");
        }
    }
}
