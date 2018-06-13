using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web.Configuration;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.CRM.ApiClient;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Service.Api.DTOs;

//using pdfforge.PDFCreator.COM;

namespace Incomm.Allocations.BLL.VBL
{
    public class DocumentBLL : IDocumentBLL
    {
        private IFileHelper _fileHelper;
        private IUnitOfWork _unitOfWork;
        private IApplicationBLL _applicationBLL;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        private IPersonApiClient _personApiClient;
        public DocumentBLL() : this(new UnitOfWork(), new ApplicationBLL(), new ApplicationHistoryBLL(), new FileHelper(),new PersonApiClient())
        {
        }

        public DocumentBLL(IUnitOfWork unitOfWork, IApplicationBLL applicationBLL, IApplicationHistoryBLL applicationHistoryBLL, IFileHelper fileHelper, IPersonApiClient personApiClient)
        {
            _unitOfWork = unitOfWork;
            _applicationBLL = applicationBLL;
            _applicationHistoryBLL = applicationHistoryBLL;
            _fileHelper = fileHelper;
            _personApiClient = personApiClient;
        }

        public string UploaDocument(VBLDocumentDTO documentDto)
        {
            var returnMessage = "";
            var application = _applicationBLL.GetApplication(documentDto.ApplicationId);
            if (application != null)
            {
                
                    var response = SendDocument(documentDto);
                    var result = response.Content.ReadAsAsync<VBLDocumentDTO>().Result;
                    var changeDescription = "";
                    if (response.IsSuccessStatusCode)
                    {
                        changeDescription = $"The document {documentDto.DocumentName} has been uploaded.";
                        var document = new VBLDocument
                        {
                            ApplicationId = result.ApplicationId,
                            DocumentName = result.DocumentName,
                            DocumentType = result.DocumentType,
                            DocumentPath = result.DocumentPath,
                            CreatedDate = DateTime.Now,
                            CreatedBy = documentDto.CreatedBy,
                            ModifiedBy = documentDto.ModifiedBy,
                            UserId = documentDto.UserId,
                            UserIPAddress = documentDto.UserIPAddress
                        };
                        _unitOfWork.VBLDocuments().Insert(document);
                    }
                    else
                    {
                        changeDescription = $"The document {documentDto.DocumentName} has not been uploaded.";
                        returnMessage = "Cannot upload the document.The service is unavailable.";
                    }
                    _applicationHistoryBLL.Create(documentDto.ApplicationId, documentDto.UserId, documentDto.UserIPAddress, ApplicationActivity.DocumentUploaded, ApplicationChangeType.Documents, changeDescription);
                    _unitOfWork.Commit(documentDto.UserId, documentDto.UserIPAddress);
                
            }
            else
            {
                returnMessage = "Cannot upload the document.The application has been deleted by someone.";
            }
            return returnMessage;
        }

      

        public List<VBLDocument> GetDocuments(ODataQueryOptions<VBLDocument> options)
        {
            var documents = options.ApplyTo(_unitOfWork.VBLDocuments()
                     .Select(includeProperties: "Application.Contacts")
                     .AsQueryable());
            return Mapper.Map<List<VBLDocument>>(documents);
        }

        public VBLDocumentDTO GetDocument(int documentId)
        {
            var document = _unitOfWork.VBLDocuments().Select(includeProperties: "Application.Contacts").FirstOrDefault(x => x.DocumentId == documentId);
            var documentDto = Mapper.Map<VBLDocumentDTO>(document);
            PopulateContactByDetails(documentDto);
          
            return documentDto;
        }

        private void PopulateContactByDetails(VBLDocumentDTO document)
        {
            if (document?.Application != null)
            {
                foreach (var contact in document.Application.Contacts)
                {
                    if (contact != null)
                    {
                        var person = _personApiClient.GetPerson(contact.GlobalIdentityKey.Value);
                        foreach (var contactDetail in person.PersonContactDetails)
                        {
                            contact.ContactByDetails.Add(Mapper.Map<VBLContactByDetailsDTO>(contactDetail));
                        }
                    }
                }
            }
        }

        public HttpResponseMessage FetchEncryptedDocument(VBLDocumentDTO document)
        {
            var documentDto = new VBLDocumentDTO
            {
                DocumentPath = document.DocumentPath
            };
            var url = ConfigurationManager.AppSettings["FileManager_WebApiUrl"] +
                      "/DocumentManager/GetEncryptedDocument";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = httpClient.PostAsJsonAsync(url, documentDto).Result;

                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
        }

        public void DownloadDocument(VBLDocumentDTO document)
        {
            var changeDescription = $"Document '{document.DocumentName}' downloaded.";
            _applicationHistoryBLL.Create(document.ApplicationId, document.UserId, document.UserIPAddress, ApplicationActivity.DocumentDownloaded, ApplicationChangeType.Documents, changeDescription);
            _unitOfWork.Commit(document.UserId, document.UserIPAddress);
        }

        public void EmailDocument(VBLDocumentDTO document, string subject, string body, string ccEmailAddress)
        {
            NetworkCredential theNetworkCredential = new NetworkCredential("HOASVC", "bradford2016", "bchtgroup");
            //CredentialCache theNetCache = new CredentialCache();
            //theNetCache.Add(new Uri(@"\\svr-tstdoc"), "Basic", theNetworkCredential);
            var toEmailAddress = document.UserId;
            var fromEmailAddress = "no-reply" + document.UserId.Substring(document.UserId.IndexOf("@", StringComparison.Ordinal), document.UserId.Length - document.UserId.IndexOf("@", StringComparison.Ordinal));

            var mainApplicant =
                _unitOfWork.SearchContacts()
                    .Select(includeProperties: "Contacts")
                    .FirstOrDefault(x => x.ApplicationId == document.ApplicationId&& x.ContactTypeName=="Applicant");
            if (mainApplicant != null)
            {
                var person = _personApiClient.GetPerson(mainApplicant.GlobalIdentityKey.Value);
                toEmailAddress = person.PersonContactDetails.FirstOrDefault(x=>x.ContactByOptionId == 4)?.ContactValue;
            }
              

            //var smtpClient = new SmtpClient();
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = theNetworkCredential;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            //smtpClient.PickupDirectoryLocation = "\\svr - tstdoc\\FileAPI - Services\\EmailPickup";
            var message = new MailMessage(fromEmailAddress, toEmailAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            if (ccEmailAddress != null)
            {
                var copy = new MailAddress(ccEmailAddress);
                message.CC.Add(copy);
            }
            var documentDTO = FetchEncryptedDocument(document).Content.ReadAsAsync<VBLDocumentDTO>().Result;
            var fileContent = _fileHelper.DecryptFileContent(documentDTO.FileContent, WebConfigurationManager.AppSettings["FileEncryptionPassword"]);
            Stream stream = new MemoryStream(fileContent);
            message.Attachments.Add(new Attachment(stream, document.DocumentName));
            SendEmail(message);
            body = body.Replace("<br>", "");
            body = body.Replace("</p>", "");
            body = body.Replace("<p>", "");
            var changeDescription = $"Document '{document.DocumentName}' emailed.<br> Subject: {subject} <br> Body: {body}";
            _applicationHistoryBLL.Create(document.ApplicationId, document.UserId, document.UserIPAddress, ApplicationActivity.DocumentEmailed, ApplicationChangeType.Documents, changeDescription);
            _unitOfWork.Commit(document.UserId, document.UserIPAddress);
        }

        public void DeleteDocument(VBLDocumentDTO document)
        {

            var changeDescription = $"Document '{document.DocumentName}' deleted.";
            _applicationHistoryBLL.Create(document.ApplicationId, document.UserId, document.UserIPAddress, ApplicationActivity.DocumentDeleted, ApplicationChangeType.Documents, changeDescription);
            _unitOfWork.VBLDocuments().Delete(document.DocumentId);
            _unitOfWork.Commit(document.UserId, document.UserIPAddress);
        }

        public VBLDocument CreateApplicationDocument(VBLDocumentDTO documentDto, string encrptionPassword)
        {
           // Logger.Info("CreateApplicationDocument entered");
            string filePath = string.Empty;
            var jobQueue = new Queue();

            bool isCouncil = documentDto.UserId.Contains("@bradford.gov.uk");
           // Logger.Info("Queue Created");
            try
            {
                var docFilePath = string.Empty;
                var appication = _applicationBLL.GetApplication(documentDto.ApplicationId);
                var mainApplicant = appication.Contacts.FirstOrDefault(x=>x.ContactTypeId == 1);
                var mainContact = _unitOfWork.SearchContacts().Select()
                    .FirstOrDefault(x => x.ContactId == mainApplicant.ContactId);
                docFilePath = documentDto.DocumentType == DocumentType.NewApplication
                    ? new PdfCreator(appication, mainContact, documentDto).CreateNewApplication(isCouncil)
                    : new PdfCreator(appication, mainContact, documentDto).GenerateVBLApplication();
                // Logger.Info("File create with path " + docFilePath);

                var fileInfo = new FileInfo(docFilePath);
                var fileContent = _fileHelper.EncryptFileContent(docFilePath, encrptionPassword);

                documentDto.FileContent = fileContent;

                var response = SendDocument(documentDto);
                var result = response.Content.ReadAsAsync<VBLDocumentDTO>().Result;


                

                File.Delete(docFilePath);
               // Logger.Info("Original File deleted successfully: ");
                var changeDescription = $"Document '{fileInfo.Name}' created.";
                var document = new VBLDocument
                {
                    ApplicationId = documentDto.ApplicationId,
                    DocumentName = fileInfo.Name.Replace("_Decrypt", ""),

                    DocumentType = documentDto.DocumentType,
                    DocumentPath = result.DocumentPath,
                    CreatedDate = DateTime.Now,
                    CreatedBy = documentDto.UserId,
                    ModifiedBy = documentDto.UserId,
                    UserId = documentDto.UserId,
                    UserIPAddress = documentDto.UserIPAddress

                };
                _unitOfWork.VBLDocuments().Insert(document);
                if (changeDescription != "")
                {
                    _applicationHistoryBLL.Create(documentDto.ApplicationId, documentDto.UserId,
                        documentDto.UserIPAddress,
                        ApplicationActivity.DocumentUploaded, ApplicationChangeType.Documents, changeDescription);
                }
                _unitOfWork.Commit(documentDto.UserId, documentDto.UserIPAddress);
                return document;
            }
            catch (Exception ex)
            {
                //Logger.Info("Exception " + ex.ToString());
                //string message = string.Empty;
                //while (ex != null)
                //{
                //    message = message + Environment.NewLine + ex.Message;
                //    ex = ex.InnerException;
                //}
                //Logger.Info("Exception Message" + message);
                throw;
            }
        }

        private void SendEmail(MailMessage email)
        {
            var filename = DateTime.Now.ToFileTimeUtc() + "_" + email.To + ".eml";
            var filepath = WebConfigurationManager.AppSettings["EmailDirectory"] + "\\" +filename;
            email.Save(filepath);
        }

        private HttpResponseMessage SendDocument(VBLDocumentDTO documentDto)
        {
            var url = ConfigurationManager.AppSettings["FileManager_WebApiUrl"] +
                      "/DocumentManager/UploadDocument?encryptionTypeId=0";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = httpClient.PostAsJsonAsync(url,documentDto).Result;

                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
        }
        


        //private static string CreatePdfFileForDocument(Queue jobQueue, string docFilePath)
        //{
        //    jobQueue.Initialize();
        //   // Logger.Info("jobQueue Initialize");
        //    if (File.Exists(docFilePath))
        //    {
        //        var pdfCreator = new PdfCreatorObj();
        //        //Logger.Info("PdfCreatorObj Initialize");
        //        // var pdf = 
        //        pdfCreator.PrintFile(docFilePath);
        //       // Logger.Info("pdfCreator.PrintFile called");
        //        Type shellObj = Type.GetTypeFromProgID("Shell.Application");
        //        //Logger.Info("Type.GetTypeFromProgID(Shell.Application) called");
        //        dynamic shellInst = Activator.CreateInstance(shellObj);
        //       // Logger.Info("Activator.CreateInstance(shellObj) called");
        //        shellInst.ShellExecute("RUNDLL32.exe", "PRINTUI,PrintUIEntry /k /n \"PDFCreator\"", "", "open", 0);
        //      //  Logger.Info("  shellInst.ShellExecute called");
        //        int ctr = 0;
        //        while (jobQueue.Count == 0)
        //        {
        //           // Logger.Info("jobQueue.Count == 0");
        //            jobQueue.WaitForJob(10);
        //            ctr++;
        //            if (ctr > 5)
        //            {
        //               // Logger.Info("job failed to enter in jobQueue");
        //                return docFilePath;
        //            }
        //        }
        //        var printJob = jobQueue.NextJob;
        //       // Logger.Info("jobQueue.NextJob found");
        //        printJob.SetProfileByGuid("DefaultGuid");

        //        printJob.ConvertTo(docFilePath);
        //        if (!printJob.IsFinished || !printJob.IsSuccessful)
        //        {
        //          //  Logger.Info("Could not convert: ");
        //        }
        //        else
        //        {
        //          //  Logger.Info("Convert successfully: ");
        //            File.Delete(docFilePath);
        //          //  Logger.Info("File deleted successfully: ");
        //            docFilePath = docFilePath.Replace(".docx", ".pdf");
        //        }
        //    }
        //    else
        //    {
        //       // Logger.Info("File does not exist");
        //    }
        //    return docFilePath;
        //}
    }
}