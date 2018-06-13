using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AllocationsAPI.WebAPI.Controllers.HRS;
using AutoMapper;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class CommonController : BaseController
    {
        public CommonController() : base(new UnitOfWork())
        {
        }

        public CommonController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        [Route("Common/GetTitles")]
        public List<Title> GetTitles()
        {
            var persistedObject = UnitOfWork.Titles().Select().OrderBy(x => x.Name);
            var titles = Mapper.Map<List<Title>>(persistedObject.ToList());
            return titles;
        }

        [HttpGet]
        [Route("Common/GetGenders")]
        public List<Gender> GetGenders()
        {
            var persistedObject = UnitOfWork.Genders().Select().OrderBy(x => x.Name);
            var genders = Mapper.Map<List<Gender>>(persistedObject.ToList());
            return genders;
        }

        [HttpGet]
        [Route("Common/GetNationalities")]
        public List<NationalityType> GetNationalities()
        {
            var persistedObject = UnitOfWork.NationalityTypes().Select().OrderBy(x => x.Name);
            var nationalities = Mapper.Map<List<NationalityType>>(persistedObject.ToList());
            return nationalities;
        }

        [HttpGet]
        [Route("Common/GetEthnicities")]
        public List<Ethnicity> GetEthnicities()
        {
            var persistedObject = UnitOfWork.Ethnicities().Select().OrderBy(x => x.Name);
            var ethnicities = Mapper.Map<List<Ethnicity>>(persistedObject.ToList());
            return ethnicities;
        }

        [HttpGet]
        [Route("Common/GetLanguages")]
        public List<PreferredLanguage> GetLanguages()
        {
            var persistedObject = UnitOfWork.PreferredLanguages().Select().OrderBy(x => x.Name);
            var languages = Mapper.Map<List<PreferredLanguage>>(persistedObject.ToList());
            return languages;
        }

        [HttpGet]
        [Route("Common/GetContactBys")]
        public List<ContactBy> GetContactBys()
        {
            var persistedObject = UnitOfWork.ContactBy().Select().OrderBy(x => x.SortOrder);
            var contactBys = Mapper.Map<List<ContactBy>>(persistedObject.ToList());
            return contactBys;
        }

        [HttpGet]
        [Route("Common/GetVBLSupportTypes")]
        public List<VBLSupportType> GetSupportTypes()
        {
            var persistedObject = UnitOfWork.VBLSupportTypes().Select().OrderBy(x => x.SortOrder);
            var contactBys = Mapper.Map<List<VBLSupportType>>(persistedObject.ToList());
            return contactBys;
        }
        
        [HttpGet]
        [Route("Common/GetVBLSupportProviders")]
        public List<VBLSupportProvider> GetVBLSupportProviders()
        {
            var persistedObject = UnitOfWork.VBLSupportProviders().Select().OrderBy(x => x.Name);
            var contactBys = Mapper.Map<List<VBLSupportProvider>>(persistedObject.ToList());
            return contactBys;
        }

        [HttpGet]
        [Route("Common/GetNotInterestedReasons")]
        public List<NotInterestedReason> GetNotInterestedReasons()
        {
            var persistedObject = UnitOfWork.NotInterestedReasons().Select().OrderBy(x => x.Name);
            var contactBys = Mapper.Map<List<NotInterestedReason>>(persistedObject.ToList());
            return contactBys;
        }

        [HttpGet]
        [Route("Common/GetApplicationCloseReasons")]
        public List<ApplicationCloseReason> GetApplicationCloseReasons()
        {
            var persistedObject = UnitOfWork.ApplicationCloseReasons().Select().OrderBy(x => x.Name);
            var contactBys = Mapper.Map<List<ApplicationCloseReason>>(persistedObject.ToList());
            return contactBys;
        }
    }
}