using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Interfaces.Common;
using Incomm.Allocations.DTO.CRM;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class LookupController : ApiController
    {
        private readonly ILookupBll _lookupBLL;

        public LookupController() : this(new LookupBLL())
        {
        }


        public LookupController(ILookupBll lookupBll)
        {
            _lookupBLL = lookupBll;
        }

        [HttpGet]
        [Route("Lookup/Get")]
        public Lookup Get(int appId)
        {
            return _lookupBLL.GetLookup(appId);
        }

        [Route("Lookup/GetSupportTypes")]
        public List<VBLSupportType> GetSupportTypes()
        {
            var supportTypes = _lookupBLL.GetSupportTypes();
            return supportTypes;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Lookup/GetSupportProviders")]
        public List<VBLSupportProvider> GetSupportProviders()
        {
            var supportProviders = _lookupBLL.GetSupportProviders();
            return supportProviders;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Lookup/GetTitles")]
        public List<Title> GetTitles()
        {
            var titles = _lookupBLL.GetTitles();
            return titles;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Lookup/GetGenders")]
        public List<Gender> GetGenders()
        {
            var genders = _lookupBLL.GetGenders();
            return genders;
        }
    }
}