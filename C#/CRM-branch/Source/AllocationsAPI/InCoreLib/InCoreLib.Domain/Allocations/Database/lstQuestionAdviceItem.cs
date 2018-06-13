using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstQuestionAdviceItem")]
    public partial class lstQuestionAdviceItem
    {
        [Key]
        [Column(Order = 0)]
        public int QstnAdviceItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QstnID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QstnAltID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdviceItemID { get; set; }

        public bool? IfAll { get; set; }

        public bool? IfYes { get; set; }

        public bool? IfNo { get; set; }

        public bool? IfNeither { get; set; }
    }
}
