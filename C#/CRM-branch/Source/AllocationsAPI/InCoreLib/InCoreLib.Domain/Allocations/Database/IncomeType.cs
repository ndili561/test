using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("IncomeType")]
    public partial class IncomeType
    {
        public int IncomeTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }

        public bool AllowMultiple { get; set; }
    }
}
