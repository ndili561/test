using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblBnBDataBK")]
    public partial class tblBnBDataBK
    {
        [Key]
        [Column(Order = 0)]
        public int RowID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Sent { get; set; }

        public DateTime? SendDate { get; set; }

        public int? LogID { get; set; }

        public int? OrderNo { get; set; }

        [StringLength(6)]
        public string FollowOnYes { get; set; }

        [StringLength(6)]
        public string FollowOnNo { get; set; }

        [StringLength(50)]
        public string OrderNo2 { get; set; }

        public string AccomProvider { get; set; }

        public string ProvidersAddress { get; set; }

        public string OrderedFrom { get; set; }

        [StringLength(50)]
        public string ConfirmedWith { get; set; }

        public DateTime? DateTimeOfOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public int? NoOfNights { get; set; }

        public string PlacementReason { get; set; }

        public string ReasonWhyPlaced { get; set; }

        public string AgenciesApproached { get; set; }

        public string AnyBarriers { get; set; }

        public string FirstName1 { get; set; }

        public string SurName1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DoBMainAppl { get; set; }

        public string FirstName2 { get; set; }

        public string SurName2 { get; set; }

        [StringLength(6)]
        public string PartnerPregnantYes { get; set; }

        [StringLength(6)]
        public string PartnerPregnantNo { get; set; }

        [StringLength(6)]
        public string Appl1617Yes { get; set; }

        [StringLength(6)]
        public string Appl1617No { get; set; }

        public string OFMFirstName1 { get; set; }

        public string OFMSurName1 { get; set; }

        [StringLength(6)]
        public string OFMSon1 { get; set; }

        [StringLength(6)]
        public string OFMDaughter1 { get; set; }

        [StringLength(6)]
        public string OFMOther1 { get; set; }

        public string OFMFirstName2 { get; set; }

        public string OFMSurName2 { get; set; }

        [StringLength(6)]
        public string OFMSon2 { get; set; }

        [StringLength(6)]
        public string OFMDaughter2 { get; set; }

        [StringLength(6)]
        public string OFMOther2 { get; set; }

        public string OFMFirstName3 { get; set; }

        public string OFMSurName3 { get; set; }

        [StringLength(6)]
        public string OFMSon3 { get; set; }

        [StringLength(6)]
        public string OFMDaughter3 { get; set; }

        [StringLength(6)]
        public string OFMOther3 { get; set; }

        public string OFMFirstName4 { get; set; }

        public string OFMSurName4 { get; set; }

        [StringLength(6)]
        public string OFMSon4 { get; set; }

        [StringLength(6)]
        public string OFMDaughter4 { get; set; }

        [StringLength(6)]
        public string OFMOther4 { get; set; }

        public string OFMFirstName5 { get; set; }

        public string OFMSurName5 { get; set; }

        [StringLength(6)]
        public string OFMSon5 { get; set; }

        [StringLength(6)]
        public string OFMDaughter5 { get; set; }

        [StringLength(6)]
        public string OFMOther5 { get; set; }

        public string Notes { get; set; }

        public int? CaseRef { get; set; }
    }
}
