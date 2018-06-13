using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLIncommunitiesRelationshipType : BaseObject
    {
        [Key]
        public int IncommunitiesRelationshipTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool Active { get; set; }
        public int? SortOrder { get; set; }
    }
}
