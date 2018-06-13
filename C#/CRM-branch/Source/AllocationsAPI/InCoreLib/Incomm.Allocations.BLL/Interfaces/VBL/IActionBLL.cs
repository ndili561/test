using System.Collections.Generic;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    /// <summary>
    /// </summary>
    public interface IActionBLL
    {
        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        List<SuitabilityCheckAction> GetActionsByContactId(int contactId);

        /// <summary>
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        bool SaveAction(SuitabilityCheckAction action);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EntityPager<SuitabilityCheckAction> GetPageOfActionsByContactId(int contactId, int currentPage, int pageSize);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="displayTabPage"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EntityPager<SuitabilityCheckAction> GetPageOfActionsByContactIdDisplayTabPage(int contactId, string displayTabPage, int currentPage, int pageSize);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        SuitabilityCheckAction GetAction(int id);
    }
}