using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs.Audit;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Helpers;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class TenantDetailController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ITenantDetailBLL _tenantDetailBLL;
        public TenantDetailController() : this(new TenantDetailBLL())
        {
        }

        public TenantDetailController(ITenantDetailBLL tenantDetailBLL)
        {
            _tenantDetailBLL = tenantDetailBLL;
        }
        [Route("TenantDetail/GetTenantDetails")]
        public PageResult<VBLTenantDetail> GetTenantDetails(ODataQueryOptions<VBLTenantDetail> options)
        {
            var tenentDetail = _tenantDetailBLL.GetTenantDetails(options);
            var tenantDetailDto = Mapper.Map<List<VBLTenantDetail>>(tenentDetail);
            return new PageResult<VBLTenantDetail>(
                tenantDetailDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }
        [HttpPost]
        [Route("TenantDetail/PostTenantDetail")]
        public HttpResponseMessage PostTenantDetail(VBLTenantDetail tenantDetail)
        {
            tenantDetail = _tenantDetailBLL.Create(tenantDetail);
            var response = Request.CreateResponse(HttpStatusCode.Created, tenantDetail);
            return response;

        }

        [HttpPut]
        [Route("TenantDetail/PutTenantDetail")]
        public HttpResponseMessage PutTenantDetail(int id, VBLTenantDetail tenantDetail)
        {
            HttpResponseMessage response;
            var persistedTenantDetail = _tenantDetailBLL.GeTenantDetail(id);
            if (persistedTenantDetail != null)
            {
                if (tenantDetail.RowVersion.ConvertByteArrayToString() !=
                 persistedTenantDetail.RowVersion.ConvertByteArrayToString())
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, tenantDetail);
                }
                _tenantDetailBLL.Update(tenantDetail, persistedTenantDetail);
                response = Request.CreateResponse(HttpStatusCode.OK, persistedTenantDetail);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, tenantDetail);
            }
            return response;
        }


        [HttpDelete]
        [Route("TenantDetail/DeleteTenantDetail")]
        public void DeleteTenantDetail(int tenantDetailId, string userId, string userIPAddress)
        {
            _tenantDetailBLL.Delete(tenantDetailId, userId, userIPAddress);
        }
    }
}