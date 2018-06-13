using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("AuditContactIncome")]
    public partial class AuditContactIncome
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        public int CustomerApplicationID { get; set; }

        public int ContactID { get; set; }

        public int IncomeTypeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IncomeAmount { get; set; }

        public int IncomeFrequencyID { get; set; }

        public bool Active { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactIncomeID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }
    }
}
