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
    public class RiskThemeBLL : IRiskThemeBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public RiskThemeBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<RiskTheme> GetRiskThemes()
        {
            var riskThemes =
                _unitOfWork
                    .RiskThemes()
                    .Select(rt => rt.Active)
                    .OrderBy(rt => rt.SortOrder)
                    .ToList();

            return riskThemes;
        }
    }
}
