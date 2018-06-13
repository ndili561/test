using System.Data.Entity.Migrations;

namespace InCoreLib.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AllocationsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AllocationsContext context)
        {
            context.Database.CommandTimeout = 360;
            //SQLScriptsHelper.ExecuteSQLScripts(context);
            SQLScriptsHelper.CreateEnumAsTables(context);
        }
    }
}