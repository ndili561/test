using System.Collections.Generic;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
    public class CustomerViewModel: BaseFilterModel
    {
        public CustomerViewModel()
        {
           CustomerSearchResult= new List<HRSCustomerDTO>(); 
        }
        public HRSCustomerDTO HRSCustomerDto { get { return new HRSCustomerDTO(); } }
        public HRSCustomerDTO CustomerSearchModel { get; set; }
        public List<HRSCustomerDTO> CustomerSearchResult { get; set; }
    }
}
