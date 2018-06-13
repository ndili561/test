using System;
using System.Collections.Generic;

namespace Incomm.Allocations.DTO
{
    public class HOAssessmentDTO
    {
        public HOAUserAdminDTO HoaUserAdminDto { get; set; }

        public HOAContactTypeDTO HoaContactTypeDto { get; set; }

        public HOAEthnicityDTO HoaEthnicityDto { get; set; }

        public HOANationalityTypeDTO HoaNationalityTypeDto { get; set; }

        public HOAApproachReasonDTO HoaApproachReasonDto { get; set; }

        public HOAEligibilityRightsDTO HoaEligibilityRightsDto { get; set; }

        public virtual ICollection<HOACaseNoteDTO> HoaCaseNoteDto { get; set; }

        public virtual ICollection<HOAQuestionAnswerDTO> HoaQuestionAndAnswerDto { get; set; }

        public bool? AdaptionsRequired { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public DateTime? AllocatedDateTime { get; set; }
        public bool? AllocatedFlag { get; set; }
        public string AllocatedUserID { get; set; }
        public int? Allocations_CustomerApplicationID { get; set; }
        public bool? Allocations_EligibleViaVBLService { get; set; }
        public int? Allocations_LevelOfNeed { get; set; }
        public string AssessmentApproachReason { get; set; }
        public string AssessmentContactType { get; set; }
        public DateTime? AssessmentDateTime { get; set; }
        public DateTime? AssessmentInterviewDateTime { get; set; }
        public string AssessmentUserLocation { get; set; }
        public string AssessorUserID { get; set; }
        public string AssessorUserIDDependantsAssessment { get; set; }
        public string AssessorUserIDHomelessnessAssessment { get; set; }
        public string AssessorUserIDJointApplicationAssessment { get; set; }
        public string AssessorUserIDMedicalAssessment { get; set; }
        public bool? CareLeaver { get; set; }
        public bool? CaseClosed { get; set; }
        public bool? CaseLocked { get; set; }
        public DateTime? CaseLockedDateTime { get; set; }
        public string CaseLockedUserID { get; set; }
        public int? CaseNoteIDEligible { get; set; }
        public int? CaseNoteIDExclusion { get; set; }
        public int? CaseNoteIDHomeless { get; set; }
        public int? CaseNoteIDIntentionally { get; set; }
        public int? CaseNoteIDLocal { get; set; }
        public int? CaseNoteIDOutcome { get; set; }
        public int? CaseNoteIDPriority { get; set; }
        public int CaseRefNumber { get; set; }
        public short? CaseStatus { get; set; }
        public string CBLRefNumber { get; set; }
        public bool? ChildInNeedAssessmentRequired { get; set; }
        public string ContactPreference { get; set; }
        public string CustomerSatisfactionComments { get; set; }
        public string CustomerSatisfactionComments2 { get; set; }
        public int? CustomerSatisfactionScore { get; set; }
        public int? CustomerSatisfactionScore2 { get; set; }
        public DateTime? DateDependantsAssessment { get; set; }
        public DateTime? DateHomelessnessAssessment { get; set; }
        public DateTime? DateJointApplicationAssessment { get; set; }
        public DateTime? DateMedicalAssessment { get; set; }
        public DateTime? DOB { get; set; }
        public string DOCSlocation { get; set; }
        public bool? DPAAccepted { get; set; }
        public bool? DPADataSharingAllowed { get; set; }
        public string Email { get; set; }
        public DateTime? EndOfInterviewDateTime { get; set; }
        public string Ethnicity { get; set; }
        public string FamilyComposition { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public bool? HasDependantsAssessment { get; set; }
        public bool? HasHomelessnessAssessment { get; set; }
        public bool? HasJointApplicationAssessment { get; set; }
        public bool? HasMedicalAssessment { get; set; }
        public bool? HighlySensitive { get; set; }
        public int? HL_198SourceIn { get; set; }
        public int? HL_198SourceOut { get; set; }
        public int? HL_213SourceIn { get; set; }
        public int? HL_213SourceOut { get; set; }
        public int? HL_AgeAtHomelessDecisionDate { get; set; }
        public string HL_AgeGroup { get; set; }
        public bool? HL_DutyOwed { get; set; }
        public string HL_HasLocalConnection5 { get; set; }
        public string HL_HasLocalConnectionNotes { get; set; }
        public string HL_HomelessDecision { get; set; }
        public DateTime? HL_HomelessDecisionDate { get; set; }
        public string HL_HomelessReason { get; set; }
        public string HL_HomelessWhereStayingNow { get; set; }
        public DateTime? HL_InterviewDate { get; set; }
        public string HL_IsEligible1 { get; set; }
        public string HL_IsEligibleNotes { get; set; }
        public string HL_IsHomeless2 { get; set; }
        public string HL_IsHomelessNotes { get; set; }
        public string HL_IsInPriorityNeed3 { get; set; }
        public string HL_IsInPriorityNeedNotes { get; set; }
        public string HL_IsIntentionallyHomeless4 { get; set; }
        public string HL_IsIntentionallyHomeless_Notes { get; set; }
        public string HL_Outcome { get; set; }
        public DateTime? HL_OutcomeDate { get; set; }
        public string HL_OutcomeOther { get; set; }
        public string HL_PriorityNeedReason { get; set; }
        public bool? HL_RepeatHomelessCase { get; set; }
        public DateTime? HL_S198DateIn { get; set; }
        public DateTime? HL_S198DateOut { get; set; }
        public bool? HL_S198Duty { get; set; }
        public bool? HL_S198DutyOut { get; set; }
        public DateTime? HL_S213DateIn { get; set; }
        public DateTime? HL_S213DateOut { get; set; }
        public bool? HL_S213Duty { get; set; }
        public bool? HL_S213DutyOut { get; set; }
        public DateTime? HL_TADateIn { get; set; }
        public DateTime? HL_TADateOut { get; set; }
        public bool? HL_TempAccommodation { get; set; }
        public string HL_TempAccommodationType { get; set; }
        public int? HL_TotalTimeResidentInWeeks { get; set; }
        public bool? HomelessFrozen { get; set; }
        public int? IncommunitiesTenancyRef { get; set; }
        public bool? IncommunitiesTenant { get; set; }
        public string LastName { get; set; }
        public bool? LiftRequired { get; set; }
        public string MaritalStatus { get; set; }
        public string MEDICAL_Address { get; set; }
        public string MEDICAL_GPFax { get; set; }
        public string MEDICAL_GPName { get; set; }
        public string MEDICAL_GPPhone { get; set; }
        public string MEDICAL_Postcode { get; set; }
        public string MEDICAL_PracticeName { get; set; }
        public string MobilePhone { get; set; }
        public bool? NeedsDependantsAssessment { get; set; }
        public bool? NeedsHomelessnessAssessment { get; set; }
        public bool? NeedsJointApplicationAssessment { get; set; }
        public bool? NeedsMedicalAssessment { get; set; }
        public string NINumber { get; set; }
        public short? NumberBedrooms { get; set; }
        public DateTime? OutcomeDate { get; set; }
        public string OutcomeOther { get; set; }
        public string OutcomeResult { get; set; }
        public int? ParentCaseRefNumber { get; set; }
        public string PA_Area1 { get; set; }
        public string PA_Area2 { get; set; }
        public string PA_Area3 { get; set; }
        public string PA_Area4 { get; set; }
        public string PA_CBLBand { get; set; }
        public string PA_EstateCodes { get; set; }
        public string PA_FloorLevel { get; set; }
        public bool? PA_GroupFloorExtension { get; set; }
        public string PA_Important { get; set; }
        public bool? PA_KitchenPartFullyConverted { get; set; }
        public string PA_LevelOfNeed { get; set; }
        public bool? PA_ManageableSteppedAccess { get; set; }
        public string PA_NoGo { get; set; }
        public short? PA_NumberBedrooms { get; set; }
        public string PA_Outcome { get; set; }
        public bool? PA_PrivateRentedInterest { get; set; }
        public string PA_PropertyTypeID { get; set; }
        public bool? PA_Ramped { get; set; }
        public bool? PA_RehousingRequired { get; set; }
        public bool? PA_Related { get; set; }
        public bool? PA_Sent { get; set; }
        public bool? PA_Stairlift { get; set; }
        public bool? PA_StepInShowerTray { get; set; }
        public bool? PA_ThroughFloorLift { get; set; }
        public DateTime? PA_UrgencyDate { get; set; }
        public bool? PA_WetRoom { get; set; }
        public bool? PetsAccepted { get; set; }
        public string PhoneLandline { get; set; }
        public string Postcode { get; set; }
        public DateTime? PregnancyDueDate { get; set; }
        public bool? Pregnant { get; set; }
        public DateTime? ReceptionDateTime { get; set; }
        public int ReceptionIndex { get; set; }
        public string ReceptionUserID { get; set; }
        public string RelevantContacts { get; set; }
        public string RTAEligibilityRights { get; set; }
        public bool? RTAIncomeProvided { get; set; }
        public string RTANationality { get; set; }
        public bool? RTAValidVisa { get; set; }
        public bool? RTAWorkingPermitted { get; set; }
        public string SupportWorkerDetails { get; set; }
        public DateTime? SystemHLDateTime { get; set; }
        public string SystemHLUserID { get; set; }
        public string Title { get; set; }
        public byte[] upsize_ts { get; set; }
        public bool? WarningFlag { get; set; }
        public string WarningNotes { get; set; }
        public DateTime? WarningNotesDateTime { get; set; }
        public string WarningNotesUserID { get; set; }
    }
}