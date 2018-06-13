using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    /// <summary>
    /// </summary>
    public class ActionType
    {
        /// <summary>
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public int ActionCategoryId { get; set; }

        /// <summary>
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Action { get; set; }

        /// <summary>
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// </summary>
        public int? SortOrder { get; set; }
    }
}
