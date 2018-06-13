using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.IH;
using Incomm.Allocations.BLL.Interfaces.IH;
using Incomm.Allocations.DTO.IH.SuitabilityNote;

namespace AllocationsAPI.WebAPI.Controllers.IH
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/IH/SuitabilityNote")]
    public class SuitabilityNoteController : ApiController
    {
        private readonly ISuitabilityNoteBLL _suitabilityNoteBll;

        public SuitabilityNoteController() : this(new SuitabilityNoteBLL())
        {}

        public SuitabilityNoteController(ISuitabilityNoteBLL suitabilityNoteBll)
        {
            _suitabilityNoteBll = suitabilityNoteBll;
        }

        [HttpGet]
        [Route("GetNote")]
        public HttpResponseMessage GetNote(int noteId)
        {
            var note = _suitabilityNoteBll.GetNote(noteId);

            return note != null
                ? Request.CreateResponse(HttpStatusCode.OK, note)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(int contactId)
        {
            var notes = _suitabilityNoteBll.GetNotes(contactId);

            return notes != null
                ? Request.CreateResponse(HttpStatusCode.OK, notes)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(int contactId, int noteTypeId)
        {
            var notes = _suitabilityNoteBll.GetNotes(contactId, noteTypeId);

            return notes != null
                ? Request.CreateResponse(HttpStatusCode.OK, notes)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(int contactId, int pageNumber, int pageSize)
        {
            var notes = _suitabilityNoteBll.GetNotes(contactId, pageNumber, pageSize);

            return notes != null
                ? Request.CreateResponse(HttpStatusCode.OK, notes)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(int contactId, int noteTypeId, int pageNumber, int pageSize)
        {
            var notes = _suitabilityNoteBll.GetNotes(contactId, noteTypeId, pageNumber, pageSize);

            return notes != null
                ? Request.CreateResponse(HttpStatusCode.OK, notes)
                : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Post([FromBody]SuitabilityNoteDTO value)
        {
            var response = _suitabilityNoteBll.SaveNote(value);

            return string.IsNullOrWhiteSpace(response)
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }

        [HttpPut]
        [Route("Put")]
        public HttpResponseMessage Put(int noteId, [FromBody]SuitabilityNoteDTO value)
        {
            var response = _suitabilityNoteBll.SaveNote(value);

            return string.IsNullOrWhiteSpace(response)
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }

        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete(int noteId, string userId, string userIp)
        {
            var response = _suitabilityNoteBll.DeleteNote(noteId, userId, userIp);

            return string.IsNullOrWhiteSpace(response)
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }
    }
}
