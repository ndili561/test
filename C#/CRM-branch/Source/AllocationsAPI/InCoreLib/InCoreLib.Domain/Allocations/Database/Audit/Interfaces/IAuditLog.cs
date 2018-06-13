using System;
using System.Collections.Generic;
using InCoreLib.Data.Enum;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Data.Audit.Interfaces
{
    public interface IAuditLog
    {
        int AuditLogId { get; set; }
        string UserName { get; set; }
        string UserIPAddress { get; set; }
        string AuditDescription { get; set; }
        DateTime EventDateUTC { get; set; }
        EventType EventType { get; set; }
        string TableName { get; set; }
        string RecordId { get; set; }
        ICollection<IAuditLogDetail> LogDetails { get; set; }
    }
}