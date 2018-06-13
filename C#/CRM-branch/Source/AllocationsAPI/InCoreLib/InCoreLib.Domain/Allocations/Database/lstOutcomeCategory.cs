using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstOutcomeCategory")]
    public partial class lstOutcomeCategory
    {
        [Key]
        public int OutcomeCategoryId { get; set; }

        public bool Deleted { get; set; }

        [StringLength(100)]
        public string OutcomeCategoryDec { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
