using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs.Audit;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class AuditLogController : ApiController
    {
        
        private IAuditLogBLL _auditLogBLL;

        public AuditLogController() : this(new AuditLogBLL())
        {
        }

        public AuditLogController(IAuditLogBLL auditLogBLL)
        {
            _auditLogBLL = auditLogBLL;

        }
        [HttpGet]
        [Route("AuditLog/GetAuditLogs")]
        public PageResult<AuditLogDto> GetAuditLogs(ODataQueryOptions<AuditLog> options)
        {
         var auditLogDto = _auditLogBLL.GetAuditLog(options);
            return new PageResult<AuditLogDto>(
                auditLogDto,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }

        [HttpGet]
        [Route("AuditLog/GetTableAndUserList")]
        public AuditLogViewModel GetTableAndUserList(bool tableAndUser)
        {
           return _auditLogBLL.GetTableAndUserList();
        }
    }
}