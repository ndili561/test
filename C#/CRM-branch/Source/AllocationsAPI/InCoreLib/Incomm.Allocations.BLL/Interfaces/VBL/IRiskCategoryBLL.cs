using System.Collections.Generic;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    /// <summary>
    /// </summary>
    public interface IRiskCategoryBLL
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        List<RiskCategory> GetRiskCategories();
    }
}