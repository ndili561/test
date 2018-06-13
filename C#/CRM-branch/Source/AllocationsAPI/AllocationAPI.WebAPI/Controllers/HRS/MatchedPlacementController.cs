using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.HRS;
using Incomm.Allocations.BLL.Interfaces.HRS;
using InCoreLib.Domain.Allocations.Database;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class MatchedPlacementController : ApiController
    {

        private IMatchedPlacementBLL _matchedPlacementBLL;

        public MatchedPlacementController() : this(new MatchedPlacementBLL())
        {
        }

        public MatchedPlacementController(IMatchedPlacementBLL matchedPlacementBLL)
        {
            _matchedPlacementBLL = matchedPlacementBLL;
        }


        [HttpGet]
        [Route("MatchedPlacement/GetMoveOnCustomers")]
        public PageResult<HRSPlacementMatchedForCustomerDTO> GetMoveOnCustomers(ODataQueryOptions<HRSPlacementMatchedForCustomer> options, int providerId)

        {
           var matchedPlacementDto = _matchedPlacementBLL.GetMoveOnCustomers(options,providerId);
            var result = new PageResult<HRSPlacementMatchedForCustomerDTO>(
                matchedPlacementDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("MatchedPlacement/GetMatchedPlacements")]
        public PageResult<HRSPlacementMatchedForCustomerDTO> GetMatchedPlacements(
            ODataQueryOptions<HRSPlacementMatchedForCustomer> options)
        {
          var  matchedPlacementDto = _matchedPlacementBLL.GetMatchedPlacements(options);
            var result = new PageResult<HRSPlacementMatchedForCustomerDTO>(
                matchedPlacementDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }


        [HttpGet]
        [Route("MatchedPlacement/HRSPlacementMatchedForCustomer")]
        public HRSPlacementMatchedForCustomerDTO HRSPlacementMatchedForCustomer(int matchedPlacementId)
        {
            return _matchedPlacementBLL.HRSPlacementMatchedForCustomer(matchedPlacementId);
        }

        [HttpPut]
        [Route("MatchedPlacement/PutMatchedPlacement")]
        public HttpResponseMessage PutMatchedPlacement(int id,
            HRSPlacementMatchedForCustomerDTO hrsPlacementMatchedForCustomerDto)
        {
            var item = _matchedPlacementBLL.PutMatchedPlacement(id, hrsPlacementMatchedForCustomerDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }

        [HttpPost]
        [Route("MatchedPlacement/CreateMoveOnMatch")]
        public HttpResponseMessage CreateMoveOnMatch(HRSPlacementMatchedForCustomerDTO item)
        {
            _matchedPlacementBLL.CreateMoveOnMatch(item);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }


    }
}