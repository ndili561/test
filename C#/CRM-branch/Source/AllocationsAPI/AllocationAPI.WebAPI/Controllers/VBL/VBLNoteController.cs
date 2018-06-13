using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;
using System.Net.Http;
using System.Net;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class VBLNoteController : BaseController
    {
        private readonly IVBLNoteBLL _noteBll;
        public VBLNoteController() : this(new VBLNoteBLL())
        {
        }

        public VBLNoteController(IVBLNoteBLL noteBLLl)
        {
            _noteBll = noteBLLl;
        }

        [HttpGet]
        [Route("VBLNote/GetVBLNote")]
        public PageResult<VBLNote> Get(ODataQueryOptions<VBLNote> options)
        {
            var vblNotes = _noteBll.GetVBLNotes(options);
            var result = new PageResult<VBLNote>(
                vblNotes,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpPost]
        [Route("VBLNote/PostVBLNote")]
        public HttpResponseMessage PostVBLNote(VBLNote note)
        {
            var vblNoteDto = _noteBll.CreateNote(note);
            var result = Request.CreateResponse(string.IsNullOrWhiteSpace(vblNoteDto.ErrorMessage) ? HttpStatusCode.OK : HttpStatusCode.PreconditionFailed, vblNoteDto);
            return result;
        }

        [HttpPut]
        [Route("VBLNote/PutVBLNote")]
        public HttpResponseMessage PutVBLNote(VBLNote note)
        {
            var vblNoteDto = _noteBll.UpdateNote(note);
            var result = Request.CreateResponse(string.IsNullOrWhiteSpace(vblNoteDto.ErrorMessage) ? HttpStatusCode.OK : HttpStatusCode.PreconditionFailed, vblNoteDto);
            return result;
        }
    }
}
