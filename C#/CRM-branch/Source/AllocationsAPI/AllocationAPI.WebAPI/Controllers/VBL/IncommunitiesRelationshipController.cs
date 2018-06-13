using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using Incomm.Allocations.DTO;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL/IncommunitiesRelationship")]
    public class IncommunitiesRelationshipController : ApiController
    {
        private readonly IIncommunitiesRelationshipBLL _incommunitiesRelationshipBll;

        public IncommunitiesRelationshipController() : this (new IncommunitiesRelationshipBLL())
        {}

        public IncommunitiesRelationshipController(IIncommunitiesRelationshipBLL incommunitiesRelationshipBll)
        {
            _incommunitiesRelationshipBll = incommunitiesRelationshipBll;
        }

        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(int incommunitiesRelationshipId)
        {
            var relationship = _incommunitiesRelationshipBll.Get(incommunitiesRelationshipId);

            return relationship != null
                ? Request.CreateResponse(HttpStatusCode.OK, relationship)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("GetByContactId")]
        public HttpResponseMessage GetByContactId(int contactId)
        {
            var relationship = _incommunitiesRelationshipBll.GetByContactId(contactId);

            return relationship != null
                ? Request.CreateResponse(HttpStatusCode.OK, relationship)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Post(VBLIncommunitiesRelationshipDTO incommunitiesRelationship)
        {
            _incommunitiesRelationshipBll.Save(incommunitiesRelationship);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("Put")]
        public HttpResponseMessage Put(int incommunitiesRelationshipId, VBLIncommunitiesRelationshipDTO incommunitiesRelationship)
        {
            _incommunitiesRelationshipBll.Save(incommunitiesRelationship);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete(VBLIncommunitiesRelationshipDTO incommunitiesRelationship)
        {
            _incommunitiesRelationshipBll.Delete(incommunitiesRelationship);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
