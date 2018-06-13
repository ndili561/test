using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAdviceReason")]
    public partial class lstAdviceReason
    {
        [Key]
        public int AdviceReasonID { get; set; }

        public int QstnID { get; set; }

        public int QstnairID { get; set; }

        public int? AdviceItemID { get; set; }

        public int? AdviceItemTypeID { get; set; }

        [StringLength(50)]
        public string AdviceHeading { get; set; }

        [StringLength(50)]
        public string AdviceReason { get; set; }

        [StringLength(50)]
        public string AdviceReason1 { get; set; }

        [StringLength(50)]
        public string AdviceReaso2 { get; set; }

        [StringLength(50)]
        public string AdviceReason3 { get; set; }

        [StringLength(50)]
        public string AdviceReason4 { get; set; }
    }
}
