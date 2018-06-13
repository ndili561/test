using System.Collections.Generic;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.IH.Expenditure;

namespace Incomm.Allocations.BLL.Interfaces.IH
{
    /// <summary>
    /// </summary>
    public interface IExpenditureBLL
    {
        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        IEnumerable<ExpenditureDetailDTO> GetExpenditureByContactId(int contactId);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EntityPager<AuditVblExpenditureDetailsDTO> GetExpenditureHistoryByContactId(int contactId, int currentPageNumber, int pageSize);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IEnumerable<ExpenditureTypeDTO> GetExpenditureTypes();

        /// <summary>
        /// </summary>
        /// <param name="expenditureDetails"></param>
        /// <returns></returns>
        bool SaveExpenditureDetails(List<ExpenditureDetailDTO> expenditureDetails);
    }
}