using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class VBLCustomerInterestController : BaseController
    {
        private IVBLCustomerInterestBLL _customerInterestControllerBLL;

        public VBLCustomerInterestController() : this(new VBLCustomerInterestBLL())
        {
        }

        public VBLCustomerInterestController(IVBLCustomerInterestBLL customerInterestControllerBLL)
        {
            _customerInterestControllerBLL = customerInterestControllerBLL;
        }


        [HttpGet]
        [Route("VBLCustomerInterest/GetLatestCustomerInterest")]
        public VBLCustomerInterest GetLatestCustomerInterest(int applicationId)
        {
            return _customerInterestControllerBLL.GetLatestCustomerInterest(applicationId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="propertyCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("VBLCustomerInterest/GetCustomerInterest")]
        public VBLCustomerInterest GetCustomerInterest(int taskId, string propertyCode)
        {
            return _customerInterestControllerBLL.GetCustomerInterest(taskId, propertyCode);
        }

        [HttpPost] //Sending long list, cannot be included in URL.
        [Route("VBLCustomerInterest/GetCustomerInterests")]
        public IList<VBLCustomerInterest> GetCustomerInterests([FromBody]IList<int> propertyMatchTaskIds)
        {
            return _customerInterestControllerBLL.GetCustomerInterests(propertyMatchTaskIds);
        }

        /// <summary>
        /// </summary>
        /// <param name="customerInterest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("VBLCustomerInterest/PostCustomerInterest")]
        public HttpResponseMessage PostCustomerInterest([FromBody] VBLCustomerInterestDTO customerInterest)
        {
            var response = new HttpResponseMessage();
            if (customerInterest == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("One or more parameters passed were invalid");
                return response;
            }
            switch (customerInterest.CustomerInterestStatusId)
            {
                case 1:
                    customerInterest = _customerInterestControllerBLL.Interested(customerInterest);
                    break;
                case 2:
                    customerInterest = _customerInterestControllerBLL.NotInterested(customerInterest);
                    break;
                case 3:
                    customerInterest = _customerInterestControllerBLL.Rejected(customerInterest);
                    break;
                case 11:
                    customerInterest = _customerInterestControllerBLL.Reconsider(customerInterest);
                    break;
                case 10:
                    customerInterest = _customerInterestControllerBLL.MatchedFromWaitingList(customerInterest);
                    break;
            }
            if (customerInterest.LandlordId > 1)
            {
                _customerInterestControllerBLL.UpdateRSLPropertyStatus(customerInterest);
            }
            response =
                Request.CreateResponse(
                    string.IsNullOrWhiteSpace(customerInterest.ErrorMessage)
                        ? HttpStatusCode.OK
                        : HttpStatusCode.PreconditionFailed, customerInterest);
            return response;
        }



        [HttpPost]
        [Route("VBLCustomerInterest/PostCustomerInterestFromVoid")]
        public HttpResponseMessage PostCustomerInterestFromVoid([FromBody] VBLCustomerInterestDTO customerInterest)
        {
            var response = new HttpResponseMessage();
            if (customerInterest == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("One or more parameters passed were invalid");
                return response;
            }

            customerInterest = _customerInterestControllerBLL.UpSertVblCustomerInterest(customerInterest);
            response = Request.CreateResponse(string.IsNullOrWhiteSpace(customerInterest.ErrorMessage) ? HttpStatusCode.OK : HttpStatusCode.PreconditionFailed, customerInterest);
            return response;

        }

    }
}
