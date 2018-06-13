using Incomm.Allocations.DTO.CRM;
using System;

namespace Incomm.Allocations.BLL.Interfaces.CRM.ApiClient
{
    /// <summary>
    /// </summary>
    public interface IPersonAddressApiClient
    {
        PersonAddressDto PostPersonAddress(PersonAddressDto person);
        PersonAddressDto PutPersonAddress(int id, PersonAddressDto person);
    }
}
