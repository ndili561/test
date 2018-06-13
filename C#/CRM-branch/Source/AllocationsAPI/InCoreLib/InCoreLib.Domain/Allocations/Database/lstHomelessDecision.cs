using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessDecision")]
    public partial class lstHomelessDecision
    {
        [Key]
        [StringLength(50)]
        public string HomelessDecision { get; set; }

        [StringLength(50)]
        public string HomelessDecisionDesc { get; set; }

        public int? P1Eindex { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
