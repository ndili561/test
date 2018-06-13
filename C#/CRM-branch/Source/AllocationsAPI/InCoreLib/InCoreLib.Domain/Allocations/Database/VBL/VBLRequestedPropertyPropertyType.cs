using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyPropertyType : BaseObject
    {
        [Key]
        public int VBLPropertyTypesOfRequestedPropertyId { get; set; }
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public int ApplicationId { get; set; }
        public VBLRequestedPropertymatchDetail VBLRequestedPropertymatchDetail { get; set; }
    }
}
