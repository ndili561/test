using System;

namespace Incomm.Allocations.DTO
{
    public class HOAExclusionDTO
    {
        public bool Active { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUserID { get; set; }
        public int CaseExclusionID { get; set; }
        public int CaseRef { get; set; }
        public bool? DutyCeased { get; set; }
        public bool? ExcludedByTAProvider { get; set; }
        public bool? FailureToCoop { get; set; }
        public bool? NotEligible { get; set; }
        public bool? NotHomeless { get; set; }
        public bool? NotPriorityNeed { get; set; }
        public string RiskNote { get; set; }
        public bool? WaiveDueToCWP { get; set; }
        public bool? WaiveDueToManager { get; set; }
    }
}