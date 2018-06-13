using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Helpers;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class SupportController : BaseController
    {
        private ISupportBLL _supportBLL;
        public SupportController() : this(new SupportBLL())
        {
        }

        public SupportController(ISupportBLL supportBLL)
        {
            _supportBLL = supportBLL;
        }

        [HttpPost]
        [Route("Support/PostSupportDetails")]
        public HttpResponseMessage PostSupportDetails(int id, VBLSupportDetailsDTO detailsDTO)
        {
            var details = _supportBLL.Create(detailsDTO);
            var response = Request.CreateResponse(HttpStatusCode.Created, details);
            return response;

        }

        [HttpPost]
        [Route("Support/PutSupportDetails")]
        public HttpResponseMessage PutSupportDetails(int contactID, VBLSupportDetailsDTO details)
        {
            HttpResponseMessage response;
            var persistedSupport = _supportBLL.GetSupport(contactID, details.SupportDetailId);
            if (persistedSupport != null && details != null)
            {
                if (details.RowVersion.ConvertByteArrayToString() != persistedSupport.RowVersion.ConvertByteArrayToString())
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, details);
                _supportBLL.UpdateSupport(details, persistedSupport);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, details);
            return response;

        }

        [HttpPut]
        [Route("Support/PutRequiredSupportDetails")]
        public HttpResponseMessage PutRequiredSupport(int contactID, VBLContact details)
        {
            HttpResponseMessage response;
            var persistedContact = _supportBLL.GetContact(contactID);
            if (persistedContact != null && details != null)
            {
                if (details.RowVersion.ConvertByteArrayToString() != persistedContact.RowVersion.ConvertByteArrayToString())
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, details);
                _supportBLL.Update(details, persistedContact);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, persistedContact);
            return response;
        }

        [HttpGet]
        [Route("Support/GetSupportDetails")]
        public VBLSupportDetailsDTO GetSupportDetails(int supportId, int contactId)
        {
            var support = _supportBLL.GetSupport(contactId, supportId);

            return support;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Support/GetSupportDetails")]
        public List<VBLSupportDetailsDTO> GetSupportDetailsByContactId(int contactId)
        {
            var support = _supportBLL.GetSupport(contactId);

            return support;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Support/GetSupportDetails")]
        public EntityPager<VBLSupportDetailsDTO> GetSupportDetailsByContactId(int contactId, int pageSize, int pageNumber)
        {
            var support = _supportBLL.GetSupport(contactId, pageSize, pageNumber);

            return support;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Support/GetRequiredSupportDetails")]
        public VBLRequiredSupportDetailDTO GetRequiredSupportDetails(int contactId)
        {
            var requiredSupport = _supportBLL.GetSupportDetails(contactId);

            return requiredSupport;
        }


        [HttpDelete]
        [Route("Support/DeleteSupportDetails")]
        public void DeleteSupportDetails(int id,string userId,string userIPAddress)
        {
            _supportBLL.Delete(id, userId, userIPAddress);

        }
        
    }
}