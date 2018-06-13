using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("LevelOfNeed")]
    public partial class LevelOfNeed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LevelOfNeedId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
