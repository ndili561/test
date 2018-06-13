using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyPrefferedNeighbourhoodDetail : BaseObject
    {
        [Key]
        public int RequestedPropertyPrefferedNeighbourhoodDetailId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int RequestedPropertyPrefferedNeighbourhoodId { get; set; }
        public VBLRequestedPropertyPrefferedNeighbourhood RequestedPropertyPrefferedNeighbourhood { get; set; }
    }
}
