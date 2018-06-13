using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incomm.Allocations.DTO.CRM;

namespace Incomm.Allocations.BLL.Interfaces.CRM.ApiClient
{
    public interface IAddressApiClient
    {
        AddressDto PostAddress(Guid address);
        AddressDto PutAddress(int id, AddressDto address);
        AddressDto GetAddress(int id);
    }
}
