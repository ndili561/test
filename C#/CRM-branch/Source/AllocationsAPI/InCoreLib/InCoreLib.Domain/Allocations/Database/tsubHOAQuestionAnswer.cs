using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tsubHOAQuestionAnswer
    {
        [Key]
        [Column(Order = 0)]
        public int AnswerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QstnairID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QstnID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seqno { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnswerTypeID { get; set; }

        public string AnswerValue { get; set; }

        public int? QstnAltID { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime AddDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public string Note { get; set; }

        public string YesNote { get; set; }

        public string NoNote { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrevQstnID { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NextQstnID { get; set; }

        public bool? QstnAltChecked { get; set; }

        public bool? OtherChecked { get; set; }

        public string OtherNote { get; set; }

        public bool? AdviceDelivered { get; set; }

        public DateTime? AdviceDeliveredDate { get; set; }

        public int? QstnChangeTypeID { get; set; }

        public int? CaseNoteID { get; set; }

        public bool? CommonQstn { get; set; }
    }
}
