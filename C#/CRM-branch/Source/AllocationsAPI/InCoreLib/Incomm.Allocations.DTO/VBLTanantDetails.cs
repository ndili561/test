using System;
using System.ComponentModel.DataAnnotations;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.DTO
{
    public class VBLTenantDetailDTO : BaseObject
    {
        [Key]
        public int TenantDetailId { get; set; }
        public int ContactId { get; set; }
        public virtual VBLContactDTO Contact { get; set; }
        public string TenantCode { get; set; }
        public string TenancyReference { get; set; }
        public DateTime? TenancyStartDate { get; set; }
        public DateTime? TenancyEndDate { get; set; }
        public bool MainTenant { get; set; }
        public bool IsActive { get; set; }
    }
    
}