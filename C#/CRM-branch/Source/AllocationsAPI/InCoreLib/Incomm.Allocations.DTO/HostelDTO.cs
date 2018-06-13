using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HostelDTO : BaseObjectDto
    {
        public int HostelId { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int HRSProviderId { get; set; }
        [Display(Name = "Provider")]
        public string Provider { get { return HrsProvider == null ? string.Empty : HrsProvider.Code; } } 

        public HRSProviderDTO HrsProvider { get; set; }
        public List<SelectListItem> HrsProviderSelectList { get; set; }

        public bool Active { get; set; }
    }
}
