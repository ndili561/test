using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lstHomelessP1eCategoriesNotHavingTempAccom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int P1eCNHTAcode { get; set; }

        [StringLength(50)]
        public string HOR_P1eCategoriesNotHavingTempAccom { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
