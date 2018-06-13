using System;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database
{
    public class HRSPlacementMatchedForCustomer : BaseObject
    {
        [Key]
        public int HRSPlacementMatchedForCustomerId { get; set; }

        public virtual int PlacementId { get; set; }
        public virtual HRSPlacement Placement { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual HRSCustomer Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual RejectionReason RejectionReason { get; set; }
        public virtual string Notes { get; set; }
        public virtual DateTime EventDate { get; set; }
    }
}
