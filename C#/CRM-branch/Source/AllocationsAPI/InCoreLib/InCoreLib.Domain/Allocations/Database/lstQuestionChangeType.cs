using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstQuestionChangeType")]
    public partial class lstQuestionChangeType
    {
        [Key]
        [Column(Order = 0)]
        public int QstnChangeTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ChangeType { get; set; }

        public bool? Active { get; set; }
    }
}
