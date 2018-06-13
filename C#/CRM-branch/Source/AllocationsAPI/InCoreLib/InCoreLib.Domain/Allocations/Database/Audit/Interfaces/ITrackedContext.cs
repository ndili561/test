using System;
using System.Data.Entity;
using Incommunities.Core.Service;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Database.Audit.Interfaces
{
    public interface ITrackedContext : IDbContext
    {
        DbSet<AuditLog> AuditLogs { get; }
        DbSet<AuditLogDetail> AuditLogDetails { get; }

        AuditLog CreateAuditLog(string userName, string userIpAddress, DateTime changeTime, EventType eventType,
            string tableName, string recordId);

        AuditLogDetail CreateAuditLogDetail(string columnName, string originalValue, string newValue, AuditLog log);
    }
}