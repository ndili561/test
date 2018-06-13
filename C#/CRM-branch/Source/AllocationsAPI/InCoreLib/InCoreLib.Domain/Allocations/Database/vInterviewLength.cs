using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("vInterviewLength")]
    public class vInterviewLength
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }

        [StringLength(50)]
        public string AssessorUserID { get; set; }

        [StringLength(50)]
        public string AssessingOfficer { get; set; }

        [StringLength(152)]
        public string CustomerName { get; set; }

        public DateTime? AssessmentInterviewDate { get; set; }

        public DateTime? AssessmentInterviewDateTime { get; set; }

        public DateTime? EndOfInterviewDateTime { get; set; }

        public int? InterviewTime { get; set; }
    }
}