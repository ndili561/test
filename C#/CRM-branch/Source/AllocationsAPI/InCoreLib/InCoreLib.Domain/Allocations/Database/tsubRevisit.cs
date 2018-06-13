using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tsubRevisit
    {
        [Key]
        public int RevisitIndex { get; set; }

        public int? ReceptionIndex { get; set; }

        public int? CaseRefNumber { get; set; }

        [StringLength(50)]
        public string ReceptionUserID { get; set; }

        [Column(TypeName = "ntext")]
        public string ReceptionNotes { get; set; }

        public DateTime? ReceptionDateTime { get; set; }

        [StringLength(50)]
        public string LeftReceptionUserID { get; set; }

        public DateTime? LeftReceptionDateTime { get; set; }

        [Column(TypeName = "ntext")]
        public string LeftReceptionNotes { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public int? RevReasonID { get; set; }

        public int? CaseNoteID { get; set; }
    }
}
