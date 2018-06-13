using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("Ethnicity")]
    public partial class Ethnicity
    {
        public int EthnicityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int SortOrder { get; set; }

        public int IBSCode { get; set; }

        [Required]
        [StringLength(100)]
        public string HOACode { get; set; }
    }
}
