using System.Collections.Generic;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSProviderViewModel : BaseFilterModel
    {
        public HRSProviderViewModel()
        {
            HRSProviderSearchResult = new List<HRSProviderDTO>();
        }

        public HRSProviderDTO HRSProviderDto
        {
            get
            {
                return new HRSProviderDTO();
            }
        } 
        public HRSProviderDTO HRSProviderSearchModel { get; set; }
        public List<HRSProviderDTO> HRSProviderSearchResult { get; set; }
    }
}
