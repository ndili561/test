using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Service.Api.DTOs
{
    public class VBLDocumentDTO : BaseObjectDto
    {
        [Key]
        public int DocumentId { get; set; }
        public int ApplicationId { get; set; }

        public VBLApplicationDTO Application { get; set; }

        [StringLength(250)]
        public string DocumentName { get; set; }
        public DocumentType DocumentType { get; set; }

        [StringLength(500)]
        public string DocumentPath { get; set; }

        public byte[] FileContent { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string EmailBody { get; set; }
        [Display(Name = "To")]
        public string EmailAddress
        {
            get
            {
                if (Application==null || Application.MainApplicant == null ||
                 Application.MainApplicant.ContactByDetails.All(x => x.ContactById != 4)) return string.Empty;
                return string.IsNullOrWhiteSpace(Application.MainApplicant.ContactByDetails.First(x => x.ContactById == 4).ContactValue) ? string.Empty : Application.MainApplicant.ContactByDetails.First(x => x.ContactById == 4).ContactValue;
            }
        }
        public bool CanDelete { get; set; }
        public bool CanEmail
        {
            get
            {
                return !string.IsNullOrWhiteSpace(EmailAddress);
            }
        }
        [Display(Name = "cc")]
        public string CCEmailAddress { get; set; }
        public string CompanyName { get; set; }
    }
}