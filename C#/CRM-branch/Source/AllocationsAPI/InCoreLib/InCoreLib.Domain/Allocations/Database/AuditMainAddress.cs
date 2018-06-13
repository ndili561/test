using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("AuditMainAddress")]
    public partial class AuditMainAddress
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        public int? CustomerApplicationID { get; set; }

        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(255)]
        public string Address2 { get; set; }

        [StringLength(255)]
        public string Address3 { get; set; }

        [StringLength(255)]
        public string Address4 { get; set; }

        [StringLength(16)]
        public string PostCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }
    }
}
