using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyHeatingType : BaseObject
    {
        [Key]
        public int VBLRequestedPropertyHeatingTypeId { get; set; }
        public int ApplicationId { get; set; }
        public VBLRequestedPropertymatchDetail VBLRequestedPropertymatchDetail { get; set; }
        public int HeatingTypeId { get; set; }
        public virtual HeatingType HeatingType { get; set; }
    }
}
