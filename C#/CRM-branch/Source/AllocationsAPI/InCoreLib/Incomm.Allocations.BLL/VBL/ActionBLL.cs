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
    public class ActionBLL : IActionBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ActionBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public List<SuitabilityCheckAction> GetActionsByContactId(int contactId)
        {
            var actions =
                _unitOfWork
                    .Actions()
                    .Select(sc => sc.ContactId == contactId)
                    .OrderByDescending(sc => sc.ActionLoggedDate)
                    .ToList();

            return actions;
        }

        /// <summary>
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool SaveAction(SuitabilityCheckAction action)
        {

            if (action.Id <= 0)
            {
                _unitOfWork.Actions().Insert(action);
            }
            else
            {
                var persistedAction =
                    _unitOfWork
                        .Actions()
                        .Select(ca => ca.Id == action.Id)
                        .SingleOrDefault();

                if (persistedAction == null)
                {
                    var recordNotFoundException = new KeyNotFoundException("A SuitabilityCheckAction record was not found in the database with id = " + action.Id);
                    throw new Exception(recordNotFoundException.Message);
                }

                if (action.ConcurrencyCheck.SequenceEqual(persistedAction.ConcurrencyCheck) == false)
                {

                    var optimisticCurrencyException =
                        new OptimisticConcurrencyException(string.Format("The SuitabilityCheckAction record with Id: {0} has been modified by another user.  Please refresh and retry", action.Id));

                    //  TODO:  Add logging ...
                    //_logging.LogErrorMessage(optimisticCurrencyException, "ActionService.SaveAction()");

                    throw new Exception(optimisticCurrencyException.Message);
                }

                persistedAction.DisplayTabName = action.DisplayTabName;
                persistedAction.DateToComplete = action.DateToComplete;
                persistedAction.ActionResponsibilityId = action.ActionResponsibilityId;
                persistedAction.ActionLoggedDate = action.ActionLoggedDate;
                persistedAction.ActionLoggedById = action.ActionLoggedById;
                persistedAction.ActionCompletedDate = action.ActionCompletedDate;
                persistedAction.Notes = action.Notes;
                persistedAction.LastModifiedById = action.LastModifiedById;
                persistedAction.ModifiedTimestamp = action.ModifiedTimestamp;

                _unitOfWork
                    .Actions()
                    .Update(persistedAction);
            }

            try
            {
                _unitOfWork.Commit();
                return true;
            }
            catch (DbUpdateException due)
            {
                //_logging.LogErrorMessage(due, "ActionService.SaveAction _unitOfWork.Commit()");
                throw new Exception(due.Message);
            }
            catch (UpdateException ue)
            {
                //_logging.LogErrorMessage(ue, "ActionService.SaveAction _unitOfWork.Commit()");
                throw new Exception(ue.Message);
            }
            catch (SqlException se)
            {
                //_logging.LogErrorMessage(se, "ActionService.SaveAction _unitOfWork.Commit()");
                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                //_logging.LogErrorMessage(ex, "ActionService.SaveAction _unitOfWork.Commit()");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public EntityPager<SuitabilityCheckAction> GetPageOfActionsByContactId(int contactId, int currentPage, int pageSize)
        {
            var pageOfActions = new EntityPager<SuitabilityCheckAction>
            {
                PageSize = pageSize,
                CurrentPageNumber = currentPage
            };

            var allActions =
                _unitOfWork
                    .Actions()
                    .Select(a => a.ContactId == contactId)
                    .OrderByDescending(a => a.ActionLoggedDate)
                    .ToList();

            var totalRows = allActions.Count;
            int remainder;

            var totalPages = Math.DivRem(totalRows, pageSize, out remainder);
            if (totalRows > 0 && totalRows < pageSize)
            {
                totalPages = 1;
            }
            else if (remainder > 0)
            {
                totalPages++;
            }

            if (currentPage > totalPages)
                currentPage = totalPages;

            var actions =
                allActions
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);

            pageOfActions.TotalPages = totalPages;
            pageOfActions.Results = actions.ToList();

            return pageOfActions;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="displayTabPage"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public EntityPager<SuitabilityCheckAction> GetPageOfActionsByContactIdDisplayTabPage(int contactId, string displayTabPage, int currentPage,
            int pageSize)
        {
            List<SuitabilityCheckAction> allActions;
            var pageOfActions = new EntityPager<SuitabilityCheckAction>
            {
                PageSize = pageSize,
                CurrentPageNumber = currentPage
            };

            if (displayTabPage == "RisksActions")
            {
                allActions =
                    _unitOfWork
                        .Actions()
                        .Select(a => a.ContactId == contactId)
                        .OrderByDescending(a => a.ActionLoggedDate)
                        .ToList();
            }
            else
            {
                allActions =
                    _unitOfWork
                        .Actions()
                        .Select(a => a.ContactId == contactId
                            && (!string.IsNullOrEmpty(displayTabPage)
                            && a.DisplayTabName == displayTabPage))
                        .OrderByDescending(a => a.ActionLoggedDate)
                        .ToList();
            }

            var totalRows = allActions.Count;
            int remainder;

            var totalPages = Math.DivRem(totalRows, pageSize, out remainder);
            if (totalRows > 0 && totalRows < pageSize)
            {
                totalPages = 1;
            }
            else if (remainder > 0)
            {
                totalPages++;
            }

            if (currentPage > totalPages)
                currentPage = totalPages;

            var actions =
                allActions
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);

            pageOfActions.TotalPages = totalPages;
            pageOfActions.Results = actions.ToList();

            return pageOfActions;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public SuitabilityCheckAction GetAction(int id)
        {
            var action =
                _unitOfWork
                    .Actions()
                    .Select(a => a.Id == id)
                    .SingleOrDefault();

            return action;
        }
    }
}
