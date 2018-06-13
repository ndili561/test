using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_MutualExchangeProperties
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }

        public int? ApplicationLevelOfNeedID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ApplicationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MatchingEarliestMoveDate { get; set; }

        [StringLength(50)]
        public string PropertyCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AgeCriteria { get; set; }

        [StringLength(20)]
        public string PropertyType { get; set; }

        public int? PropertyNumBedrooms { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SchemeID { get; set; }

        [StringLength(30)]
        public string SubNeighbourhoodCode { get; set; }

        public int? FlatFloorLevel { get; set; }

        public bool? LiftAccess { get; set; }

        public bool? Careline { get; set; }

        [StringLength(50)]
        public string HeatingType { get; set; }

        public bool? Garden { get; set; }

        public bool? HasStepsToAccess { get; set; }

        public int? NumStepsToAccess { get; set; }

        public bool? IsWheelChairAdapted { get; set; }

        public bool? HasRampedAccess { get; set; }

        public bool? IsLevelAccessProperty { get; set; }

        public bool? HasStairlift { get; set; }

        public bool? HasWalkInShower { get; set; }

        public bool? HasStepInShower { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ServiceCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OtherCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalRent { get; set; }

        public bool? MatchingTrustCare { get; set; }

        public bool? MatchingGarden { get; set; }

        public bool? MatchingWheelChairAdapted { get; set; }

        public bool? MatchingRampedAccess { get; set; }

        public bool? MatchingLevelAccessProperty { get; set; }

        public bool? MatchingStairlift { get; set; }

        public bool? MatchingWalkInShower { get; set; }

        public bool? MatchingStepInShower { get; set; }

        public bool? MatchingLiftServed { get; set; }

        public int? MatchingFloorlevel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MatchingApplicantsAge { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(17)]
        public string PaymentCycle { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime VoidDate { get; set; }

        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(255)]
        public string Address2 { get; set; }

        [StringLength(255)]
        public string Address3 { get; set; }

        [StringLength(255)]
        public string Address4 { get; set; }

        [StringLength(16)]
        public string PostCode { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1)]
        public string MarketingInformationWeb { get; set; }

        [StringLength(50)]
        public string LandLord { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(538)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MutualExchangeProperty { get; set; }
    }
}
