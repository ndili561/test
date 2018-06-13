using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLCustomerInterest : BaseObject
    {
        [Key]
        public int CustomerInterestId { get; set; }
        public string PropertyCode { get; set; }
        public int VoidId { get; set; }
        public int CustomerInterestStatusId { get; set; }
        public virtual CustomerInterestStatu CustomerInterestStatus { get; set; }
        public int VoidContactId { get; set; }
        public bool IsPreViewingUndertaken { get; set; }
        public DateTime StatusReasonsDate { get; set; }
        public string OutcomeNotes { get; set; }
        public bool CustomerDecision { get; set; }
        public string Notes { get; set; }
        public int TaskId { get; set; }
        public int ActivityId { get; set; }
        public int ApplicationId { get; set; }
        public virtual VBLApplication Application { get; set; }
        public int LandlordId { get; set; }
        public int? NotInterestedReasonId { get; set; }
    }
}
