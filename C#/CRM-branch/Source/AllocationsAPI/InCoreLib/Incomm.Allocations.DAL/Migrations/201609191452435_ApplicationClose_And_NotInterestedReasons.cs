namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationClose_And_NotInterestedReasons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationCloseReasons",
                c => new
                    {
                        ApplicationCloseReasonId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ApplicationCloseReasonId);
            
            CreateTable(
                "dbo.NotInterestedReasons",
                c => new
                    {
                        NotInterestedReasonId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.NotInterestedReasonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NotInterestedReasons");
            DropTable("dbo.ApplicationCloseReasons");
        }
    }
}
