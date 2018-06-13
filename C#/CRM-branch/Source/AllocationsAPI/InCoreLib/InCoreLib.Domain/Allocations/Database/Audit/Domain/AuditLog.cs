using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Database.Audit.Domain
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }

        public string UserName { get; set; }
        public string UserIPAddress { get; set; }
        public string AuditDescription { get; set; }
        public DateTime EventDateUTC { get; set; }
        public EventType EventType { get; set; }
        public string TableName { get; set; }
        public string RecordId { get; set; }
        public virtual ICollection<AuditLogDetail> AuditLogDetails { get; set; }
    }
}