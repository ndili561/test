using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyPropertySize : BaseObject
    {
        [Key]
        public int VBLPropertySizesOfRequestedPropertyId { get; set; }
        public int ApplicationId { get; set; }
        public VBLRequestedPropertymatchDetail VBLRequestedPropertymatchDetail { get; set; }
        public int PropertySizeId { get; set; }
        public virtual PropertySize PropertySize { get; set; }
    }
}
