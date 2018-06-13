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
    public class HostelController : BaseController
    {
        private IHostelBLL _hostelBLL;

        public HostelController() : this(new HostelBLL())
        {
        }

        public HostelController(IHostelBLL hostelBLL)
        {
            _hostelBLL = hostelBLL;
        }

        [HttpGet]
        [Route("Hostel/GetHostels")]
        public PageResult<HostelDTO> GetHostels(ODataQueryOptions<Hostel> options)
        {
            var hostelDto = _hostelBLL.GetHostels(options);
            return new PageResult<HostelDTO>(
                hostelDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }

        [HttpGet]
        [Route("Hostel/GetAllHostels")]
        public PageResult<HostelDTO> GetAllHostels()
        {
            var hostelDto = _hostelBLL.GetAllHostels();
            return new PageResult<HostelDTO>(
                hostelDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }

        [HttpGet]
        [Route("Hostel/GetHostel")]
        public HostelDTO Hostel(int hostelId)
        {
            return _hostelBLL.Hostel(hostelId);
        }

        [HttpPost]
        [Route("Hostel")]
        public HttpResponseMessage PostHostel(HostelDTO item)
        {
            item = _hostelBLL.PostHostel(item);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }

        [HttpPut]
        [Route("Hostel")]
        public HttpResponseMessage PutHostel(int id, HostelDTO hostelDto)
        {
            var item = _hostelBLL.PutHostel(id, hostelDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }
    }
}