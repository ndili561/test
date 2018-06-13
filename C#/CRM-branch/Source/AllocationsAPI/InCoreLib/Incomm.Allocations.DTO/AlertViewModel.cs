using System.Collections.Generic;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
    public class AlertViewModel : BaseFilterModel
    {
        public AlertViewModel()
        {
            AlertDtoList = new List<AlertDTO>();
            HRSPlacementMatchedForCustomerList= new List<HRSPlacementMatchedForCustomerDTO>();
        }
        public Status FilterStatus { get; set; }
        public string ProviderCode { get; set; }
        public AlertDTO AlertDto {get { return new AlertDTO(); }}
    
        public List<AlertDTO> AlertDtoList { get; set; }
        public HRSCustomerDTO HRSCustomerDto { get { return new HRSCustomerDTO(); } }
        public List<HRSCustomerDTO> HRSCustomerDtoList { get; set; }

        public List<HRSPlacementMatchedForCustomerDTO> HRSPlacementMatchedForCustomerList { get; set; }
    }
}
