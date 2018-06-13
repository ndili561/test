using System;
using System.ComponentModel.DataAnnotations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSQuestionAnswerDTO : BaseObjectDto
    {
        [Key]
        public int AnswerID { get; set; }

        public int PlacementId { get; set; }

        [Key]
        public int QstnairID { get; set; }

        [Key]
        public int QstnID { get; set; }

        [Key]
        public int CaseRef { get; set; }

        [Key]
        public int Seqno { get; set; }

        [Key]
        public int AnswerTypeID { get; set; }

        public string AnswerValue { get; set; }

        public int? QstnAltID { get; set; }

        [Key]
        public DateTime AddDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Note { get; set; }

        public string YesNote { get; set; }

        public string NoNote { get; set; }

        [Key]
        public int PrevQstnID { get; set; }

        [Key]
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
