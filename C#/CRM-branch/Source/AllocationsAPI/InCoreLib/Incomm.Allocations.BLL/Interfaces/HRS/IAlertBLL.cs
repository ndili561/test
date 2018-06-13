using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IAlertBLL
    {
        List<AlertDTO> GetAlerts(ODataQueryOptions<HRSAlert> options);
        AlertDTO GetAlert(int caseEventId);
    }
}