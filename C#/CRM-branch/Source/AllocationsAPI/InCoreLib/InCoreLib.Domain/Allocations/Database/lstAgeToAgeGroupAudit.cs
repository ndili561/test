using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAgeToAgeGroupAudit")]
    public partial class lstAgeToAgeGroupAudit
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

        public int? AgeValue { get; set; }

        [StringLength(50)]
        public string OriginalAgeGroup { get; set; }

        [StringLength(50)]
        public string RevisedAgeGroup { get; set; }
    }
}
