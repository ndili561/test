using AutoMapper;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Interfaces.IH;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.IH.Income;
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
    public class IncomeBLL : IIncomeBLL
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        public IncomeBLL() : this(new UnitOfWork())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public IncomeBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public IEnumerable<IncomeDetailDTO> GetIncomeByContactId(int contactId)
        {
            var incomes = _unitOfWork.VBLIncomeDetails().Select(id => id.ContactId == contactId);

            if (incomes == null)
                return null;

            return Mapper.Map<List<IncomeDetailDTO>>(incomes);
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="incomeId"></param>
        /// <returns></returns>
        public IncomeDetailDTO GetIncomeByContactIdAndIncomeId(int contactId, int incomeId)
        {
            var income = _unitOfWork.VBLIncomeDetails().Select(id => id.ContactId == contactId && id.IncomeDetailId == incomeId).SingleOrDefault();

            return Mapper.Map<IncomeDetailDTO>(income);
        }


        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        public bool SaveIncomeDetail(IncomeDetailDTO incomeDetails)
        {
            if (incomeDetails == null)
                return false;

            bool success = true;

            try
            {

                //  Insert the record.
                if (incomeDetails.IncomeDetailId <= 0 && (incomeDetails.Amount > 0))
                {
                    var incomeToPersist = new VBLIncomeDetail
                    {
                        Amount = incomeDetails.Amount,
                        ContactId = incomeDetails.ContactId,
                        CreatedBy = incomeDetails.CreatedBy,
                        CreatedDate = incomeDetails.CreatedDate,
                        IncomeFrequencyId = incomeDetails.IncomeFrequencyId,
                        IncomeTypeId = incomeDetails.IncomeTypeId,
                        IncomesComment = incomeDetails.IncomesComment,
                        ModifiedBy = incomeDetails.ModifiedBy,
                        ModifiedDate = incomeDetails.ModifiedDate,
                        UserIPAddress = incomeDetails.UserIPAddress,
                        UserId = incomeDetails.UserId
                    };

                    _unitOfWork.VBLIncomeDetails().Insert(incomeToPersist);
                }
                else if (incomeDetails.IncomeDetailId > 0 && incomeDetails.Amount > 0)
                {
                    //  Update
                    var incomeToPersist = _unitOfWork.VBLIncomeDetails().Select(id => id.IncomeDetailId == incomeDetails.IncomeDetailId).SingleOrDefault();
                    if (incomeToPersist == null || incomeToPersist.RowVersion.SequenceEqual(incomeDetails.RowVersion) == false)
                    {

                        OptimisticConcurrencyException optimisticConcurrencyException = new OptimisticConcurrencyException();
                        Logger.Error(optimisticConcurrencyException, string.Format("The income record for incomeDetailId: {0}, failed to update due to another user changing the record.", incomeDetails.IncomeDetailId));
                        throw optimisticConcurrencyException;
                    }

                    if (incomeToPersist.Amount != incomeDetails.Amount
                        || incomeToPersist.IncomesComment != incomeDetails.IncomesComment
                        || incomeToPersist.IncomeFrequencyId != incomeDetails.IncomeFrequencyId
                        || incomeToPersist.IncomeTypeId != incomeDetails.IncomeTypeId)
                    {
                        incomeToPersist.Amount = incomeDetails.Amount;
                        incomeToPersist.IncomesComment = incomeDetails.IncomesComment;
                        incomeToPersist.IncomeFrequencyId = incomeDetails.IncomeFrequencyId;
                        incomeToPersist.IncomeTypeId = incomeDetails.IncomeTypeId;
                        incomeToPersist.ModifiedBy = incomeDetails.ModifiedBy;
                        incomeToPersist.ModifiedDate = DateTime.Now;

                        _unitOfWork.VBLIncomeDetails().Update(incomeToPersist);
                    }

                }
                else if (incomeDetails.IncomeDetailId > 0 && incomeDetails.Amount == 0)
                {
                    //  Delete
                    var incomeToDelete = _unitOfWork.VBLIncomeDetails().Select(ed => ed.IncomeDetailId == incomeDetails.IncomeDetailId).SingleOrDefault();
                    if (incomeToDelete == null)
                    {
                        InvalidDataException incInvalidDataException = new InvalidDataException();
                        Logger.Error(incInvalidDataException, string.Format("Failed to delete the incomeDetail Record with incomeDetailId {0}", incomeDetails.IncomeDetailId));
                        throw new InvalidDataException();
                    }

                    _unitOfWork.VBLIncomeDetails().Delete(incomeToDelete);
                }


                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public EntityPager<AuditIncomeDetailDTO> GetIncomeHistoryByContactId(int contactId, int currentPageNumber, int pageSize)
        {
            var incomeHistories = _unitOfWork.AuditVBLIncomeDetails().Select(ai => ai.ContactId == contactId);
            var totalRecords = incomeHistories.ToList().Count;
            var skipRows = 0;

            if (currentPageNumber > 1)
                skipRows = ((currentPageNumber - 1) * pageSize) + 1;

            if (incomeHistories == null)
                return null;

            var pageOfIncomeHistories = incomeHistories.OrderByDescending(i => i.ModifiedDate).Skip(skipRows).Take(pageSize).ToList();

            EntityPager<AuditIncomeDetailDTO> results = new EntityPager<AuditIncomeDetailDTO>();
            results.Results = Mapper.Map<List<AuditIncomeDetailDTO>>(pageOfIncomeHistories);
            results.TotalPages = totalRecords / pageSize;
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
        public IEnumerable<IncomeTypeDTO> GetIncomeTypes()
        {
            var incomeTypes = _unitOfWork.IncomeTypes().Select();

            if (incomeTypes == null)
                return null;

            return Mapper.Map<List<IncomeTypeDTO>>(incomeTypes);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IncomeFrequencyDTO> GetIncomeFrequencies()
        {
            var incomeFrequencies = _unitOfWork.IncomeFrequencies().Select();

            if (incomeFrequencies == null)
                return null;

            return Mapper.Map<List<IncomeFrequencyDTO>>(incomeFrequencies);
        }

        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        public bool SaveIncomeDetails(List<IncomeDetailDTO> incomeDetails)
        {
            if (incomeDetails == null)
                return false;

            bool success = true;

            try
            {
                foreach (var incomeDetail in incomeDetails)
                {
                    //  Insert the record.
                    if (incomeDetail.IncomeDetailId <= 0 && (incomeDetail.Amount > 0))
                    {
                        var incomeToPersist = new VBLIncomeDetail
                        {
                            Amount = incomeDetail.Amount,
                            ContactId = incomeDetail.ContactId,
                            CreatedBy = incomeDetail.CreatedBy,
                            CreatedDate = incomeDetail.CreatedDate,
                            IncomeFrequencyId = incomeDetail.IncomeFrequencyId,
                            IncomeTypeId = incomeDetail.IncomeTypeId,
                            IncomesComment = incomeDetail.IncomesComment,
                            ModifiedBy = incomeDetail.ModifiedBy,
                            ModifiedDate = incomeDetail.ModifiedDate,
                            UserIPAddress = incomeDetail.UserIPAddress,
                            UserId = incomeDetail.UserId
                        };

                        _unitOfWork.VBLIncomeDetails().Insert(incomeToPersist);
                    }
                    else if (incomeDetail.IncomeDetailId > 0 && incomeDetail.Amount > 0)
                    {
                        //  Update
                        var incomeToPersist = _unitOfWork.VBLIncomeDetails().Select(id => id.IncomeDetailId == incomeDetail.IncomeDetailId).SingleOrDefault();
                        if (incomeToPersist == null || incomeToPersist.RowVersion.SequenceEqual(incomeDetail.RowVersion) == false)
                        {

                            OptimisticConcurrencyException optimisticConcurrencyException = new OptimisticConcurrencyException();
                            //Logger.Error(optimisticConcurrencyException, string.Format("The income record for incomeDetailId: {0}, failed to update due to another user changing the record.", incomeDetail.IncomeDetailId));
                            throw optimisticConcurrencyException;
                        }

                        if (incomeToPersist.Amount != incomeDetail.Amount
                            || incomeToPersist.IncomesComment != incomeDetail.IncomesComment
                            || incomeToPersist.IncomeFrequencyId != incomeDetail.IncomeFrequencyId)
                        {
                            incomeToPersist.Amount = incomeDetail.Amount;
                            incomeToPersist.IncomesComment = incomeDetail.IncomesComment;
                            incomeToPersist.IncomeFrequencyId = incomeDetail.IncomeFrequencyId;
                            incomeToPersist.ModifiedBy = incomeDetail.ModifiedBy;
                            incomeToPersist.ModifiedDate = DateTime.Now;

                            _unitOfWork.VBLIncomeDetails().Update(incomeToPersist);
                        }

                    }
                    else if (incomeDetail.IncomeDetailId > 0 && incomeDetail.Amount == 0)
                    {
                        //  Delete
                        var incomeToDelete = _unitOfWork.VBLIncomeDetails().Select(ed => ed.IncomeDetailId == incomeDetail.IncomeDetailId).SingleOrDefault();
                        if (incomeToDelete == null)
                        {
                            InvalidDataException incInvalidDataException = new InvalidDataException();
                          //  Logger.Error(incInvalidDataException, string.Format("Failed to delete the incomeDetail Record with incomeDetailId {0}", incomeDetail.IncomeDetailId));
                            throw new InvalidDataException();
                        }

                        _unitOfWork.VBLIncomeDetails().Delete(incomeToDelete);
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



        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        public bool DeleteIncomeDetail(IncomeDetailDTO incomeDetails)
        {
            if (incomeDetails == null)
                return false;

            bool success = true;

            try
            {
                //  Delete
                var incomeToDelete = _unitOfWork.VBLIncomeDetails().Select(ed => ed.IncomeDetailId == incomeDetails.IncomeDetailId).SingleOrDefault();
                if (incomeToDelete == null)
                {
                    InvalidDataException incInvalidDataException = new InvalidDataException();
                    Logger.Error(incInvalidDataException, string.Format("Failed to delete the incomeDetail Record with incomeDetailId {0}", incomeDetails.IncomeDetailId));
                    throw new InvalidDataException();
                }

                //  Because the trigger inserts AFTER EF has deleted the record,
                //  it cannot update the ModifiedBy and ModifiedDate correctly in the Audit.
                //  To get round this, we update the record first to the correct value and then
                //  delete the audit record
                incomeToDelete.ModifiedBy = incomeDetails.ModifiedBy;
                incomeToDelete.ModifiedDate = incomeDetails.ModifiedDate;

                _unitOfWork.VBLIncomeDetails().Update(incomeToDelete);
                _unitOfWork.Commit();

                var audit = _unitOfWork.AuditVBLIncomeDetails()
                    .Select(a => a.IncomeDetailId == incomeDetails.IncomeDetailId && a.ChangeType == "Updated")
                    .OrderByDescending(a => a.ModifiedDate)
                    .FirstOrDefault();

                if (audit != null)
                {
                    _unitOfWork.AuditVBLIncomeDetails().Delete(audit);
                }
                _unitOfWork.Commit();

                _unitOfWork.VBLIncomeDetails().Delete(incomeToDelete);
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
