using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class bkp_CustomerNote_Note_Audit
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        public int? CustomerApplicationId { get; set; }

        [StringLength(10)]
        public string ChangeType { get; set; }

        [Key]
        [Column(Order = 1)]
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
