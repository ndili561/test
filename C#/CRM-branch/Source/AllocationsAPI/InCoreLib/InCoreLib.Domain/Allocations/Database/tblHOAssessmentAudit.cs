using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblHOAssessmentAudit")]
    public partial class tblHOAssessmentAudit
    {
        [Key]
        [Column(Order = 0)]
        public DateTime RevisionDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RevisionUserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string AuditAction { get; set; }

        public int? CaseRefNumber { get; set; }

        public int? OriginalReceptionIndex { get; set; }

        public int? RevisedReceptionIndex { get; set; }

        [StringLength(50)]
        public string OriginalReceptionUserID { get; set; }

        [StringLength(50)]
        public string RevisedReceptionUserID { get; set; }

        public DateTime? OriginalReceptionDateTime { get; set; }

        public DateTime? RevisedReceptionDateTime { get; set; }

        public bool? OriginalAllocatedFlag { get; set; }

        public bool? RevisedAllocatedFlag { get; set; }

        [StringLength(50)]
        public string OriginalAllocatedUserID { get; set; }

        [StringLength(50)]
        public string RevisedAllocatedUserID { get; set; }

        public DateTime? OriginalAllocatedDateTime { get; set; }

        public DateTime? RevisedAllocatedDateTime { get; set; }

        public bool? OriginalCaseLocked { get; set; }

        public bool? RevisedCaseLocked { get; set; }

        [StringLength(50)]
        public string OriginalCaseLockedUserID { get; set; }

        [StringLength(50)]
        public string RevisedCaseLockedUserID { get; set; }

        public DateTime? OriginalCaseLockedDateTime { get; set; }

        public DateTime? RevisedCaseLockedDateTime { get; set; }

        [StringLength(50)]
        public string OriginalAssessorUserID { get; set; }

        [StringLength(50)]
        public string RevisedAssessorUserID { get; set; }

        public DateTime? OriginalAssessmentDateTime { get; set; }

        public DateTime? RevisedAssessmentDateTime { get; set; }

        public DateTime? OriginalAssessmentInterviewDateTime { get; set; }

        public DateTime? RevisedAssessmentInterviewDateTime { get; set; }

        [StringLength(50)]
        public string OriginalAssessmentApproachReason { get; set; }

        [StringLength(50)]
        public string RevisedAssessmentApproachReason { get; set; }

        [StringLength(50)]
        public string OriginalAssessmentContactType { get; set; }

        [StringLength(50)]
        public string RevisedAssessmentContactType { get; set; }

        [StringLength(50)]
        public string OriginalCBLRefNumber { get; set; }

        [StringLength(50)]
        public string RevisedCBLRefNumber { get; set; }

        public bool? OriginalNeedsJointApplicationAssessment { get; set; }

        public bool? RevisedNeedsJointApplicationAssessment { get; set; }

        public bool? OriginalNeedsDependantsAssessment { get; set; }

        public bool? RevisedNeedsDependantsAssessment { get; set; }

        public bool? OriginalNeedsMedicalAssessment { get; set; }

        public bool? RevisedNeedsMedicalAssessment { get; set; }

        public bool? OriginalNeedsHomelessnessAssessment { get; set; }

        public bool? RevisedNeedsHomelessnessAssessment { get; set; }

        public bool? OriginalHasJointApplicationAssessment { get; set; }

        public bool? RevisedHasJointApplicationAssessment { get; set; }

        public bool? OriginalHasDependantsAssessment { get; set; }

        public bool? RevisedHasDependantsAssessment { get; set; }

        public bool? OriginalHasMedicalAssessment { get; set; }

        public bool? RevisedHasMedicalAssessment { get; set; }

        public bool? OriginalHasHomelessnessAssessment { get; set; }

        public bool? RevisedHasHomelessnessAssessment { get; set; }

        [StringLength(50)]
        public string OriginalAssessorUserIDJointApplicationAssessment { get; set; }

        [StringLength(50)]
        public string RevisedAssessorUserIDJointApplicationAssessment { get; set; }

        [StringLength(50)]
        public string OriginalAssessorUserIDDependantsAssessment { get; set; }

        [StringLength(50)]
        public string RevisedAssessorUserIDDependantsAssessment { get; set; }

        [StringLength(50)]
        public string OriginalAssessorUserIDMedicalAssessment { get; set; }

        [StringLength(50)]
        public string RevisedAssessorUserIDMedicalAssessment { get; set; }

        [StringLength(50)]
        public string OriginalAssessorUserIDHomelessnessAssessment { get; set; }

        [StringLength(50)]
        public string RevisedAssessorUserIDHomelessnessAssessment { get; set; }

        public DateTime? OriginalDateJointApplicationAssessment { get; set; }

        public DateTime? RevisedDateJointApplicationAssessment { get; set; }

        public DateTime? OriginalDateDependantsAssessment { get; set; }

        public DateTime? RevisedDateDependantsAssessment { get; set; }

        public DateTime? OriginalDateMedicalAssessment { get; set; }

        public DateTime? RevisedDateMedicalAssessment { get; set; }

        public DateTime? OriginalDateHomelessnessAssessment { get; set; }

        public DateTime? RevisedDateHomelessnessAssessment { get; set; }

        public bool? OriginalIncommunitiesTenant { get; set; }

        public bool? RevisedIncommunitiesTenant { get; set; }

        public int? OriginalIncommunitiesTenancyRef { get; set; }

        public int? RevisedIncommunitiesTenancyRef { get; set; }

        [StringLength(50)]
        public string OriginalTitle { get; set; }

        [StringLength(50)]
        public string RevisedTitle { get; set; }

        [StringLength(50)]
        public string OriginalFirstName { get; set; }

        [StringLength(50)]
        public string RevisedFirstName { get; set; }

        [StringLength(50)]
        public string OriginalLastName { get; set; }

        [StringLength(50)]
        public string RevisedLastName { get; set; }

        public DateTime? OriginalDOB { get; set; }

        public DateTime? RevisedDOB { get; set; }

        [StringLength(50)]
        public string OriginalMaritalStatus { get; set; }

        [StringLength(50)]
        public string RevisedMaritalStatus { get; set; }

        [StringLength(1)]
        public string OriginalGender { get; set; }

        [StringLength(1)]
        public string RevisedGender { get; set; }

        public bool? OriginalPregnant { get; set; }

        public bool? RevisedPregnant { get; set; }

        public DateTime? OriginalPregnancyDueDate { get; set; }

        public DateTime? RevisedPregnancyDueDate { get; set; }

        [StringLength(50)]
        public string OriginalEthnicity { get; set; }

        [StringLength(50)]
        public string RevisedEthnicity { get; set; }

        [StringLength(50)]
        public string OriginalNINumber { get; set; }

        [StringLength(50)]
        public string RevisedNINumber { get; set; }

        [StringLength(50)]
        public string OriginalAddressLine1 { get; set; }

        [StringLength(50)]
        public string RevisedAddressLine1 { get; set; }

        [StringLength(50)]
        public string OriginalAddressLine2 { get; set; }

        [StringLength(50)]
        public string RevisedAddressLine2 { get; set; }

        [StringLength(50)]
        public string OriginalAddressLine3 { get; set; }

        [StringLength(50)]
        public string RevisedAddressLine3 { get; set; }

        [StringLength(50)]
        public string OriginalAddressLine4 { get; set; }

        [StringLength(50)]
        public string RevisedAddressLine4 { get; set; }

        [StringLength(50)]
        public string OriginalPostcode { get; set; }

        [StringLength(50)]
        public string RevisedPostcode { get; set; }

        [StringLength(50)]
        public string OriginalContactPreference { get; set; }

        [StringLength(50)]
        public string RevisedContactPreference { get; set; }

        [StringLength(50)]
        public string OriginalPhoneLandline { get; set; }

        [StringLength(50)]
        public string RevisedPhoneLandline { get; set; }

        [StringLength(50)]
        public string OriginalMobilePhone { get; set; }

        [StringLength(50)]
        public string RevisedMobilePhone { get; set; }

        [StringLength(50)]
        public string OriginalEmail { get; set; }

        [StringLength(50)]
        public string RevisedEmail { get; set; }

        [StringLength(50)]
        public string OriginalFamilyComposition { get; set; }

        [StringLength(50)]
        public string RevisedFamilyComposition { get; set; }

        public short? OriginalNumberBedrooms { get; set; }

        public short? RevisedNumberBedrooms { get; set; }

        [StringLength(50)]
        public string OriginalRTANationality { get; set; }

        [StringLength(50)]
        public string RevisedRTANationality { get; set; }

        [StringLength(50)]
        public string OriginalRTAEligibilityRights { get; set; }

        [StringLength(50)]
        public string RevisedRTAEligibilityRights { get; set; }

        public bool? OriginalRTAIncomeProvided { get; set; }

        public bool? RevisedRTAIncomeProvided { get; set; }

        public bool? OriginalRTAValidVisa { get; set; }

        public bool? RevisedRTAValidVisa { get; set; }

        public bool? OriginalRTAWorkingPermitted { get; set; }

        public bool? RevisedRTAWorkingPermitted { get; set; }

        public bool? OriginalDPAAccepted { get; set; }

        public bool? RevisedDPAAccepted { get; set; }

        public bool? OriginalDPADataSharingAllowed { get; set; }

        public bool? RevisedDPADataSharingAllowed { get; set; }

        public DateTime? OriginalPA_UrgencyDate { get; set; }

        public DateTime? RevisedPA_UrgencyDate { get; set; }

        public bool? OriginalPA_RehousingRequired { get; set; }

        public bool? RevisedPA_RehousingRequired { get; set; }

        public short? OriginalPA_NumberBedrooms { get; set; }

        public short? RevisedPA_NumberBedrooms { get; set; }

        public bool? OriginalPA_PrivateRentedInterest { get; set; }

        public bool? RevisedPA_PrivateRentedInterest { get; set; }

        [StringLength(50)]
        public string OriginalPA_LevelOfNeed { get; set; }

        [StringLength(50)]
        public string RevisedPA_LevelOfNeed { get; set; }

        [StringLength(50)]
        public string OriginalPA_CBLBand { get; set; }

        [StringLength(50)]
        public string RevisedPA_CBLBand { get; set; }

        [StringLength(50)]
        public string OriginalPA_Area1 { get; set; }

        [StringLength(50)]
        public string RevisedPA_Area1 { get; set; }

        [StringLength(50)]
        public string OriginalPA_Area2 { get; set; }

        [StringLength(50)]
        public string RevisedPA_Area2 { get; set; }

        [StringLength(50)]
        public string OriginalPA_Area3 { get; set; }

        [StringLength(50)]
        public string RevisedPA_Area3 { get; set; }

        [StringLength(50)]
        public string OriginalPA_Area4 { get; set; }

        [StringLength(50)]
        public string RevisedPA_Area4 { get; set; }

        public string OriginalPA_EstateCodes { get; set; }

        public string RevisedPA_EstateCodes { get; set; }

        [StringLength(50)]
        public string OriginalPA_PropertyTypeID { get; set; }

        [StringLength(50)]
        public string RevisedPA_PropertyTypeID { get; set; }

        [StringLength(50)]
        public string OriginalPA_FloorLevel { get; set; }

        [StringLength(50)]
        public string RevisedPA_FloorLevel { get; set; }

        public bool? OriginalPA_GroupFloorExtension { get; set; }

        public bool? RevisedPA_GroupFloorExtension { get; set; }

        public bool? OriginalPA_KitchenPartFullyConverted { get; set; }

        public bool? RevisedPA_KitchenPartFullyConverted { get; set; }

        public bool? OriginalPA_ManageableSteppedAccess { get; set; }

        public bool? RevisedPA_ManageableSteppedAccess { get; set; }

        public bool? OriginalPA_Ramped { get; set; }

        public bool? RevisedPA_Ramped { get; set; }

        public bool? OriginalPA_Stairlift { get; set; }

        public bool? RevisedPA_Stairlift { get; set; }

        public bool? OriginalPA_StepInShowerTray { get; set; }

        public bool? RevisedPA_StepInShowerTray { get; set; }

        public bool? OriginalPA_ThroughFloorLift { get; set; }

        public bool? RevisedPA_ThroughFloorLift { get; set; }

        public bool? OriginalPA_WetRoom { get; set; }

        public bool? RevisedPA_WetRoom { get; set; }

        [StringLength(50)]
        public string OriginalPA_Outcome { get; set; }

        [StringLength(50)]
        public string RevisedPA_Outcome { get; set; }

        public bool? OriginalPA_Sent { get; set; }

        public bool? RevisedPA_Sent { get; set; }

        public bool? OriginalPA_Related { get; set; }

        public bool? RevisedPA_Related { get; set; }

        public string OriginalPA_Important { get; set; }

        public string RevisedPA_Important { get; set; }

        public string OriginalPA_NoGo { get; set; }

        public string RevisedPA_NoGo { get; set; }

        [StringLength(255)]
        public string OriginalMEDICAL_PracticeName { get; set; }

        [StringLength(255)]
        public string RevisedMEDICAL_PracticeName { get; set; }

        [StringLength(50)]
        public string OriginalMEDICAL_GPName { get; set; }

        [StringLength(50)]
        public string RevisedMEDICAL_GPName { get; set; }

        public string OriginalMEDICAL_Address { get; set; }

        public string RevisedMEDICAL_Address { get; set; }

        [StringLength(50)]
        public string OriginalMEDICAL_Postcode { get; set; }

        [StringLength(50)]
        public string RevisedMEDICAL_Postcode { get; set; }

        [StringLength(50)]
        public string OriginalMEDICAL_GPPhone { get; set; }

        [StringLength(50)]
        public string RevisedMEDICAL_GPPhone { get; set; }

        [StringLength(50)]
        public string OriginalMEDICAL_GPFax { get; set; }

        [StringLength(50)]
        public string RevisedMEDICAL_GPFax { get; set; }

        public string OriginalDOCSlocation { get; set; }

        public string RevisedDOCSlocation { get; set; }

        public DateTime? OriginalOutcomeDate { get; set; }

        public DateTime? RevisedOutcomeDate { get; set; }

        [StringLength(255)]
        public string OriginalOutcomeResult { get; set; }

        [StringLength(255)]
        public string RevisedOutcomeResult { get; set; }

        public string OriginalOutcomeOther { get; set; }

        public string RevisedOutcomeOther { get; set; }

        [StringLength(50)]
        public string OriginalSystemHLUserID { get; set; }

        [StringLength(50)]
        public string RevisedSystemHLUserID { get; set; }

        public DateTime? OriginalSystemHLDateTime { get; set; }

        public DateTime? RevisedSystemHLDateTime { get; set; }

        public DateTime? OriginalHL_InterviewDate { get; set; }

        public DateTime? RevisedHL_InterviewDate { get; set; }

        [StringLength(50)]
        public string OriginalHL_IsEligible1 { get; set; }

        [StringLength(50)]
        public string RevisedHL_IsEligible1 { get; set; }

        public string OriginalHL_IsEligibleNotes { get; set; }

        public string RevisedHL_IsEligibleNotes { get; set; }

        [StringLength(50)]
        public string OriginalHL_IsHomeless2 { get; set; }

        [StringLength(50)]
        public string RevisedHL_IsHomeless2 { get; set; }

        public string OriginalHL_IsHomelessNotes { get; set; }

        public string RevisedHL_IsHomelessNotes { get; set; }

        [StringLength(50)]
        public string OriginalHL_IsInPriorityNeed3 { get; set; }

        [StringLength(50)]
        public string RevisedHL_IsInPriorityNeed3 { get; set; }

        public string OriginalHL_IsInPriorityNeedNotes { get; set; }

        public string RevisedHL_IsInPriorityNeedNotes { get; set; }

        [StringLength(50)]
        public string OriginalHL_IsIntentionallyHomeless4 { get; set; }

        [StringLength(50)]
        public string RevisedHL_IsIntentionallyHomeless4 { get; set; }

        public string OriginalHL_IsIntentionallyHomeless_Notes { get; set; }

        public string RevisedHL_IsIntentionallyHomeless_Notes { get; set; }

        [StringLength(50)]
        public string OriginalHL_HasLocalConnection5 { get; set; }

        [StringLength(50)]
        public string RevisedHL_HasLocalConnection5 { get; set; }

        public string OriginalHL_HasLocalConnectionNotes { get; set; }

        public string RevisedHL_HasLocalConnectionNotes { get; set; }

        [StringLength(50)]
        public string OriginalHL_HomelessDecision { get; set; }

        [StringLength(50)]
        public string RevisedHL_HomelessDecision { get; set; }

        public DateTime? OriginalHL_HomelessDecisionDate { get; set; }

        public DateTime? RevisedHL_HomelessDecisionDate { get; set; }

        public bool? OriginalHL_DutyOwed { get; set; }

        public bool? RevisedHL_DutyOwed { get; set; }

        public bool? OriginalHL_S198Duty { get; set; }

        public bool? RevisedHL_S198Duty { get; set; }

        public bool? OriginalHL_S213Duty { get; set; }

        public bool? RevisedHL_S213Duty { get; set; }

        public bool? OriginalHL_RepeatHomelessCase { get; set; }

        public bool? RevisedHL_RepeatHomelessCase { get; set; }

        [StringLength(50)]
        public string OriginalHL_PriorityNeedReason { get; set; }

        [StringLength(50)]
        public string RevisedHL_PriorityNeedReason { get; set; }

        [StringLength(50)]
        public string OriginalHL_HomelessReason { get; set; }

        [StringLength(50)]
        public string RevisedHL_HomelessReason { get; set; }

        [StringLength(50)]
        public string OriginalHL_HomelessWhereStayingNow { get; set; }

        [StringLength(50)]
        public string RevisedHL_HomelessWhereStayingNow { get; set; }

        public int? OriginalHL_AgeAtHomelessDecisionDate { get; set; }

        public int? RevisedHL_AgeAtHomelessDecisionDate { get; set; }

        [StringLength(50)]
        public string OriginalHL_AgeGroup { get; set; }

        [StringLength(50)]
        public string RevisedHL_AgeGroup { get; set; }

        public bool? OriginalHL_TempAccommodation { get; set; }

        public bool? RevisedHL_TempAccommodation { get; set; }

        [StringLength(255)]
        public string OriginalHL_TempAccommodationType { get; set; }

        [StringLength(255)]
        public string RevisedHL_TempAccommodationType { get; set; }

        public DateTime? OriginalHL_TADateIn { get; set; }

        public DateTime? RevisedHL_TADateIn { get; set; }

        public DateTime? OriginalHL_TADateOut { get; set; }

        public DateTime? RevisedHL_TADateOut { get; set; }

        public int? OriginalHL_TotalTimeResidentInWeeks { get; set; }

        public int? RevisedHL_TotalTimeResidentInWeeks { get; set; }

        [StringLength(255)]
        public string OriginalHL_Outcome { get; set; }

        [StringLength(255)]
        public string RevisedHL_Outcome { get; set; }

        public string OriginalHL_OutcomeOther { get; set; }

        public string RevisedHL_OutcomeOther { get; set; }

        public DateTime? OriginalHL_OutcomeDate { get; set; }

        public DateTime? RevisedHL_OutcomeDate { get; set; }

        public bool? OriginalWarningFlag { get; set; }

        public bool? RevisedWarningFlag { get; set; }

        public string OriginalWarningNotes { get; set; }

        public string RevisedWarningNotes { get; set; }

        [StringLength(50)]
        public string OriginalWarningNotesUserID { get; set; }

        [StringLength(50)]
        public string RevisedWarningNotesUserID { get; set; }

        public DateTime? OriginalWarningNotesDateTime { get; set; }

        public DateTime? RevisedWarningNotesDateTime { get; set; }

        public bool? OriginalCareLeaver { get; set; }

        public bool? RevisedCareLeaver { get; set; }

        public bool? OriginalChildInNeedAssessmentRequired { get; set; }

        public bool? RevisedChildInNeedAssessmentRequired { get; set; }

        [StringLength(3)]
        public string OriginalAssessmentUserLocation { get; set; }

        [StringLength(3)]
        public string RevisedAssessmentUserLocation { get; set; }

        public short? OriginalCaseStatus { get; set; }

        public short? RevisedCaseStatus { get; set; }

        public DateTime? OriginalEndOfInterviewDateTime { get; set; }

        public DateTime? RevisedEndOfInterviewDateTime { get; set; }

        public int? OriginalCustomerSatisfactionScore { get; set; }

        public int? RevisedCustomerSatisfactionScore { get; set; }

        public bool? OriginalAdaptionsRequired { get; set; }

        public bool? RevisedAdaptionsRequired { get; set; }

        public bool? OriginalPetsAccepted { get; set; }

        public bool? RevisedPetsAccepted { get; set; }

        public bool? OriginalLiftRequired { get; set; }

        public bool? RevisedLiftRequired { get; set; }

        public bool? OriginalCaseClosed { get; set; }

        public bool? RevisedCaseClosed { get; set; }

        public bool? OriginalHomelessFrozen { get; set; }

        public bool? RevisedHomelessFrozen { get; set; }

        public string OriginalRelevantContacts { get; set; }

        public string RevisedRelevantContacts { get; set; }

        public string OriginalCustomerSatisfactionComments { get; set; }

        public string RevisedCustomerSatisfactionComments { get; set; }

        public bool? OriginalHL_S198DutyOut { get; set; }

        public bool? RevisedHL_S198DutyOut { get; set; }

        public bool? OriginalHL_S213DutyOut { get; set; }

        public bool? RevisedHL_S213DutyOut { get; set; }

        public int? OriginalParentCaseRefNumber { get; set; }

        public int? RevisedParentCaseRefNumber { get; set; }

        public string OriginalSupportWorkerDetails { get; set; }

        public string RevisedSupportWorkerDetails { get; set; }

        public int? OriginalAllocations_CustomerApplicationID { get; set; }

        public int? RevisedAllocations_CustomerApplicationID { get; set; }

        public int? OriginalAllocations_LevelOfNeed { get; set; }

        public int? RevisedAllocations_LevelOfNeed { get; set; }

        public bool? OriginalAllocations_EligibleViaVBLService { get; set; }

        public bool? RevisedAllocations_EligibleViaVBLService { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OriginalHL_S198DateIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RevisedHL_S198DateIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OriginalHL_S198DateOut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RevisedHL_S198DateOut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OriginalHL_S213DateIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RevisedHL_S213DateIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OriginalHL_S213DateOut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RevisedHL_S213DateOut { get; set; }

        public int? OriginalHL_198SourceIn { get; set; }

        public int? RevisedHL_198SourceIn { get; set; }

        public int? OriginalHL_198SourceOut { get; set; }

        public int? RevisedHL_198SourceOut { get; set; }

        public int? OriginalHL_213SourceIn { get; set; }

        public int? RevisedHL_213SourceIn { get; set; }

        public int? OriginalHL_213SourceOut { get; set; }

        public int? RevisedHL_213SourceOut { get; set; }

        public int? OriginalCustomerSatisfactionScore2 { get; set; }

        public int? RevisedCustomerSatisfactionScore2 { get; set; }

        public string OriginalCustomerSatisfactionComments2 { get; set; }

        public string RevisedCustomerSatisfactionComments2 { get; set; }
    }
}
