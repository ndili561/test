using System.Collections.Generic;
using System.Web.Http.OData.Query;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IAuditLogBLL
    {
        List<string> GetVBLUserNameList();
        List<string> GetVBLTableNameList();
        List<AuditLog> GetAuditLogs(ODataQueryOptions<AuditLog> options);
    }
}