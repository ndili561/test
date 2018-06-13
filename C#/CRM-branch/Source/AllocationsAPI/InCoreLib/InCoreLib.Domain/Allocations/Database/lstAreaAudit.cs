using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAreaAudit")]
    public partial class lstAreaAudit
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

        [StringLength(8)]
        public string Area { get; set; }

        [StringLength(50)]
        public string OriginalIncommunitiesLMT { get; set; }

        [StringLength(50)]
        public string RevisedIncommunitiesLMT { get; set; }

        public short? OriginalSortorder { get; set; }

        public short? RevisedSortorder { get; set; }
    }
}
