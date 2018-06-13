using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.DAL;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [RoutePrefix("api/HRS")]
    public class ApplicationHealthController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationHealthController() : this(new UnitOfWork())
        {
        }

        public ApplicationHealthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("ApplicationHealth/Check")]
        public HttpResponseMessage Check()
        {
            try
            {
                var genderList = _unitOfWork.Genders().Select();
                var genderDtoList = Mapper.Map<List<GenderDto>>(genderList.ToList());
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(string.Empty),
                    ReasonPhrase = "Success"
                };
            }
            catch (Exception ex)
            {
                var errors = "";
                do
                {
                    errors = errors + ex.Message;
                    ex = ex.InnerException;
                } while (ex != null);
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(errors),
                    ReasonPhrase = "Web API Exception"
                };
                return responseMessage;
            }
        }
    }
}