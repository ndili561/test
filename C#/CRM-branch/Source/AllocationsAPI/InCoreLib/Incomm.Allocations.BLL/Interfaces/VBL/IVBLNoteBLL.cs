using System.Collections.Generic;
using InCoreLib.Domain.Allocations.Database.VBL;
using System.Web.Http.OData.Query;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IVBLNoteBLL
    {
        List<VBLNote> GetVBLNotes(ODataQueryOptions<VBLNote> options);
        VBLNoteDTO CreateNote(VBLNote note);

        VBLNoteDTO UpdateNote(VBLNote note);
    }
}
