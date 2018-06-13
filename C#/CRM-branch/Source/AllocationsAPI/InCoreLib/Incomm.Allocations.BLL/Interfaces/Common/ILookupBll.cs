using System.Collections.Generic;
using Incomm.Allocations.DTO.CRM;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.Common
{
    /// <summary>
    /// </summary>
    public interface ILookupBll
    {
        CRMLookup GetCRMLookup();
        Lookup GetLookup(int appId);
        List<VBLSupportType> GetSupportTypes();
        List<VBLSupportProvider> GetSupportProviders();
        List<Title> GetTitles();
        List<Gender> GetGenders();
        List<SuitabilityNoteType> GetSuitabilityNoteTypes(bool onlyActive);
    }
}
