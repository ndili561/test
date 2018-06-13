using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class SupportTypeController : ApiController
    {
        private readonly ISupportTypeBLL _supportTypeBLL;
        public SupportTypeController() : this(new SupportTypeBLL())
        {
        }

        public SupportTypeController(ISupportTypeBLL supportTypeBLL)
        {
            _supportTypeBLL = supportTypeBLL;
        }

        [HttpGet]
        [Route("SupportType/SupportTypeList")]
        public List<SupportTypeDTO> SupportTypeList()
        {
           return _supportTypeBLL.GetSupportTypes();
        }

        [HttpGet]
        [Route("SupportType/SupportType")]
        public SupportTypeDTO SupportType(int supportTypeId)
        {
            return _supportTypeBLL.GetSupportType(supportTypeId); ;
        }

        [HttpPost]
        [Route("SupportType")]
        public HttpResponseMessage PostSupportType(SupportTypeDTO supportTypeDTO)
        {
            supportTypeDTO = _supportTypeBLL.Create(supportTypeDTO);
            var response = Request.CreateResponse(HttpStatusCode.Created, supportTypeDTO);
            return response;
        }


        [HttpPut]
        [Route("SupportType")]
        public HttpResponseMessage PutSupportType(int id, SupportTypeDTO supportTypeDTO)
        {
            supportTypeDTO = _supportTypeBLL.Update(supportTypeDTO);
            var response = Request.CreateResponse(HttpStatusCode.Created, supportTypeDTO);
       
            return response;
        }
    }
}