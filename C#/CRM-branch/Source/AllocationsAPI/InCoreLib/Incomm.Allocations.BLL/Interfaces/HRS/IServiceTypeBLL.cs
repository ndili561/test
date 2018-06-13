using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IServiceTypeBLL
    {
        List<ServiceTypeDTO> GetServiceTypes();
        ServiceTypeDTO GetServiceType(int serviceTypeId);
        ServiceTypeDTO Create(ServiceTypeDTO serviceTypeDto);
        ServiceTypeDTO Update(ServiceTypeDTO serviceTypeDto);
    }
}