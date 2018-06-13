using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Incommunities.Core.Service;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Database.Audit
{
    public class TrackedContext : DbContext, ITrackedContext, IDbContext
    {
        public TrackedContext()
        {
        }

        public TrackedContext(string name)
            : base(name)
        {
        }

        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<AuditLogDetail> AuditLogDetails { get; set; }

        public AuditLog CreateAuditLog(string userName, string userIpAddress, DateTime changeTime, EventType eventType,
            string tableName, string recordId)
        {
            var newlog = new AuditLog
            {
                UserName = userName,
                UserIPAddress = userIpAddress,
                EventDateUTC = changeTime,
                EventType = eventType,
                TableName = tableName,
                RecordId = recordId
            };
            return newlog;
        }

        public AuditLogDetail CreateAuditLogDetail(string columnName, string originalValue, string newValue,
            AuditLog log)
        {
            var newlogdetail = new AuditLogDetail
            {
                ColumnName = columnName,
                OriginalValue = originalValue,
                NewValue = newValue,
                AuditLog = log
            };
            return newlogdetail;
        }

        public virtual int SaveChanges(string userName, string userIPAddress)
        {
            AuditChanges( userName, userIPAddress);

            IEnumerable<DbEntityEntry> addedEntries = GetAdditions();
            // Call the original SaveChanges(), which will save both the changes made and the audit records...Note that added entry auditing is still remaining.
            int result = base.SaveChanges();
            //By now., we have got the primary keys of added entries of added entiries because of the call to savechanges.

            AuditAdditions(  addedEntries, userName, userIPAddress);

            //save changes to audit of added entries
            base.SaveChanges();
            return result;
        }

        /// <summary>
        ///     This method saves the model changes to the database.
        ///     If the tracker for a table is active, it will also put the old values in tracking table.
        /// </summary>
        /// <returns>Returns the number of objects written to the underlying database.</returns>
        public override int SaveChanges()
        {
            int result = base.SaveChanges();
            return result;
        }

        #region Helpers

        public void AuditChanges(string userName, string userIPAddress)
        {
            // Get all Deleted/Modified entities (not Unmodified or Detached or Added)
            foreach (
                var ent in ChangeTracker.Entries()
                    .Where(p => p.State == EntityState.Deleted || p.State == EntityState.Modified))
            {
                AddAuditRecord(ent, ent.State == EntityState.Modified ? EventType.Modified : EventType.Deleted, userName, userIPAddress);
            }
        }

        public IEnumerable<DbEntityEntry> GetAdditions()
        {
            return ChangeTracker.Entries().Where(p => p.State == EntityState.Added).ToList();
        }

        public void AuditAdditions(IEnumerable<DbEntityEntry> addedEntries, string userName, string userIPAddress)
        {
            // Get all Added entities
            foreach (var ent in addedEntries)
            {
                AddAuditRecord(ent, EventType.Added, userName, userIPAddress);
            }
        }

        private void AddAuditRecord(DbEntityEntry ent, EventType eventType, string userName, string userIPAddress)
        {
            using (var auditer = new LogAuditor(ent))
            {
                
                if (!string.IsNullOrWhiteSpace(userName)&& !string.IsNullOrWhiteSpace(userIPAddress))
                {
                    var record = auditer.CreateLogRecord(userName, userIPAddress,
                        eventType,
                        this);
                    if (record != null && record.AuditLogDetails.Any())
                    {
                        AuditLogs.Add(record);
                    }
                }
            }
        }

        #endregion Helpers
    }
}