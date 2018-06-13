using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tsubHomelessnessReview
    {
        [Key]
        public int HLReviewIndex { get; set; }

        public int CaseRef { get; set; }

        public int HLReviewSeqno { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReviewRequestedDate { get; set; }

        [StringLength(100)]
        public string MeansOfNotify { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SentToCouncilDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ForecastReturnDecisionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReturnDecisionDate { get; set; }

        [StringLength(100)]
        public string CouncilsDecision { get; set; }

        [StringLength(100)]
        public string NewDecision { get; set; }

        public bool? OutcomeReview { get; set; }

        public bool? DecisionReview { get; set; }

        public string ReturnDecisionText { get; set; }

        public string Notes { get; set; }

        public int? ReviewAgainst { get; set; }
    }
}
