using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstTACancelReason")]
    public partial class lstTACancelReason
    {
        [Key]
        [Column(Order = 0)]
        public int CancReasonID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string ReasonDesc { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Active { get; set; }
    }
}
