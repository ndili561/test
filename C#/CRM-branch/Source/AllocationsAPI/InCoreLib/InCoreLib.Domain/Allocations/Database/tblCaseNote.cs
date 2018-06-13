using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblCaseNote
    {
        public int? CaseRefNumber { get; set; }

        [Key]
        public int CaseNoteIndex { get; set; }

        public DateTime? CaseNoteDate { get; set; }

        [StringLength(50)]
        public string CaseNoteUserID { get; set; }

        [StringLength(50)]
        public string CaseNoteType { get; set; }

        [Column(TypeName = "ntext")]
        public string CaseNote { get; set; }

        public bool? CaseNoteConfidentialFlag { get; set; }

        [StringLength(50)]
        public string CaseNoteConfidentialFlagUserID { get; set; }

        public DateTime? CaseNoteConfidentialFlagDateSet { get; set; }

        public DateTime? CaseNoteLastEditedDateTime { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public int? QstnrSectionID { get; set; }

        public int? QstnrSubSectionID { get; set; }

        public int? QstnID { get; set; }

        public virtual tblHOAssessment tblHOAssessment { get; set; }

        [NotMapped]
        [SkipTracking]
        public virtual string UserId { get; set; }

        [NotMapped]
        [SkipTracking]
        public virtual string UserIPAddress { get; set; }
    }
}
