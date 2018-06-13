using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLApplication : BaseObject
    {
        public VBLApplication()
        {
            VBLCustomerInterests = new List<VBLCustomerInterest>();
            VBLApplicationHistories = new List<VBLApplicationHistory>();
            VBLDocuments = new List<VBLDocument>();
            Contacts = new List<VBLContact>();
        }
        [Key]
        public int ApplicationId { get; set; }
        public int ApplicationStatusID { get; set; }
        public ApplicationStatu ApplicationStatus { get; set; }
        public string ApplicationStatusReason { get; set; }
        public int? ApplicationStatusReasonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool? ApplicationEligible { get; set; }
        public DateTime? HOALevelOfNeedDate { get; set; }
        public int? ApplicationLevelOfNeedID { get; set; }
        public bool? DataProtectionIsPrinted { get; set; }
        public bool? DataProtectionIsSigned { get; set; }
        public bool? DataProtectionConsented { get; set; }
        public int? HOACaseRef { get; set; }
        public string HOAContact { get; set; }
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
        public DateTime? EarliestMoveDate { get; set; }
        public DateTime? LatestMoveDate { get; set; }
        [StringLength(1000)]
        public string ApplicationLevelOfNeedReason { get; set; }
        public string AssessmentLastModifiedInfo { get; set; }

        public int? ResidencyTypeId { get; set; }
        public ResidencyType ResidencyType { get; set; }
        [StringLength(255)]
        public string LandLordName { get; set; }
        public int? MoveReasonId { get; set; }
        public MoveReason MoveReason { get; set; }

        public int? TenancyTypeId { get; set; }
        public TenancyType TenancyType { get; set; }
        public int? LandlordId { get; set; }
        public Landlord LandLord { get; set; }

        public bool? LeaveVacantProperty { get; set; }
        public bool? IsSignedDeclarationUploaded { get; set; }
        public bool? MatchToMutualExchage { get; set; }
        public int? MutualExchagePropertyDetailId { get; set; }
        public virtual VBLMutualExchagePropertyDetail VblMutualExchagePropertyDetail { get; set; }
        public ICollection<VBLContact> Contacts { get; set; }
        public virtual ICollection<VBLCustomerInterest> VBLCustomerInterests { get; set; }
        public int? RequestedPropertymatchDetailId { get; set; }
        public virtual VBLRequestedPropertymatchDetail VBLRequestedPropertymatchDetail { get; set; }
        [NotMapped]
        public virtual VBLAddress Address { get; set; }
        [ForeignKey("ApplicationLevelOfNeedID")]
        public virtual LevelOfNeed LevelOfNeeds { get; set; }
        public bool IsMainTenant { get; set; }
        public DateTime? DateMovedIn { get; set; }
        [NotMapped]
        public SaveApplication SaveApplication { get; set; }

        public virtual ICollection<VBLApplicationHistory> VBLApplicationHistories { get; set; }

        public virtual ICollection<VBLDocument> VBLDocuments { get; set; }
    }
}
