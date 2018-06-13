using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Enumerations;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Incomm.Allocations.BLL.VBL
{
    public class SmsBLL : ISmsBLL
    {

        private IUnitOfWork _unitOfWork;
        private IApplicationBLL _applicationBLL;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public SmsBLL() : this(new UnitOfWork(), new ApplicationBLL(), new ApplicationHistoryBLL())
        {
        }

        public SmsBLL(IUnitOfWork unitOfWork, IApplicationBLL applicationBLL, IApplicationHistoryBLL applicationHistoryBLL)
        {
            _unitOfWork = unitOfWork;
            _applicationBLL = applicationBLL;
            _applicationHistoryBLL = applicationHistoryBLL;
        }

        public bool SendSMS(VBLContactDTO contactDto, string number, string message, string userId)
        {
            if (contactDto.ApplicationId != null)
            {
                number = Regex.Replace(number, @"\s+", "");
                string filename = DateTime.Now.Ticks + number;
                string path = "\\" + filename;
                string account = "VBL";

                var response = writeSMSFile(path, number, message, account, userId);
                var changeDescription = "";
                bool messageCreated;
                if (response.IsSuccessStatusCode)
                {
                    changeDescription = $"SMS sent to {number} with message '{message}'.";
                    messageCreated = true;

                }
                else
                {
                    changeDescription = $"SMS FAILED to send to {number} with message '{message}'.Error: " +
                                        response.StatusCode;
                    messageCreated = false;
                }
                _applicationHistoryBLL.Create((int)contactDto.ApplicationId, contactDto.UserId,
                        contactDto.UserIPAddress, ApplicationActivity.SMSSent, ApplicationChangeType.SMS,
                        changeDescription);
                _unitOfWork.Commit();
                return messageCreated;
            }
            return false;
        }

        public HttpResponseMessage Status()
        {
            var url = ConfigurationManager.AppSettings["SMS_WebAPiUrl"] + "/Status";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    var response = httpClient.GetAsync(url).Result;
                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
        }


        static HttpResponseMessage writeSMSFile(string path, string number, string message, string account, string userId)
        {
            var url = ConfigurationManager.AppSettings["SMS_WebApiUrl"] + "/SMSMessage/UploadSMS?path=" + path + "&number=" + number + "&message=" + message + "&account=" + account + "&userId=" + userId;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = httpClient.GetAsync(url).Result;
                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }

        }
    }
    
}
