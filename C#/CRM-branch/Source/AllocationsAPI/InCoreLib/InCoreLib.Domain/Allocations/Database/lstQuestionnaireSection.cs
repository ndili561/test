using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstQuestionnaireSection")]
    public partial class lstQuestionnaireSection
    {
        [Key]
        [Column(Order = 0)]
        public int QstnairSectionID { get; set; }

        public int? QstnairID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string SectionDesc { get; set; }

        [StringLength(250)]
        public string SectionHeadingText { get; set; }
    }
}
