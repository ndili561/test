namespace InCoreLib.Data.Audit.Interfaces
{
    public interface IAuditLogDetail
    {
        int Id { get; set; }
        string ColumnName { get; set; }
        string OriginalValue { get; set; }
        string NewValue { get; set; }
        int AuditLogId { get; set; }
        IAuditLog Log { get; set; }
    }
}