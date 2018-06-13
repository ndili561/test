using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstRelationship")]
    public partial class lstRelationship
    {
        [Key]
        [StringLength(50)]
        public string RelationshipID { get; set; }

        [StringLength(50)]
        public string RelationshipDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
