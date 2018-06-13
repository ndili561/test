using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tsubHOAEvent
    {
        [Key]
        [Column(Order = 0)]
        public int CaseEventID { get; set; }

        public int? CaseRef { get; set; }

        public int? EntityID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seqno { get; set; }

        public int? Priority { get; set; }

        public DateTime? ForecastStartDate { get; set; }

        public DateTime? ForecastCompletionDate { get; set; }

        public DateTime? ActualStartDate { get; set; }

        public DateTime? ActualCompletionDate { get; set; }

        public DateTime? RequiredStartDate { get; set; }

        public DateTime? RequiredCompletionDate { get; set; }

        public string Note { get; set; }

        public bool? Completed { get; set; }

        [StringLength(50)]
        public string CompletedUserID { get; set; }

        [StringLength(50)]
        public string AssignedTo { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public bool? NotNeeded { get; set; }

        public DateTime? NotNeededDate { get; set; }

        [StringLength(50)]
        public string NotNeededUserID { get; set; }

        public bool? UnableToComplete { get; set; }

        public DateTime? UnableToCompleteDate { get; set; }

        [StringLength(50)]
        public string UnableToCompleteUserID { get; set; }

        public int? QstnID { get; set; }

        [NotMapped]
        [SkipTracking]
        public virtual string UserId { get; set; }

        [NotMapped]
        [SkipTracking]
        public virtual string UserIPAddress { get; set; }
    }
}
