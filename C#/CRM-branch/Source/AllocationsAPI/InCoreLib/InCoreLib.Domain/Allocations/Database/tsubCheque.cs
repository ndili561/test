using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubCheque")]
    public partial class tsubCheque
    {
        [Key]
        [Column(Order = 0)]
        public int ChequeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RefNo { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal ChequeNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AccountNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime ChequeDate { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal ChequeValue { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal AllocatedValue { get; set; }
    }
}
