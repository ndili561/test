using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstReviewDecOut")]
    public partial class lstReviewDecOut
    {
        [Key]
        public int DecOutID { get; set; }

        public bool Active { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(3)]
        public string DecOut { get; set; }
    }
}
