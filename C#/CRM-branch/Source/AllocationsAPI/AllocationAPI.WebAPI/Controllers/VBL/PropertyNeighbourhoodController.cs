using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class PropertyNeighbourhoodController : ApiController
    {
        private readonly IPropertyNeighbourhoodBLL _propertyNeighbourhoodBLL;

        public PropertyNeighbourhoodController() : this(new PropertyNeighbourhoodBLL())
        {
        }

        public PropertyNeighbourhoodController(IPropertyNeighbourhoodBLL propertyNeighbourhoodBLL)
        {
            _propertyNeighbourhoodBLL = propertyNeighbourhoodBLL;
        }

        [Route("PropertyNeighbourhood/GetPropertyNeighbourhoods")]
        [HttpGet]
        public PageResult<VBLPropertyNeighbourhood> GetAuditLogs(ODataQueryOptions<VBLPropertyNeighbourhood> options)
        {
            var propertyNeighbourhood = _propertyNeighbourhoodBLL.GetPropertyNeighbourhoods(options);
            var result = new PageResult<VBLPropertyNeighbourhood>(
                propertyNeighbourhood,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }
     
    }
}