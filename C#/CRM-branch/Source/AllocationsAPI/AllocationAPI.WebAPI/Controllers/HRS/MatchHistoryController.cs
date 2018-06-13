using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class MatchHistoryController : BaseController
    {
        public IMatchHistoryBLL _matchHistory;

        public MatchHistoryController() : this(new MatchHistoryBLL())
        {
        }

        public MatchHistoryController(IMatchHistoryBLL matchHistory)
        {
            _matchHistory = matchHistory;

        }

        [HttpGet]
        [Route("MatchHistory/HRSMatch")]
        public HRSMatchHistoryDTO HRSMatch(int matchId, bool returnSingle)
        {
          return  _matchHistory.HRSMatch(matchId,returnSingle);
        }

        [HttpGet]
        [Route("MatchHistory/GetAcceptedHRSMatch")]
        public HRSMatchHistoryDTO GetAcceptedHRSMatch(int customerId, bool returnSingle, int placementId)
        {
           return _matchHistory.GetAcceptedHRSMatch(customerId, returnSingle, placementId);
        }

        [HttpGet]
        [Route("MatchHistory/GetMatchHistoryForCustomer")]
        public List<HRSMatchHistoryDTO> GetMatchHistoryForCustomer(int hrsCustomerId)
        {
          return  _matchHistory.GetMatchHistoryForCustomer(hrsCustomerId);
        }

        [HttpGet]
        [Route("MatchHistory/GetAllMatchHistory")]
        public List<HRSMatchHistoryDTO> GetAllMatchHistory()
        {
           return _matchHistory.GetAllMatchHistory();
        }
        
        [HttpPut]
        [Route("MatchHistory/ReconsiderPreviousMatch")]
        public HttpResponseMessage ReconsiderPreviousMatch(int matchId, HRSPlacementMatchedForCustomerDTO match)
        {
           var item = _matchHistory.ReconsiderPreviousMatch(matchId, match);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
         
            return response;
        }




    }
}