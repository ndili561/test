using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstOutcomeResultAudit")]
    public partial class lstOutcomeResultAudit
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
        public string OutcomeResult { get; set; }

        [StringLength(100)]
        public string OriginalOutcomeResultDec { get; set; }

        [StringLength(100)]
        public string RevisedOutcomeResultDec { get; set; }

        public int? OriginalOutcomeCategoryId { get; set; }

        public int? RevisedOutcomeCategoryId { get; set; }

        public bool? OriginalOutcomeOtherField { get; set; }

        public bool? RevisedOutcomeOtherField { get; set; }
    }
}
