using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAnswerType")]
    public partial class lstAnswerType
    {
        [Key]
        [Column(Order = 0)]
        public int AnswerTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TypeDesc { get; set; }
    }
}
