using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.CRM;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Incomm.Allocations.BLL.DTOs
{
    public class CRMVBLContactDTO : BaseObjectDto
    {
        public CRMVBLContactDTO()
        {
            AvailableIncomeDetails = new List<VBLIncomeDetailDTO>();
        }
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "Application Id")]
        public int? ApplicationId { get; set; }

        public virtual CRMVBLApplicationDTO Application { get; set; }

        public PersonDto Person { get; set; }
        public SearchContactDto SearchContact { get; set; }

        [Display(Name = "Has NI Number?")]
        public bool HasNationalInsuranceNumber => !string.IsNullOrEmpty(Person?.NationalInsuranceNumber);

        public int ContactTypeId { get; set; }

        [Display(Name = "Role")]
        public virtual ContactType ContactType { get; set; }

        public bool MainTenantOnTenancy { get; set; }
       
        [Display(Name = "Relationship")]
        public int? RelationshipId { get; set; }
        public virtual Relationship Relationship { get; set; }


        public string TabTitle
        {
             
         get { return ContactTypeId == 1 ? string.IsNullOrWhiteSpace(Person?.Forename) ? "New Application" : Person.Forename + " " + Person?.Surname : string.IsNullOrWhiteSpace(Person?.Forename) ? "New Household Member" : Person?.Forename + " " + Person?.Surname;  }
            
        }

        public string strDateOfBirth
        {
            get
            {
                if (Person != null && Person.DateOfBirth.HasValue)
                {
                    var shortDoB = Person.DateOfBirth.ToString().Substring(0, 10);
                    return shortDoB;

                }
                return "";
            }
        }

        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Pregnant ?")]
        public bool IsPregnant { get; set; }
        [Display(Name = "Pregnancy due date")]
        public DateTime? PregnancyDueDate { get; set; }
        [Display(Name = "Have you lived in the UK for 5 years?")]
        public bool LivedInUKForFiveYears { get; set; }
        [Display(Name = "Are you subject to immigration controls?")]
        public bool ImmigrationControl { get; set; }
        [Display(Name = "Eligible for public funds?")]
        public bool PublicFunds { get; set; }

        public string TenancyReference { get; set; }
        public bool Active { get; set; }
        public bool IsMovingIn { get; set; }
        public bool RegisteredDisabled { get; set; }
        public VBLAddressDTO MainAddress
        {
            get
            {
                VBLAddressDTO mainAddress = null;
                if (Addresses != null && Addresses.Any())
                {
                    mainAddress =
                  Addresses.FirstOrDefault(a => a.AddressType == AddressType.Main)
                  ?? Addresses.FirstOrDefault(a => a.AddressType == AddressType.Contact)
                  ?? Addresses.FirstOrDefault(a => a.AddressType == AddressType.Living);
                }
                return mainAddress;
            }
        }
        public bool HasIncome { get { return (IncomeDetails != null && IncomeDetails.Any()); } }
        [Display(Name = "Preferred Language")]
        public int PreferredLanguageId { get; set; }
        [Display(Name = "Preferred Time")]
        public string PreferredContactTime { get; set; }
        [Display(Name = "Reason for having no income")]
        public string NoIncomeReason { get; set; }
        [Display(Name = "How do this impact on your housing need?")]
        public string DisabilityImpactOnHousingNeed { get; set; }
     
        public virtual PreferredLanguage Language { get; set; }

        public virtual List<VBLIncomeDetailDTO> IncomeDetails { get; set; }

        public virtual List<VBLIncomeDetailDTO> AvailableIncomeDetails { get; set; }
        public virtual List<VBLAddressDTO> Addresses { get; set; }
        public virtual ICollection<VBLReceivingSupportDetails> ReceivingSupportDetails { get; set; }
        public virtual ICollection<VBLRequestedSupportDetails> RequestedSupportDetails { get; set; }
        public virtual List<VBLSupportTypeDTO> AvailableSupport { get; set; }
        [Display(Name = "Support Required")]
        public string[] SelectedRequiredSupports { get; set; }

        public List<SelectListItem> AvailableRequiredSupportsSelectListItems { get; set; }
        public virtual List<VBLDisabilityDetails> DisabilityDetails { get; set; }
        [Display(Name = "Disability Types")]
        public string[] SelectedDisabilityTypes { get; set; }

        public List<SelectListItem> AvailableDisabilitiesSelectListItems { get; set; }

        public virtual List<VBLDisabilityTypeDTO> AvailableDisabilityTypes { get; set; }
        public virtual List<VBLIncommunitiesRelationshipTypeDTO> IncommunitiesRelationshipTypes { get; set; }
        public virtual List<VBLContactByDetailsDTO> ContactByDetails { get; set; }

        public string CssClassForContactType
        {
            get
            {
                if (ContactTypeId == 0)
                {
                    return "danger";
                }
                if (ContactTypeId == 1)
                {
                    return "mint";
                }
                if (ContactTypeId == 2)
                {
                    return "warning";
                }
                if (ContactTypeId == 3)
                {
                    return "default";
                }

                return "default";
            }
        }
        public virtual List<IncomeType> IncomeTypes { get; set; }
        public virtual List<IncomeFrequency> IncomeFrequencies { get; set; }
        public List<SelectListItem> IncomeTypeSelectList { get; set; }
        public List<SelectListItem> IncomeFrequencySelectList { get; set; }
        public List<SelectListItem> TitleSelectList { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }
        public List<SelectListItem> NationalitySelectList { get; set; }
        public List<SelectListItem> EthnicitySelectList { get; set; }
        public List<SelectListItem> LanguageSelectList { get; set; }
        public List<ContactByDTO> ContactBys { get; set; }
        public List<VBLSupportDetailsDTO> SupportDetails { get; set; }
        public SaveContact SaveContact { get; set; }

        public string SelectedDisabilityTypesString
        {
            get
            {
                return DisabilityDetails == null || !DisabilityDetails.Any()
                   ? "['']"
                   : "['" + string.Join("','", DisabilityDetails) + "']";
            }
        }


        public string SelectedRequiredSupportsString
        {
            get
            {
                return RequestedSupportDetails == null || !RequestedSupportDetails.Any()
                   ? "['']"
                   : "['" + string.Join("','", RequestedSupportDetails.Select(x=>x.SupportTypeId)) + "']";
            }
        }
               

        public string OtherSupportDetails { get; set; }
        public int[] SelectedRequiredSupportsIds { get; set; }
        public int[] SelectedDisabilitiesIds { get; set; }

        public bool CurrentSupport { get; set; }
        public bool RequiredSupport { get; set; }
        public string RowVersionBase64
        {
            get
            {
                if (RowVersion == null)
                {
                    return string.Empty;
                }
                return Convert.ToBase64String(RowVersion);
            }
        }

        public Guid? GlobalIdentityKey { get; set; }
        public bool? ClaimHousingBenefitAtNewProperty { get; set; }
        public bool? ClaimingHousingBenefitAtCurrentProperty { get; set; }
    }
}