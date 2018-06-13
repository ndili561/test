using System.Collections.Generic;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IHousingGatewayBLL
    {
        List<SupportTypeDTO> GetSupportTypeSync();
        Task<List<SupportTypeDTO>> GetSupportType();
        Task<List<ServiceTypeDTO>> GetServiceType();
        List<ServiceTypeDTO> GetServiceTypeSync();
        Task<string> GetApplicationHealth();
    }
}