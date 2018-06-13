using System.Collections.Generic;
using Incomm.Allocations.DTO;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSPlacementViewModel : BaseFilterModel
    {
        public HRSPlacementViewModel()
        {
            PlacementSearchResult = new List<HRSPlacementDTO>(); 
        }
        public HRSPlacementDTO PlacementSearchModel { get; set; }
        public List<HRSPlacementDTO> PlacementSearchResult { get; set; }
    }
}
