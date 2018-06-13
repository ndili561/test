using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.Domain.Allocations.Database;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class HRSCustomerController : BaseController
    {
        private ICustomerBLL _customerBLL;

        public HRSCustomerController() : this(new CustomerBLL())
        {
        }

        public HRSCustomerController(ICustomerBLL customerBLL)
        {
            _customerBLL = customerBLL;
        }

        [HttpGet]
        [Route("HRSCustomer/GetCustomers")]
        public PageResult<HRSCustomerDTO> GetCustomers(ODataQueryOptions<HRSCustomer> options)
        {
          var  customerDto = _customerBLL.GetHRSCustomers(options);
            var result = new PageResult<HRSCustomerDTO>(
                customerDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("HRSCustomer/GetHRSCustomer")]
        public HRSCustomerDTO HRSCustomer(int HRSCustomerId)
        {
          return  _customerBLL.GetHRSCustomer(HRSCustomerId);
        }

        [HttpGet]
        [Route("HRSCustomer/RunMatchAlgorithmAndGetHRSCustomer")]
        public HRSCustomerDTO RunMatchAlgorithmAndGetHRSCustomer(int hrsCustomerId, bool runMatchAlgorithm)
        {
            return _customerBLL.RunMatchAlgorithmAndGetHRSCustomer(hrsCustomerId , runMatchAlgorithm);
        }
        [HttpPost]
        [Route("HRSCustomer")]
        public HttpResponseMessage PostHRSCustomer(HRSCustomerDTO item)
        {
            item = _customerBLL.PostHRSCustomer(item);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }

        [HttpPut]
        [Route("HRSCustomer")]
        public HttpResponseMessage PutHRSCustomer(int id, HRSCustomerDTO hrsCustomerDto)
        {
            hrsCustomerDto = _customerBLL.UpdateCustomer(id, hrsCustomerDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, hrsCustomerDto);
            return response;
        }

        [HttpDelete]
        [Route("HRSCustomer/DeleteCustomer")]
        public void DeleteCustomer(int id)
        {
            _customerBLL.DeleteCustomer(id);
        }

        [HttpGet]
        [Route("HRSCustomer/HRSCustomerByApplicationId")]
        public HRSCustomerDTO HRSCustomerByApplicationId(int applicationId)
        {
            return _customerBLL.HRSCustomerByApplicationId(applicationId);
        }
    }
}