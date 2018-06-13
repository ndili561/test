using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Service.Api.DTOs;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [ElmahHandleWebApiError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/VBL")]
    public class DocumentMigrationController : ApiController
    {
        private IFileHelper _fileHelper;
        private IApplicationBLL _applicationBLL;
        private IUnitOfWork _unitOfWork;
        private IApplicationHistoryBLL _applicationHistoryBll;
        public DocumentMigrationController() : this(new FileHelper(), new ApplicationBLL(), new UnitOfWork(), new ApplicationHistoryBLL())
        {
        }

        public DocumentMigrationController(IFileHelper fileHelper, IApplicationBLL applicationBLL, IUnitOfWork unitOfWork, IApplicationHistoryBLL applicationHistoryBll)
        {
            _fileHelper = fileHelper;
            _applicationBLL = applicationBLL;
            _unitOfWork = unitOfWork;
            _applicationHistoryBll = applicationHistoryBll;
        }

        [HttpPost]
        [Route("DocumentMigration/Upload")]
        public HttpResponseMessage Upload(VBLDocumentDTO documentDto)
        {
            try
            {
                HttpResponseMessage result;
                if (documentDto == null)
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else if (!_fileHelper.CheckFolderExists(documentDto.DocumentPath))
                {
                    result = Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    var uploadedFilePath = documentDto.DocumentPath + @"\Temp_" + DateTime.Now.ToFileTimeUtc() + "_" + documentDto.DocumentName;
                    File.WriteAllBytes(uploadedFilePath, documentDto.FileContent);
                    var fileContent = _fileHelper.EncryptFileContent(uploadedFilePath, WebConfigurationManager.AppSettings["FileEncryptionPassword"]);
                    var encrptedFilePath = uploadedFilePath.Replace("Temp_", "");
                    File.WriteAllBytes(encrptedFilePath, fileContent);
                    File.Delete(uploadedFilePath);
                    documentDto.DocumentPath = encrptedFilePath;
                    var document = UploaDocument(documentDto);
                    result = Request.CreateResponse(!string.IsNullOrEmpty(document) ? HttpStatusCode.PreconditionFailed : HttpStatusCode.OK, documentDto);
                }
                return result;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        public string UploaDocument(VBLDocumentDTO documentDto)
        {
            var returnMessage = "";
            var application = _applicationBLL.GetApplication(documentDto.ApplicationId);
            if (application != null)
            {
                
                    var changeDescription = $"The document {documentDto.DocumentName} has been uploaed.";
                    var document = new VBLDocument
                    {
                        ApplicationId = documentDto.ApplicationId,
                        DocumentName = documentDto.DocumentName,
                        DocumentType = documentDto.DocumentType,
                        DocumentPath = documentDto.DocumentPath,
                        CreatedDate = DateTime.Now,
                        CreatedBy = documentDto.CreatedBy,
                        ModifiedBy = documentDto.ModifiedBy,
                        UserId = documentDto.UserId,
                        UserIPAddress = documentDto.UserIPAddress
                    };
                    _unitOfWork.VBLDocuments().Insert(document);
                    _applicationHistoryBll.Create(documentDto.ApplicationId, documentDto.UserId, documentDto.UserIPAddress, ApplicationActivity.DocumentUploaded, ApplicationChangeType.Documents, changeDescription);
                    _unitOfWork.Commit(document.UserId, document.UserIPAddress);
                
            }
            else
            {
                returnMessage = "Cannot upload the document.The application has been deleted by someone.";
            }
            return returnMessage;
        }

    }
}