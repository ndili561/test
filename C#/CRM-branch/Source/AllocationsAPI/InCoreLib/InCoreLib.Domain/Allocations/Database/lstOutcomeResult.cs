using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstOutcomeResult")]
    public partial class lstOutcomeResult
    {
        [Key]
        [StringLength(50)]
        public string OutcomeResult { get; set; }

        [StringLength(100)]
        public string OutcomeResultDec { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public int? OutcomeCategoryId { get; set; }

        public bool OutcomeOtherField { get; set; }
    }
}
