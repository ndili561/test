using System.Collections.Generic;
using System.Web.Http.OData.Query;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
   public interface ITenantDetailBLL
    {
        VBLTenantDetail GeTenantDetail(int tenantDetailId);
        List<VBLTenantDetail> GetTenantDetails(ODataQueryOptions<VBLTenantDetail> options);
        VBLTenantDetail Create(VBLTenantDetail tenentDetails);
        VBLTenantDetail Update(VBLTenantDetail tenentDetails, VBLTenantDetail persistedTenentDetails);
       void Delete(int contactId, string userId, string userIpAddress);
    }
}
