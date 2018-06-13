using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstFloorLevel")]
    public partial class lstFloorLevel
    {
        [Key]
        [StringLength(50)]
        public string FloorLevel { get; set; }

        [StringLength(50)]
        public string FloorLevelDescription { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
