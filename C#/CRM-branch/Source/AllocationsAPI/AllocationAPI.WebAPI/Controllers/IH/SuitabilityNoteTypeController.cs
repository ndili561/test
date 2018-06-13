using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Interfaces.Common;

namespace AllocationsAPI.WebAPI.Controllers.IH
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/IH/SuitabilityNoteType")]
    public class SuitabilityNoteTypeController : ApiController
    {
        private readonly ILookupBll _lookupBll;

        public SuitabilityNoteTypeController() : this(new LookupBLL())
        {}

        public SuitabilityNoteTypeController(ILookupBll lookupBll)
        {
            _lookupBll = lookupBll;
        }

        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(bool onlyActive = true)
        {
            var types = _lookupBll.GetSuitabilityNoteTypes(onlyActive);

            return types != null
                ? Request.CreateResponse(HttpStatusCode.OK, types)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
