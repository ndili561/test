using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using Incomm.Allocations.BLL.DTOs.Audit;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;

namespace Incomm.Allocations.BLL
{
    public class AuditLogBLL :  IAuditLogBLL
    {
        private IUnitOfWork _unitOfWork;
        public AuditLogBLL() : this(new UnitOfWork())
        {
        }

        public AuditLogBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<AuditLogDto> GetAuditLog(ODataQueryOptions<AuditLog> options)
        {
            var auditLog =
                options.ApplyTo(_unitOfWork.AuditLogs().Select(includeProperties: "AuditLogDetails").AsQueryable());
         return  Mapper.Map<List<AuditLogDto>>(auditLog);
        }

        public AuditLogViewModel GetTableAndUserList()
        {
            var auditLogViewModel = new AuditLogViewModel
            {
                UserNameList = _unitOfWork.AuditLogs().Select().ToList().Select(x => x.UserName).Distinct().ToList(),
                TableNameList = _unitOfWork.AuditLogs().Select().ToList().Select(x => x.TableName).Distinct().ToList()
            };
            return auditLogViewModel;
        }
    }
}