using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.OData.Query;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Service.Api.DTOs;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IDocumentBLL
    {
        string UploaDocument(VBLDocumentDTO documentDto);
        List<VBLDocument> GetDocuments(ODataQueryOptions<VBLDocument> options);
        VBLDocumentDTO GetDocument(int documentId);
        HttpResponseMessage FetchEncryptedDocument(VBLDocumentDTO document);
        void DownloadDocument(VBLDocumentDTO document);
        void EmailDocument(VBLDocumentDTO document, string subject, string body, string ccEmailAddress);
        void DeleteDocument(VBLDocumentDTO document);

        VBLDocument CreateApplicationDocument(VBLDocumentDTO documentDto, string encrptionPassword);
    }
}