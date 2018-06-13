using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstCallOutcome")]
    public partial class lstCallOutcome
    {
        [Key]
        [Column(Order = 0)]
        public int OutcomeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string OutcomeDesc { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Active { get; set; }
    }
}
