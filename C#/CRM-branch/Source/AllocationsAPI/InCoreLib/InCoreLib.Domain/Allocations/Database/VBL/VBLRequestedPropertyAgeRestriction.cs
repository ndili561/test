using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertyAgeRestriction : BaseObject
    {
        [Key]
        public int VBLAgeRestrictionsOfRequestedPropertyId { get; set; }
        public int AgeRestrictionId { get; set; }
        public virtual AgeRestriction AgeRestriction { get; set; }
        public int ApplicationId { get; set; }
        public VBLRequestedPropertymatchDetail VBLRequestedPropertymatchDetail { get; set; }
    }
}
