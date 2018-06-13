using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAccommodationTypeAudit")]
    public partial class lstAccommodationTypeAudit
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
        public string AccommodationType { get; set; }

        [StringLength(50)]
        public string OriginalAccommodationTypeDesc { get; set; }

        [StringLength(50)]
        public string RevisedAccommodationTypeDesc { get; set; }
    }
}
