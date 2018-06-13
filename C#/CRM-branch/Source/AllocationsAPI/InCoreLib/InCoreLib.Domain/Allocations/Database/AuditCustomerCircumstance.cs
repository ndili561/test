using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class AuditCustomerCircumstance
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

        public int? LivedAtAddress { get; set; }

        public int? LivedAtAddressMonths { get; set; }

        [StringLength(50)]
        public string ResidencyTypeCode { get; set; }

        [StringLength(255)]
        public string LandLordName { get; set; }

        public int? MoveReasonID { get; set; }

        public bool? RecievingSupport { get; set; }

        public bool? RequiresSupport { get; set; }

        [StringLength(1000)]
        public string SupportRequiredFor { get; set; }

        [StringLength(50)]
        public string TenancyTypeCode { get; set; }

        [StringLength(50)]
        public string LandLordCode { get; set; }

        [StringLength(1000)]
        public string IncomesComments { get; set; }

        public bool? HasIncome { get; set; }

        public bool? MainTenantOnTenancy { get; set; }

        public bool? LeaveVacantProperty { get; set; }

        [StringLength(50)]
        public string PropertyCode { get; set; }

        [StringLength(50)]
        public string TenancyCode { get; set; }

        [StringLength(20)]
        public string PropertyType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ServiceCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OtherCharges { get; set; }

        public int? PropertyNumBedrooms { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AgeCriteria { get; set; }

        [StringLength(50)]
        public string HeatingType { get; set; }

        public int? FlatFloorLevel { get; set; }

        public bool? HasStepsToAccess { get; set; }

        public int? NumStepsToAccess { get; set; }

        public bool? HasGarden { get; set; }

        public bool? HasLift { get; set; }

        public bool? HasTrustcare { get; set; }

        public bool? IsWheelChairAdapted { get; set; }

        public bool? HasRampedAccess { get; set; }

        public bool? IsLevelAccessProperty { get; set; }

        public bool? HasStairlift { get; set; }

        public bool? HasWalkInShower { get; set; }

        public bool? HasStepInShower { get; set; }

        [StringLength(255)]
        public string LivingAddress1 { get; set; }

        [StringLength(255)]
        public string LivingAddress2 { get; set; }

        [StringLength(255)]
        public string LivingAddress3 { get; set; }

        [StringLength(255)]
        public string LivingAddress4 { get; set; }

        [StringLength(16)]
        public string LivingPostCode { get; set; }

        public int? LivedAtAddressDays { get; set; }
    }
}
