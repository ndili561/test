using AutoMapper;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Interfaces.IH;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.IH.Expenditure;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.IO;
using System.Linq;

namespace Incomm.Allocations.BLL.IH
{
    /// <summary>
    /// </summary>
    public class ExpenditureBLL : IExpenditureBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        public ExpenditureBLL() : this(new UnitOfWork())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ExpenditureBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public IEnumerable<ExpenditureDetailDTO> GetExpenditureByContactId(int contactId)
        {
            var expenditure = _unitOfWork.VBLExpenditureDetails().Select(e => e.ContactId == contactId);

            if (expenditure == null)
                return null;

            return Mapper.Map<List<ExpenditureDetailDTO>>(expenditure);
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public EntityPager<AuditVblExpenditureDetailsDTO> GetExpenditureHistoryByContactId(int contactId, int currentPageNumber, int pageSize)
        {
            var expenditure = _unitOfWork.AuditVBLExpenditureDetails().Select(ae => ae.ContactId == contactId);
            int totalRecords = expenditure.ToList().Count;
            int skipRows = 0;

            if (currentPageNumber > 1)
                skipRows = ((currentPageNumber - 1) * pageSize) + 1;

            if (expenditure == null)
                return null;

            var pageOfExpenditures = expenditure.OrderByDescending(e => e.ModifiedDate).Skip(skipRows).Take(pageSize).ToList();

            EntityPager<AuditVblExpenditureDetailsDTO> results = new EntityPager<AuditVblExpenditureDetailsDTO>();
            results.Results = Mapper.Map<List<AuditVblExpenditureDetailsDTO>>(pageOfExpenditures);
            results.TotalPages = totalRecords / pageSize > 0 ? totalRecords / pageSize : 1;
            var remainder = totalRecords % pageSize;
            if (remainder > 0 && totalRecords > pageSize)
            {
                results.TotalPages += 1;
            }
            results.PageSize = pageSize;
            results.CurrentPageNumber = currentPageNumber;

            return results;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExpenditureTypeDTO> GetExpenditureTypes()
        {
            var expenditureTypes = _unitOfWork.ExpenditureTypes().Select();

            if (expenditureTypes == null)
                return null;

            return Mapper.Map<List<ExpenditureTypeDTO>>(expenditureTypes);
        }

        /// <summary>
        /// </summary>
        /// <param name="expenditureDetails"></param>
        /// <returns></returns>
        /// <exception cref="OptimisticConcurrencyException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        public bool SaveExpenditureDetails(List<ExpenditureDetailDTO> expenditureDetails)
        {
            if (expenditureDetails == null)
                return false;

            bool success = true;

            try
            {
                foreach (var expenditureDetail in expenditureDetails)
                {
                    //  Insert the expenditure
                    if (expenditureDetail.ExpenditureDetailId <= 0 && (expenditureDetail.Amount > 0 || expenditureDetail.FutureCostInUse > 0 || expenditureDetail.Debt > 0))
                    {
                        var expenditureToPersist = new VBLExpenditureDetail
                        {
                            Amount = expenditureDetail.Amount,
                            ContactId = expenditureDetail.ContactId,
                            CreatedBy = expenditureDetail.CreatedBy,
                            CreatedDate = expenditureDetail.CreatedDate,
                            Debt = expenditureDetail.Debt.GetValueOrDefault(),
                            ExpenditureFrequencyId = expenditureDetail.ExpenditureFrequencyId,
                            ExpenditureTypeId = expenditureDetail.ExpenditureTypeId,
                            ExpendituresComment = expenditureDetail.ExpendituresComment,
                            FutureCostInUse = expenditureDetail.FutureCostInUse.GetValueOrDefault(),
                            ModifiedBy = expenditureDetail.ModifiedBy,
                            ModifiedDate = expenditureDetail.ModifiedDate,
                            UserIPAddress = expenditureDetail.UserIPAddress,
                            UserId = expenditureDetail.UserId
                        };

                        _unitOfWork.VBLExpenditureDetails().Insert(expenditureToPersist);
                    }
                    else if (expenditureDetail.ExpenditureDetailId > 0 && (expenditureDetail.Amount > 0 || expenditureDetail.FutureCostInUse > 0 || expenditureDetail.Debt > 0))
                    {
                        //  Update
                        var expenditureToPersist = _unitOfWork.VBLExpenditureDetails().Select(ed => ed.ExpenditureDetailId == expenditureDetail.ExpenditureDetailId).SingleOrDefault();
                        if (expenditureToPersist == null ||
                            expenditureToPersist.RowVersion.SequenceEqual(expenditureDetail.RowVersion) == false)
                        {
                            OptimisticConcurrencyException optimisticConcurrencyException = new OptimisticConcurrencyException();
                           // Logger.Error(optimisticConcurrencyException, string.Format("The expenditure record for expenditureDetailId: {0}, failed to update due to another user changing the record.", expenditureDetail.ExpenditureDetailId));
                            throw optimisticConcurrencyException;
                        }

                        //  Only update if any changes to the row details.
                        if (expenditureToPersist.Amount != expenditureDetail.Amount
                            || expenditureToPersist.ExpenditureFrequencyId != expenditureDetail.ExpenditureFrequencyId
                            || expenditureToPersist.Debt != expenditureDetail.Debt
                            || expenditureToPersist.FutureCostInUse != expenditureDetail.FutureCostInUse
                            || expenditureToPersist.ExpendituresComment != expenditureDetail.ExpendituresComment)
                        {
                            expenditureToPersist.Amount = expenditureDetail.Amount;
                            expenditureToPersist.ExpenditureFrequencyId = expenditureDetail.ExpenditureFrequencyId;
                            expenditureToPersist.Debt = expenditureDetail.Debt.GetValueOrDefault();
                            expenditureToPersist.FutureCostInUse = expenditureDetail.FutureCostInUse.GetValueOrDefault();
                            expenditureToPersist.ExpendituresComment = expenditureDetail.ExpendituresComment;
                            expenditureToPersist.ModifiedDate = DateTime.Now;
                            expenditureToPersist.ModifiedBy = expenditureDetail.ModifiedBy;

                            _unitOfWork.VBLExpenditureDetails().Update(expenditureToPersist);
                        }
                    }
                    else if (expenditureDetail.ExpenditureDetailId > 0 && expenditureDetail.Amount == 0 && expenditureDetail.FutureCostInUse == 0 && expenditureDetail.Debt == 0)
                    {
                        //  Delete
                        var expenditureToDelete = _unitOfWork.VBLExpenditureDetails().Select(ed => ed.ExpenditureDetailId == expenditureDetail.ExpenditureDetailId).SingleOrDefault();
                        if (expenditureToDelete == null)
                        {
                            var invalidDataException = new InvalidDataException();
                            //Logger.Error(invalidDataException, string.Format("Failed to delete the expenditureDetail Record with expenditureDetailId {0}", expenditureDetail.ExpenditureDetailId));
                            throw invalidDataException;
                        }


                        expenditureToDelete.ModifiedBy = expenditureDetail.ModifiedBy;
                        expenditureToDelete.ModifiedDate = expenditureDetail.ModifiedDate;
                        _unitOfWork.VBLExpenditureDetails().Update(expenditureToDelete);
                        _unitOfWork.Commit();

                        var audit =
                            _unitOfWork.AuditVBLExpenditureDetails()
                                .Select(a => a.ExpenditureDetailId == expenditureDetail.ExpenditureDetailId
                                    && a.ChangeType == "Updated")
                                .OrderByDescending(a => a.ModifiedDate)
                                .FirstOrDefault();

                        if (audit != null)
                        {
                            _unitOfWork.AuditVBLExpenditureDetails().Delete(audit);
                            _unitOfWork.Commit();
                        }

                        _unitOfWork.VBLExpenditureDetails().Delete(expenditureToDelete);
                    }
                }

                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }
    }
}
