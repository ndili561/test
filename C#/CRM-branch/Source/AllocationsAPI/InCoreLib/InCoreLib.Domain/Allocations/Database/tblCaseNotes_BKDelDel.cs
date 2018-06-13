using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblCaseNotes_BKDelDel
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
    }
}
