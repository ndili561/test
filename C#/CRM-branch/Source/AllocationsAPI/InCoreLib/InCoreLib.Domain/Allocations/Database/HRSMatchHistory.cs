using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("HRSMatchHistory")]
    public class HRSMatchHistory : BaseObject
    {
        [Key]
        public int MatchHistoryId { get; set; }
        public int PlacementId { get; set; }
        public virtual HRSPlacement Placement { get; set; }
        public int HRSCustomerId { get; set; }
        public virtual HRSCustomer Customer { get; set; }
        public virtual Status Outcome { get; set; }
        public virtual RejectionReason Reason { get; set; }
        public virtual string Notes { get; set; }
        public DateTime DecisionDate { get; set; }
        public bool Reconsidered { get; set; }
    }
}