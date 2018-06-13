using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("vWaitingList")]
    public class vWaitingList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerRef { get; set; }

        [StringLength(152)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string Area1 { get; set; }

        [StringLength(50)]
        public string Area2 { get; set; }

        [StringLength(50)]
        public string Area3 { get; set; }

        [StringLength(50)]
        public string Area4 { get; set; }

        public short? NumberOfBedrooms { get; set; }

        public DateTime? AssessmentInterviewDate { get; set; }

        public int? DaysSinceInterview { get; set; }
    }
}