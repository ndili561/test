using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAdviceItemType")]
    public partial class lstAdviceItemType
    {
        [Key]
        public int AdviceItemTypeID { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}
