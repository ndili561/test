using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstFamilyComposition")]
    public partial class lstFamilyComposition
    {
        [Key]
        [StringLength(50)]
        public string FamilyComposition { get; set; }

        [StringLength(50)]
        public string P1Egrouping { get; set; }

        [Column("Number dependant children")]
        [StringLength(50)]
        public string Number_dependant_children { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
