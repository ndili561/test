using System.Collections.Generic;
using System.Web.Http.OData.Query;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IPropertyNeighbourhoodBLL
    {
        List<VBLPropertyNeighbourhood> GetPropertyNeighbourhoods(ODataQueryOptions<VBLPropertyNeighbourhood> options);
        int GetPropertyNeighbourhoodIdForPostcode(string Postcode);
        List<decimal> GetLongLatForPostCode(string Postcode);
    }
}