using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstNationalityType")]
    public partial class lstNationalityType
    {
        [Key]
        [StringLength(50)]
        public string NationalityType { get; set; }

        [StringLength(50)]
        public string NationalityTypeDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
