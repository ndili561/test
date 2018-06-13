using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Service.Api.DTOs;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [ElmahHandleWebApiError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/VBL")]
    public class EmailController : ApiController
    {
        private IDocumentBLL _documentBLL;

        public EmailController() : this(new DocumentBLL())
        {
        }

        public EmailController(IDocumentBLL documentBLL)
        {
            _documentBLL = documentBLL;
        }

        [HttpPost]
        [Route("Email/PostEmail")]
        public HttpResponseMessage PostEmail(VBLDocumentDTO documentDto)
        {
            HttpResponseMessage result;
            var document = _documentBLL.GetDocument(documentDto.DocumentId);
            if (document == null)
            {
                result = Request.CreateResponse(HttpStatusCode.PreconditionFailed);
            }
            else
            {
                document.UserIPAddress = documentDto.UserIPAddress;
                document.UserId = documentDto.UserId;
                _documentBLL.EmailDocument(document, documentDto.Subject, documentDto.EmailBody, documentDto.CCEmailAddress);
                var resultDto = new VBLDocumentDTO
                {
                    ApplicationId = document.ApplicationId,
                    DocumentId = document.DocumentId,
                    DocumentName = document.DocumentName
                };
                result = Request.CreateResponse(HttpStatusCode.OK, resultDto);
            }
            return result;
        }
    }
}