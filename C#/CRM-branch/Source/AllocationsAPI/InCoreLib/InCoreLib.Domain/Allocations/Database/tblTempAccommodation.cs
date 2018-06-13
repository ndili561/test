using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblTempAccommodation")]
    public partial class tblTempAccommodation
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

        public int? AccomProviderID { get; set; }

        public int? PlacementReasonID { get; set; }

        public bool? ColdWeather { get; set; }

        public bool? Cancelled { get; set; }

        public DateTime? CancelledDateTime { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmenityChargeLevied { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmenityChargePaid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TACost { get; set; }

        public bool? PaidByCreditCard { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceRcvdDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InvoiceValue { get; set; }

        public bool? AmenityChargePaymentExpected { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NightsToBeBilled { get; set; }

        public int? CaseNoteID { get; set; }

        public int? LocalAuthorityID { get; set; }
    }
}
