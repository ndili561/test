using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstHomelessWhereStayingNow")]
    public partial class lstHomelessWhereStayingNow
    {
        [Key]
        [StringLength(50)]
        public string HomelessWhereStayingNow { get; set; }

        [StringLength(100)]
        public string HomelessWhereStayingNowDesc { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
