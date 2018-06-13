using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tsubTASuppInvoice
    {
        [Key]
        [Column(Order = 0)]
        public int SuppInvID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccomProviderID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        [StringLength(50)]
        public string SuppInvNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SuppInvDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddDate { get; set; }

        public string Note { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VATValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoOfDaysPaid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoOfDaysUnallocated { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueMatched { get; set; }

        public DateTime? MatchDateStart { get; set; }

        public DateTime? MatchDateComplete { get; set; }
    }
}
