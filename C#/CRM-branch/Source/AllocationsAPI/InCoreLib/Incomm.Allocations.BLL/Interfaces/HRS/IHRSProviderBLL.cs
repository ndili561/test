using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IHRSProviderBLL
    {
        List<HRSProviderDTO> GetHRSProviders(ODataQueryOptions<HRSProvider> options);
        HRSProviderDTO GetHRSProvider(int providerId);
        HRSProviderDTO PostHRSProvider(HRSProviderDTO item);
        HRSProviderDTO PutHRSProvider(int id, HRSProviderDTO hrsProviderDto);
    }
}