using System.Collections.Generic;
using System.Linq;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.VBL
{
    /// <summary>
    /// </summary>
    public class ActionTypeBLL : IActionTypeBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ActionTypeBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<ActionType> GetActionTypes()
        {
            var actionTypes =
                _unitOfWork
                    .ActionTypes()
                    .Select(at => at.Active)
                    .OrderBy(at => at.SortOrder)
                    .ToList();

            return actionTypes;
        }
    }
}
