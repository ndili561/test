using Incomm.Allocations.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveContactPersonData : DbMigration
    {
        public override void Up()
        {
            Sql(SqlProgrammability.Alter_PropertyMatchForApplicationId);
            Sql(SqlProgrammability.create_SearchContactView);
            Sql(SqlProgrammability.RemoveDuplicateCRMData);
            //DropForeignKey("dbo.VBLAddresses", "ApplicationId", "dbo.VBLApplications");
            //DropForeignKey("dbo.VBLApplications", "AddressId", "dbo.VBLAddresses");
            //DropForeignKey("dbo.VBLAddresses", "VBLContact_ContactId", "dbo.VBLContacts");
            //DropForeignKey("dbo.VBLContactByDetails", "ContactById", "dbo.ContactBy");
            //DropForeignKey("dbo.VBLContactByDetails", "ContactId", "dbo.VBLContacts");
            //DropForeignKey("dbo.VBLContacts", "EthnicityId", "dbo.Ethnicity");
            //DropForeignKey("dbo.VBLContacts", "GenderId", "dbo.Gender");
            //DropForeignKey("dbo.VBLContacts", "NationalityTypeId", "dbo.NationalityType");
            //DropForeignKey("dbo.VBLContacts", "LanguageId", "dbo.PreferredLanguages");
            //DropForeignKey("dbo.VBLContacts", "TitleId", "dbo.Title");
            //DropIndex("dbo.VBLContacts", new[] { "TitleId" });
            //DropIndex("dbo.VBLContacts", new[] { "GenderId" });
            //DropIndex("dbo.VBLContacts", new[] { "EthnicityId" });
            //DropIndex("dbo.VBLContacts", new[] { "NationalityTypeId" });
            //DropIndex("dbo.VBLContacts", new[] { "LanguageId" });
            //DropIndex("dbo.VBLAddresses", new[] { "ApplicationId" });
            //DropIndex("dbo.VBLAddresses", new[] { "VBLContact_ContactId" });
            //DropIndex("dbo.VBLApplications", new[] { "AddressId" });
            //DropIndex("dbo.VBLContactByDetails", new[] { "ContactId" });
            //DropIndex("dbo.VBLContactByDetails", new[] { "ContactById" });
            //AddColumn("dbo.SearchContacts", "NationalInsuranceNumber", c => c.String());
            //AddColumn("dbo.SearchContacts", "AddressId", c => c.Int());
            //DropColumn("dbo.VBLContacts", "NationalInsuranceNumber");
            //DropColumn("dbo.VBLContacts", "TitleId");
            //DropColumn("dbo.VBLContacts", "GenderId");
            //DropColumn("dbo.VBLContacts", "EthnicityId");
            //DropColumn("dbo.VBLContacts", "NationalityTypeId");
            //DropColumn("dbo.VBLContacts", "Forename");
            //DropColumn("dbo.VBLContacts", "Surname");
            //DropColumn("dbo.VBLContacts", "DateOfBirth");
            //DropColumn("dbo.VBLContacts", "LanguageId");
            //DropColumn("dbo.VBLApplications", "AddressId");
            //DropTable("dbo.VBLAddresses");
            //DropTable("dbo.VBLContactByDetails");
            //DropTable("dbo.PreferredLanguages");
        }
        
        public override void Down()
        {
            Sql(SqlProgrammability.drop_SearchContactView);
            //CreateTable(
            //    "dbo.PreferredLanguages",
            //    c => new
            //        {
            //            LanguageId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Active = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.LanguageId);

            //CreateTable(
            //    "dbo.VBLContactByDetails",
            //    c => new
            //        {
            //            ContactId = c.Int(nullable: false),
            //            ContactById = c.Int(nullable: false),
            //            ContactValue = c.String(),
            //            ContactText = c.String(),
            //            ConcurrencyCheck = c.Binary(),
            //        })
            //    .PrimaryKey(t => new { t.ContactId, t.ContactById });

            //CreateTable(
            //    "dbo.VBLAddresses",
            //    c => new
            //        {
            //            AddressId = c.Int(nullable: false, identity: true),
            //            LivedAtAddressYears = c.Int(),
            //            LivedAtAddressMonths = c.Int(),
            //            AddressType = c.Int(nullable: false),
            //            PropertyCode = c.String(),
            //            AddressLine1 = c.String(),
            //            AddressLine2 = c.String(),
            //            AddressLine3 = c.String(),
            //            AddressLine4 = c.String(),
            //            PostCode = c.String(),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy = c.String(maxLength: 256),
            //            CreatedDate = c.DateTime(nullable: false),
            //            RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
            //            ModifiedBy = c.String(maxLength: 256),
            //            ModifiedDate = c.DateTime(),
            //            ApplicationId = c.Int(),
            //            VBLContact_ContactId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.AddressId);

            //AddColumn("dbo.VBLApplications", "AddressId", c => c.Int());
            //AddColumn("dbo.VBLContacts", "LanguageId", c => c.Int(nullable: false));
            //AddColumn("dbo.VBLContacts", "DateOfBirth", c => c.DateTime(nullable: false));
            //AddColumn("dbo.VBLContacts", "Surname", c => c.String());
            //AddColumn("dbo.VBLContacts", "Forename", c => c.String());
            //AddColumn("dbo.VBLContacts", "NationalityTypeId", c => c.Int(nullable: false));
            //AddColumn("dbo.VBLContacts", "EthnicityId", c => c.Int(nullable: false));
            //AddColumn("dbo.VBLContacts", "GenderId", c => c.Int(nullable: false));
            //AddColumn("dbo.VBLContacts", "TitleId", c => c.Int(nullable: false));
            //AddColumn("dbo.VBLContacts", "NationalInsuranceNumber", c => c.String());
            //DropColumn("dbo.SearchContacts", "AddressId");
            //DropColumn("dbo.SearchContacts", "NationalInsuranceNumber");
            //CreateIndex("dbo.VBLContactByDetails", "ContactById");
            //CreateIndex("dbo.VBLContactByDetails", "ContactId");
            //CreateIndex("dbo.VBLApplications", "AddressId");
            //CreateIndex("dbo.VBLAddresses", "VBLContact_ContactId");
            //CreateIndex("dbo.VBLAddresses", "ApplicationId");
            //CreateIndex("dbo.VBLContacts", "LanguageId");
            //CreateIndex("dbo.VBLContacts", "NationalityTypeId");
            //CreateIndex("dbo.VBLContacts", "EthnicityId");
            //CreateIndex("dbo.VBLContacts", "GenderId");
            //CreateIndex("dbo.VBLContacts", "TitleId");
            //AddForeignKey("dbo.VBLContacts", "TitleId", "dbo.Title", "TitleId", cascadeDelete: true);
            //AddForeignKey("dbo.VBLContacts", "LanguageId", "dbo.PreferredLanguages", "LanguageId", cascadeDelete: true);
            //AddForeignKey("dbo.VBLContacts", "NationalityTypeId", "dbo.NationalityType", "NationalityTypeId", cascadeDelete: true);
            //AddForeignKey("dbo.VBLContacts", "GenderId", "dbo.Gender", "GenderId", cascadeDelete: true);
            //AddForeignKey("dbo.VBLContacts", "EthnicityId", "dbo.Ethnicity", "EthnicityId", cascadeDelete: true);
            //AddForeignKey("dbo.VBLContactByDetails", "ContactId", "dbo.VBLContacts", "ContactId", cascadeDelete: true);
            //AddForeignKey("dbo.VBLContactByDetails", "ContactById", "dbo.ContactBy", "ContactById", cascadeDelete: true);
            //AddForeignKey("dbo.VBLAddresses", "VBLContact_ContactId", "dbo.VBLContacts", "ContactId");
            //AddForeignKey("dbo.VBLApplications", "AddressId", "dbo.VBLAddresses", "AddressId");
            //AddForeignKey("dbo.VBLAddresses", "ApplicationId", "dbo.VBLApplications", "ApplicationId");
        }
    }
}
