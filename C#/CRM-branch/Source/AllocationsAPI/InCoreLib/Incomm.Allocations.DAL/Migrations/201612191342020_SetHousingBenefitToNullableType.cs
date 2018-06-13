namespace InCoreLib.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SetHousingBenefitToNullableType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VBLContacts", "ClaimHousingBenefitAtNewProperty", c => c.Boolean());
            AlterColumn("dbo.VBLContacts", "ClaimingHousingBenefitAtCurrentProperty", c => c.Boolean());
            Sql("UPDATE dbo.VBLContacts SET ClaimHousingBenefitAtNewProperty = NULL, ClaimingHousingBenefitAtCurrentProperty = NULL");
            Sql(@"  BEGIN TRY
	                    DECLARE @ConstraintName VARCHAR(200)
	                    SELECT @ConstraintName = NAME FROM SYS.DEFAULT_CONSTRAINTS WHERE COL_NAME(PARENT_OBJECT_ID, PARENT_COLUMN_ID) = 'ClaimHousingBenefitAtNewProperty'
	                    EXEC ('ALTER TABLE dbo.VBLContacts DROP CONSTRAINT ' + @ConstraintName)
	                    SELECT @ConstraintName = NAME FROM SYS.DEFAULT_CONSTRAINTS WHERE COL_NAME(PARENT_OBJECT_ID, PARENT_COLUMN_ID) = 'ClaimingHousingBenefitAtCurrentProperty'
	                    EXEC ('ALTER TABLE dbo.VBLContacts DROP CONSTRAINT ' + @ConstraintName)
                    END TRY
                    BEGIN CATCH END CATCH");
        }
        
        public override void Down()
        {
            Sql("UPDATE dbo.VBLContacts SET ClaimHousingBenefitAtNewProperty = 0 WHERE ClaimHousingBenefitAtNewProperty IS NULL");
            Sql("UPDATE dbo.VBLContacts SET ClaimingHousingBenefitAtCurrentProperty = 0 WHERE ClaimingHousingBenefitAtCurrentProperty IS NULL");
            AlterColumn("dbo.VBLContacts", "ClaimingHousingBenefitAtCurrentProperty", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VBLContacts", "ClaimHousingBenefitAtNewProperty", c => c.Boolean(nullable: false));
        }
    }
}
