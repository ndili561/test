using Incomm.Allocations.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// </summary>
    public partial class RiskAndActionTableData : DbMigration
    {
        public override void Up()
        {
            Sql(SqlProgrammability.InsertActionAndRiskLookupData);
        }

        public override void Down()
        {
            Sql(SqlProgrammability.DeleteActionAndRiskLookupData);
        }
    }
}
