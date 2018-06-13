using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("Title")]
    public partial class Title
    {
        public int TitleId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }

        public int DefaultGenderID { get; set; }
    }
}
