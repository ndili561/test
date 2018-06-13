
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Incomm.Allocations.BLL.DTOs
{
    public class CRMVBLApplicationDTO : BaseObjectDto
    {
        public CRMVBLApplicationDTO()
        {
            SearchPropertyList = new List<SearchPropertyDTO>();
        }
        [Display(Name = "Application Id")]
        public int ApplicationId { get; set; }

        public int ApplicationStatusID { get; set; }

        [Display(Name = "Status")]
        public ApplicationStatu ApplicationStatus { get; set; }

        public string ApplicationStatusReason { get; set; }
        public int? ApplicationStatusReasonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool? ApplicationEligible { get; set; }
        public DateTime? HOALevelOfNeedDate { get; set; }
        [Display(Name = "Level of need")]
        public int? ApplicationLevelOfNeedID { get; set; }
        [Display(Name = "Reason banding given")]
        public string ApplicationLevelOfNeedReason { get; set; }
        [Display(Name = "Last modified by")]
        public string AssessmentLastModifiedInfo { get; set; }
        public bool? DataProtectionIsPrinted { get; set; }
        public bool? DataProtectionIsSigned { get; set; }
        public bool? DataProtectionConsented { get; set; }
        public int? HOACaseRef { get; set; }

        [StringLength(1000)]
        public string HOAOutcome { get; set; }
        [Display(Name = "HOA contact")]
        public string HOAContact { get; set; }

        public DateTime? HOAOutcomeDate { get; set; }
        public bool? HOACaseIsOpen { get; set; }
        public bool? HOAEligabilitySet { get; set; }
        public int? HOAAppointmentActivityID { get; set; }
        public DateTime? HOAAppointmentScheduledStart { get; set; }
        public int? HOAAppointmentStatusID { get; set; }
        public bool? HOAAppointmentIsAssessor { get; set; }
        public int? VBLSatisfationActivityID { get; set; }
        public DateTime? ApplicationClosedDate { get; set; }
        public DateTime? EarliestMoveDate { get; set; }
        public DateTime? LatestMoveDate { get; set; }

        public int? ResidencyTypeId { get; set; }
        public ResidencyType ResidencyType { get; set; }

        [StringLength(255)]
        public string LandLordName { get; set; }

        [Display(Name = "What is the main reason you are wanting to move?")]
        public int? MoveReasonId { get; set; }
       
        public MoveReason MoveReason { get; set; }
      
        [Display(Name = "Tenancy Type")]
        public int? TenancyTypeId { get; set; }
        public TenancyType TenancyType { get; set; }
        public int? LandlordId { get; set; }
        public Landlord LandLord { get; set; }
        [Display(Name = "Will you be giving vacant posession of the property?")]
        public bool? LeaveVacantProperty { get; set; }
        public bool? IsSignedDeclarationUploaded { get; set; }
        public bool? MatchToMutualExchage { get; set; }
        public int? MutualExchagePropertyDetailId { get; set; }
        public virtual VBLMutualExchagePropertyDetailDTO VblMutualExchagePropertyDetail { get; set; }
        public virtual VBLRequestedPropertymatchDetailDTO VBLRequestedPropertymatchDetail { get; set; }
        public ICollection<CRMVBLContactDTO> Contacts { get; set; }
        public virtual List<VBLCustomerInterestDTO> VBLCustomerInterests { get; set; }

        public CRMVBLContactDTO MainApplicant
        {
            get { return Contacts == null ? null : Contacts.FirstOrDefault(x => x.ContactTypeId == 1); }
        }

        public string CssClassForStatus
        {
            get
            {
                if (ApplicationStatusID == 1)
                {
                    return "mint";
                }
                if (ApplicationStatusID == 2)//expired
                {
                    return "dark";//"danger";
                }
                if (ApplicationStatusID == 3)//rehoused
                {
                    return "dark";//"default";
                }
                if (ApplicationStatusID == 4)//incomplete
                {
                    return "warning";
                }
                if (ApplicationStatusID == 5)//manual
                {
                    return "dark";
                }
                return "default";
            }
        }



        public string[] SelectedResidencyTypes { get; set; }

        public List<SelectListItem> ResidencyTypesSelectListItems { get; set; }
        public string[] SelectedLandlords { get; set; }

        public List<SelectListItem> LandlordsSelectListItems { get; set; }
        public string[] SelectedTenancyTypes { get; set; }

        public List<SelectListItem> TenancyTypeSelectListItems { get; set; }
        public string[] SelectedMoveReasons { get; set; }

        public List<SelectListItem> LevelsOfNeedSelectListItems { get; set; }
        public string[] SelectedLevelsOfNeed { get; set; }

        public List<SelectListItem> MoveReasonSelectListItems { get; set; }
        [Display(Name = "Date Moved In")]
        public DateTime? DateMovedIn { get; set; }

        public int? AddressId { get; set; }
        public virtual VBLAddressDTO Address { get; set; }
        public virtual LevelOfNeed LevelOfNeeds { get; set; }
        [Display(Name = "Are you the main tenant on the rent agreement?")]
        public bool IsMainTenant { get; set; }
        public MvcHtmlString AddressHtml { get { return ToHtmlString(); } }

        public MvcHtmlString ToHtmlString()
        {
            const string linebreak = "<br/>";
            var sb = new StringBuilder();
            if (Address == null) return new MvcHtmlString(sb.ToString());
            if (!string.IsNullOrWhiteSpace(Address.AddressLine1))
            {
                sb.Append(Address.AddressLine1).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(Address.AddressLine2))
            {
                sb.Append(Address.AddressLine2).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(Address.AddressLine3))
            {
                sb.Append(Address.AddressLine3).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(Address.AddressLine4))
            {
                sb.Append(Address.AddressLine4).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(Address.PostCode))
            {
                sb.Append(Address.PostCode).Append(linebreak);
            }
            return new MvcHtmlString(sb.ToString());
        }

        public SaveApplication SaveApplication { get; set; }
        public List<SearchPropertyDTO> SearchPropertyList { get; set; }

    }
}