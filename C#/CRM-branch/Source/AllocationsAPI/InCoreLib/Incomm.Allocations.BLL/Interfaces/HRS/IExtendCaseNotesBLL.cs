using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IExtendCaseNotesBLL
    {
        List<tblCaseNoteDTO> GetHRSExtendStayNotes(string CurrentUserEmail);
    }
}