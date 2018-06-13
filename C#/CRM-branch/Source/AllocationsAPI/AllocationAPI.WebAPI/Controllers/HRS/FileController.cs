using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using InCoreLib.DAL;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class FileController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FileController() : this(new UnitOfWork())
        {
        }

        public FileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("File/Download")]
        public HttpResponseMessage Download(int caseRef)
        {
            HttpResponseMessage result = null;
            var localFilePath = WebConfigurationManager.AppSettings["FilePath"] + "\\" + caseRef + "\\";
            var directotyInfo = new DirectoryInfo(localFilePath);
            try
            {
                var fileInfo = directotyInfo.GetFiles();
                if (!fileInfo.Any())
                {
                    result = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {
                    var file = fileInfo.Where(x=> x.Name.Contains("InitialInterview")).OrderByDescending(x => x.LastWriteTimeUtc).FirstOrDefault();
                    // Serve the file to the client
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new StreamContent(new FileStream(file.FullName, FileMode.Open, FileAccess.Read));
                    result.Content.Headers.ContentDisposition =
                        new ContentDispositionHeaderValue("attachment") {FileName = file.Name};
                }

                return result;
            }
            catch (Exception ex)
            {
                // LogErrorMessage(ex);
                throw;
            }
        }
    }
}