using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL
{
    public class AlertBLL :  IAlertBLL
    {
        private IUnitOfWork _unitOfWork;
        public AlertBLL() : this(new UnitOfWork())
        {
        }

        public AlertBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     
        public List<AlertDTO> GetAlerts(ODataQueryOptions<HRSAlert> options)
        {
            var customers = options.ApplyTo(_unitOfWork.HRSAlert().Select().AsQueryable());
            return Mapper.Map<List<AlertDTO>>(customers);
        }

        public AlertDTO GetAlert(int caseEventId)
        {
            var result = _unitOfWork.HRSAlert().Select().FirstOrDefault(x => x.CaseEventID == caseEventId);
            var result2 = Mapper.Map<AlertDTO>(result);
            return result2;
        }
    }
}