using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblRehousedCustomersAudit")]
    public partial class tblRehousedCustomersAudit
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

        public int? CaseRefNumber { get; set; }

        public DateTime? OriginalOutcomeDate { get; set; }

        public DateTime? RevisedOutcomeDate { get; set; }
    }
}
