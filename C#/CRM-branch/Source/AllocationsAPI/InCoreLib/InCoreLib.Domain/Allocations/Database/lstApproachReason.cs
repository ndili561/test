using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstApproachReason")]
    public partial class lstApproachReason
    {
        [Key]
        [StringLength(50)]
        public string ApproachReasonCode { get; set; }

        [StringLength(50)]
        public string ApproachReasonDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
