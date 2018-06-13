namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClaimingHosingBenefitsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLContacts", "ClaimHousingBenefitAtNewProperty", c => c.Boolean(nullable: false));
            AddColumn("dbo.VBLContacts", "ClaimingHousingBenefitAtCurrentProperty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLContacts", "ClaimingHousingBenefitAtCurrentProperty");
            DropColumn("dbo.VBLContacts", "ClaimHousingBenefitAtNewProperty");
        }
    }
}
