using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstQuestionnaire")]
    public partial class lstQuestionnaire
    {
        [Key]
        [Column(Order = 0)]
        public int QstnairID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [StringLength(150)]
        public string QstnairDesc { get; set; }

        [StringLength(50)]
        public string QstnairShortDesc { get; set; }
    }
}
