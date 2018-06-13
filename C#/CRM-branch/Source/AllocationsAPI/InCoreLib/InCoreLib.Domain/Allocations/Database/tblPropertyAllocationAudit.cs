using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblPropertyAllocationAudit")]
    public partial class tblPropertyAllocationAudit
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

        public int? PropertyAllocationOutcomeID { get; set; }

        public int? OriginalPropertyID { get; set; }

        public int? RevisedPropertyID { get; set; }

        public int? OriginalCaseRefNumber { get; set; }

        public int? RevisedCaseRefNumber { get; set; }

        [StringLength(255)]
        public string OriginalFullName { get; set; }

        [StringLength(255)]
        public string RevisedFullName { get; set; }

        [StringLength(50)]
        public string OriginalAssessorUserID { get; set; }

        [StringLength(50)]
        public string RevisedAssessorUserID { get; set; }

        [StringLength(50)]
        public string OriginalAllocationOutcome { get; set; }

        [StringLength(50)]
        public string RevisedAllocationOutcome { get; set; }
    }
}
