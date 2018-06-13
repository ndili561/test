using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstUserLocation")]
    public partial class lstUserLocation
    {
        [Key]
        [StringLength(3)]
        public string UserLocation { get; set; }

        [StringLength(50)]
        public string UserLocationDescription { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public string UserLocationAddress { get; set; }
    }
}
