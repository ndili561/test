using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLDisabilityDetails : BaseObject
    {
        [Key]
        public int DisabilityDetailId { get; set; }

        public int DisabilityTypeId { get; set; }
        public virtual VBLDisabilityType DisabilityType { get; set; }
        public int ContactId { get; set; }
        public VBLContact Contact { get; set; }
        public string Comment { get; set; }
    }
}