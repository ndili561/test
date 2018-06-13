using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("CustomerApplication")]
    public partial class CustomerApplication
    {
        public int CustomerApplicationId { get; set; }

        public int ApplicationStatusID { get; set; }

        [StringLength(1000)]
        public string ApplicationStatusReason { get; set; }

        public DateTime ApplicationDate { get; set; }

        public bool? ApplicationEligable { get; set; }

        public DateTime? HOALevelOfNeedDate { get; set; }

        public int? ApplicationLevelOfNeedID { get; set; }

        public bool? DataProtectionIsPrinted { get; set; }

        public bool? DataProtectionIsSigned { get; set; }

        public bool? DataProtectionConsented { get; set; }

        public int? HOACaseRef { get; set; }

        [StringLength(1000)]
        public string HOAOutcome { get; set; }

        public DateTime? HOAOutcomeDate { get; set; }

        public bool? HOACaseIsOpen { get; set; }

        public bool? HOAEligabilitySet { get; set; }

        public int? HOAAppointmentActivityID { get; set; }

        public DateTime? HOAAppointmentScheduledStart { get; set; }

        public int? HOAAppointmentStatusID { get; set; }

        public bool? HOAAppointmentIsAssessor { get; set; }

        public int? VBLSatisfationActivityID { get; set; }

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

        public bool? ApplicantsUnderEighteen { get; set; }

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

        public bool? PropertyisTerminating { get; set; }

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
        public string MoveReason { get; set; }

        [StringLength(25)]
        public string TelNum { get; set; }

        public bool? ContactByPhone { get; set; }

        [StringLength(25)]
        public string MobileNum { get; set; }

        public bool? ContactByMobile { get; set; }

        public bool? ContactByMobileText { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public bool? ContactByEmail { get; set; }

        public bool? ContactByMail { get; set; }

        public bool? WillVisitTheOffices { get; set; }

        [StringLength(255)]
        public string MainAddress1 { get; set; }

        [StringLength(255)]
        public string MainAddress2 { get; set; }

        [StringLength(255)]
        public string MainAddress3 { get; set; }

        [StringLength(255)]
        public string MainAddress4 { get; set; }

        [StringLength(16)]
        public string MainPostCode { get; set; }

        [StringLength(255)]
        public string ContactAddress1 { get; set; }

        [StringLength(255)]
        public string ContactAddress2 { get; set; }

        [StringLength(255)]
        public string ContactAddress3 { get; set; }

        [StringLength(255)]
        public string ContactAddress4 { get; set; }

        [StringLength(16)]
        public string ContactPostCode { get; set; }

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

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }

        public int? LivedAtAddressDays { get; set; }

        [StringLength(150)]
        public string LastUpdatedUsernameLevelOfNeed { get; set; }

        public int? LastUpdatedPersonIDLevelOfNeed { get; set; }

        public bool? ContactBySecondaryNum { get; set; }

        [StringLength(25)]
        public string SecondaryPhoneNum { get; set; }

        public int? ActivityLocationID { get; set; }

        public bool? IsSignedDeclarationUploaded { get; set; }
    }
}
