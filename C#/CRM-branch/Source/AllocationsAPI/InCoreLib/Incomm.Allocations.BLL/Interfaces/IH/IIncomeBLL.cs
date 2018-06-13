using System.Collections.Generic;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.IH.Income;

namespace Incomm.Allocations.BLL.Interfaces.IH
{
    /// <summary>
    /// </summary>
    public interface IIncomeBLL
    {
        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        IEnumerable<IncomeDetailDTO> GetIncomeByContactId(int contactId);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EntityPager<AuditIncomeDetailDTO> GetIncomeHistoryByContactId(int contactId, int currentPageNumber, int pageSize);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IEnumerable<IncomeTypeDTO> GetIncomeTypes();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IEnumerable<IncomeFrequencyDTO> GetIncomeFrequencies();

        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        bool SaveIncomeDetails(List<IncomeDetailDTO> incomeDetails);

        IncomeDetailDTO GetIncomeByContactIdAndIncomeId(int contactId, int incomeId);

        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        bool SaveIncomeDetail(IncomeDetailDTO incomeDetails);


        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        bool DeleteIncomeDetail(IncomeDetailDTO incomeDetails);

    }
}