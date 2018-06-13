using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Allocations.Database.Extensions;

namespace InCoreLib.Domain.Allocations.Database.Audit
{
    public class LogDetailsAuditor : IDisposable
    {
        private readonly DbEntityEntry _dbEntry;
        private readonly AuditLog _log;

        public LogDetailsAuditor(DbEntityEntry dbEntry, AuditLog log)
        {
            _dbEntry = dbEntry;
            _log = log;
        }

        public void Dispose()
        {
        }

        public IEnumerable<AuditLogDetail> CreateLogDetails(ITrackedContext ctx)
        {
            var type = _dbEntry.Entity.GetType().GetEntityType();
            return from propertyName in PropertyNamesOf(_dbEntry)
                where type.IsTrackingEnabled(propertyName) && IsValueChanged(propertyName)
                select ctx.CreateAuditLogDetail(
                    type.GetColumnName(propertyName),
                    OriginalValue(propertyName),
                    CurrentValue(propertyName),
                    _log);
        }

        protected virtual EntityState StateOf(DbEntityEntry dbEntry)
        {
            return dbEntry.State;
        }

        private IEnumerable<string> PropertyNamesOf(DbEntityEntry dbEntry)
        {
            var propertyValues = StateOf(dbEntry) == EntityState.Added
                ? dbEntry.CurrentValues
                : dbEntry.OriginalValues;
            return propertyValues.PropertyNames;
        }

        private bool IsValueChanged(string propertyName)
        {
            var prop = _dbEntry.Property(propertyName);
            var changed = (StateOf(_dbEntry) == EntityState.Added && prop.CurrentValue != null) ||
                          (StateOf(_dbEntry) == EntityState.Deleted && prop.OriginalValue != null) ||
                          (StateOf(_dbEntry) == EntityState.Modified && prop.IsModified);
            return changed && !string.Equals(OriginalValue(propertyName), CurrentValue(propertyName));
        }

        private string OriginalValue(string propertyName)
        {
            if (StateOf(_dbEntry) == EntityState.Added)
            {
                return null;
            }

            var value = _dbEntry.Property(propertyName).OriginalValue;
            return value != null ? value.ToString() : null;
        }

        private string CurrentValue(string propertyName)
        {
            if (StateOf(_dbEntry) == EntityState.Deleted)
            {
                // It will be invalid operation when its in deleted state. in that case, new value should be null
                return null;
            }

            var value = _dbEntry.Property(propertyName).CurrentValue;
            return value != null ? value.ToString() : null;
        }
    }
}