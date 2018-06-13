using System.Collections.Generic;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    /// <summary>
    /// </summary>
    public interface IRiskBLL
    {
        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        List<SuitabilityCheckRisk> GetRisksByContactId(int contactId);

        /// <summary>
        /// </summary>
        /// <param name="risk"></param>
        /// <returns></returns>
        bool SaveRisk(SuitabilityCheckRisk risk);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EntityPager<SuitabilityCheckRisk> GetPageOfRisksByContactId(int contactId, int currentPage, int pageSize);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="displayTabName"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EntityPager<SuitabilityCheckRisk> GetPageOfRisksByContactIdDisplayTabName(int contactId, string displayTabName, int currentPage, int pageSize);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>

        /// <returns></returns>
        SuitabilityCheckRisk GetRisk(int id);
    }
}
