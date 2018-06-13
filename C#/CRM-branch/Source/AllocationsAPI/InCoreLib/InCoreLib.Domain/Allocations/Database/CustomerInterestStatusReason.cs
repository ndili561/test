using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class CustomerInterestStatusReason
    {
        [Key]
        public int CustomerInterestStatusReasonsID { get; set; }

        public DateTime StatusReasonsDate { get; set; }

        public int CustomerInterestID { get; set; }

        public int CustomerInterestStatusID { get; set; }

        [StringLength(1000)]
        public string OutcomeNotes { get; set; }

        public int? ActivityID { get; set; }

        public bool CustomerDecision { get; set; }

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }

        public bool HasNotes { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public virtual CustomerInterest CustomerInterest { get; set; }
    }
}
