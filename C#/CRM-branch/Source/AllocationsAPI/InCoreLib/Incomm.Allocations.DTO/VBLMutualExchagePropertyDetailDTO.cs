using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLMutualExchagePropertyDetailDTO : BaseObject
    {
        public VBLMutualExchagePropertyDetailDTO()
        {
            AdaptationDetails = new List<VBLMutualExchangeAdaptationDetails>();
        }
        [Key]
        public int MutualExchagePropertyDetailId { get; set; }


        public string PropertyCode { get; set; }
        public string TenancyCode { get; set; }
        [Display(Name = "Property Type")]
        public int PropertyTypeId { get; set; }
        public bool PropertyIsTerminating { get; set; }
        public decimal Rent { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal OtherCharges { get; set; }
        [Display(Name = "Property Size (bedrooms)")]
        public int PropertyNumberOfBedrooms { get; set; }
        [Display(Name = "Age Restricted")]
        public int AgeCritera { get; set; }
        public List<SelectListItem> AgeRestrictionSelectListItems { get; set; }
        [Display(Name = "Heating Type")]
        public int HeatingTypeId { get; set; }
        public virtual HeatingType HeatingType { get; set; }
        public int FlatFloorLevel { get; set; }
        public bool HasStepsToAccess { get; set; }
        [Display(Name = "Number Of Steps To Access")]
        public int NumberOfStepsToAccess { get; set; }
        public bool HasGarden { get; set; }
        public bool HasLift { get; set; }
        public bool HasTrustcare { get; set; }
        public bool IsWheelChairAdapted { get; set; }
        public bool HasRampledAccess { get; set; }
        public bool IsLevelAccessProperty { get; set; }
        public bool HasStairLift { get; set; }
        public bool HasWalkInShower { get; set; }
        public bool HasStepInShower { get; set; }

        [Display(Name = "Does the property have any adaptations?")]
        private bool? _hasAdaptation;
        public bool HasAdaptations
        {
            get
            {
                return _hasAdaptation.HasValue ? _hasAdaptation.Value : AdaptationDetails == null ? false : AdaptationDetails.Count > 0;
            }
            set { _hasAdaptation = value; }
        }
        public PropertyType PropertyType { get; set; }


        public int? AgeRestrictionId { get; set; }
        public virtual AgeRestriction AgeRestriction { get; set; }

        public List<SelectListItem> PropertyTypeSelectListItems { get; set; }
        public string[] SelectedPropertyTypes { get; set; }

        public virtual int? PropertyEntranceTypeId { get; set; }
        public virtual PropertyEntranceType PropertyEntranceType { get; set; }
        public List<SelectListItem> EntranceTypeSelectListItems { get; set; }
        public string[] SelectedEntranceTypes { get; set; }

        public virtual int? PropertyBlockTypeId { get; set; }
        public virtual PropertyBlockType PropertyBlockType { get; set; }
        public List<SelectListItem> BlockTypeSelectListItems { get; set; }
        public string[] SelectedBlockTypes { get; set; }

        public int? PropertySizeId { get; set; }
        public virtual PropertySize PropertySize { get; set; }
        public List<SelectListItem> PropertySizeSelectListItems { get; set; }

        [Display(Name = "Adaptation Details")]
        public virtual ICollection<VBLMutualExchangeAdaptationDetails> AdaptationDetails { get; set; }
        public List<SelectListItem> AdaptationDetailSelectListItems { get; set; }

        [Display(Name = "Adaptation Details")]
        public string[] SelectedAdaptationDetails { get; set; }

        public string SelectedAdaptationsString
        {
            get
            {
                return AdaptationDetails == null || !AdaptationDetails.Any()
                ? "['']"
                : "['" + string.Join("','", AdaptationDetails) + "']";
            }
        }
           
        //public int ApplicationId { get; set; }
        public virtual VBLApplication Application { get; set; }
        public List<SelectListItem> HeatingTypeSelectListItems { get; set; }

    }
}
