using System.Collections.Generic;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    /// <summary>
    /// </summary>
    public interface IActionResponsibilityBLL
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        List<ActionResponsibility> GetActionResponsibilities();
    }
}