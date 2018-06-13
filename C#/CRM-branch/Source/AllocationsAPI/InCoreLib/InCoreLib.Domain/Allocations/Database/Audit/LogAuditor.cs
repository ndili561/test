using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Allocations.Database.Extensions;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Database.Audit
{
    public class LogAuditor : IDisposable
    {
        private readonly DbEntityEntry _dbEntry;

        public LogAuditor(DbEntityEntry dbEntry)
        {
            _dbEntry = dbEntry;
        }

        public void Dispose()
        {
        }

        public AuditLog CreateLogRecord(object userName, string userIpAddress, EventType eventType, ITrackedContext context)
        {
            var entityType = _dbEntry.Entity.GetType().GetEntityType();
            var changeTime = DateTime.UtcNow;

            if (!entityType.IsTrackingEnabled())
            {
                return null;
            }

            var keyNames = entityType.GetPrimaryKeyNames(context);

            var newlog = context.CreateAuditLog(
                userName != null ? userName.ToString() : null,
                userIpAddress,
                changeTime,
                eventType,
                entityType.GetTableName(context),
                _dbEntry.GetPrimaryKeyValues(keyNames).ToString()
                );

            using (var detailsAuditor = eventType == EventType.Added
                ? new AddedLogDetailsAuditor(_dbEntry, newlog)
                : new LogDetailsAuditor(_dbEntry, newlog))
            {
                newlog.AuditLogDetails = detailsAuditor.CreateLogDetails(context).ToList();
            }

            return newlog;
        }
    }
}