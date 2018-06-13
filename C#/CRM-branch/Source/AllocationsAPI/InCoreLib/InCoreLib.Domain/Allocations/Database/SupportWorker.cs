using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("SupportWorker")]
    public partial class SupportWorker
    {
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

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }
    }
}
