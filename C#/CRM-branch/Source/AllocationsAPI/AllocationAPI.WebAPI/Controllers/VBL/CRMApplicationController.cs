using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
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
    public class CRMApplicationController : BaseController
    {
        private readonly IApplicationBLL _ApplicationBll;
        private readonly IContactBLL _contactBll;
        public CRMApplicationController() : this(new ApplicationBLL(), new ContactBLL())
        {
        }

        public CRMApplicationController(IApplicationBLL ApplicationBll, IContactBLL contactBll)
        {
            _ApplicationBll = ApplicationBll;
            _contactBll = contactBll;
        }

        [HttpGet]
        [Route("CrmApplications")]
        public PageResult<CRMVBLApplicationDTO> GetApplications(ODataQueryOptions<CRMVBLApplicationDTO> options)
        {
            var customerDto = _ApplicationBll.GetApplications(Mapper.Map<ODataQueryOptions<VBLApplication>>(options));
            var result = new PageResult<CRMVBLApplicationDTO>(
                Mapper.Map<List<CRMVBLApplicationDTO>>(customerDto),
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("CrmApplications/GetApplication")]
        public CRMVBLApplicationDTO GetApplication(int applicationId)
        {
            var result = _ApplicationBll.GetApplication(applicationId);
            var mappedresult = Mapper.Map<CRMVBLApplicationDTO>(result);
           
            return mappedresult;
        }


        [HttpGet]
        [Route("CrmApplications/GetBasicApplication")]
        public CRMVBLApplicationDTO GetBasicApplication(int applicationId)
        {
            var application = Mapper.Map<CRMVBLApplicationDTO>(_ApplicationBll.GetBasicApplication(applicationId));
            return application;
        }

        [HttpGet]
        [Route("CrmApplications/GetApplicationForContactPages")]
        public CRMVBLApplicationDTO GetApplicationForContactPages(int applicationId)
        {
            var application = _ApplicationBll.GetApplicationForContactPages(applicationId);
            application.Contacts = application.Contacts.Where(x => x.Active).ToList();
            return Mapper.Map<CRMVBLApplicationDTO>(application);
        }

        [HttpGet]
        [Route("CrmApplications/GetApplicationForPropertyDetailPages")]
        public CRMVBLApplicationDTO GetApplicationForPropertyDetailPages(int applicationId)
        {
            var application = _ApplicationBll.GetApplicationForPropertyDetailPages(applicationId);
            application.Contacts.Add(_contactBll.GetMainContactForApplication(application.ApplicationId));
            var result = Mapper.Map<CRMVBLApplicationDTO>(application);
            if (result.VBLRequestedPropertymatchDetail != null)
            {
                foreach (var propertyType in result.VBLRequestedPropertymatchDetail.PropertyTypes)
                {
                    propertyType.VBLRequestedPropertymatchDetail.Application = null;
                }
            }

            return result;
        }

        [HttpGet]
        [Route("CrmApplications/GetApplicationForPropertyPreferencePages")]
        public CRMVBLApplicationDTO GetApplicationForPropertyPreferencePages(int applicationId)
        {
            var application = _ApplicationBll.GetApplicationForPropertyPreferencePages(applicationId);
            application.Contacts.Add(_contactBll.GetMainContactForApplication(application.ApplicationId));
            var result = Mapper.Map<CRMVBLApplicationDTO>(application);
            if (result.VBLRequestedPropertymatchDetail != null)
            {
                foreach (var propertyType in result.VBLRequestedPropertymatchDetail.PropertyTypes)
                {
                    propertyType.VBLRequestedPropertymatchDetail.Application = null;
                }
            }

            return result;
        }

        [HttpGet]
        [Route("CrmApplications/GetApplicationForPropertyShopPages")]
        public CRMVBLApplicationDTO GetApplicationForPropertyShopPages(int applicationId)
        {
            var application = _ApplicationBll.GetApplicationForPropertyShopPages(applicationId);
            application.Contacts.Add(_contactBll.GetMainContactForApplication(application.ApplicationId));
            var result = Mapper.Map<CRMVBLApplicationDTO>(application);
            if (result.VBLRequestedPropertymatchDetail != null)
            {
                foreach (var propertyType in result.VBLRequestedPropertymatchDetail.PropertyTypes)
                {
                    propertyType.VBLRequestedPropertymatchDetail.Application = null;
                }
            }


            return result;
        }

        [HttpPut]
        [Route("CrmApplications/PutApplication")]
        public HttpResponseMessage PutApplication(int id, VBLApplication application)
        {
            HttpResponseMessage response;
            var applicationRowVersion = _ApplicationBll.GetApplicationRowVersion(id);
            if (applicationRowVersion != null)
            {
                if (application.RowVersion.ConvertByteArrayToString() != applicationRowVersion)
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, application);
                }
                application= _ApplicationBll.Update(application);
                response = Request.CreateResponse(HttpStatusCode.OK, application);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, application);
            }
            return response;
        }
        [HttpPut]
        [Route("CrmApplications/PutApplicationDate")]
        public HttpResponseMessage UpdateApplicationDate(int id, VBLApplication application)
        {
            HttpResponseMessage response;
            var applicationRowVersion = _ApplicationBll.GetApplicationRowVersion(id);
            if (applicationRowVersion != null)
            {
                if (application.RowVersion.ConvertByteArrayToString() != applicationRowVersion)
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, application);
                }
                application= _ApplicationBll.UpdateApplicationDate(application);
                response = Request.CreateResponse(HttpStatusCode.OK, application);
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
        [Route("CrmApplications/UpdateApplicationStatus")]
        public HttpResponseMessage UpdateApplicationStatus(VBLApplication customerApplication)
        {
            HttpResponseMessage response;
            var persistedApplication = Mapper.Map<VBLApplication>(_ApplicationBll.GetApplication(customerApplication.ApplicationId));
            if (persistedApplication != null)
            {
                if (customerApplication.RowVersion.ConvertByteArrayToString() != persistedApplication.RowVersion.ConvertByteArrayToString())
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, customerApplication);
                }

                bool saveSuccess = _ApplicationBll.UpdateApplicationStatus(customerApplication, persistedApplication);
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