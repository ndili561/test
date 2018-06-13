using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLRequestedPropertymatchDetailDTO : BaseObject
    {
        public VBLRequestedPropertymatchDetailDTO()
        {
            AdaptationDetails = new List<VBLRequestedPropertyAdaptationDetails>();
            PropertyTypes = new List<VBLRequestedPropertyPropertyType>();
            AgeRestrictions = new List<VBLRequestedPropertyAgeRestriction>();
            PropertySizes = new List<VBLRequestedPropertyPropertySize>();
            RequestedPropertyPrefferedNeighbourhoods = new List<VBLRequestedPropertyPrefferedNeighbourhood>();
            Schemes = new List<VBLRequestedPropertyScheme>();
            HeatingTypes = new List<VBLRequestedPropertyHeatingType>();
        }
        [Display(Name = "What type of property would you like to live in?")]
        public virtual List<VBLRequestedPropertyPropertyType> PropertyTypes { get; set; }
        public virtual List<VBLRequestedPropertyAgeRestriction> AgeRestrictions { get; set; }
        [Display(Name = "How many bedrooms do you require?")]
        public virtual List<VBLRequestedPropertyPropertySize> PropertySizes { get; set; }
        public virtual List<VBLRequestedPropertyPrefferedNeighbourhood> RequestedPropertyPrefferedNeighbourhoods { get; set; }
        public virtual List<VBLRequestedPropertyScheme> Schemes { get; set; }
        public virtual List<VBLRequestedPropertyHeatingType> HeatingTypes { get; set; }
        public int ApplicationId { get; set; }
        public virtual VBLApplication Application { get; set; }
        public bool IsNewVBLApplication { get; set; }
        public int AdaptationDetailsOfRequestedPropertyId { get; set; }
        
        //new questions
      
        [Display(Name = "Do you have a cat or a dog?")]
        public bool? CatOrDog { get; set; }
        [Display(Name = "Would you be willing to rehome your pet?")]
        public bool? RehousePet { get; set; }
        [Display(Name = "Would you consider a property with a communal entrance?")]
        public bool? CommunalEntrance { get; set; }
        [Display(Name = "Would you consider a property in a high-rise block of flats?")]
        public bool? HighRise { get; set; } 
        
        [Display(Name = "Do you require age restricted accomodation?")]
        public bool? AgeRestricted { get; set; }
       
        [Display(Name = "Are you able to manage steps?")]
        public bool? ManageSteps { get; set; }

        public virtual NumberOfSteps NumberOfSteps { get; set; }

        private bool? _requireAdaptation;
        [Display(Name = "Do you require adaptations?")]
        public bool? RequireAdaptations
        {
            get
            {
                return _requireAdaptation.HasValue ? _requireAdaptation.Value : AdaptationDetails == null ? false : AdaptationDetails.Count > 0;
            }
            set { _requireAdaptation = value; }
        }
        public bool? LiftServed { get; set; }
        //both
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public virtual List<VBLRequestedPropertyAdaptationDetails> AdaptationDetails { get; set; }


        public virtual List<PropertyType> AvailablePropertyTypes { get; set; }
        public List<SelectListItem> PropertyTypeSelectListItems { get; set; }
        public string[] SelectedPropertyTypes { get; set; }

        public string SelectedPropertyTypesString
        {
            get
            {
                return PropertyTypes == null || !PropertyTypes.Any()
                ? "['']"
                : "['" + string.Join("','", PropertyTypes) + "']";
            }
        }
           


        public virtual List<PropertySize> AvailablePropertySizes { get; set; }
        public List<SelectListItem> PropertySizeSelectListItems { get; set; }
        public string[] SelectedPropertySizes { get; set; }

        public string SelectedPropertySizesString
        {
            get
            {
               return PropertySizes == null || !PropertySizes.Any()
                ? "['']"
                : "['" + string.Join("','", PropertySizes) + "']";
            }
        }
          

        public virtual List<AgeRestriction> AvailableAgeRestrictions { get; set; }
        public List<SelectListItem> AgeRestrictionSelectListItems { get; set; }
        public string[] SelectedAgeRestrictions { get; set; }

        public string SelectedAgeRestrictionsString
        {
            get
            {
                return AgeRestrictions == null || !AgeRestrictions.Any()
                ? "['']"
                : "['" + string.Join("','", AgeRestrictions) + "']";
            }
        }
            

        public virtual List<Adaptation> AvailableAdaptations { get; set; }
        public List<SelectListItem> AdaptationSelectListItems { get; set; }
        public string[] SelectedAdaptations { get; set; }

        public string SelectedAdaptationsString
        {
            get
            {
                return AdaptationDetails == null || !AdaptationDetails.Any()
                ? "['']"
                : "['" + string.Join("','", AdaptationDetails) + "']";
            }
        }
            
    }
}
