using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("SuitabilityNotes")]
    public class SuitabilityNote : BaseObject
    {
        [Key]
        public int SuitabilityNoteId { get; set; }

        [Required]
        [ForeignKey("SuitabilityNoteType")]
        public int SuitabilityNoteTypeId { get; set; }

        [Required]
        [ForeignKey("VBLContact")]
        [Index("IX_SuitabilityNotes_ContactId", IsClustered = false, IsUnique = false)]
        public int ContactId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual VBLContact VBLContact { get; set; }

        public virtual SuitabilityNoteType SuitabilityNoteType { get; set; }
    }
}