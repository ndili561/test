using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessOutcomeResultAudit")]
    public partial class lstHomelessOutcomeResultAudit
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
        public string HomelessOutcomeResult { get; set; }

        [StringLength(50)]
        public string OriginalHomelessOutcomeResultDesc { get; set; }

        [StringLength(50)]
        public string RevisedHomelessOutcomeResultDesc { get; set; }

        [StringLength(50)]
        public string OriginalHOR_P1eCategoriesHavingTempAccom { get; set; }

        [StringLength(50)]
        public string RevisedHOR_P1eCategoriesHavingTempAccom { get; set; }

        [StringLength(50)]
        public string OriginalHOR_P1eCategoriesNotHavingTempAccom { get; set; }

        [StringLength(50)]
        public string RevisedHOR_P1eCategoriesNotHavingTempAccom { get; set; }
    }
}
