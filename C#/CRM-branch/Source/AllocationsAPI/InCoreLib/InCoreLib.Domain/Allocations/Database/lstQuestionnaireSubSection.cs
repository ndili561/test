using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstQuestionnaireSubSection")]
    public partial class lstQuestionnaireSubSection
    {
        [Key]
        [Column(Order = 0)]
        public int QstnairSubSectionID { get; set; }

        public int? QstnairSectionID { get; set; }

        public int? QstnairID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string SubSectionDesc { get; set; }

        [StringLength(250)]
        public string SubSectionHeadingText { get; set; }
    }
}
