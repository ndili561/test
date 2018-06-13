using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class CaseNoteController : BaseController
    {
        private ICaseNoteBLL _caseNoteBLL;


        public CaseNoteController() : this(new CaseNoteBLL())
        {
        }

        public CaseNoteController(ICaseNoteBLL caseNoteBLL)
        {
            _caseNoteBLL = caseNoteBLL;
        }

        [HttpPost]
        [Route("CaseNote")]
        public HttpResponseMessage PostCaseNote(tblCaseNoteDTO item)
        {
            item = _caseNoteBLL.PostCaseNote(item);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }
        [HttpGet]
        [Route("CaseNote/GetEndOfServiceNotes")]
        public PageResult<tblCaseNoteDTO> GetEndOfServiceNotes(ODataQueryOptions<tblCaseNote> options)
        {
          var  notes = _caseNoteBLL.GetEndOfServiceNotes(options);
            return new PageResult<tblCaseNoteDTO>(
                notes,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }
    }
}