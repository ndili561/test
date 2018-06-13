using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public class vReceptionWaitingTime
    {
        public DateTime? ReceptionDateTime { get; set; }

        public DateTime? ReceptionDate { get; set; }

        public DateTime? AssessmentInterviewDateTime { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }

        public int? ReceptionWaitingTime { get; set; }

        [StringLength(10)]
        public string ReceptionDay { get; set; }

        public int? ReceptionHour { get; set; }

        [StringLength(50)]
        public string AllocatedUserID { get; set; }

        [StringLength(50)]
        public string AllocatedUser { get; set; }
    }
}