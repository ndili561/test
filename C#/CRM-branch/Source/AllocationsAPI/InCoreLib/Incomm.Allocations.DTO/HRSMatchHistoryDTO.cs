using System;
using System.ComponentModel.DataAnnotations;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSMatchHistoryDTO : BaseObjectDto
    {
        [Display(Name = "ID")]
        public int MatchHistoryId { get; set; }
        public HRSPlacementDTO Placement { get; set; }
        public HRSCustomerDTO Customer { get; set; }
        [Display(Name = "Outcome")]
        public Status Outcome { get; set; }
        [Display(Name = "Reason")]
        public RejectionReason Reason { get; set; }
        [Display(Name = "Notes")]
        public virtual string Notes { get; set; }
        [Display(Name = "Date")]
        public DateTime DecisionDate { get; set; }
        public bool Reconsidered { get; set; }
    }
}