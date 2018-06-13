using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstFamilyCompositionAudit")]
    public partial class lstFamilyCompositionAudit
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
        public string FamilyComposition { get; set; }

        [StringLength(50)]
        public string OriginalP1Egrouping { get; set; }

        [StringLength(50)]
        public string RevisedP1Egrouping { get; set; }

        [StringLength(50)]
        public string OriginalNumberdependantchildren { get; set; }

        [StringLength(50)]
        public string RevisedNumberdependantchildren { get; set; }
    }
}
