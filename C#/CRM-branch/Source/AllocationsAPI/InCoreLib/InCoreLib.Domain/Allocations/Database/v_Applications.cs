using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_Applications
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationStatusID { get; set; }

        [StringLength(1000)]
        public string OriginalApplicationStatusReason { get; set; }

        [StringLength(1000)]
        public string ApplicationStatusReason { get; set; }

        [Column(Order = 2)]
        public DateTime OriginalApplicationDate { get; set; }

        [Column(Order = 3)]
        public DateTime ApplicationDate { get; set; }

        public bool? ApplicationEligability { get; set; }

        public DateTime? HOALevelOfNeedDate { get; set; }

        public int? LevelOfNeed { get; set; }

        [Column(Order = 4)]
        [StringLength(50)]
        public string ApplicationBanding { get; set; }

        public int? CaseRefNumber { get; set; }

        [StringLength(1000)]
        public string HOAOutcome { get; set; }

        public DateTime? HOAOutcomeDate { get; set; }

        public bool? HOACaseIsOpen { get; set; }

        public bool? HOAEligabilitySet { get; set; }

        public int? VBLSatisfationActivityID { get; set; }

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }

        public DateTime? ApplicationClosedDate { get; set; }

        [StringLength(255)]
        public string MatchingPropertyTypes { get; set; }

        [StringLength(255)]
        public string MatchingNumBedrooms { get; set; }

        [StringLength(500)]
        public string MatchingLocations { get; set; }

        [StringLength(255)]
        public string MatchingSchemes { get; set; }

        [StringLength(255)]
        public string MatchingHeatingTypes { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MatchingEarliestMoveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MatchingLatestMoveDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MatchingApplicantsAge { get; set; }

        public bool? MutualExchange { get; set; }

        public int? MatchingFloorlevel { get; set; }

        public bool? MatchingLiftServed { get; set; }

        public bool? MatchingTrustCare { get; set; }

        public bool? MatchingSheltered { get; set; }

        public bool? MatchingGarden { get; set; }

        public bool? MatchingWheelChairAdapted { get; set; }

        public bool? MatchingRampedAccess { get; set; }

        public bool? MatchingLevelAccessProperty { get; set; }

        public bool? MatchingStairlift { get; set; }

        public bool? MatchingWalkInShower { get; set; }

        public bool? MatchingStepInShower { get; set; }

        [StringLength(1000)]
        public string MatchingPropertyTypesNames { get; set; }

        [StringLength(1000)]
        public string MatchingNumBedroomsNames { get; set; }

        [StringLength(1000)]
        public string MatchingLocationsNames { get; set; }

        [StringLength(1000)]
        public string MatchingSchemesNames { get; set; }

        [StringLength(1000)]
        public string MatchingHeatingTypesNames { get; set; }

        [StringLength(50)]
        public string MutualExchangePropertyCode { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VoidID { get; set; }

        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TitleId { get; set; }

        [Column(Order = 7)]
        [StringLength(50)]
        public string Forename { get; set; }

        [Column(Order = 8)]
        [StringLength(50)]
        public string Surname { get; set; }

        [Column(Order = 9)]
        [StringLength(255)]
        public string Email { get; set; }

        [Column(Order = 10)]
        [StringLength(25)]
        public string MobileNum { get; set; }

        [Column(Order = 11)]
        [StringLength(25)]
        public string TelNum { get; set; }

        public bool? DataProtectionIsPrinted { get; set; }

        public bool? DataProtectionIsSigned { get; set; }

        public bool? DataProtectionConsented { get; set; }
    }
}
