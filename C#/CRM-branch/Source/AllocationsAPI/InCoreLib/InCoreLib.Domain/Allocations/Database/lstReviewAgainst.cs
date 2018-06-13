using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstReviewAgainst")]
    public partial class lstReviewAgainst
    {
        [Key]
        [Column(Order = 0)]
        public int ReviewAgainstID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [StringLength(150)]
        public string ReviewAgainstDescription { get; set; }
    }
}
