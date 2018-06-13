using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class HRSAlertController : BaseController
    {
        private IAlertBLL _alertBLL;
        public HRSAlertController() : this(new AlertBLL())
        {
        }

        public HRSAlertController(IAlertBLL alertBLL)
        {
            _alertBLL = alertBLL;

        }

        [HttpGet]
        [Route("HRSAlert/GetHRSAlerts")]
        public PageResult<AlertDTO> GetHRSAlerts(ODataQueryOptions<HRSAlert> options)
        {

            var alertDto = _alertBLL.GetAlerts(options);
            var result = new PageResult<AlertDTO>(
                alertDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("HRSAlert/GetAlert")]
        public AlertDTO GetAlert(int caseEventId)
        {
            return _alertBLL.GetAlert(caseEventId);
        }
    }
}