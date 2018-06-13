using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstArea")]
    public partial class lstArea
    {
        [Key]
        [StringLength(8)]
        public string Area { get; set; }

        [StringLength(50)]
        public string IncommunitiesLMT { get; set; }

        public short? Sortorder { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
