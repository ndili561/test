using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstCaseStatusAudit")]
    public partial class lstCaseStatusAudit
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

        public int? CaseStatus { get; set; }

        [StringLength(50)]
        public string OriginalCaseStatusDescription { get; set; }

        [StringLength(50)]
        public string RevisedCaseStatusDescription { get; set; }
    }
}
