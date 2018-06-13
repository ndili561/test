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
    public class RiskCategoryBLL : IRiskCategoryBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public RiskCategoryBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<RiskCategory> GetRiskCategories()
        {
            var riskCategories =
                _unitOfWork
                    .RiskCategories()
                    .Select(rc => rc.Active)
                    .OrderBy(rc => rc.SortOrder)
                    .ToList();

            return riskCategories;
        }
    }
}
