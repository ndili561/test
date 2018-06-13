using Incomm.Allocations.BLL.IH;
using Incomm.Allocations.BLL.Interfaces.IH;
using Incomm.Allocations.DTO.IH.Income;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Razor.Generator;
using Incomm.Allocations.BLL.IH;
using Incomm.Allocations.BLL.Interfaces.IH;
using Incomm.Allocations.DTO.IH.Income;
using Newtonsoft.Json;

namespace AllocationsAPI.WebAPI.Controllers.IH
{
    /// <summary>
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/IH")]
    public class IncomeController : ApiController
    {
        /// <summary>
        /// </summary>
        private readonly IIncomeBLL _incomeBusinessLogic;

        /// <summary>
        /// </summary>
        public IncomeController()
        {
            _incomeBusinessLogic = new IncomeBLL();
        }

        /// <summary>
        /// </summary>
        /// <param name="incomeBusinessLogic"></param>
        public IncomeController(IIncomeBLL incomeBusinessLogic)
        {
            _incomeBusinessLogic = incomeBusinessLogic;
        }


        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Income/GetIncomeByContactId")]
        public HttpResponseMessage GetIncomeByContactId(int contactId)
        {

            var incomeDetails = _incomeBusinessLogic.GetIncomeByContactId(contactId);

            var jsonContent = JsonConvert.SerializeObject(incomeDetails);

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
        /// <param name="incomeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Income/GetIncomeByContactIdAndIncomeId")]
        public HttpResponseMessage GetIncomeByContactIdAndIncomeId(int contactId, int incomeId)
        {
            var incomeDetails = _incomeBusinessLogic.GetIncomeByContactIdAndIncomeId(contactId, incomeId);
            var jsonContent = JsonConvert.SerializeObject(incomeDetails);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            };

            return response;
        }

        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Income/SaveIncomeDetail")]
        public HttpResponseMessage SaveIncomeDetail(IncomeDetailDTO incomeDetails)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            var success = _incomeBusinessLogic.SaveIncomeDetail(incomeDetails);
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

        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Income/DeleteIncomeDetail")]
        public HttpResponseMessage DeleteIncomeDetail(IncomeDetailDTO incomeDetails)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            var success = _incomeBusinessLogic.DeleteIncomeDetail(incomeDetails);
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

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Income/GetIncomeHistoryByContactId")]
        public HttpResponseMessage GetIncomeHistoryByContactId(int contactId, int currentPageNumber, int pageSize)
        {
            var incomeDetails = _incomeBusinessLogic.GetIncomeHistoryByContactId(contactId, currentPageNumber, pageSize);

            var jsonContent = JsonConvert.SerializeObject(incomeDetails);

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
        [Route("Income/GetIncomeTypes")]
        public HttpResponseMessage GetIncomeTypes()
        {

            var incomeTypes = _incomeBusinessLogic.GetIncomeTypes();

            var jsonContent = JsonConvert.SerializeObject(incomeTypes);

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
        [Route("Income/GetIncomeFrequencies")]
        public HttpResponseMessage GetIncomeFrequencies()
        {

            var incomeFrequencies = _incomeBusinessLogic.GetIncomeFrequencies();

            var jsonContent = JsonConvert.SerializeObject(incomeFrequencies);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            };

            return response;
        }

        /// <summary>
        /// </summary>
        /// <param name="incomeDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Income/SaveIncomeDetails")]
        public HttpResponseMessage SaveIncomeDetails(List<IncomeDetailDTO> incomeDetails)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            var success = _incomeBusinessLogic.SaveIncomeDetails(incomeDetails);
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
