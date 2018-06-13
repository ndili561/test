using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lst198213Sources
    {
        [Key]
        public int SourceID { get; set; }

        [Required]
        [StringLength(150)]
        public string SourceDesc { get; set; }

        public bool Active { get; set; }

        public bool AppliesTo198 { get; set; }

        public bool AppliesTo213 { get; set; }
    }
}
