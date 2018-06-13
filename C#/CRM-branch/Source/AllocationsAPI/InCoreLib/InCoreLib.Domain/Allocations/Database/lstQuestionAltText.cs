using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstQuestionAltText")]
    public partial class lstQuestionAltText
    {
        [Key]
        [Column(Order = 0)]
        public int QstnAltID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QstnID { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Active { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seqno { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string ItemText { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime AddDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool OtherYes { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool OtherNote { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool ShowCheckBox { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool ShowNote { get; set; }

        public int? NextQstnID { get; set; }
    }
}
