using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public  class HRSQuestionAnswer : BaseObject
    {
        [Key]
        public int AnswerID { get; set; }

        public int PlacementId { get; set; }

        public int QstnairID { get; set; }

        public int QstnID { get; set; }

        public int CaseRef { get; set; }

        public int Seqno { get; set; }

        public int AnswerTypeID { get; set; }

        public string AnswerValue { get; set; }

        public int? QstnAltID { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Note { get; set; }

        public string YesNote { get; set; }

        public string NoNote { get; set; }

        public int PrevQstnID { get; set; }

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
