using InCoreLib.Domain.Allocations.Database.Audit;

namespace InCoreLib.Data.Audit.Interfaces
{
    public interface ITrackerModel
    {
        TrackedContext TrackedContext { get; }
        //IAuditLog CreateAuditLog(string userName, string userIpAddress, DateTime changeTime, EventType eventType,
        //    string tableName, string recordId);

        //IAuditLogDetail CreateAuditLogDetail(string columnName, string originalValue, string newValue, IAuditLog log);
    }
}