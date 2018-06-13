using System.Collections.Generic;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs.Audit
{
    public class AuditLogViewModel : BaseFilterModel
    {
        public AuditLogViewModel()
        {
           AuditLogSearchResult= new List<AuditLogDto>(); 
        }

        public AuditLogDto AuditLogDto
        {
            get
            {
                return new AuditLogDto();
            }
        } 
        public AuditLogDto AuditLogSearchModel { get; set; }
        public List<AuditLogDto> AuditLogSearchResult { get; set; }
        public List<string> UserNameList { get; set; }
        public List<string> TableNameList { get; set; }
    }
}
