using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public class SubNeighbourhood
    {
        [Key]
        public int SubNeighbourhoodId { get; set; }
        public string SubNeighbourhoodCode { get; set; }
        public string SubNeighbourhoodName { get; set; }
        public string NeighbourhoodCode { get; set; }
        public string NeighbourhoodName { get; set; }
        public string ManagementAreaCode { get; set; }
        public string ManagementAreaDescription { get; set; }
        public bool Active { get; set; }
        public int? SortOrder { get; set; }
        public int? ShapeId { get; set; }
        public string SubNeighbourhoodCodeComb { get; set; }
        public int? OldShapeId { get; set; }
    }
}
