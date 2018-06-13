using Incomm.Allocations.DTO.CRM;
using System;

namespace Incomm.Allocations.BLL.Interfaces.CRM.ApiClient
{
    /// <summary>
    /// </summary>
    public interface IPersonApiClient
    {
        PersonDto PostPerson(PersonDto person);
        PersonDto PutPerson(Guid globalIdentityKey, PersonDto person);
        PersonDto GetPerson(Guid globalIdentityKey);
    }
}
