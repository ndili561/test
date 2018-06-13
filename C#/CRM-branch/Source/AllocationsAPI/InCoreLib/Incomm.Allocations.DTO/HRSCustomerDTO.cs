using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Domain.Enum;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSCustomerDTO : BaseObjectDto
    {
        public int HRSCustomerId { get; set; }

        [Display(Name = "Case Ref")]
        public int? HOACaseReference { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "DoB")]
        public DateTime? DoB { get; set; }

        public string DateOfBirth
        {
            get { return DoB.HasValue ? DoB.Value.ToString("d") : string.Empty; }
        }

        [Display(Name = "Officer")]
        public string GatewayOfficer { get; set; }

        public string GatewayOfficerName
        {
            get { return GatewayOfficer.GetFullName(); }
        }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Support Type")]
        public SupportType SupportType { get; set; }

        [Display(Name = "Priority")]
        public Priority Priority { get; set; }

        [Display(Name = "Minimum Bedroom Size")]
        public int MinBedroomSize { get; set; }

        public List<SelectListItem> MinBedroomSizeSelectList { get; set; }

        public List<SelectListItem> SupportTypeSelectList { get; set; }
        public List<SelectListItem> ServiceTypeSelectList { get; set; }

        [Display(Name = "Support Type")]
        public string[] SelectedSupportType { get; set; }

        public string[] SelectedSupportTypeDescription { get; set; }

        public string[] SelectedServiceTypeDescription { get; set; }

        public string SelectedSupportTypeCode { get; set; }

        [Display(Name = "Service")]
        public string[] SelectedServiceType { get; set; }

        public string SelectedServiceTypeString
        {
            get
            {
                return SelectedServiceType == null || !SelectedServiceType.Any()
                  ? "['']"
                  : "['" + string.Join("','", SelectedServiceType) + "']";
            }
        }


        public string SelectedSupportTypeString
        {
            get
            {
                return SelectedSupportType == null || !SelectedSupportType.Any()
                  ? "['']"
                  : "['" + string.Join("','", SelectedSupportType) + "']";
            }
        }


        public List<HRSPlacementMatchedForCustomerDTO> HRSPlacementsMatched { get; set; }

        [Display(Name = "Status")]
        public virtual Status Status { get; set; }

        public virtual CustomerGender Gender { get; set; }
        public bool RunMatchingAlgorithm => (Status == Status.Reconsider || Status == Status.OnWaitingList || Status == Status.PlacementMatchedByOfficer) && (SelectedServiceType != null && SelectedSupportType != null);
        public string StatusCssClass
        {
            get { return EnumExtensions.GetAttribute<DisplayClassAttribute>(Status); }
        }

        private TimeSpan span
        {
            get
            {
                return DateTime.Now.Subtract(DateAdded);
            }
        }

        public int HoursSinceDecisionOutstanding =
            int.Parse(WebConfigurationManager.AppSettings["HoursSinceDecisionOutstanding"]);

        public string CssClassForProviderAlerts
        {
            get { return span.TotalHours > HoursSinceDecisionOutstanding ? "danger" : String.Empty; }
        }
    }
}