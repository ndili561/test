using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.DAL.Migrations
{
    public static class SQLScriptsHelper
    {
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static void CreateEnumAsTables(AllocationsContext context)
        {
            context.Seed<Priority>();
            context.Seed<Status>();
            context.Seed<AddressType>();
            context.Seed<PlacementStatus>();
            context.Seed<ApplicationActivity>();
            context.Seed<ApplicationChangeType>();
            context.Seed<CustomerGender>();
            context.Seed<DocumentType>();
            context.Seed<NoteType>();
            context.Seed<PlacementGender>();
            context.Seed<Priority>();
            context.Seed<PropertyAgeRestriction>();
            context.Seed<RejectionReason>();
            context.Seed<SaveApplication>();
            context.Seed<SaveContact>();
            context.Seed<UserType>();
        }

        public static void ExecuteSQLScripts(AllocationsContext context)
        {
            var files = GetSqlFiles();

            if (context != null)
                files.ForEach(f => context.Database.ExecuteSqlCommand(Files.ReadAllText(f)));
        }

        private static List<string> GetSqlFiles(string baseDir = "DefaultData")
        {
            var files1 = Folder.GetFiles(baseDir);
            var files = files1
                //.Where(f => f.StartsWith("defaultdata", StringComparison.InvariantCultureIgnoreCase) == false)
                .OrderBy(f => f)
                .Select(f => baseDir + "." + f)
                .ToList();

            return files;
        }

        public static string GetStoredProcedureSql(string storedProcedureName)
        {
           // var files = GetSqlFiles("StoredProcedure");
            var name = storedProcedureName+".sql";
            var list = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(f => f.EndsWith(name));
           // var file = files.FirstOrDefault(f => f.Contains(storedProcedureName));
            return Files.ReadAllText(list);
        }
    }
}
