using System.Collections.Generic;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.IH.SuitabilityNote;

namespace Incomm.Allocations.BLL.Interfaces.IH
{
    public interface ISuitabilityNoteBLL
    {
        IList<SuitabilityNoteDTO> GetNotes(int contactId);

        IList<SuitabilityNoteDTO> GetNotes(int contactId, int typeId);

        EntityPager<SuitabilityNoteDTO> GetNotes(int contactId, int pageNumber, int pageSize);

        EntityPager<SuitabilityNoteDTO> GetNotes(int contactId, int typeId, int pageNumber, int pageSize);

        SuitabilityNoteDTO GetNote(int suitabilityNoteId);

        string SaveNote(SuitabilityNoteDTO note);

        string DeleteNote(int suitabilityNoteId, string userId, string userIp);
    }
}