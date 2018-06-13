using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lstHomelessP1eCategoriesHavingTempAccomAudit
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

        public int? P1eCHTAcode { get; set; }

        [StringLength(50)]
        public string OriginalHOR_P1eCategoriesHavingTempAccom { get; set; }

        [StringLength(50)]
        public string RevisedHOR_P1eCategoriesHavingTempAccom { get; set; }
    }
}
