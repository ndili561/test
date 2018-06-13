namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    // Column was already dropped when the audit tables were refreshed.
    public partial class UpdateExpenditureAuditTable : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.AuditVblExpenditureDetails", "RowVersion");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.AuditVblExpenditureDetails", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
