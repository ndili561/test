namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FixMissingMigrationsFromDevInEFBranch : DbMigration
    {
        public override void Up()
        {
            
            AlterColumn("dbo.VBLContacts", "ClaimHousingBenefitAtNewProperty", c => c.Boolean());
            AlterColumn("dbo.VBLContacts", "ClaimingHousingBenefitAtCurrentProperty", c => c.Boolean());
        }

        public override void Down()
        {
            DropForeignKey("dbo.VBLIncommunitiesRelationships", "ContactId", "dbo.VBLContacts");
            AlterColumn("dbo.VBLContacts", "ClaimingHousingBenefitAtCurrentProperty", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VBLContacts", "ClaimHousingBenefitAtNewProperty", c => c.Boolean(nullable: false));
        }
    }
}
