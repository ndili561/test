using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class qrpt_TempAccomodationUse
    {
        [Key]
        public int CaseRefNumber { get; set; }

        [StringLength(50)]
        public string AssessorUserID { get; set; }

        public bool? HasHomelessnessAssessment { get; set; }

        [StringLength(255)]
        public string HL_TempAccommodationType { get; set; }

        public DateTime? HL_TADateIn { get; set; }

        public DateTime? HL_TADateOut { get; set; }

        [StringLength(50)]
        public string HL_HomelessDecision { get; set; }

        public DateTime? HL_HomelessDecisionDate { get; set; }

        [StringLength(50)]
        public string FamilyComposition { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? AssessmentInterviewDateTime { get; set; }

        public double? Age { get; set; }
    }
}
