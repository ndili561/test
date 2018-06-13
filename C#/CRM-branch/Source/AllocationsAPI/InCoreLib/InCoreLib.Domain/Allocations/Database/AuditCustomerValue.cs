using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class AuditCustomerValue
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }

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

        public bool? MatchToMutualExhanges { get; set; }

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

        [StringLength(500)]
        public string URIReferrer { get; set; }
    }
}
