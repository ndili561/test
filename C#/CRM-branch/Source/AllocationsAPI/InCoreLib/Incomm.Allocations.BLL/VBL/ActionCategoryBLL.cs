using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.VBL
{
    /// <summary>
    /// </summary>
    public class ActionCategoryBLL : IActionCategoryBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ActionCategoryBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<ActionCategory> GetActionCategories()
        {
            var actionCategories =
                _unitOfWork
                    .ActionCategories()
                    .Select(ac => ac.Active)
                    .OrderBy(ac => ac.SortOrder)
                    .ToList();

            return actionCategories;
        }
    }
}
