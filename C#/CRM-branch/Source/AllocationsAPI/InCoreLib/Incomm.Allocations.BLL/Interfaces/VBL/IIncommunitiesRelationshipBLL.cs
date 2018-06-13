using Incomm.Allocations.DTO;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IIncommunitiesRelationshipBLL
    {
        VBLIncommunitiesRelationshipDTO Get(int vblIncommunitiesRelationshipId);
        VBLIncommunitiesRelationshipDTO GetByContactId(int contactId);
        void Delete(VBLIncommunitiesRelationshipDTO relationship);
        void Save(VBLIncommunitiesRelationshipDTO relationship);
    }
}