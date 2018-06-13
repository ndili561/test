using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;

namespace InCoreLib.Domain.Allocations.Database.Audit
{
    public abstract class TrackedUnitOfWork : IDisposable
    {
        private IRepository<AuditLogDetail> _auditLogDetailsRepository;
        private IRepository<AuditLog> _auditLogRepository;

        protected TrackedUnitOfWork(TrackedContext context)
        {
            Context = context;
        }

        // ReSharper disable once ConvertToAutoProperty
        public TrackedContext Context { get; set; }

        public virtual void Dispose()
        {
            Context.Dispose();
        }

        public IRepository<AuditLog> AuditLogs()
        {
            return _auditLogRepository ??
                   (_auditLogRepository = new Repository<AuditLog>(Context));
        }

        public IRepository<AuditLogDetail> AuditLogDetails()
        {
            return _auditLogDetailsRepository ??
                   (_auditLogDetailsRepository = new Repository<AuditLogDetail>());
        }

        public virtual void Refresh(object entityObject, RefreshMode refreshMode = RefreshMode.ClientWins)
        {
            var objectContext = (Context as IObjectContextAdapter).ObjectContext;
            objectContext.Refresh(refreshMode, entityObject);
        }

        public void Commit(string userId="", string userIPAddress = "")
        {
            Context.SaveChanges(userId, userIPAddress);
        }
    }
}