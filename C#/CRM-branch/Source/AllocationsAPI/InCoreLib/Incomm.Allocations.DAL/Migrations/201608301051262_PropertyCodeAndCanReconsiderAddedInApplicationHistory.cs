namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyCodeAndCanReconsiderAddedInApplicationHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLApplicationHistories", "PropertyCode", c => c.String());
            AddColumn("dbo.VBLApplicationHistories", "CanReconsider", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLApplicationHistories", "CanReconsider");
            DropColumn("dbo.VBLApplicationHistories", "PropertyCode");
        }
    }
}
