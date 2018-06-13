namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSQuestionsAndAnswersDTO
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int AnswerId { get; set; }
        public int AnswerTypeID { get; set; }
        public string Answer { get; set; }
        public string AnswerYesNo { get; set; }
    }
}
