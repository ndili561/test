using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using InCoreLib.Domain.Allocations.Database.VBL;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLSupportDetailsDTO :BaseObjectDto
    {
        public int SupportDetailId { get; set; }
        [Display(Name = "Provider Name")]
        public string Name { get; set; }
        public int SupportTypeId { get; set; }
        [Display(Name = "Support Reason")]
        public virtual VBLSupportType SupportType { get; set; }
        public int SupportProviderId { get; set; }
        [Display(Name = "Provider Type")]
        public virtual VBLSupportProvider SupportProvider { get; set; }
        public int ContactId { get; set; }
        public VBLContact Contact { get; set; }
        [Display(Name = "Contact Details")]
        public virtual ICollection<VBLSupportContactByDetails> ContactByDetails { get; set; }
        [Display(Name = "3rd Party Authorised")]
        public bool ThirdPartyAuth { get; set; }
        public string[] SelectedContactByTypes { get; set; }
        public virtual List<ContactByDTO> ContactBys { get; set; }

        public string SelectedContactBysString
        {
            get
            {
                return ContactBys == null || !ContactBys.Any()
                  ? "['']"
                  : "['" + string.Join("','", ContactBys) + "']";
            }
        }
            

        public List<VBLSupportType> SupportTypeList { get; set; }
        public List<SelectListItem> SupportTypeSelectList { get; set; }
        public List<SelectListItem> SupportProviderSelectList { get; set; }
        public List<SelectListItem> ProviderContactBySelectList { get; set; }

        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }
}
