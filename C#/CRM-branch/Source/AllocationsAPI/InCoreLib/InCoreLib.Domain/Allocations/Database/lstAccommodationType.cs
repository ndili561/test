using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAccommodationType")]
    public partial class lstAccommodationType
    {
        [Key]
        [StringLength(50)]
        public string AccommodationType { get; set; }

        [StringLength(50)]
        public string AccommodationTypeDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
