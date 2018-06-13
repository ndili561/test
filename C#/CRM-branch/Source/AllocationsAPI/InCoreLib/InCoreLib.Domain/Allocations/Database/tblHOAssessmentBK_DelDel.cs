using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblHOAssessmentBK_DelDel
    {
        [Key]
        [Column(Order = 0)]
        public int CaseRefNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceptionIndex { get; set; }

        [StringLength(50)]
        public string ReceptionUserID { get; set; }

        public DateTime? ReceptionDateTime { get; set; }

        public bool? AllocatedFlag { get; set; }

        [StringLength(50)]
        public string AllocatedUserID { get; set; }

        public DateTime? AllocatedDateTime { get; set; }

        public bool? CaseLocked { get; set; }

        [StringLength(50)]
        public string CaseLockedUserID { get; set; }

        public DateTime? CaseLockedDateTime { get; set; }

        [StringLength(50)]
        public string AssessorUserID { get; set; }

        public DateTime? AssessmentDateTime { get; set; }

        public DateTime? AssessmentInterviewDateTime { get; set; }

        [StringLength(50)]
        public string AssessmentApproachReason { get; set; }

        [StringLength(50)]
        public string AssessmentContactType { get; set; }

        [StringLength(50)]
        public string CBLRefNumber { get; set; }

        public bool? NeedsJointApplicationAssessment { get; set; }

        public bool? NeedsDependantsAssessment { get; set; }

        public bool? NeedsMedicalAssessment { get; set; }

        public bool? NeedsHomelessnessAssessment { get; set; }

        public bool? HasJointApplicationAssessment { get; set; }

        public bool? HasDependantsAssessment { get; set; }

        public bool? HasMedicalAssessment { get; set; }

        public bool? HasHomelessnessAssessment { get; set; }

        [StringLength(50)]
        public string AssessorUserIDJointApplicationAssessment { get; set; }

        [StringLength(50)]
        public string AssessorUserIDDependantsAssessment { get; set; }

        [StringLength(50)]
        public string AssessorUserIDMedicalAssessment { get; set; }

        [StringLength(50)]
        public string AssessorUserIDHomelessnessAssessment { get; set; }

        public DateTime? DateJointApplicationAssessment { get; set; }

        public DateTime? DateDependantsAssessment { get; set; }

        public DateTime? DateMedicalAssessment { get; set; }

        public DateTime? DateHomelessnessAssessment { get; set; }

        public bool? IncommunitiesTenant { get; set; }

        public int? IncommunitiesTenancyRef { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string MaritalStatus { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public bool? Pregnant { get; set; }

        public DateTime? PregnancyDueDate { get; set; }

        [StringLength(50)]
        public string Ethnicity { get; set; }

        [StringLength(50)]
        public string NINumber { get; set; }

        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        public string AddressLine3 { get; set; }

        [StringLength(50)]
        public string AddressLine4 { get; set; }

        [StringLength(50)]
        public string Postcode { get; set; }

        [StringLength(50)]
        public string ContactPreference { get; set; }

        [StringLength(50)]
        public string PhoneLandline { get; set; }

        [StringLength(50)]
        public string MobilePhone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string FamilyComposition { get; set; }

        public short? NumberBedrooms { get; set; }

        [StringLength(50)]
        public string RTANationality { get; set; }

        [StringLength(50)]
        public string RTAEligibilityRights { get; set; }

        public bool? RTAIncomeProvided { get; set; }

        public bool? RTAValidVisa { get; set; }

        public bool? RTAWorkingPermitted { get; set; }

        public bool? DPAAccepted { get; set; }

        public bool? DPADataSharingAllowed { get; set; }

        public DateTime? PA_UrgencyDate { get; set; }

        public bool? PA_RehousingRequired { get; set; }

        public short? PA_NumberBedrooms { get; set; }

        public bool? PA_PrivateRentedInterest { get; set; }

        [StringLength(50)]
        public string PA_LevelOfNeed { get; set; }

        [StringLength(50)]
        public string PA_CBLBand { get; set; }

        [StringLength(50)]
        public string PA_Area1 { get; set; }

        [StringLength(50)]
        public string PA_Area2 { get; set; }

        [StringLength(50)]
        public string PA_Area3 { get; set; }

        [StringLength(50)]
        public string PA_Area4 { get; set; }

        public string PA_EstateCodes { get; set; }

        [StringLength(50)]
        public string PA_PropertyTypeID { get; set; }

        [StringLength(50)]
        public string PA_FloorLevel { get; set; }

        public bool? PA_GroupFloorExtension { get; set; }

        public bool? PA_KitchenPartFullyConverted { get; set; }

        public bool? PA_ManageableSteppedAccess { get; set; }

        public bool? PA_Ramped { get; set; }

        public bool? PA_Stairlift { get; set; }

        public bool? PA_StepInShowerTray { get; set; }

        public bool? PA_ThroughFloorLift { get; set; }

        public bool? PA_WetRoom { get; set; }

        [StringLength(50)]
        public string PA_Outcome { get; set; }

        public bool? PA_Sent { get; set; }

        public bool? PA_Related { get; set; }

        public string PA_Important { get; set; }

        public string PA_NoGo { get; set; }

        [StringLength(255)]
        public string MEDICAL_PracticeName { get; set; }

        [StringLength(50)]
        public string MEDICAL_GPName { get; set; }

        [Column(TypeName = "ntext")]
        public string MEDICAL_Address { get; set; }

        [StringLength(50)]
        public string MEDICAL_Postcode { get; set; }

        [StringLength(50)]
        public string MEDICAL_GPPhone { get; set; }

        [StringLength(50)]
        public string MEDICAL_GPFax { get; set; }

        [Column(TypeName = "ntext")]
        public string DOCSlocation { get; set; }

        public DateTime? OutcomeDate { get; set; }

        [StringLength(255)]
        public string OutcomeResult { get; set; }

        public string OutcomeOther { get; set; }

        [StringLength(50)]
        public string SystemHLUserID { get; set; }

        public DateTime? SystemHLDateTime { get; set; }

        public DateTime? HL_InterviewDate { get; set; }

        [StringLength(50)]
        public string HL_IsEligible1 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsEligibleNotes { get; set; }

        [StringLength(50)]
        public string HL_IsHomeless2 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsHomelessNotes { get; set; }

        [StringLength(50)]
        public string HL_IsInPriorityNeed3 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsInPriorityNeedNotes { get; set; }

        [StringLength(50)]
        public string HL_IsIntentionallyHomeless4 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsIntentionallyHomeless_Notes { get; set; }

        [StringLength(50)]
        public string HL_HasLocalConnection5 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_HasLocalConnectionNotes { get; set; }

        [StringLength(50)]
        public string HL_HomelessDecision { get; set; }

        public DateTime? HL_HomelessDecisionDate { get; set; }

        public bool? HL_DutyOwed { get; set; }

        public bool? HL_S198Duty { get; set; }

        public bool? HL_S213Duty { get; set; }

        public bool? HL_RepeatHomelessCase { get; set; }

        [StringLength(50)]
        public string HL_PriorityNeedReason { get; set; }

        [StringLength(50)]
        public string HL_HomelessReason { get; set; }

        [StringLength(50)]
        public string HL_HomelessWhereStayingNow { get; set; }

        public int? HL_AgeAtHomelessDecisionDate { get; set; }

        [StringLength(50)]
        public string HL_AgeGroup { get; set; }

        public bool? HL_TempAccommodation { get; set; }

        [StringLength(255)]
        public string HL_TempAccommodationType { get; set; }

        public DateTime? HL_TADateIn { get; set; }

        public DateTime? HL_TADateOut { get; set; }

        public int? HL_TotalTimeResidentInWeeks { get; set; }

        [StringLength(255)]
        public string HL_Outcome { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_OutcomeOther { get; set; }

        public DateTime? HL_OutcomeDate { get; set; }

        public bool? WarningFlag { get; set; }

        [Column(TypeName = "ntext")]
        public string WarningNotes { get; set; }

        [StringLength(50)]
        public string WarningNotesUserID { get; set; }

        public DateTime? WarningNotesDateTime { get; set; }

        public bool? CareLeaver { get; set; }

        public bool? ChildInNeedAssessmentRequired { get; set; }

        [StringLength(3)]
        public string AssessmentUserLocation { get; set; }

        public short? CaseStatus { get; set; }

        public DateTime? EndOfInterviewDateTime { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public int? CustomerSatisfactionScore { get; set; }

        public bool? AdaptionsRequired { get; set; }

        public bool? PetsAccepted { get; set; }

        public bool? LiftRequired { get; set; }

        public bool? CaseClosed { get; set; }

        public bool? HomelessFrozen { get; set; }

        public string RelevantContacts { get; set; }

        public string CustomerSatisfactionComments { get; set; }

        public bool? HL_S198DutyOut { get; set; }

        public bool? HL_S213DutyOut { get; set; }

        public int? ParentCaseRefNumber { get; set; }

        public string SupportWorkerDetails { get; set; }
    }
}
