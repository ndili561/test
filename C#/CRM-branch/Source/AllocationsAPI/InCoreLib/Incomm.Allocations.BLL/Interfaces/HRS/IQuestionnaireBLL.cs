using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface IQuestionnaireBLL
    {
        List<lstQuestionDTO> GetHRSQuestions();
        List<HRSQuestionAnswerDTO> GetHRSAnswers(int caseRef);
        List<HRSQuestionAnswerDTO> PostAnswers(List<HRSQuestionAnswerDTO> answersDtos);
        void PutAnswers(int caseRef, List<HRSQuestionAnswerDTO> answersDtos);
    }
}