namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyCodeAddedInAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLAddresses", "PropertyCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLAddresses", "PropertyCode");
        }
    }
}
