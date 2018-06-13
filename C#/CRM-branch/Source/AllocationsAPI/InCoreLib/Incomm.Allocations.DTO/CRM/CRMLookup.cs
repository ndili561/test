using System.Collections.Generic;

namespace Incomm.Allocations.DTO.CRM
{
    public class CRMLookup
    {
        public CRMLookup()
        {
            Titles= new List<TitleDto>();
            Genders = new List<GenderDto>();
            Ethnicities = new List<EthnicityDto>();
            Nationalities = new List<NationalityTypeDto>();
            Languages = new List<LanguageDto>();
        }
        
        public List<TitleDto> Titles { get; set; }
        public List<GenderDto> Genders { get; set; }
        public List<EthnicityDto> Ethnicities { get; set; }
        public List<NationalityTypeDto> Nationalities { get; set; }
        public List<LanguageDto> Languages { get; set; }
    }
}
