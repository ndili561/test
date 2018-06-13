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
    public class ServiceTypeController :ApiController
    {
        private readonly IServiceTypeBLL _serviceTypeBLL;
        public ServiceTypeController() : this(new ServiceTypeBLL())
        {
        }

        public ServiceTypeController(IServiceTypeBLL serviceTypeBLL)
        {
            _serviceTypeBLL = serviceTypeBLL;
        }
      
        [HttpGet]
        [Route("ServiceType/ServiceTypeList")]
        public List<ServiceTypeDTO> ServiceTypeList()
        {
            return _serviceTypeBLL.GetServiceTypes();
        }

        [HttpGet]
        [Route("ServiceType/ServiceType")]
        public ServiceTypeDTO ServiceType(int serviceTypeId)
        {
            return _serviceTypeBLL.GetServiceType(serviceTypeId);
        }

        [HttpPost]
        [Route("ServiceType")]
        public HttpResponseMessage PostServiceType(ServiceTypeDTO serviceTypeDto)
        {
            serviceTypeDto = _serviceTypeBLL.Create(serviceTypeDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, serviceTypeDto);
            return response;
        }


        [HttpPut]
        [Route("ServiceType")]
        public HttpResponseMessage PutServiceType(int id, ServiceTypeDTO serviceTypeDto)
        {
            serviceTypeDto = _serviceTypeBLL.Update(serviceTypeDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, serviceTypeDto);
           
            return response;
        }
    }
}