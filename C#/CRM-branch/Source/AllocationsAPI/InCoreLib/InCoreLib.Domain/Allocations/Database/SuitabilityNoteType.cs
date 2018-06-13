using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("SuitabilityNoteTypes")]
    public class SuitabilityNoteType
    {
        [Required]
        public int SuitabilityNoteTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}