using AutoMapper;
using Incomm.Allocations.BLL.CRM.ApiClient;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;
using InCoreLib.Helpers;
using System.Collections.Generic;
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
    public class ContactController : BaseController
    {
        private IContactBLL _contactBLL;
        private readonly IPersonApiClient _personApiClient;

        public ContactController() : this(new ContactBLL(), new PersonApiClient())
        {
        }

        public ContactController(IContactBLL contactBLL, IPersonApiClient personApiClient)
        {
            _contactBLL = contactBLL;
            _personApiClient = personApiClient;
        }

        [HttpGet]
        [Route("contacts")]
        public PageResult<VBLContactDTO> GetContacts(ODataQueryOptions<VBLContact> options)
        {
            var contact = _contactBLL.GetContacts(options);
            var contactDtos = Mapper.Map<IEnumerable<VBLContactDTO>>(contact);
            foreach (var contactDto in contactDtos)
            {

                var person = _personApiClient.GetPerson(contactDto.GlobalIdentityKey.Value);
                contactDto.TitleId = person.TitleId;
                contactDto.GenderId = person.GenderId;
                contactDto.EthnicityId = person.EthnicityId;
                contactDto.RelationshipId = person.RelationshipId;
                if (contactDto.DisabilityDetails != null)
                {
                    foreach (var disabilityDetail in contactDto.DisabilityDetails)
                    {
                        disabilityDetail.Contact = null;
                    }
                }
                if (contactDto.ReceivingSupportDetails != null)
                {
                    foreach (var supportDetail in contactDto.ReceivingSupportDetails)
                    {
                        supportDetail.Contact = null;
                    }
                }
                if (contactDto.RequestedSupportDetails != null)
                {
                    foreach (var supportDetail in contactDto.RequestedSupportDetails)
                    {
                        supportDetail.Contact = null;
                    }
                }

            }
            var result = new PageResult<VBLContactDTO>(
                contactDtos,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("contacts/GetContactsForSearch")]
        public PageResult<SearchContact> GetContactsForSearch(ODataQueryOptions<SearchContact> options)
        {
            var contactDtos = _contactBLL.GetContactsForSearch(options);
            var result = new PageResult<SearchContact>(
                contactDtos,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpGet]
        [Route("contacts/GetContact")]
        public VBLContactDTO GetContact(int contactId)
        {
            var contact = _contactBLL.GetContact(contactId);

            var contactDto = Mapper.Map<VBLContactDTO>(contact);
            var person = _personApiClient.GetPerson(contactDto.GlobalIdentityKey.Value);
            if (person != null)
            {
                contactDto.TitleId = person.TitleId;
                contactDto.RelationshipId = person.RelationshipId;
                contactDto.PreferredLanguageId = person.PreferredLanguageId??0;
                contactDto.EthnicityId = person.EthnicityId;
                contactDto.GenderId = person.GenderId;
                contactDto.ContactByDetails.AddRange(Mapper.Map<List<VBLContactByDetailsDTO>>(person.PersonContactDetails));
            }
            else
            {
                contactDto.ErrorMessage = "The CRM API is not working .Please contact helpdesk.";
            }
            if (contactDto.DisabilityDetails != null)
            {
                foreach (var disabilityDetail in contactDto.DisabilityDetails)
                {
                    disabilityDetail.Contact = null;
                }
            }
            foreach (var incomeDetail in contactDto.IncomeDetails)
            {
                incomeDetail.Contact = null;
            }
            foreach (var supportDetail in contactDto.ReceivingSupportDetails)
            {
                supportDetail.Contact = null;
            }
            foreach (var supportDetail in contactDto.RequestedSupportDetails)
            {
                supportDetail.Contact = null;
            }
            return contactDto;
        }

        [HttpPost]
        [Route("contacts/GetContacts")]
        public IList<VBLContact> GetContact(IList<int> applicationIds)
        {
            var contact = _contactBLL.GetContacts(applicationIds);

            return contact;
        }

        [HttpPost]
        [Route("contacts/PostContact")]
        public HttpResponseMessage PostContact(VBLContactDTO contact)
        {
            contact = _contactBLL.Create(contact);
            var response = Request.CreateResponse(HttpStatusCode.Created, contact);
            return response;

        }

        [HttpPut]
        [Route("contacts/PutContact")]
        public HttpResponseMessage PutContact(int id, VBLContactDTO contact)
        {
            HttpResponseMessage response;
            var contactRowVersion = _contactBLL.GetContactRowVersion(id);
            if (contactRowVersion != null)
            {
                if (contact.RowVersion.ConvertByteArrayToString() != contactRowVersion)
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, contact);
                }

                contact= _contactBLL.Update(contact);

                response = Request.CreateResponse(HttpStatusCode.OK, contact);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, contact);
            }
            return response;
        }


        [HttpDelete]
        [Route("contacts/DeleteContact")]
        public void DeleteContact(int contactId, string userId, string userIPAddress)
        {
            _contactBLL.Delete(contactId, userId, userIPAddress);
        }

        [HttpGet]
        [Route("contacts/GetTransferCheck")]
        public IHttpActionResult GetTransferCheck(int contactId)
        {
            var result = _contactBLL.GetTransferCheck(contactId);

            return result != null
                ? (IHttpActionResult)Ok(Mapper.Map<TransferCheckDto>(result))
                : StatusCode(HttpStatusCode.NoContent);
            ;
        }

        [HttpPost]
        [Route("contacts/SaveTransferCheck")]
        public IHttpActionResult SaveTransferCheck(TransferCheckDto dto)
        {
            var obj = Mapper.Map<TransferCheck>(dto);
            var result = _contactBLL.SaveTransferCheck(obj);

            return result ? (IHttpActionResult)Ok() : StatusCode(HttpStatusCode.BadRequest);
            ;
        }
    }
}