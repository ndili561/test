using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstPriorityNeedsReason")]
    public partial class lstPriorityNeedsReason
    {
        [Key]
        [StringLength(50)]
        public string PriorityNeedsReason { get; set; }

        [StringLength(50)]
        public string PriorityNeedsReasonDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
