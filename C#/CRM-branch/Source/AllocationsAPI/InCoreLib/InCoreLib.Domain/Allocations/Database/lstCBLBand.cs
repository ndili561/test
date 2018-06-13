using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstCBLBand")]
    public partial class lstCBLBand
    {
        [Key]
        [StringLength(50)]
        public string CBLBand { get; set; }

        [StringLength(50)]
        public string CBLBandDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
