using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblCaseNotesAudit")]
    public partial class tblCaseNotesAudit
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

        public int? OriginalCaseRefNumber { get; set; }

        public int? RevisedCaseRefNumber { get; set; }

        public int? CaseNoteIndex { get; set; }

        public DateTime? OriginalCaseNoteDate { get; set; }

        public DateTime? RevisedCaseNoteDate { get; set; }

        [StringLength(50)]
        public string OriginalCaseNoteUserID { get; set; }

        [StringLength(50)]
        public string RevisedCaseNoteUserID { get; set; }

        [StringLength(50)]
        public string OriginalCaseNoteType { get; set; }

        [StringLength(50)]
        public string RevisedCaseNoteType { get; set; }

        public string OriginalCaseNote { get; set; }

        public string RevisedCaseNote { get; set; }

        public bool? OriginalCaseNoteConfidentialFlag { get; set; }

        public bool? RevisedCaseNoteConfidentialFlag { get; set; }

        [StringLength(50)]
        public string OriginalCaseNoteConfidentialFlagUserID { get; set; }

        [StringLength(50)]
        public string RevisedCaseNoteConfidentialFlagUserID { get; set; }

        public DateTime? OriginalCaseNoteConfidentialFlagDateSet { get; set; }

        public DateTime? RevisedCaseNoteConfidentialFlagDateSet { get; set; }

        public DateTime? OriginalCaseNoteLastEditedDateTime { get; set; }

        public DateTime? RevisedCaseNoteLastEditedDateTime { get; set; }
    }
}
