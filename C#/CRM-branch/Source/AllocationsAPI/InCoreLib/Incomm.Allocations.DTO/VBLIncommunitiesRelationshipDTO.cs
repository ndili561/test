using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.DTO
{
    public class VBLIncommunitiesRelationshipDTO : BaseObjectDto
    {
        public int VBLIncommunitiesRelationshipId { get; set; }

        public int ContactId { get; set; }

        public bool HasIncommunitiesRelationship { get; set; }

        public string IncommunitiesRelationshipDescription { get; set; }
    }
}
