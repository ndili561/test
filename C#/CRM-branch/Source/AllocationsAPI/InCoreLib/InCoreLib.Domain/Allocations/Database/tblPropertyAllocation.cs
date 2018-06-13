using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblPropertyAllocation")]
    public partial class tblPropertyAllocation
    {
        [Key]
        public int PropertyAllocationOutcomeID { get; set; }

        public int? PropertyID { get; set; }

        public int? CaseRefNumber { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string AssessorUserID { get; set; }

        [StringLength(50)]
        public string AllocationOutcome { get; set; }
    }
}
