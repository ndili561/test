using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database.VBL;
using System.Collections.Generic;
using System.Web.Http.OData.Query;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IApplicationBLL
    {
        string GetApplicationRowVersion(int applicationId);
        VBLApplication GetApplication(int applicationId);
        VBLApplication GetApplicationOnly(int customerApplicationApplicationId);
        VBLPropertyShopDTO GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(VBLPropertyShopDTO postcode);
        VBLApplication GetApplicationWithNeighbourhoodsDetails(int applicationId);
        List<VBLApplication> GetApplications(ODataQueryOptions<VBLApplication> options);
        VBLApplication Update(VBLApplication application);
        VBLApplication UpdateApplicationDate(VBLApplication application);
        VBLApplication GetApplicationForContactPages(int applicationId);
        VBLApplication GetApplicationForPropertyDetailPages(int applicationId);
        VBLApplication GetApplicationForPropertyPreferencePages(int applicationId);
        VBLApplication GetApplicationForPropertyShopPages(int applicationId);
        VBLApplication GetBasicApplication(int applicationId);

        /// <summary>
        /// </summary>
        /// <param name="customerApplication"></param>
        /// <param name="persistedApplication"></param>
        /// <returns></returns>
        bool UpdateApplicationStatus(VBLApplication customerApplication, VBLApplication persistedApplication);

        
    }
}