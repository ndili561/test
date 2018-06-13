using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs.Audit;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class AuditController : ApiController
    {
        private readonly IAuditLogBLL _auditLogBLL;

        public AuditController() : this(new AuditLogBLL())
        {
        }

        public AuditController(IAuditLogBLL auditLogBll)
        {
            _auditLogBLL = auditLogBll;
        }
        [Route("Audit/GetAuditDetails")]
        public PageResult<AuditLog> GetAuditLogs(ODataQueryOptions<AuditLog> options)
        {
            var auditLog = _auditLogBLL.GetAuditLogs(options);
            var result = new PageResult<AuditLog>(
                auditLog,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
            return result;
        }
        [Route("Audit/GetTablesAndUsers")]
        public AuditLogViewModel GetTableAndUserList()
        {
            var userNameList = _auditLogBLL.GetVBLUserNameList();
            var tableNameList = _auditLogBLL.GetVBLTableNameList();
            var auditLogViewModel = new AuditLogViewModel();
            auditLogViewModel.UserNameList = new List<string>();
            auditLogViewModel.TableNameList = new List<string>();
            auditLogViewModel.UserNameList.AddRange(userNameList);
            auditLogViewModel.TableNameList.AddRange(tableNameList);
            return auditLogViewModel;
        }
    }
}