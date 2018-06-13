using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.VBL
{
    public class ApplicationHistoryBLL : IApplicationHistoryBLL
    {

        private IUnitOfWork _unitOfWork;
        public ApplicationHistoryBLL() : this(new UnitOfWork())
        {
        }

        public ApplicationHistoryBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public VBLApplicationHistory GetApplicationHistory(int applicationHistoryId)
        {
            return _unitOfWork.VBLApplicationHistory().Select().FirstOrDefault(x => x.Id == applicationHistoryId);
        }

        public List<VBLApplicationHistory> GetApplicationHistoryList(string propertyCode)
        {
            return _unitOfWork.VBLApplicationHistory().Select().Where(x => x.PropertyCode == propertyCode).ToList();
        }

        public PageResult<VBLApplicationHistory> GetApplicationHistories(ODataQueryOptions<VBLApplicationHistory> options)
        {
            throw new NotImplementedException();
        }

        public VBLApplicationHistory Create(int applicationId, string createdBy, string userIPAddress, ApplicationActivity applicationActivity, ApplicationChangeType applicationChangeType, string changeDescription, string propertyCode = "", bool canReconsider = false)
        {
            var vblApplicationHistory = new VBLApplicationHistory
            {
                ApplicationActivity = applicationActivity,
                ApplicationChangeType = applicationChangeType,
                ApplicationChangeDescription = changeDescription,
                CreatedBy = createdBy,
                ModifiedBy = createdBy,
                CreatedDate = DateTime.Now,
                ApplicationId = applicationId,
                PropertyCode= propertyCode,
                CanReconsider =canReconsider
            };
            _unitOfWork.VBLApplicationHistory().Insert(vblApplicationHistory);
            _unitOfWork.Commit(createdBy, userIPAddress);
            return vblApplicationHistory;
        }

        public VBLApplicationHistory Update(VBLApplicationHistory applicationHistory)
        {
            _unitOfWork.VBLApplicationHistory().Update(applicationHistory);
            _unitOfWork.Commit(applicationHistory.CreatedBy, applicationHistory.UserIPAddress);
            return applicationHistory;
        }

        public void UpdateRange(List<VBLApplicationHistory > applicationHistoryList)
        {
            _unitOfWork.VBLApplicationHistory().UpdateRange(applicationHistoryList);
            _unitOfWork.Commit(applicationHistoryList.First().CreatedBy, applicationHistoryList.First().UserIPAddress);
        }
    }
}