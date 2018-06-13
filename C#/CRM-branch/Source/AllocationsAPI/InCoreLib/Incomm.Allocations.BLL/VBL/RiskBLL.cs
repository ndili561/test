using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.VBL
{
    /// <summary>
    /// </summary>
    public class RiskBLL : IRiskBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public RiskBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public List<SuitabilityCheckRisk> GetRisksByContactId(int contactId)
        {
            var risks =
                _unitOfWork
                    .Risks()
                    .Select(cr => cr.ContactId == contactId)
                    .OrderByDescending(r=>r.LoggedDate)
                    .ToList();

            return risks;
        }

        /// <summary>
        /// </summary>
        /// <param name="risk"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveRisk(SuitabilityCheckRisk risk)
        {

            if (risk.Id <= 0)
            {
                risk.ModifiedTimestamp = DateTime.Now;
                _unitOfWork.Risks().Insert(risk);
            }
            else
            {
                var persistedRisk =
                    _unitOfWork
                        .Risks()
                        .Select(cr => cr.Id == risk.Id)
                        .SingleOrDefault();

                if (persistedRisk == null)
                {
                    var recordNotFoundException = new KeyNotFoundException("A SuitabilityCheckRisk record was not found in the database with id = " + risk.Id);
                    throw new Exception(recordNotFoundException.Message);
                }

                if (persistedRisk.ConcurrencyCheck.SequenceEqual(risk.ConcurrencyCheck) == false)
                {

                    var optimisticCurrencyException = new OptimisticConcurrencyException(string.Format("The SuitabilityCheckRisk with id: {0} has been modified by another user.  Please refresh and retry", risk.Id));

                    //  TODO:  Implement logging
                    //_logging.LogErrorMessage(optimisticCurrencyException, "RiskService.SaveRisk()");

                    throw new Exception(optimisticCurrencyException.Message);
                }

                persistedRisk.DisplayTabName = risk.DisplayTabName;
                persistedRisk.LoggedDate = risk.LoggedDate;
                persistedRisk.LoggedById = risk.LoggedById;
                persistedRisk.LastReviewedDate = risk.LastReviewedDate;
                persistedRisk.RiskDetail = risk.RiskDetail;
                persistedRisk.LastModifiedById = risk.LastModifiedById;
                persistedRisk.ModifiedTimestamp = DateTime.Now;
                persistedRisk.RiskThemeId = risk.RiskThemeId;
                persistedRisk.RiskCategoryId = risk.RiskCategoryId;

                _unitOfWork.Risks().Update(persistedRisk);
            }

            try
            {
                _unitOfWork.Commit();
                return true;
            }
            catch (DbUpdateException due)
            {
                //_logging.LogErrorMessage(due, "RiskService.SaveRisk _unitOfWork.Commit()");
                throw new Exception(due.Message);
            }
            catch (UpdateException ue)
            {
                //_logging.LogErrorMessage(ue, "RiskService.SaveRisk _unitOfWork.Commit()");
                throw new Exception(ue.Message);
            }
            catch (SqlException se)
            {
                //_logging.LogErrorMessage(se, "RiskService.SaveRisk _unitOfWork.Commit()");
                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                //_logging.LogErrorMessage(ex, "RiskService.SaveRisk _unitOfWork.Commit()");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public EntityPager<SuitabilityCheckRisk> GetPageOfRisksByContactId(int contactId, int currentPage, int pageSize)
        {
            var pageOfRisks = new EntityPager<SuitabilityCheckRisk>
            {
                PageSize = pageSize,
                CurrentPageNumber = currentPage
            };

            var allRisks =
                _unitOfWork
                    .Risks()
                    .Select(r => r.ContactId == contactId)
                    .OrderByDescending(r => r.LoggedDate)
                    .ToList();

            //  Calculate total rows and total pages based on pageSize
            var totalRows = allRisks.Count;
            int remainder;

            var totalPages = Math.DivRem(totalRows, pageSize, out remainder);
            if (totalRows > 0 && totalRows < pageSize)
                totalPages = 1;
            else if (remainder > 0)
            {
                totalPages++;
            }

            if (currentPage > totalPages)
                currentPage = totalPages;

            var risks =
                allRisks
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);

            pageOfRisks.TotalPages = totalPages;
            pageOfRisks.Results = risks.ToList();

            return pageOfRisks;

        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="displayTabName"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public EntityPager<SuitabilityCheckRisk> GetPageOfRisksByContactIdDisplayTabName(int contactId, string displayTabName, int currentPage, int pageSize)
        {
            List<SuitabilityCheckRisk> allRisks;
            var pageOfRisks = new EntityPager<SuitabilityCheckRisk>
            {
                PageSize = pageSize,
                CurrentPageNumber = currentPage
            };

            if (displayTabName == "RisksActions")
            {
                allRisks =
                _unitOfWork
                    .Risks()
                    .Select(r => r.ContactId == contactId)
                    .OrderByDescending(r => r.LoggedDate)
                    .ToList();
            }
            else
            {
                allRisks =
                _unitOfWork
                    .Risks()
                    .Select(r => r.ContactId == contactId && (!string.IsNullOrEmpty(displayTabName) && r.DisplayTabName == displayTabName))
                    .OrderByDescending(r=>r.LoggedDate)
                    .ToList();
            }

            //  Calculate total rows and total pages based on pageSize
            var totalRows = allRisks.Count;
            int remainder;

            var totalPages = Math.DivRem(totalRows, pageSize, out remainder);
            if (totalRows > 0 && totalRows < pageSize)
                totalPages = 1;
            else if (remainder > 0)
            {
                totalPages++;
            }

            if (currentPage > totalPages)
                currentPage = totalPages;

            var risks =
                allRisks
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);

            pageOfRisks.TotalPages = totalPages;
            pageOfRisks.Results = risks.ToList();

            return pageOfRisks;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SuitabilityCheckRisk GetRisk(int id)
        {
            var risk =
                _unitOfWork
                    .Risks()
                    .Select(r => r.Id == id)
                    .SingleOrDefault();

            return risk;
        }
    }
}
