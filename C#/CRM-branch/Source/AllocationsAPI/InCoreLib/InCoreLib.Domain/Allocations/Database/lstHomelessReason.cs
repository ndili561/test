using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessReason")]
    public partial class lstHomelessReason
    {
        [Key]
        [StringLength(50)]
        public string HomelessReason { get; set; }

        [StringLength(100)]
        public string HomelessReasonDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
