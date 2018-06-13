using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public class vCaseStatu
    {
        public DateTime? AllocatedDateTime { get; set; }

        [StringLength(50)]
        public string AllocatedOfficer { get; set; }

        [StringLength(50)]
        public string CaseStatusDescription { get; set; }

        public bool? CaseClosed { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }

        [StringLength(152)]
        public string CustomerName { get; set; }

        [StringLength(258)]
        public string Address { get; set; }

        [StringLength(152)]
        public string ContactDetails { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string ApproachReason { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool RehousingRequired { get; set; }

        [StringLength(50)]
        public string Area1 { get; set; }

        [StringLength(50)]
        public string Area2 { get; set; }

        [StringLength(50)]
        public string Area3 { get; set; }

        [StringLength(50)]
        public string Area4 { get; set; }

        public short? BedroomNeed { get; set; }
    }
}