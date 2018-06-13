using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public class AuditCustomerInterestStatusReason
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerInterestStatusReasonsID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime StatusReasonsDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerInterestID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerInterestStatusID { get; set; }

        [StringLength(1000)]
        public string OutcomeNotes { get; set; }

        public int? ActivityID { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool CustomerDecision { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }

        public bool? HasNotes { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }
    }
}