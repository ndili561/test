using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstLevelOfNeed")]
    public partial class lstLevelOfNeed
    {
        [Key]
        [StringLength(1)]
        public string LevelOfNeed { get; set; }

        [StringLength(50)]
        public string LevelOfNeedDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
