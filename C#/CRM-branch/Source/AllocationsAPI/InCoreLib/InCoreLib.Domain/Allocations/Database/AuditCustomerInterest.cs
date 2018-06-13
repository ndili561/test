using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("AuditCustomerInterest")]
    public partial class AuditCustomerInterest
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerInterestID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }

        public int CustomerApplicationID { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyCode { get; set; }

        public int CustomerInterestStatusID { get; set; }

        public int CustomerInterestStatusReasonsID { get; set; }

        public int? VoidContactID { get; set; }
    }
}
