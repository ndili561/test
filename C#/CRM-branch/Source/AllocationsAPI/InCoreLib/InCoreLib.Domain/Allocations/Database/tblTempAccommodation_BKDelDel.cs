using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblTempAccommodation_BKDelDel
    {
        [Key]
        public int TempAccomodationIndex { get; set; }

        public int? CaseRefNumber { get; set; }

        [StringLength(255)]
        public string TempAccommodationType { get; set; }

        public DateTime? TempAccommodationDateIn { get; set; }

        public DateTime? TempAccommodationDateOut { get; set; }

        public int? TotalTimeResidentInWeeks { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public string Note { get; set; }
    }
}
