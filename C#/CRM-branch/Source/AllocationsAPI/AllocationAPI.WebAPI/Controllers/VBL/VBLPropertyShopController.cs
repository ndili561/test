using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class VBLPropertyShopController : BaseController
    {
        private IVBLPropertyShopBLL _propertyShopBLL;
      
        public VBLPropertyShopController() : this(new VBLPropertyShopBLL())
        {
        }

        public VBLPropertyShopController(IVBLPropertyShopBLL propertyShopBLL)
        {
            _propertyShopBLL = propertyShopBLL;
        }
        //get
        [HttpGet]
        [Route("VBLPropertyShop")]
        public HttpResponseMessage GetPropertyShop(string propertyCode)
        {
            var propertyShop = _propertyShopBLL.GetVBLPropertyShop(propertyCode);
            var result = propertyShop == null ? Request.CreateResponse(HttpStatusCode.PreconditionFailed) : Request.CreateResponse(HttpStatusCode.Found, propertyShop);
            return result;
        }


    }
}