using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstOutcomeCategoryAudit")]
    public partial class lstOutcomeCategoryAudit
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

        public int? OutcomeCategoryId { get; set; }

        public bool? OriginalDeleted { get; set; }

        public bool? RevisedDeleted { get; set; }

        [StringLength(100)]
        public string OriginalOutcomeCategoryDec { get; set; }

        [StringLength(100)]
        public string RevisedOutcomeCategoryDec { get; set; }
    }
}
