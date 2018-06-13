using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lstPlacementReason
    {
        [Key]
        [Column(Order = 0)]
        public int ReasonID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [StringLength(150)]
        public string PlacementReason { get; set; }
    }
}
