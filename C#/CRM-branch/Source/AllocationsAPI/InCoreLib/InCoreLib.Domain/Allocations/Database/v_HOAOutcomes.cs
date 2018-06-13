using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_HOAOutcomes
    {
        [Key]
        [Column(Order = 0)]
        public int CustomerApplicationID { get; set; }

        public int? ApplicationLevelOfNeedID { get; set; }

        public bool? ApplicationEligable { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ApplicationDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }
    }
}
