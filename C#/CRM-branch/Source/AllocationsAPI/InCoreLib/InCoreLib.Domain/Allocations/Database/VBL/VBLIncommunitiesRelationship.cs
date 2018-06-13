using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLIncommunitiesRelationship : BaseObject
    {
        [Key]
        public int VBLIncommunitiesRelationshipId { get; set; }

        [Required]
        [ForeignKey("Contact")]
        [Index("IX_VBLIncommunitiesRelationships_ContactId", IsClustered = false, IsUnique = true)]
        public int ContactId { get; set; }

        public bool HasIncommunitiesRelationship { get; set; }

        public string IncommunitiesRelationshipDescription { get; set; }

        public virtual VBLContact Contact { get; set; }
    }
}