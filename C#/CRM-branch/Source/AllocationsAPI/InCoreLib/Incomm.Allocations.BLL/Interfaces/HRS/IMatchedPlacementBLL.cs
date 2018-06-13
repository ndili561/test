using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.Interfaces.HRS
{
    public interface IMatchedPlacementBLL
    {
        List<HRSPlacementMatchedForCustomerDTO> GetMoveOnCustomers(
            ODataQueryOptions<HRSPlacementMatchedForCustomer> options, int providerId);

        List<HRSPlacementMatchedForCustomerDTO> GetMatchedPlacements(
            ODataQueryOptions<HRSPlacementMatchedForCustomer> options);

        HRSPlacementMatchedForCustomerDTO PutMatchedPlacement(int id,
            HRSPlacementMatchedForCustomerDTO hrsPlacementMatchedForCustomerDto);

        HRSPlacementMatchedForCustomerDTO HRSPlacementMatchedForCustomer(int matchedPlacementId);

        void InsertOrUpdateMatchHistory(HRSPlacementMatchedForCustomer placementMatchedForCustomer);

        void SaveCaseNoteForHOA(HRSPlacementMatchedForCustomerDTO hrsPlacementMatchedForCustomerDto,
            HRSPlacementMatchedForCustomer persistedObject);

        HRSPlacementMatchedForCustomerDTO CreateMoveOnMatch(HRSPlacementMatchedForCustomerDTO item);
    }
}
