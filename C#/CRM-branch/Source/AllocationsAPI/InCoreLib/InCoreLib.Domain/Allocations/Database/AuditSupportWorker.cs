using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("AuditSupportWorker")]
    public partial class AuditSupportWorker
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupportWorkerID { get; set; }

        public int CustomerApplicationID { get; set; }

        [Required]
        [StringLength(1000)]
        public string SupportWorkerReason { get; set; }

        [Required]
        [StringLength(100)]
        public string SupportWorkerName { get; set; }

        [Required]
        [StringLength(255)]
        public string SupportWorkerContact { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }
    }
}
