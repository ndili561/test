using System;
using System.Data.Entity.Core.Objects;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;

namespace InCoreLib.Data.Audit.Interfaces
{
    public interface ITrackedUnitOfWork<out T> : IDisposable
        where T : ITrackerModel
    {
        T Context { get; }

        IRepository<IAuditLog> AuditLogs();

        IRepository<IAuditLogDetail> AuditLogDetails();

        void Refresh(object entityObject, RefreshMode refreshMode = RefreshMode.ClientWins);

        void Commit();
    }
}