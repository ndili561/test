using System;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLCustomerInterestDTO : BaseObjectDto
    {
        [Key]
        public int CustomerInterestId { get; set; }
        public string PropertyCode { get; set; }
        public int VoidId { get; set; }
        public int CustomerInterestStatusId { get; set; }
        public virtual CustomerInterestStatu CustomerInterestStatus { get; set; }
        public int VoidContactId { get; set; }
        public bool IsPreViewingUndertaken { get; set; }
        public DateTime StatusReasonsDate { get; set; }
        public string OutcomeNotes { get; set; }
        public bool CustomerDecision { get; set; }
        public string Notes { get; set; }
        public int TaskId { get; set; }
        public int ActivityId { get; set; }
        public bool IsRSLProperty { get; set; }
        public int ApplicationHistoryId { get; set; }
        public int ApplicationId { get; set; }

        public VBLApplicationDTO Application { get; set; }
        public int LandlordId  { get; set; }
        public int? NotInterestedReasonID { get; set; }

    }
}