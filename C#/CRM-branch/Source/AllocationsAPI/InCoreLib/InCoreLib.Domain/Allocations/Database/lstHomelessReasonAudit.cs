using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessReasonAudit")]
    public partial class lstHomelessReasonAudit
    {
        [Key]
        [Column(Order = 0)]
        public DateTime RevisionDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RevisionUserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string AuditAction { get; set; }

        [StringLength(50)]
        public string HomelessReason { get; set; }

        [StringLength(100)]
        public string OriginalHomelessReasonDesc { get; set; }

        [StringLength(100)]
        public string RevisedHomelessReasonDesc { get; set; }
    }
}
