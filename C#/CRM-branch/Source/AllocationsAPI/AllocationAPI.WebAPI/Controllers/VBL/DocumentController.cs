using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Service.Api.DTOs;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [ElmahHandleWebApiError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/VBL")]
    public class DocumentController : ApiController
    {
        private IDocumentBLL _documentBLL;
        private IFileHelper _fileHelper;
        public DocumentController() : this(new DocumentBLL(), new FileHelper())
        {
        }

        public DocumentController(IDocumentBLL documentBLL, IFileHelper fileHelper)
        {
            _documentBLL = documentBLL;
            _fileHelper = fileHelper;
        }

        [HttpGet]
        [Route("Document/GetDocuments")]
        public PageResult<VBLDocument> GetDocuments(ODataQueryOptions<VBLDocument> options)
        {
            var documentsDto = _documentBLL.GetDocuments(options);
            var result = new PageResult<VBLDocument>(
                documentsDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }

        [HttpPost]
        [Route("Document/CreateApplicationDocument")]
        public HttpResponseMessage CreateApplicationDocument(VBLDocumentDTO documentDto)
        {
            HttpResponseMessage result;
          
                var document = _documentBLL.CreateApplicationDocument(documentDto, WebConfigurationManager.AppSettings["FileEncryptionPassword"]);
                result = Request.CreateResponse(HttpStatusCode.Created, document);
            
            return result;
        }


        [HttpGet]
        [Route("Document/GetDocument")]
        public VBLDocumentDTO GetDocument(int documentId)
        {
            return _documentBLL.GetDocument(documentId);
        }
        [HttpGet]
        [Route("Document/Download")]
        public HttpResponseMessage Download(int documentId, string userId, string userIPAddress)
        {
            HttpResponseMessage result;
            var document = _documentBLL.GetDocument(documentId);
            if (document == null)
            {
                result = Request.CreateResponse(HttpStatusCode.PreconditionFailed);
            }
            else if (_fileHelper.CheckFolderExists(document.DocumentPath))
            {
                result = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                document.UserIPAddress = userIPAddress;
                document.UserId = userId;
                _documentBLL.DownloadDocument(document);
                var documentDTO = _documentBLL.FetchEncryptedDocument(document).Content.ReadAsAsync<VBLDocumentDTO>().Result;
                if (documentDTO.FileContent == null)
                {
                    documentDTO.ErrorMessage = "The file content is NULL";
                }
                else
                {
                    var fileContent = _fileHelper.DecryptFileContent(documentDTO.FileContent, WebConfigurationManager.AppSettings["FileEncryptionPassword"]);
                    documentDTO = new VBLDocumentDTO
                    {
                        ApplicationId = document.ApplicationId,
                        DocumentId = document.DocumentId,
                        DocumentName = document.DocumentName,
                        FileContent = fileContent
                    };
                }
              
                result = Request.CreateResponse(HttpStatusCode.Created, documentDTO);
            }
            return result;
        }

        [HttpPost]
        [Route("Document/Upload")]
        public HttpResponseMessage Upload(VBLDocumentDTO documentDto)
        {
            try
            {
                HttpResponseMessage result;

                var fileContent = _fileHelper.EncryptFileContent(documentDto.FileContent, WebConfigurationManager.AppSettings["FileEncryptionPassword"]);
                documentDto.FileContent = fileContent;

                    var document = _documentBLL.UploaDocument(documentDto);
                    result = Request.CreateResponse(!string.IsNullOrEmpty(document) ? HttpStatusCode.PreconditionFailed : HttpStatusCode.OK, documentDto);
                
                return result;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("Document/Delete")]
        public HttpResponseMessage Delete(int documentId, string userId, string userIPAddress)
        {
            HttpResponseMessage result;
            var document = _documentBLL.GetDocument(documentId);
            if (document == null)
            {
                result = Request.CreateResponse(HttpStatusCode.PreconditionFailed);
            }
            else if (_fileHelper.CheckFolderExists(document.DocumentPath))
            {
                result = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                document.UserIPAddress = userIPAddress;
                document.UserId = userId;
                _documentBLL.DeleteDocument(document);
                var documentDto = new VBLDocumentDTO
                {
                    ApplicationId = document.ApplicationId,
                    DocumentName = document.DocumentName
                };
                result = Request.CreateResponse(HttpStatusCode.OK, documentDto);
            }
            return result;
        }
    }

}