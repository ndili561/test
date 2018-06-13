using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class RequestedPropertyPrefferedNeighbourhoodController : ApiController
    {
        private readonly IRequestedPropertyPrefferedNeighbourhoodBLL _requestedPropertyPrefferedNeighbourhoodBll;

        public RequestedPropertyPrefferedNeighbourhoodController() : this(new RequestedPropertyPrefferedNeighbourhoodBLL())
        {
        }

        public RequestedPropertyPrefferedNeighbourhoodController(IRequestedPropertyPrefferedNeighbourhoodBLL requestedPropertyPrefferedNeighbourhoodBll)
        {
            _requestedPropertyPrefferedNeighbourhoodBll = requestedPropertyPrefferedNeighbourhoodBll;
        }
        [HttpPost]
        [Route("RequestedPropertyPrefferedNeighbourhood/Post")]
        public HttpResponseMessage Post(VBLRequestedPropertyPrefferedNeighbourhood requestedPropertyPrefferedNeighbourhood)
        {
            requestedPropertyPrefferedNeighbourhood = _requestedPropertyPrefferedNeighbourhoodBll.Create(requestedPropertyPrefferedNeighbourhood);
            var response = Request.CreateResponse(HttpStatusCode.Created, requestedPropertyPrefferedNeighbourhood);
            return response;

        }


    }
}
