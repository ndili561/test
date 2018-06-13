using System;
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
    public class HRSProviderController : BaseController
    {
        private IHRSProviderBLL _hrsProviderBLL;

        public HRSProviderController() : this(new HRSProviderBLL())
        {
        }

        public HRSProviderController(IHRSProviderBLL hrsProviderBLL)
        {
            _hrsProviderBLL = hrsProviderBLL;
        }

        [HttpGet]
        [Route("HRSProvider/GetHRSProviders")]
        public PageResult<HRSProviderDTO> GetHRSProviders(ODataQueryOptions<HRSProvider> options)
        {
           var hostelDto = _hrsProviderBLL.GetHRSProviders(options);
            return new PageResult<HRSProviderDTO>(
                hostelDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }

        [HttpGet]
        [Route("HRSProvider/GetHRSProvider")]
        public HRSProviderDTO GetHRSProvider(int providerId)
        {
           return _hrsProviderBLL.GetHRSProvider(providerId);
        }

        [HttpPost]
        [Route("HRSProvider")]
        public HttpResponseMessage PostHRSProvider(HRSProviderDTO item)
        {
            item = _hrsProviderBLL.PostHRSProvider(item);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }

        [HttpPut]
        [Route("HRSProvider")]
        public HttpResponseMessage PutHRSProvider(int id, HRSProviderDTO hrsProviderDto)
        {
            var item = _hrsProviderBLL.PutHRSProvider(id,hrsProviderDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }
    }
}