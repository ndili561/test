using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLTenantDetail : BaseObject
    {
        [Key]
        public int TenantDetailId { get; set; }
        public int ContactId { get; set; }
        public virtual VBLContact Contact { get; set; }
        public string TenantCode { get; set; }
        public string TenancyReference { get; set; }
        public DateTime? TenancyStartDate { get; set; }
        public DateTime? TenancyEndDate { get; set; }
        public bool MainTenant { get; set; }
        public bool IsActive { get; set; }
    }
    
}