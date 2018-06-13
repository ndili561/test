using Incomm.Allocations.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// </summary>
    public partial class RemoveDuplicateRiskCategory : DbMigration
    {
        /// <summary>
        /// </summary>
        public override void Up()
        {
            Sql(SqlProgrammability.RemoveDuplicateRiskCategory);
        }

        /// <summary>
        /// </summary>
        public override void Down()
        {
        }
    }
}
