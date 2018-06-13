using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class lstBnBReason
    {
        [Key]
        [Column(Order = 0)]
        public int BnBReasonID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Active { get; set; }
    }
}
