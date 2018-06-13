using Incomm.Allocations.DTO;
using System.Collections.Generic;

namespace Incomm.Allocations.BLL.Interfaces.HOA
{
    public interface IQuestionAnswerBLL
    {
        ICollection<HOAQuestionAnswerDTO> GetQuestionsAnswers(int caseRefNumber);
        ICollection<HOAAnswerTypeDTO> GetAnswerTypes();
    }
}