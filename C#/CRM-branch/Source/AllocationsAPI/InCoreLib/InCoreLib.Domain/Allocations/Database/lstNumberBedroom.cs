using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lstNumberBedroom
    {
        [Key]
        [Column("Number Bedrooms")]
        [StringLength(50)]
        public string Number_Bedrooms { get; set; }

        [Column("Number Bedrooms Desc")]
        [StringLength(50)]
        public string Number_Bedrooms_Desc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
