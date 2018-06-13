using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessOutcomeResult")]
    public partial class lstHomelessOutcomeResult
    {
        [Key]
        [StringLength(50)]
        public string HomelessOutcomeResult { get; set; }

        [StringLength(50)]
        public string HomelessOutcomeResultDesc { get; set; }

        [StringLength(50)]
        public string HOR_P1eCategoriesHavingTempAccom { get; set; }

        [StringLength(50)]
        public string HOR_P1eCategoriesNotHavingTempAccom { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
