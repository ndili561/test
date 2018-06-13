using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public class vAdviceEndToEndTime
    {
        public int? E2EDays { get; set; }

        public DateTime? ReceptionVisitDate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }

        [StringLength(100)]
        public string AdviceOutcome { get; set; }

        public DateTime? AdviceOutcomeDate { get; set; }

        [StringLength(50)]
        public string AssessorUserID { get; set; }

        [StringLength(50)]
        public string AssessingOfficer { get; set; }
    }
}