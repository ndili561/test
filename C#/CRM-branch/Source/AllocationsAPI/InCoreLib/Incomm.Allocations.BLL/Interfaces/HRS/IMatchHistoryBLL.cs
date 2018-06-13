using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IMatchHistoryBLL
    {
        HRSMatchHistoryDTO HRSMatch(int matchId, bool returnSingle);

        HRSMatchHistoryDTO GetAcceptedHRSMatch(int customerId, bool returnSingle, int placementId);

        List<HRSMatchHistoryDTO> GetMatchHistoryForCustomer(int hrsCustomerId);

        List<HRSMatchHistoryDTO> GetAllMatchHistory();

        HRSMatchHistoryDTO ReconsiderPreviousMatch(int matchId, HRSPlacementMatchedForCustomerDTO match);
    }
}