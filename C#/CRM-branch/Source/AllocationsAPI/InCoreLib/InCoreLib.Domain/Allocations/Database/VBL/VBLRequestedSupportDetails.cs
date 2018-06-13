using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedSupportDetails : BaseObject
    {
        [Key]
        public int RequestedSupportDetailId { get; set; }
        public int SupportTypeId { get; set; }
        public virtual VBLSupportType SupportType { get; set; }
        public int ContactId { get; set; }
        public VBLContact Contact { get; set; }
    }
}
