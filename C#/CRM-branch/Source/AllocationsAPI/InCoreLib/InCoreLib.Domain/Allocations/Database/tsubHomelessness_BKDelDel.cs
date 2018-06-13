using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tsubHomelessness_BKDelDel
    {
        [Key]
        [Column(Order = 0)]
        public int HLIndex { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HLSeqno { get; set; }

        public DateTime? HL_InterviewDate { get; set; }

        [StringLength(50)]
        public string HL_IsEligible1 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsEligibleNotes { get; set; }

        [StringLength(50)]
        public string HL_IsHomeless2 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsHomelessNotes { get; set; }

        [StringLength(50)]
        public string HL_IsInPriorityNeed3 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsInPriorityNeedNotes { get; set; }

        [StringLength(50)]
        public string HL_IsIntentionallyHomeless4 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_IsIntentionallyHomeless_Notes { get; set; }

        [StringLength(50)]
        public string HL_HasLocalConnection5 { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_HasLocalConnectionNotes { get; set; }

        [StringLength(50)]
        public string HL_HomelessDecision { get; set; }

        public DateTime? HL_HomelessDecisionDate { get; set; }

        public bool? HL_DutyOwed { get; set; }

        public bool? HL_S198Duty { get; set; }

        public bool? HL_S213Duty { get; set; }

        public bool? HL_S198DutyOut { get; set; }

        public bool? HL_S213DutyOut { get; set; }

        public bool? HL_RepeatHomelessCase { get; set; }

        [StringLength(50)]
        public string HL_PriorityNeedReason { get; set; }

        [StringLength(50)]
        public string HL_HomelessReason { get; set; }

        [StringLength(50)]
        public string HL_HomelessWhereStayingNow { get; set; }

        public int? HL_AgeAtHomelessDecisionDate { get; set; }

        [StringLength(50)]
        public string HL_AgeGroup { get; set; }

        public bool? HL_TempAccommodation { get; set; }

        [StringLength(255)]
        public string HL_TempAccommodationType { get; set; }

        public DateTime? HL_TADateIn { get; set; }

        public DateTime? HL_TADateOut { get; set; }

        public int? HL_TotalTimeResidentInWeeks { get; set; }

        [StringLength(255)]
        public string HL_Outcome { get; set; }

        [Column(TypeName = "ntext")]
        public string HL_OutcomeOther { get; set; }

        public DateTime? HL_OutcomeDate { get; set; }

        [StringLength(50)]
        public string AssessorUserIDHomelessnessAssessment { get; set; }
    }
}
