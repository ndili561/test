using System.Collections.Generic;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.DTO.CRM
{
    public class Lookup
    {
        public  Lookup()
        { }
        public List<CustomerInterestStatu> CustomerInterestStatus { get; set; }
        public List<TitleDto> Titles { get; set; }
        public List<NationalityTypeDto> Nationalities { get; set; }
        public List<EthnicityDto> Ethnicities { get; set; }
        public List<GenderDto> Genders { get; set; }
        public List<LanguageDto> Languages { get; set; }
        public List<ContactBy> ContactBys { get; set; }
        public virtual List<IncomeType> IncomeTypes { get; set; }
        public virtual List<IncomeFrequency> IncomeFrequencies { get; set; }
        public virtual List<VBLDisabilityType> DisabilityTypes { get; set; }
        public virtual List<VBLSupportType> RequiredSupports { get; set; }
        public string MainApplicantName { get; set; }
        public virtual List<ResidencyType> ResidencyTypes { get; set; }
        public virtual List<Landlord> Landlords { get; set; }
        public virtual List<TenancyType> TenancyTypes { get; set; }
        public virtual List<PropertyType> PropertyTypes { get; set; }
        public virtual List<MoveReason> MoveReasons { get; set; }
        public virtual List<LevelOfNeed> LevelOfNeeds { get; set; }
        public virtual List<PropertySize> PropertySize { get; set; }
        public virtual List<PropertyEntranceType> PropertyEntrances { get; set; }
        public virtual List<PropertyBlockType> BlockTypes { get; set; }
        public virtual List<Adaptation> Adaptations { get; set; }
        public virtual List<AgeRestriction> AgeRestrictions { get; set; }
        public List<HeatingType> HeatingTypes { get; set; }
        public List<Relationship> Relationships { get; set; }
        public List<NotInterestedReason> NotInterestedReasons { get; set; }
        public List<ApplicationCloseReason> ApplicationCloseReasons { get; set; }
    }
}