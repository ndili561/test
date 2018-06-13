using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessDecisionAudit")]
    public partial class lstHomelessDecisionAudit
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
        public string HomelessDecision { get; set; }

        [StringLength(50)]
        public string OriginalHomelessDecisionDesc { get; set; }

        [StringLength(50)]
        public string RevisedHomelessDecisionDesc { get; set; }

        public int? OriginalP1Eindex { get; set; }

        public int? RevisedP1Eindex { get; set; }
    }
}
