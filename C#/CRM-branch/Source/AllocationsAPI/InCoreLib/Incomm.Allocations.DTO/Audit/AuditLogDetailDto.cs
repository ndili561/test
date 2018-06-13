using System.ComponentModel.DataAnnotations;

namespace Incomm.Allocations.BLL.DTOs.Audit
{
    public class AuditLogDetailDto
    {
        public int Id { get; set; }

        [Display(Name = "Column Name")]
        public string ColumnName { get; set; }

        [Display(Name = "Original Value")]
        public string OriginalValue { get; set; }

        [Display(Name = "New Value")]
        public string NewValue { get; set; }

        public virtual int AuditLogId { get; set; }

        public AuditLogDto AuditLog { get; set; }
    }
}