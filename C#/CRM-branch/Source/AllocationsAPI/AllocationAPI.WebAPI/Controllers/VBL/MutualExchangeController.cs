using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using Incomm.Allocations.DTO;
using Newtonsoft.Json;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [ElmahHandleWebApiError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/VBL")]
    public class MutualExchangeController : ApiController
    {
        private IMutexBLL _mutexBLL;

        public MutualExchangeController() : this(new MutexBLL())
        {
            
        }

        public MutualExchangeController(IMutexBLL mutexBLL)
        {
            _mutexBLL = mutexBLL;
        }

        [HttpPost]
        [Route("MutualExchange/AcceptMutexOffer")]
        public HttpResponseMessage AcceptMutex(MutualExchangeDTO mutexNotification)
        {
            mutexNotification = _mutexBLL.AcceptMutex(mutexNotification);
            var response = Request.CreateResponse(HttpStatusCode.Created, mutexNotification);
            return response;
        }

        [HttpPost]
        [Route("MutualExchange/RefuseMutexOffer")]
        public HttpResponseMessage RefuseMutex(MutualExchangeDTO mutexNotification)
        {
            mutexNotification = _mutexBLL.RefuseMutex(mutexNotification);
            var response = Request.CreateResponse(HttpStatusCode.Created, mutexNotification);
            return response;
        }


    }
}