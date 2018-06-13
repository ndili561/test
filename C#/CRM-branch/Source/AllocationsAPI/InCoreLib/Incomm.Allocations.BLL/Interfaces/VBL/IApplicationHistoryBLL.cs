using System.Collections.Generic;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IApplicationHistoryBLL
    {
        VBLApplicationHistory GetApplicationHistory(int applicationId);
        List<VBLApplicationHistory> GetApplicationHistoryList(string propertyCode);
        PageResult<VBLApplicationHistory> GetApplicationHistories(ODataQueryOptions<VBLApplicationHistory> options);
        VBLApplicationHistory Create(int applicationId, string createdBy, string userIPAddress, ApplicationActivity applicationActivity, ApplicationChangeType applicationChangeType, string changeDescription,string propertyCode="",bool canReconsider =false);
        VBLApplicationHistory Update(VBLApplicationHistory applicationHistory);
        void UpdateRange(List<VBLApplicationHistory> applicationHistory);
    }
}