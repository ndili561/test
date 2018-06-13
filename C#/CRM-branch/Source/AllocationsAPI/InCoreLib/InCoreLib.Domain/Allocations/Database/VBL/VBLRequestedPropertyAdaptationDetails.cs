using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyAdaptationDetails : BaseObject
    {
        [Key, Column(Order = 0)]
        public int ApplicationId { get; set; }
        [Key, Column(Order = 1)]
        public int AdaptationId { get; set; }
        public virtual Adaptation Adaptation { get; set; }
        public VBLRequestedPropertymatchDetail VBLRequestedPropertymatchDetail { get; set; }
    }
}
