using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.IH;
using Incomm.Allocations.BLL.Interfaces.IH;
using Incomm.Allocations.DTO.IH.Expenditure;
using Newtonsoft.Json;

namespace AllocationsAPI.WebAPI.Controllers.IH
{
    /// <summary>
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/IH")]
    public class ExpenditureController : ApiController
    {
        /// <summary>
        /// </summary>
        private readonly IExpenditureBLL _expenditureBusinessLogic;

        /// <summary>
        /// </summary>
        public ExpenditureController()
        {
            _expenditureBusinessLogic = new ExpenditureBLL();
        }

        /// <summary>
        /// </summary>
        /// <param name="expenditureBusinessLogic"></param>
        public ExpenditureController(IExpenditureBLL expenditureBusinessLogic)
        {
            _expenditureBusinessLogic = expenditureBusinessLogic;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Expenditure/GetExpenditureByContactId")]
        public HttpResponseMessage GetExpenditureByContactId(int contactId)
        {

            var expenditure = _expenditureBusinessLogic.GetExpenditureByContactId(contactId);

            var jsonContent = JsonConvert.SerializeObject(expenditure);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            };

            return response;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Expenditure/GetExpenditureHistoryByContactId")]
        public HttpResponseMessage GetExpenditureHistoryByContactId(int contactId, int currentPageNumber, int pageSize)
        {
            var expenditure = _expenditureBusinessLogic.GetExpenditureHistoryByContactId(contactId, currentPageNumber, pageSize);

            var jsonContent = JsonConvert.SerializeObject(expenditure);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            };

            return response;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Expenditure/GetExpenditureTypes")]
        public HttpResponseMessage GetExpenditureTypes()
        {

            var expenditureTypes = _expenditureBusinessLogic.GetExpenditureTypes();

            var jsonContent = JsonConvert.SerializeObject(expenditureTypes);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            };

            return response;
        }

        /// <summary>
        /// </summary>
        /// <param name="expenditureDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Expenditure/SaveExpenditureDetails")]
        public HttpResponseMessage SaveExpenditureDetails(List<ExpenditureDetailDTO> expenditureDetails)
        {

            HttpResponseMessage responseMessage = new HttpResponseMessage();

            var success = _expenditureBusinessLogic.SaveExpenditureDetails(expenditureDetails);
            if (success)
            {
                responseMessage.StatusCode = HttpStatusCode.OK;
                responseMessage.Content = new StringContent(true.ToString());
            }
            else
            {
                responseMessage.StatusCode = HttpStatusCode.InternalServerError;
                responseMessage.Content = new StringContent("Data failed to save.");
            }

            return responseMessage;
        }
    }
}
