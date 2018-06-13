using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Incomm.Allocations.DTO
{
    public class SearchContactDto 
    {
        [Key]
        public int ContactId { get; set; }
        public Guid? GlobalIdentityKey { get; set; }

        [Display(Name = "Status")]
        public string ApplicationStatus { get; set; }
        [Display(Name = "Application Id")]
        public int ApplicationId { get; set; }
        [Display(Name = "First Name")]
        public string Forename { get; set; }
        [Display(Name = "Last Name")]
        public string Surname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        [Display(Name = "Role")]
        public string ContactTypeName { get; set; }

        public string CssClassForContactType
        {
            get
            {
                if (ContactTypeName?.ToLower() == "applicant")
                {
                    return "mint";
                }
                return "default";
            }
        }
        public string CssClassForStatus
        {
            get
            {
                if (ApplicationStatus == null)
                {
                    return "default";
                }
                switch (ApplicationStatus.ToLower())
                {
                    case "open":
                        return "mint";
                    case "expired":
                        return "dark";
                    case "rehoused":
                        return "dark";
                    case "incomplete":
                        return "warning";
                    case "manual":
                        return "dark";
                    default:
                        return "dark";
                }
            }
        }
        public MvcHtmlString AddressHtml { get { return ToHtmlString(); } }

        public MvcHtmlString ToHtmlString()
        {
            const string linebreak = "<br/>";
            var sb = new StringBuilder();
            if (Address == null) return new MvcHtmlString(sb.ToString());
            var address = Address.Split(new[] { "  " }, StringSplitOptions.None);
            if (!string.IsNullOrWhiteSpace(address[0]))
            {
                sb.Append(address[0]).Append(linebreak);
            }
            if (address.Length > 1 && !string.IsNullOrWhiteSpace(address[1]))
            {
                sb.Append(address[1]).Append(linebreak);
            }
            if (address.Length > 2 && !string.IsNullOrWhiteSpace(address[2]))
            {
                sb.Append(address[2]).Append(linebreak);
            }
            if (address.Length > 3 && !string.IsNullOrWhiteSpace(address[3]))
            {
                sb.Append(address[3]).Append(linebreak);
            }
            if (address.Length > 4 && !string.IsNullOrWhiteSpace(address[4]))
            {
                sb.Append(address[4]).Append(linebreak);
            }
            return new MvcHtmlString(sb.ToString());
        }
        public string Gender { get; set; }
        public string Ethinicity { get; set; }
        public string Language { get; set; }
        public string Nationality { get; set; }
        public string Title { get; set; }
        public string NationalInsuranceNumber { get; set; }
    }
}