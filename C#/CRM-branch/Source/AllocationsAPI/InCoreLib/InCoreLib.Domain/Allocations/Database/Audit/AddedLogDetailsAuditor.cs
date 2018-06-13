using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using InCoreLib.Data.Audit;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;

namespace InCoreLib.Domain.Allocations.Database.Audit
{
    /// <summary>
    ///     Creates AuditLogDetails for entries added in a previous call to SaveChanges.
    /// </summary>
    public class AddedLogDetailsAuditor : LogDetailsAuditor
    {
        public AddedLogDetailsAuditor(DbEntityEntry dbEntry, AuditLog log) : base(dbEntry, log)
        {
        }

        /// <summary>
        ///     Treat unchanged entries as added entries when creating audit records.
        /// </summary>
        /// <param name="dbEntry"></param>
        /// <returns></returns>
        protected override EntityState StateOf(DbEntityEntry dbEntry)
        {
            if (dbEntry.State == EntityState.Unchanged)
            {
                return EntityState.Added;
            }

            return base.StateOf(dbEntry);
        }
    }
}