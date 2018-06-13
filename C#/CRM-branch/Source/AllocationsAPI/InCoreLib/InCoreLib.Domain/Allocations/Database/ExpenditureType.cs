using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    /// <summary>
    /// </summary>
    [Table("ExpenditureType")]
    public partial class ExpenditureType
    {
        /// <summary>
        /// </summary>
        public int ExpenditureTypeId { get; set; }

        /// <summary>
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// </summary>
        public int? SortOrder { get; set; }

        /// <summary>
        /// </summary>
        public bool AllowMultiple { get; set; }
    }
}
