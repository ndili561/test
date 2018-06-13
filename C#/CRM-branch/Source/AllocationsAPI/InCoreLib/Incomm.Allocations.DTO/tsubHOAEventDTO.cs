using System;
using System.ComponentModel.DataAnnotations;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.DTOs
{
    public class tsubHOAEventDTO :BaseObjectDto
    {
        public int HRSCustomerId;

        public int CaseEventID { get; set; }

        public int? CaseRef { get; set; }

        public int? EntityID { get; set; }

    
        public int EventID { get; set; }


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

    }
}
