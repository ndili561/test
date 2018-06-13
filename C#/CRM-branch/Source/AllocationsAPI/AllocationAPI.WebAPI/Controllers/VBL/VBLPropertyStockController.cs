using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class VBLPropertyStockController : BaseController
    {
        private readonly IVBLPropertyStockBLL _propertyStockBll;
        public VBLPropertyStockController() : this(new VBLPropertyStockBLL())
        {
        }

        public VBLPropertyStockController(IVBLPropertyStockBLL propertyStockBll)
        {
            _propertyStockBll = propertyStockBll;
        }
        [HttpGet]
        [Route("VBLPropertyStock/GetPropertyStock")]
        public PageResult<VBLPropertyStockDTO> Get(ODataQueryOptions<VBLPropertyStockDTO> options)
        {
            var stringSeparators = new string[] { "eq" };
            List<VBLPropertyStockDTO> outputresult = new List<VBLPropertyStockDTO>() ;
            var filterQuery = options.Filter.RawValue.Split(stringSeparators, StringSplitOptions.None);
            var applicationId = 0;
            int.TryParse(filterQuery[1], out applicationId);
            var propertyStock = _propertyStockBll.GetPropertyStock(applicationId);
            if (options.OrderBy != null && options.Skip !=null && options.Top != null)
            {
                outputresult = propertyStock.OrderBy(x => options.OrderBy).Skip(options.Skip.Value).Take(options.Top.Value).ToList();
            }
            else
            {
                outputresult = propertyStock.ToList();
            }
            var result = new PageResult<VBLPropertyStockDTO>(
             outputresult,
             Request.ODataProperties().NextLink,
             propertyStock.Count);
            return result;
        }
        [HttpGet]
        [Route("VBLPropertyStock/GetWhatAreMyChances")]
        public PageResult<VBLWhatAreMyChancesDTO> GetWhatAreMyChances(ODataQueryOptions<VBLWhatAreMyChancesDTO> options)
        {
            var stringSeparators = new string[] { "eq" };
            var filterQuery = options.Filter.RawValue.Split(stringSeparators, StringSplitOptions.None);
            var applicationId = 0;
            int.TryParse(filterQuery[1], out applicationId);

            var whatAreMyChances = _propertyStockBll.GetWhatAreMyChances(applicationId).AsQueryable();
            var outputresult = options.ApplyTo(whatAreMyChances);
            var applicationDto = Mapper.Map<List<VBLWhatAreMyChancesDTO>>(outputresult);
            var result = new PageResult<VBLWhatAreMyChancesDTO>(
              applicationDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }
    }
}
