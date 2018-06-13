using Incomm.Allocations.DTO;
using System.Collections.Generic;

namespace Incomm.Allocations.BLL.Interfaces.HOA
{
    public interface ICaseNotesBLL
    {
        IList<HOACaseNoteDTO> GetCaseNotes(int caseRefNumber);

        IList<HOACaseNoteTypeDTO> GetCaseNoteTypes();
    }
}