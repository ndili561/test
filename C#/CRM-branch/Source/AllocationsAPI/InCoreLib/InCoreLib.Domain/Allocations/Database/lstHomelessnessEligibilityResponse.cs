using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessnessEligibilityResponse")]
    public partial class lstHomelessnessEligibilityResponse
    {
        [Key]
        [StringLength(50)]
        public string HomelessnessEligibilityResponse { get; set; }

        [StringLength(50)]
        public string HomelessnessEligibilityResponseDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
