using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("Logos")]
    public partial class Logo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string LogoFile { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte[] LogoImage { get; set; }
    }
}
