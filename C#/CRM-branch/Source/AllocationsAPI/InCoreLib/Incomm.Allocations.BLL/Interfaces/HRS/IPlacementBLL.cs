using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IPlacementBLL
    {
        List<HRSPlacementDTO> GetPlacements(ODataQueryOptions<HRSPlacement> options);
        HRSPlacementDTO GetPlacement(int placementId);
        HRSPlacementDTO PostHRSPlacement(HRSPlacementDTO placementDto);
        HRSPlacementDTO PutPlacement(int id, HRSPlacementDTO placementDto);
        void DeletePlacement(int id, string userId, string userIPAddress);

    }
}