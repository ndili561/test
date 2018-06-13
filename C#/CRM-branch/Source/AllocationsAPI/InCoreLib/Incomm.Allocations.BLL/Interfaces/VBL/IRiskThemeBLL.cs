using System.Collections.Generic;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    /// <summary>
    /// </summary>
    public interface IRiskThemeBLL
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        List<RiskTheme> GetRiskThemes();
    }
}