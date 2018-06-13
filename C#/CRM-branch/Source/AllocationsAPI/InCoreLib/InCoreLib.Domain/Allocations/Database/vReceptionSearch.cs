using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("vReceptionSearch")]
    public class vReceptionSearch
    {
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Forename { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime? DoB { get; set; }

        public bool? Warning { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PACustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceptionIndex { get; set; }

        public int? CaseClosed { get; set; }

        public int? HighlySensitive { get; set; }
    }
}