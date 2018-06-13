using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubHOAExclusion")]
    public partial class tsubHOAExclusion
    {
        [Key]
        [Column(Order = 0)]
        public int CaseExclusionID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime AddDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string AddUserID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        public bool? NotHomeless { get; set; }

        public bool? NotPriorityNeed { get; set; }

        public bool? DutyCeased { get; set; }

        public bool? FailureToCoop { get; set; }

        public bool? NotEligible { get; set; }

        public bool? WaiveDueToCWP { get; set; }

        public bool? WaiveDueToManager { get; set; }

        public string RiskNote { get; set; }

        public bool? ExcludedByTAProvider { get; set; }
    }
}
