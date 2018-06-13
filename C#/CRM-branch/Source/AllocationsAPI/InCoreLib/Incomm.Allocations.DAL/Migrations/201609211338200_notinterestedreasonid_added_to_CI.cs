namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notinterestedreasonid_added_to_CI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLCustomerInterests", "NotInterestedReasonId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLCustomerInterests", "NotInterestedReasonId");
        }
    }
}
