using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("PropertyFloorLevel")]
    public partial class PropertyFloorLevel
    {
        public int PropertyFloorLevelId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
