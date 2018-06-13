using Incomm.Allocations.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateExpenditureRelatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditVblExpenditureDetails",
                c => new
                {
                    AuditID = c.Int(nullable: false, identity: true),
                    ExpenditureDetailId = c.Int(nullable: false),
                    ExpendituresComment = c.String(),
                    ExpenditureTypeId = c.Int(nullable: false),
                    ExpenditureFrequencyId = c.Int(nullable: false),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Debt = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FutureCostInUse = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ContactId = c.Int(nullable: false),
                    LoginName = c.String(),
                    ChangeType = c.String(),
                    ChangeDate = c.DateTime(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    ModifiedBy = c.String(maxLength: 60),
                    ModifiedDate = c.DateTime(),
                })
                .PrimaryKey(t => t.AuditID)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);

            CreateTable(
                "dbo.AuditVBLIncomeDetails",
                c => new
                {
                    AuditID = c.Int(nullable: false, identity: true),
                    IncomeDetailId = c.Int(nullable: false),
                    IncomesComment = c.String(),
                    IncomeTypeId = c.Int(nullable: false),
                    IncomeFrequencyId = c.Int(nullable: false),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ContactId = c.Int(nullable: false),
                    LoginName = c.String(),
                    ChangeType = c.String(),
                    ChangeDate = c.DateTime(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    ModifiedBy = c.String(maxLength: 60),
                    ModifiedDate = c.DateTime(),
                })
                .PrimaryKey(t => t.AuditID)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.IncomeFrequency", t => t.IncomeFrequencyId, cascadeDelete: true)
                .ForeignKey("dbo.IncomeType", t => t.IncomeTypeId, cascadeDelete: true)
                .Index(t => t.IncomeTypeId)
                .Index(t => t.IncomeFrequencyId)
                .Index(t => t.ContactId);

            CreateTable(
                "dbo.ExpenditureType",
                c => new
                {
                    ExpenditureTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Active = c.Boolean(nullable: false),
                    SortOrder = c.Int(),
                    AllowMultiple = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ExpenditureTypeId);

            CreateTable(
                "dbo.VBLExpenditureDetails",
                c => new
                {
                    ExpenditureDetailId = c.Int(nullable: false, identity: true),
                    ExpendituresComment = c.String(),
                    ExpenditureTypeId = c.Int(nullable: false),
                    ExpenditureFrequencyId = c.Int(nullable: false),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Debt = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FutureCostInUse = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ContactId = c.Int(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    ModifiedBy = c.String(maxLength: 60),
                    ModifiedDate = c.DateTime(),
                })
                .PrimaryKey(t => t.ExpenditureDetailId)
                .ForeignKey("dbo.VBLContacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);

            //AddColumn("dbo.tbl_Property", "CatDog", c => c.Boolean());
            //AddColumn("dbo.tbl_Property", "NumSteps", c => c.Int(nullable: false));
            //AddColumn("dbo.tbl_Property", "HighRise", c => c.Boolean());
            //AddColumn("dbo.tbl_Property", "CommEnt", c => c.Boolean());
            //DropTable("dbo.VBLPropertyShops");
            //DropTable("dbo.VBLPropertyShopImages");

            Sql(SqlProgrammability.InsertExpenditureTypeData);
            Sql(SqlProgrammability.CreatetrVBLExpenditureDetailsTrigger);
            Sql(SqlProgrammability.CreatetrVBLIncomeDetailsTrigger);
        }

        public override void Down()
        {
            Sql(SqlProgrammability.RemovetrVBLExpenditureDetailsTrigger);
            Sql(SqlProgrammability.RemovetrVBLIncomeDetailsTrigger);

            DropForeignKey("dbo.VBLExpenditureDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.AuditVBLIncomeDetails", "IncomeTypeId", "dbo.IncomeType");
            DropForeignKey("dbo.AuditVBLIncomeDetails", "IncomeFrequencyId", "dbo.IncomeFrequency");
            DropForeignKey("dbo.AuditVBLIncomeDetails", "ContactId", "dbo.VBLContacts");
            DropForeignKey("dbo.AuditVblExpenditureDetails", "ContactId", "dbo.VBLContacts");
            DropIndex("dbo.VBLExpenditureDetails", new[] { "ContactId" });
            DropIndex("dbo.AuditVBLIncomeDetails", new[] { "ContactId" });
            DropIndex("dbo.AuditVBLIncomeDetails", new[] { "IncomeFrequencyId" });
            DropIndex("dbo.AuditVBLIncomeDetails", new[] { "IncomeTypeId" });
            DropIndex("dbo.AuditVblExpenditureDetails", new[] { "ContactId" });
            //DropColumn("dbo.tbl_Property", "CommEnt");
            //DropColumn("dbo.tbl_Property", "HighRise");
            //DropColumn("dbo.tbl_Property", "NumSteps");
            //DropColumn("dbo.tbl_Property", "CatDog");
            DropTable("dbo.VBLExpenditureDetails");
            DropTable("dbo.ExpenditureType");
            DropTable("dbo.AuditVBLIncomeDetails");
            DropTable("dbo.AuditVblExpenditureDetails");
        }
    }
}
