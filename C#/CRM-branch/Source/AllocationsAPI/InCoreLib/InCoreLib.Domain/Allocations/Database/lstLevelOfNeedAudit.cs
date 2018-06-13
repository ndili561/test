using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstLevelOfNeedAudit")]
    public partial class lstLevelOfNeedAudit
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

        [StringLength(1)]
        public string LevelOfNeed { get; set; }

        [StringLength(50)]
        public string OriginalLevelOfNeedDesc { get; set; }

        [StringLength(50)]
        public string RevisedLevelOfNeedDesc { get; set; }
    }
}
