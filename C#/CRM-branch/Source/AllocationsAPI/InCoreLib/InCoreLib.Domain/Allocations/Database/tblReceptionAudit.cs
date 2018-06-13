using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblReceptionAudit")]
    public partial class tblReceptionAudit
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

        public int? ReceptionIndex { get; set; }

        [StringLength(50)]
        public string OriginalReceptionUserID { get; set; }

        [StringLength(50)]
        public string RevisedReceptionUserID { get; set; }

        public DateTime? OriginalReceptionDateTime { get; set; }

        public DateTime? RevisedReceptionDateTime { get; set; }

        [StringLength(50)]
        public string OriginalReceptionTitle { get; set; }

        [StringLength(50)]
        public string RevisedReceptionTitle { get; set; }

        [StringLength(50)]
        public string OriginalReceptionFirstName { get; set; }

        [StringLength(50)]
        public string RevisedReceptionFirstName { get; set; }

        [StringLength(50)]
        public string OriginalReceptionLastName { get; set; }

        [StringLength(50)]
        public string RevisedReceptionLastName { get; set; }

        public DateTime? OriginalReceptionDOB { get; set; }

        public DateTime? RevisedReceptionDOB { get; set; }

        [StringLength(255)]
        public string OriginalReceptionAddressLine1 { get; set; }

        [StringLength(255)]
        public string RevisedReceptionAddressLine1 { get; set; }

        [StringLength(50)]
        public string OriginalReceptionApproachReason { get; set; }

        [StringLength(50)]
        public string RevisedReceptionApproachReason { get; set; }

        [StringLength(50)]
        public string OriginalReceptionContactType { get; set; }

        [StringLength(50)]
        public string RevisedReceptionContactType { get; set; }

        public string OriginalReceptionContactDetails { get; set; }

        public string RevisedReceptionContactDetails { get; set; }

        public string OriginalReceptionNotes { get; set; }

        public string RevisedReceptionNotes { get; set; }

        public bool? OriginalReceptionAllocatedToHOA { get; set; }

        public bool? RevisedReceptionAllocatedToHOA { get; set; }

        public int? OriginalCaseRefNumber { get; set; }

        public int? RevisedCaseRefNumber { get; set; }

        public bool? OriginalWarningFlag { get; set; }

        public bool? RevisedWarningFlag { get; set; }

        [StringLength(50)]
        public string OriginalLeftReceptionUserID { get; set; }

        [StringLength(50)]
        public string RevisedLeftReceptionUserID { get; set; }

        public DateTime? OriginalLeftReceptionDateTime { get; set; }

        public DateTime? RevisedLeftReceptionDateTime { get; set; }

        public string OriginalLeftReceptionNotes { get; set; }

        public string RevisedLeftReceptionNotes { get; set; }

        [StringLength(3)]
        public string OriginalReceptionUserLocation { get; set; }

        [StringLength(3)]
        public string RevisedReceptionUserLocation { get; set; }
    }
}
