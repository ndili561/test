using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class EventController : ApiController
    {
        private readonly IEventBLL _eventBLL;

        public EventController() : this(new EventBLL())
        {
        }

        public EventController(IEventBLL eventBLL)
        {
            _eventBLL = eventBLL;
        }
        public IEnumerable<tsubHOAEventDTO> GetAllEvents()
        {
             return _eventBLL.GetAllEvents();
        }

        [HttpGet]
        [Route("Event/GetEvent")]
        public tsubHOAEventDTO GetEvent(int id)
        {
            return _eventBLL.GetEvent(id);
        }

        [HttpPut]
        [Route("Event")]
        public HttpResponseMessage PutEvent(int id, tsubHOAEventDTO eventDto)
        {
            var hoaEventDto = _eventBLL.PutEvent(id, eventDto);
            if (hoaEventDto.CaseRef != 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, hoaEventDto);
                return response;
            }
           return Request.CreateResponse(HttpStatusCode.Conflict);
        }

        public void DeleteEvent(int id)
        {
            _eventBLL.DeleteEvent(id);
        }
    }
}