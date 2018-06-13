using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs.Audit;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IAuditLogBLL
    {
        List<AuditLogDto> GetAuditLog(ODataQueryOptions<AuditLog> options);
        AuditLogViewModel GetTableAndUserList();
    }
}