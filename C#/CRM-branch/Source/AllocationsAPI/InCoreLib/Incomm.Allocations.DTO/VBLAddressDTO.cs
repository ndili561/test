using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLAddressDTO : BaseObject
    {
        [Key]
        public int AddressId { get; set; }
        public int? LivedAtAddressYears { get; set; }
        public int? LivedAtAddressMonths { get; set; }
        public AddressType AddressType { get; set; }
        [Display(Name = "House Name/Number")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Street")]
        public string AddressLine2 { get; set; }
        [Display(Name = "Town")]
        public string AddressLine3 { get; set; }
        [Display(Name = "Area")]
        public string AddressLine4 { get; set; }
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }
        public bool IsActive { get; set; }
        public string PropertyCode { get; set; }
        public MvcHtmlString AddressHtml { get { return ToHtmlString(); } }
        public MvcHtmlString ToHtmlString()
        {
            const string linebreak = "<br/>";
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(AddressLine1))
            {
                sb.Append(AddressLine1).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(AddressLine2))
            {
                sb.Append(AddressLine2).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(AddressLine3))
            {
                sb.Append(AddressLine3).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(AddressLine4))
            {
                sb.Append(AddressLine4).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(PostCode))
            {
                sb.Append(PostCode).Append(linebreak);
            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}
