using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyScheme : BaseObject
    {
        [Key]
        public int VBLRequestedPropertySchemeId { get; set; }
        public int ApplicationId { get; set; }
        public VBLRequestedPropertymatchDetail VBLRequestedPropertymatchDetail { get; set; }
        public int SchemeId { get; set; }
        public virtual Scheme Scheme { get; set; }
    }
}
