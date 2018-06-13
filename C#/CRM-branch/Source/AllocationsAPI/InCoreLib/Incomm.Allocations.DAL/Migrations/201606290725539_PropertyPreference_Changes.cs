namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyPreference_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLRequestedPropertymatchDetails", "NumberOfSteps", c => c.Int(nullable: false));
            AlterColumn("dbo.VBLCustomerInterests", "PropertyCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VBLCustomerInterests", "PropertyCode", c => c.Int(nullable: false));
            DropColumn("dbo.VBLRequestedPropertymatchDetails", "NumberOfSteps");
        }
    }
}
