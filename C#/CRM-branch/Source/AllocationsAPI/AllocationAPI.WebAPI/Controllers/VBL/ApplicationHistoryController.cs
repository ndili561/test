using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AllocationsAPI.WebAPI.Controllers.HRS;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class ApplicationHistoryController : BaseController
    {
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public ApplicationHistoryController() : this(new ApplicationHistoryBLL())
        {
        }

        public ApplicationHistoryController(IApplicationHistoryBLL applicationHistoryBLL)
        {
            _applicationHistoryBLL = applicationHistoryBLL;
        }

        [HttpGet]
        [Route("ApplicationHistory")]
        public PageResult<VBLApplicationHistory> GetApplicationHistory(ODataQueryOptions<VBLApplicationHistory> options)
        {
            var applicationHistory =
                options.ApplyTo(
                    UnitOfWork.VBLApplicationHistory()
                        .Select()
                        .AsQueryable());
            var applicationHistoryDto = Mapper.Map<List<VBLApplicationHistory>>(applicationHistory);

            var result = new PageResult<VBLApplicationHistory>(
                applicationHistoryDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpPost]
        [Route("ApplicationHistory/PostApplicationHistory")]
        public HttpResponseMessage PostApplicationHistory(VBLApplicationHistory applicationHistory)
        {
            applicationHistory = _applicationHistoryBLL.Create(applicationHistory.ApplicationId, applicationHistory.CreatedBy, applicationHistory.UserIPAddress, applicationHistory.ApplicationActivity, applicationHistory.ApplicationChangeType, applicationHistory.ApplicationChangeDescription);
            var response = Request.CreateResponse(HttpStatusCode.Created, applicationHistory);
            return response;

        }

    }
}