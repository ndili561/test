using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("TenancyType")]
    public partial class TenancyType
    {
        [Key]
        public int TenancyTypeId { get; set; }
        public string Code { get; set; }
       
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string TenancyTypeAndCategoryCode { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }

   
    }
}
