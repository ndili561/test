using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstCaseNoteType")]
    public partial class lstCaseNoteType
    {
        [Key]
        [StringLength(50)]
        public string CaseNoteType { get; set; }

        [StringLength(50)]
        public string CaseNoteTypeDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
