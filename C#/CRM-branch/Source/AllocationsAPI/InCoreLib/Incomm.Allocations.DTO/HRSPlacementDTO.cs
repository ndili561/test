using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Domain.Enum;

namespace Incomm.Allocations.DTO
{
    public class HRSPlacementDTO : BaseObjectDto
    {
        public int PlacementId { get; set; }
        public bool MoveOnPlacement { get; set; }
        public virtual int? MoveOnCustomerId { get; set; }
        public virtual HRSCustomer MoveOnCustomer { get; set; }


        [Display(Name = "Provider")]
        public int HRSProviderId { get; set; }

        public HRSProviderDTO HRSProvider { get; set; }

        [Display(Name = "Worker's Name")]
        [Required]
        public string ContactName { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        public string ContactNumber { get; set; }

        [Display(Name = "Address/Reference")]
        public string Address { get; set; }

        public virtual int SupportTypeId { get; set; }
        public virtual SupportTypeDTO SupportType { get; set; }
        public virtual int? HostelId { get; set; }
        public virtual Hostel Hostel { get; set; }
        public virtual ICollection<ServiceTypeDTO> ServiceTypes { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        public List<SelectListItem> SupportTypeSelectList { get; set; }
        public List<SelectListItem> ServiceTypeSelectList { get; set; }
        public List<SelectListItem> HostelSelectList { get; set; }

        private int _serviceTypeId;

        [Display(Name = "Service Type")]
        public virtual int ServiceTypeId
        {
            get
            {
                if (_serviceTypeId == 0 && ServiceTypes != null && ServiceTypes.Any())
                {
                    _serviceTypeId = ServiceTypes.Select(x => x.ServiceTypeId).First();
                }
                return _serviceTypeId;
            }
            set { _serviceTypeId = value; }
        }

        public virtual string ServiceTypeDetails
        { get { return ServiceType == null ? string.Empty : ServiceType.Code; } }
        
        public virtual ServiceTypeDTO ServiceType { get; set; }

        [Display(Name = "Minimum Bedroom")]
        public int MinimumBedroom { get; set; }
        public List<SelectListItem> MinBedroomSizeSelectList { get; set; }

        [Display(Name = "Status")]
        public virtual PlacementStatus PlacementStatus { get; set; }

        [Display(Name = "Gender")]
        public virtual PlacementGender PlacementGender { get; set; }

        public string PlacementStatusCssClass
        {
            get { return EnumExtensions.GetAttribute<DisplayClassAttribute>(PlacementStatus); }
        }

        public List<HRSPlacementMatchedForCustomerDTO> HRSCustomersMatched { get; set; }

        public bool RunMatchingAlgorithm =>((!MoveOnPlacement) && PlacementStatus != PlacementStatus.Completed && PlacementStatus != PlacementStatus.Occupied);

        public HRSPlacementDTO()
        {
            HostelSelectList = new List<SelectListItem>();
            SupportTypeSelectList = new List<SelectListItem>();
            ServiceTypeSelectList = new List<SelectListItem>();
        }
    }
}