using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    /// <summary>
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class CustomerInterestController : ApiController
    {
        /// <summary>
        /// </summary>
        private readonly IVBLCustomerInterestBLL _customerInterestControllerBll;


        /// <summary>
        /// </summary>
        /// <param name="customerInterestControllerBll"></param>
        public CustomerInterestController(IVBLCustomerInterestBLL customerInterestControllerBll)
        {
            _customerInterestControllerBll = customerInterestControllerBll;
        }

        /// <summary>
        /// </summary>
        public CustomerInterestController()
        {
            _customerInterestControllerBll = new VBLCustomerInterestBLL();
        }


        ///// <summary>
        ///// </summary>
        ///// <param name="customerInterest"></param>
        ///// <param name="updateVoids"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("VBLCustomerInterest/PostCustomerInterest")]
        //public HttpResponseMessage PostCustomerInterest(bool updateVoids,[FromBody]VBLCustomerInterest customerInterest)
        //{

        //    HttpResponseMessage response = new HttpResponseMessage();
        //    response.StatusCode = HttpStatusCode.OK;

        //    if (customerInterest == null)
        //    {
        //        response.StatusCode = HttpStatusCode.BadRequest;
        //        response.Content     = new StringContent("One or more parameters passed were invalid");
        //        return response;
        //    }
        //    bool? result = null;
        //    if (!updateVoids)
        //    {
        //        result = _customerInterestControllerBll.UpsertCustomerInterest(customerInterest);
        //    }
        //    else
        //    {
        //        result = _customerInterestControllerBll.UpsertCustomerInterestAndVoids(customerInterest);
        //    }
        //    if (result == null || result == false)
        //    {
        //        response.StatusCode = HttpStatusCode.BadRequest;
        //        response.Content = new StringContent("Customer Interest failed to save.");
        //        return response;
        //    }

        //    return response;

        //}


    }
}
