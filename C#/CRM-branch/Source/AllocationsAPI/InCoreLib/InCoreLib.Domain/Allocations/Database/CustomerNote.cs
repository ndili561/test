using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("CustomerNote")]
    public partial class CustomerNote
    {
        public int CustomerNoteID { get; set; }

        public int CustomerApplicationID { get; set; }

        public int VoidContactID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string NoteDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Note { get; set; }

        public bool NoteActive { get; set; }
    }
}
