using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AllocationsAPI.WebAPI.Controllers.HRS;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Helpers;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class RequestedPropertymatchDetailController : BaseController
    {
        private IRequestedPropertymatchDetailBLL _requestedPropertymatchDetailBLL;
        public RequestedPropertymatchDetailController() : this(new RequestedPropertymatchDetailBLL())
        {
        }

        public RequestedPropertymatchDetailController(IRequestedPropertymatchDetailBLL requestedPropertymatchDetailBLL)
        {
            _requestedPropertymatchDetailBLL = requestedPropertymatchDetailBLL;
        }

        [HttpGet]
        [Route("applications/GetRequestedPropertymatchDetails")]
        public VBLRequestedPropertymatchDetail GetRequestedPropertymatchDetails(int applicationId)
        {
            return _requestedPropertymatchDetailBLL.GetRequestedPropertymatchDetail(applicationId);
        }

        [HttpPut]
        [Route("RequestedPropertymatchDetails/PutRequestedPropertymatchDetails")]
        public HttpResponseMessage PutApplicatiRequestedPropertymatchDetails(int id, VBLRequestedPropertymatchDetail requestedPropertymatchDetail)
        {
            HttpResponseMessage response;
            var persistedRequestedPropertymatchDetail = _requestedPropertymatchDetailBLL.GetRequestedPropertymatchDetail(id);

            if (requestedPropertymatchDetail != null )
            {
                if (persistedRequestedPropertymatchDetail != null && requestedPropertymatchDetail.RowVersion.ConvertByteArrayToString() !=persistedRequestedPropertymatchDetail.RowVersion.ConvertByteArrayToString())
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, requestedPropertymatchDetail);
                }
                _requestedPropertymatchDetailBLL.Update(requestedPropertymatchDetail, persistedRequestedPropertymatchDetail);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, persistedRequestedPropertymatchDetail);
            return response;
        }

    }
}