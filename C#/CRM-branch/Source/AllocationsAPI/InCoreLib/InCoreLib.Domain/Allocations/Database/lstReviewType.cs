using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lstReviewType
    {
        [Key]
        public int ReviewTypeID { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(50)]
        public string ReviewDesc { get; set; }
    }
}
