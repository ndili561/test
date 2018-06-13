namespace Incomm.Allocations.DTO
{
    public class HOAQuestionAnswerDTO
    {
        public HOAAnswerTypeDTO HoaAnswerTypeDto { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int AnswerId { get; set; }
        public int AnswerTypeId { get; set; }
        public string Answer { get; set; }
        public string AnswerNote { get; set; }
        public int CalculatedSequenceNumber { get; set; }
    }
}