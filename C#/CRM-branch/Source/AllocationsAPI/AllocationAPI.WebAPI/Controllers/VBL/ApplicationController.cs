using AutoMapper;
using Incomm.Allocations.BLL.CRM.ApiClient;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationBLL _applicationBll;
        private readonly IContactBLL _contactBll;
        private readonly IPersonApiClient _personApiClient;

        public ApplicationController() : this(new ApplicationBLL(),new ContactBLL(), new PersonApiClient())
        {
        }

        public ApplicationController(IApplicationBLL applicationBll, IContactBLL contactBll, IPersonApiClient personApiClient)
        {
            _applicationBll = applicationBll;
            _contactBll = contactBll;
            _personApiClient = personApiClient;
        }

        [HttpGet]
        [Route("applications")]
        public PageResult<VBLApplicationDTO> GetApplications(ODataQueryOptions<VBLApplicationDTO> options)
        {
            var customerDto = _applicationBll.GetApplications(Mapper.Map<ODataQueryOptions<VBLApplication>>(options));
            var result = new PageResult<VBLApplicationDTO>(
                Mapper.Map<IList<VBLApplicationDTO>>(customerDto),
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("applications/GetApplication")]
        public VBLApplicationDTO GetApplication(int applicationId)
        {
            var result = _applicationBll.GetApplication(applicationId);
            var mappedResult = Mapper.Map<VBLApplicationDTO>(result);

            foreach (var contact in mappedResult.Contacts)
            {
                var person = _personApiClient.GetPerson(contact.GlobalIdentityKey.Value);
                contact.TitleId = person.TitleId;
                contact.RelationshipId = person.RelationshipId;
                contact.PreferredLanguageId = person.PreferredLanguageId ?? 0;
                contact.EthnicityId = person.EthnicityId;
                contact.GenderId = person.GenderId;
                contact.ContactByDetails.AddRange(Mapper.Map<List<VBLContactByDetailsDTO>>(person.PersonContactDetails));
            }

            return mappedResult;
        }


        [HttpGet]
        [Route("applications/GetBasicApplication")]
        public VBLApplication GetBasicApplication(int applicationId)
        {
            var application = _applicationBll.GetBasicApplication(applicationId);
            return application;
        }

        [HttpGet]
        [Route("applications/GetApplicationForContactPages")]
        public VBLApplication GetApplicationForContactPages(int applicationId)
        {
            var application = _applicationBll.GetApplicationForContactPages(applicationId);
            application.Contacts = application.Contacts.Where(x => x.Active).ToList();
            return application;
        }

        [HttpGet]
        [Route("applications/GetApplicationForPropertyDetailPages")]
        public VBLApplication GetApplicationForPropertyDetailPages(int applicationId)
        {
            var application = _applicationBll.GetApplicationForPropertyDetailPages(applicationId);
            application.Contacts.Add(_contactBll.GetMainContactForApplication(application.ApplicationId));
            foreach (var propertyType in application.VBLRequestedPropertymatchDetail.PropertyTypes)
            {
                propertyType.VBLRequestedPropertymatchDetail.Application = null;
            }
            return application;
        }

        [HttpGet]
        [Route("applications/GetApplicationForPropertyPreferencePages")]
        public VBLApplication GetApplicationForPropertyPreferencePages(int applicationId)
        {
            var application = _applicationBll.GetApplicationForPropertyPreferencePages(applicationId);
            application.Contacts.Add(_contactBll.GetMainContactForApplication(application.ApplicationId));
            return application;
        }

        [HttpGet]
        [Route("applications/GetApplicationForPropertyShopPages")]
        public VBLApplication GetApplicationForPropertyShopPages(int applicationId)
        {
            var application = _applicationBll.GetApplicationForPropertyShopPages(applicationId);
            application.Contacts.Add(_contactBll.GetMainContactForApplication(application.ApplicationId));
            return application;
        }

        [HttpPut]
        [Route("applications/PutApplication")]
        public HttpResponseMessage PutApplication(int id, VBLApplication application)
        {
            HttpResponseMessage response;
            var persistedApplication = _applicationBll.GetApplication(id);
            if (persistedApplication != null)
            {
                if (application.RowVersion.ConvertByteArrayToString() != persistedApplication.RowVersion.ConvertByteArrayToString())
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, application);
                }
                _applicationBll.Update(application);
                response = Request.CreateResponse(HttpStatusCode.OK, persistedApplication);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, application);
            }
            return response;
        }
        [HttpPut]
        [Route("applications/PutApplicationDate")]
        public HttpResponseMessage UpdateApplicationDate(int id, VBLApplication application)
        {
            HttpResponseMessage response;
            var persistedApplication = _applicationBll.GetApplication(id);
            if (persistedApplication != null)
            {
                if (application.RowVersion.ConvertByteArrayToString() != persistedApplication.RowVersion.ConvertByteArrayToString())
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, application);
                }
                _applicationBll.UpdateApplicationDate(application);
                response = Request.CreateResponse(HttpStatusCode.OK, persistedApplication);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, application);
            }
            return response;
        }

        /// <summary>
        /// </summary>
        /// <param name="customerApplication"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("applications/UpdateApplicationStatus")]
        public HttpResponseMessage UpdateApplicationStatus(VBLApplicationDTO customerApplicationDTO)
        {
            HttpResponseMessage response;

            var customerApplication = Mapper.Map<VBLApplication>(customerApplicationDTO);

            var persistedApplication = _applicationBll.GetApplicationOnly(customerApplication.ApplicationId);
            if (persistedApplication != null)
            {
                if (customerApplication.RowVersion.ConvertByteArrayToString() != persistedApplication.RowVersion.ConvertByteArrayToString())
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, customerApplication);
                }

                bool saveSuccess = _applicationBll.UpdateApplicationStatus(customerApplication, persistedApplication);
                if (saveSuccess)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, persistedApplication);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed,
                        "Customer Application Status Updated Failed for customer ApplicationId:" +
                        customerApplication.ApplicationId);
                }

            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, customerApplication);
            }
            return response;
        }

    }
}