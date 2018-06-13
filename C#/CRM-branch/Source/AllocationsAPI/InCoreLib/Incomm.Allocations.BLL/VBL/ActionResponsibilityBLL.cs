using System;
using System.Collections.Generic;
using System.Linq;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.VBL
{
    /// <summary>
    /// </summary>
    public class ActionResponsibilityBLL : IActionResponsibilityBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public ActionResponsibilityBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<ActionResponsibility> GetActionResponsibilities()
        {
            var actionResponsibilities =
                _unitOfWork
                    .ActionResponsibilities()
                    .Select(ar => ar.Active)
                    .OrderBy(ar => ar.SortOrder)
                    .ToList();

            return actionResponsibilities;
        }
    }
}
