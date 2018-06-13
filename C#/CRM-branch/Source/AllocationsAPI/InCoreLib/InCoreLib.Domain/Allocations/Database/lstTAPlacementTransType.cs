using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstTAPlacementTransType")]
    public partial class lstTAPlacementTransType
    {
        [Key]
        [Column(Order = 0)]
        public int TransactionTypeID { get; set; }

        [StringLength(150)]
        public string TransDesc { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }
    }
}
