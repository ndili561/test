using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_SubNeighbourhood
    {
        [Key]
        [Column(Order = 0)]
        public int SubNeighbourhoodId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string SubNeighbourhoodCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SubNeighbourhoodName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(15)]
        public string NeighbourhoodCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string NeighbourhoodName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(15)]
        public string ManagementAreaCode { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string ManagementAreaDescription { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool Active { get; set; }

        public int? SortOrder { get; set; }

        public int? ShapeId { get; set; }

        [StringLength(30)]
        public string SubNeighbourhoodCodeComb { get; set; }
    }
}
