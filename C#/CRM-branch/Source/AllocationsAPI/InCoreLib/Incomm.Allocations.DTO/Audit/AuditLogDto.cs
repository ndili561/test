using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using InCoreLib.Domain.Enum;

namespace Incomm.Allocations.BLL.DTOs.Audit
{
    public class AuditLogDto
    {
        public AuditLogDto()
        {
            AuditLogDetails = new List<AuditLogDetailDto>();
        }

        public int AuditLogId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string UserIPAddress { get; set; }
        public string AuditDescription { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime EventDateUTC { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public EventType EventType { get; set; }

        [Required]
        [MaxLength(256)]
        [Display(Name = "Entity Type")]
        public string TableName { get; set; }

        [Required]
        [MaxLength(256)]
        public string RecordId { get; set; }

        public ICollection<AuditLogDetailDto> AuditLogDetails { get; set; }
        public ICollection<SelectListItem> UserList { get; set; }
        public ICollection<SelectListItem> TableList { get; set; }
    }
}