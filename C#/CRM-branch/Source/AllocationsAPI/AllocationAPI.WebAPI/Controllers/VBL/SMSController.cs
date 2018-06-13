using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
//using com.esendex.sdk.messaging;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class SMSController : BaseController
    {

        private IContactBLL _contactBLL;
        private ISmsBLL _smsBLL;
        public SMSController() : this(new ContactBLL(), new SmsBLL())
        {
        }

        public SMSController(IContactBLL contactBLL, ISmsBLL smsBLL)
        {
            _contactBLL = contactBLL;
            _smsBLL = smsBLL;
        }

        [HttpPost]
        [Route("SMS/PostSMS")]
        public HttpResponseMessage PostSMS(int messageType, string userId, VBLContactDTO contactDto)
        {
            HttpResponseMessage result;
            var filePathExists = _smsBLL.Status();
            if (!filePathExists.IsSuccessStatusCode)
            {
                return filePathExists;
            }
            var contact = _contactBLL.GetContact(contactDto.ContactId);
            if (contact == null)
            {
                result = Request.CreateResponse(HttpStatusCode.PreconditionFailed);
            }
            else
            {
                if (contact.ContactByDetails.Any(x => x.ContactById == 3 || x.ContactById == 9))
                {
                    var contactby = contact.ContactByDetails.First(x => x.ContactById == 3 || x.ContactById == 9);
                    var message = "";
                    switch (messageType)
                    {
                        case 1:
                            message = "Your housing application has been created. Incommunities will contact you when we match you to a property.";
                            break;
                        case 2:
                            message = "You have been rejected for a property. Please contact Incommunities for further details.";
                            break;
                        case 3:
                            message = "Your application for housing has been closed. Please contact Incommunities if you need further information";
                            break;
                        case 4:
                            message = "Your application has been reopened. Incommunities will contact you when you get a property match.";
                            break;
                        default:
                            message = "Please contact Incommunities.";
                            break;
                    }
                    contactDto.UserId = userId;
                    if (_smsBLL.SendSMS(contactDto, contactby.ContactValue, message, userId))
                    {
                        result = Request.CreateResponse(HttpStatusCode.OK, contact);
                    }
                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.InternalServerError, contact);
                    }

                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.PreconditionFailed);
                }
            }
            return result;

        }

    }
}
