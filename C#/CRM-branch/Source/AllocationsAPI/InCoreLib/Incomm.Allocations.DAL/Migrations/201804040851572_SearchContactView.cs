using Incomm.Allocations.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SearchContactView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VBLContacts", "GlobalIdentityKey", c => c.Guid());
            Sql("UPDATE VBLContacts SET GlobalIdentityKey = NEWID()");
        }

        public override void Down()
        {
            DropColumn("dbo.VBLContacts", "GlobalIdentityKey");
           
        }
    }
}
