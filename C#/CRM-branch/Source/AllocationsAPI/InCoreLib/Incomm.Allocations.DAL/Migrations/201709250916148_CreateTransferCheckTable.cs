namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTransferCheckTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransferChecks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        IsAsbCheckOk = c.Boolean(nullable: false),
                        IsDebtCheckOk = c.Boolean(nullable: false),
                        IsOtherTenancyBreachesCheckOk = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId, unique: true, name: "IX_TransferCheck_ContactId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransferChecks", "ContactId", "dbo.VBLContacts");
            DropIndex("dbo.TransferChecks", "IX_TransferCheck_ContactId");
            DropTable("dbo.TransferChecks");
        }
    }
}
