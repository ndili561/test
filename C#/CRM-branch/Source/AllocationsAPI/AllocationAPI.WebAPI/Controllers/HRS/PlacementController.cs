using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using System.Web.UI;
using AutoMapper;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class PlacementController : BaseController
    {
        private IPlacementBLL _placementBLL;

        public PlacementController() : this(new PlacementBLL())
        {
        }

        public PlacementController(IPlacementBLL placementBLL)
        {

            _placementBLL = placementBLL;
        }
        

        [HttpGet]
        [Route("Placement/GetPlacements")]
        public PageResult<HRSPlacementDTO> GetPlacements(ODataQueryOptions<HRSPlacement> options)
        {


            var placementDto = _placementBLL.GetPlacements(options);
            
            var result = new PageResult<HRSPlacementDTO>(
                placementDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("Placement/GetPlacement")]
        public HRSPlacementDTO Placement(int HRSPlacementId)
        {
           return _placementBLL.GetPlacement(HRSPlacementId);
        }

        [HttpPost]
        [Route("Placement/PostHRSPlacement")]
        public HttpResponseMessage PostHRSPlacement(HRSPlacementDTO item)
        {
            item = _placementBLL.PostHRSPlacement(item);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }
        [HttpPut]
        [Route("Placement")]
        public HttpResponseMessage PutPlacement(int id, HRSPlacementDTO placement)
        {
            var item =  _placementBLL.PutPlacement(id, placement);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
           
            return response;
        }
        [HttpDelete]
        [Route("Placement/DeletePlacement")]
        public void DeletePlacement(int id, string userId, string userIPAddress)
        {
            _placementBLL.DeletePlacement(id, userId , userIPAddress);
        }
    }
}