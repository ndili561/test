using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lstHomelessP1eCategoriesHavingTempAccom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int P1eCHTAcode { get; set; }

        [StringLength(50)]
        public string HOR_P1eCategoriesHavingTempAccom { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
