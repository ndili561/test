using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class ExtendStayNotesController : BaseController
    {
        private IExtendCaseNotesBLL _extendCaseNotesBLL;
        public ExtendStayNotesController() : this(new ExtendStayNotesBLL())
        {
        }

        public ExtendStayNotesController(IExtendCaseNotesBLL extendCaseNotesBLL)
        {
            _extendCaseNotesBLL = extendCaseNotesBLL;
        }
        [HttpGet]
        [Route("ExtendStayNotes/GetHRSExtendStayNotes")]
        public List<tblCaseNoteDTO> GetHRSExtendStayNotes(string CurrentUserEmail)
        {
           return _extendCaseNotesBLL.GetHRSExtendStayNotes(CurrentUserEmail);
        }
    }
}