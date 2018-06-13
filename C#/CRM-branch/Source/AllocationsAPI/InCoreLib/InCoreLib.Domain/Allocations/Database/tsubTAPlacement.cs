using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubTAPlacement")]
    public partial class tsubTAPlacement
    {
        [Key]
        [Column(Order = 0)]
        public int TAPlacementID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TempAccomodationIndex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AdjustedDateTo { get; set; }

        public int? AccomProviderID { get; set; }

        public string Note { get; set; }

        public bool? AccomProviderPhoned { get; set; }

        public DateTime? AccomProviderPhnDate { get; set; }

        public bool? AccomProviderConfSent { get; set; }

        public DateTime? AccomProviderConfSentDate { get; set; }

        public bool? FollowOnOrder { get; set; }

        public int? FollowOnOrderTAPlacementID { get; set; }

        public int? NoOfNights { get; set; }

        public int? ReasonID { get; set; }

        public int? BnBReasonID { get; set; }

        public string AgenciesApproached { get; set; }

        public string Barriers { get; set; }

        public int? CouncilRefNo { get; set; }

        public bool? Pregnant { get; set; }

        public bool? MainApp16or17 { get; set; }

        [StringLength(3)]
        public string OrderLocnID { get; set; }

        public DateTime? DateOfOrder { get; set; }

        [StringLength(50)]
        public string BookingUserID { get; set; }

        public bool? InvMatched { get; set; }

        public DateTime? InvMatchDate { get; set; }

        public int? SuppInvID { get; set; }

        public bool? ChqMatched { get; set; }

        public DateTime? ChqMatchDate { get; set; }

        public int? ChqID { get; set; }

        public int? LocalAuthorityID { get; set; }
    }
}
