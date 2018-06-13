using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IHostelBLL
    {
        List<HostelDTO> GetHostels(ODataQueryOptions<Hostel> options);
        List<HostelDTO> GetAllHostels();
        HostelDTO Hostel(int hostelId);
        HostelDTO PostHostel(HostelDTO item);
        HostelDTO PutHostel(int id, HostelDTO hostelDto);
    }
}