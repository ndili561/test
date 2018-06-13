using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tbl_Audit_CustomerApplication
    {
        [Key]
        public int AuditID { get; set; }

        public int? CustomerApplicationId { get; set; }

        [StringLength(10)]
        public string ChangeType { get; set; }

        [Required]
        [StringLength(128)]
        public string Username { get; set; }

        [StringLength(30)]
        public string ChangeDate { get; set; }

        [StringLength(500)]
        public string FieldName { get; set; }

        [StringLength(4000)]
        public string FromValue { get; set; }

        [StringLength(4000)]
        public string ToVaue { get; set; }
    }
}
