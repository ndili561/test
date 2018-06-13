using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyPrefferedNeighbourhood : BaseObject
    {
        [Key]
        public int RequestedPropertyPrefferedNeighbourhoodId { get; set; }
        public int ApplicationId { get; set; }
        public bool IsCurrent { get; set; }
        public VBLRequestedPropertymatchDetail RequestedPropertymatchDetail { get; set; }
        public List<VBLRequestedPropertyPrefferedNeighbourhoodDetail> RequestedPropertyPrefferedNeighbourhoodDetails { get; set; }
    }
}
