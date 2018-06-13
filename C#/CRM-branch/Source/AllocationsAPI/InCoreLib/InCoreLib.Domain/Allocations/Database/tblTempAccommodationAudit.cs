using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblTempAccommodationAudit")]
    public partial class tblTempAccommodationAudit
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

        public int? TempAccomodationIndex { get; set; }

        public int? OriginalCaseRefNumber { get; set; }

        public int? RevisedCaseRefNumber { get; set; }

        [StringLength(255)]
        public string OriginalTempAccommodationType { get; set; }

        [StringLength(255)]
        public string RevisedTempAccommodationType { get; set; }

        public DateTime? OriginalTempAccommodationDateIn { get; set; }

        public DateTime? RevisedTempAccommodationDateIn { get; set; }

        public DateTime? OriginalTempAccommodationDateOut { get; set; }

        public DateTime? RevisedTempAccommodationDateOut { get; set; }

        public int? OriginalTotalTimeResidentInWeeks { get; set; }

        public int? RevisedTotalTimeResidentInWeeks { get; set; }

        public string OriginalNote { get; set; }

        public string RevisedNote { get; set; }
    }
}
