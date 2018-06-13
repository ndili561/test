using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IEventBLL
    {
        IEnumerable<tsubHOAEventDTO> GetAllEvents();
        tsubHOAEventDTO GetEvent(int id);
        tsubHOAEventDTO PutEvent(int id, tsubHOAEventDTO eventDto);
        void DeleteEvent(int id);
    }
}