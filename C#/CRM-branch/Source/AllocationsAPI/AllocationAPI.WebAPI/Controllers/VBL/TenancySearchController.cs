using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AllocationsAPI.WebAPI.Controllers.HRS;
using AutoMapper;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class TenancySearchController : BaseController
    {
        public TenancySearchController() : this(new UnitOfWork())
        {
        }


        public TenancySearchController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }

        [HttpGet]
        [Route("TenancySearch/Get")]
        public PageResult<VBLTenancySearch> Get(ODataQueryOptions<VBLTenancySearch> options)
        {
            var tenancies =
                options.ApplyTo(
                    UnitOfWork.VBLTenancySearches()
                        .Select(includeProperties:"")
                        .AsQueryable());
            try
            {
                var tenanciesDto = Mapper.Map<List<VBLTenancySearch>>(tenancies);

                var result = new PageResult<VBLTenancySearch>(
                    tenanciesDto,
                    Request.ODataProperties().NextLink,
                    Request.ODataProperties().TotalCount);
                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
         
        }

    }
}