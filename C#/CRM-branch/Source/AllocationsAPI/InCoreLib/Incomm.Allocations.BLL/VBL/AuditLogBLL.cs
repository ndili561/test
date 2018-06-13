using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;

namespace Incomm.Allocations.BLL.VBL
{
    public class AuditLogBLL : IAuditLogBLL
    {

        private IUnitOfWork _unitOfWork;
        public AuditLogBLL() : this(new UnitOfWork())
        {
        }

        public AuditLogBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> GetVBLUserNameList()
        {
            return
                _unitOfWork.AuditLogs()
                    .Select()
                    .Where(x => x.TableName.StartsWith("VBL"))
                    .ToList()
                    .Select(x => x.UserName)
                    .Distinct()
                    .ToList();
        }

        public List<string> GetVBLTableNameList()
        {
          return  _unitOfWork.AuditLogs()
                .Select()
                .Where(x => x.TableName.StartsWith("VBL"))
                .ToList()
                .Select(x => x.TableName)
                .Distinct()
                .ToList();
        }

        public List<AuditLog> GetAuditLogs(ODataQueryOptions<AuditLog> options)
        {
            var contacts =
                 options.ApplyTo(_unitOfWork.AuditLogs().Select2(x => true, includeProperties: i =>
                         new
                        {
                            i.AuditLogDetails
                        })
                 .AsNoTracking()
                 .AsQueryable());
            return Mapper.Map<List<AuditLog>>(contacts);
        }
    }
}