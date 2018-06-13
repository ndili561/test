using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubTABookingCall")]
    public partial class tsubTABookingCall
    {
        [Key]
        [Column(Order = 0)]
        public int CallID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        public int? TAID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime CallDateTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProviderID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime CallStart { get; set; }

        public DateTime? CallEnd { get; set; }

        public int? OutcomeID { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public int? BookingType { get; set; }

        public bool? SuccessfulOutcome { get; set; }
    }
}
