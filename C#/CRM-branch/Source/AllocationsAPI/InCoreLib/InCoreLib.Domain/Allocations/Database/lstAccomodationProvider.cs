using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAccomodationProvider")]
    public partial class lstAccomodationProvider
    {
        [Key]
        [Column(Order = 0)]
        public int AccomProviderID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Addr1 { get; set; }

        [StringLength(150)]
        public string Addr2 { get; set; }

        [StringLength(150)]
        public string Addr3 { get; set; }

        [StringLength(150)]
        public string Addr4 { get; set; }

        [StringLength(12)]
        public string PCode { get; set; }

        [StringLength(150)]
        public string EMailAddrs1 { get; set; }

        [StringLength(150)]
        public string EMailAddrs2 { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool TakingNewBookings { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BookingsCanStartFrom { get; set; }

        public bool? BookingsToStop { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BookingsToStopDate { get; set; }

        public int? MaxStay { get; set; }

        public int? MinStay { get; set; }

        [StringLength(20)]
        public string Telno { get; set; }

        [StringLength(50)]
        public string FaxNo { get; set; }

        [StringLength(20)]
        public string MobileNo { get; set; }

        public string Notes { get; set; }

        public bool? BnBOffered { get; set; }

        public bool? IsHostel { get; set; }

        public bool? HavePreferences { get; set; }

        public bool? WillAcceptIfChildInHH { get; set; }

        public bool? WillAcceptIfSingleMale { get; set; }

        public bool? WillAcceptIfSingleFemale { get; set; }

        public bool? WillAcceptIf16To25 { get; set; }
    }
}
