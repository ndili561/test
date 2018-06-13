using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_HOAInterface
    {
        [Key]
        [Column(Order = 0)]
        public int CustomerApplicationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationStatusID { get; set; }

        [StringLength(1000)]
        public string ApplicationStatusReason { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ApplicationDate { get; set; }

        public bool? ApplicationEligible { get; set; }

        public DateTime? HOALevelOfNeedDate { get; set; }

        public int? ApplicationLevelOfNeedID { get; set; }

        public int? HOACaseRef { get; set; }

        [StringLength(1000)]
        public string HOAOutcome { get; set; }

        public DateTime? HOAOutcomeDate { get; set; }

        public bool? HOACaseIsOpen { get; set; }

        public bool? HOAEligabilitySet { get; set; }

        public DateTime? ApplicationClosedDate { get; set; }

        public bool? HOAEligible { get; set; }

        public int? HOALevelOfNeedID { get; set; }

        [StringLength(255)]
        public string MoveReason { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActivityID { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public int? ActivityStatusID { get; set; }
    }
}
