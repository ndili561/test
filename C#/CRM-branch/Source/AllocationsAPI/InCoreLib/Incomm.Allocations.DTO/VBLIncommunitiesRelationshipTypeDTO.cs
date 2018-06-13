using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.DTOs
{
   public class VBLIncommunitiesRelationshipTypeDTO : BaseObject
    {
        [Key]
        public int IncommunitiesRelationshipTypeId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int? SortOrder { get; set; }
    }
}
