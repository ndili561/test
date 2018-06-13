using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstRevisitReason")]
    public partial class lstRevisitReason
    {
        [Key]
        public int RevReasonID { get; set; }

        [StringLength(150)]
        public string RevDesc { get; set; }

        public bool? Active { get; set; }
    }
}
