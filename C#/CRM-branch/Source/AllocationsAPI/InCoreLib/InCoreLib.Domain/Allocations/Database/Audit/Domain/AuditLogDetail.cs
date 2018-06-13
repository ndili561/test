using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.Audit.Domain
{
    public class AuditLogDetail
    {
        [Key]
        public int Id { get; set; }

        public string ColumnName { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }

        public int AuditLogId { get; set; }
        public virtual AuditLog AuditLog { get; set; }
    }
}