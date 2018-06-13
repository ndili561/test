using Incomm.Allocations.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// </summary>
    public partial class FixActionCategoryAffordablilitySpellingMistake : DbMigration
    {
        /// <summary>
        /// </summary>
        public override void Up()
        {
            Sql(SqlProgrammability.FixActionCategoryAffordabilitySpellingMistake);
        }

        /// <summary>
        /// </summary>
        public override void Down()
        {
            Sql(SqlProgrammability.RevertActionCategoryAffordabilitySpellingMistake);
        }
    }
}
