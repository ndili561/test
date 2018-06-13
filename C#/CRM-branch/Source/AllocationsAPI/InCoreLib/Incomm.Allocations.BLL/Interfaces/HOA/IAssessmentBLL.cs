using Incomm.Allocations.DTO;

namespace Incomm.Allocations.BLL.Interfaces.HOA
{
    public interface IAssessmentBLL
    {
        HOAssessmentDTO GetAssessment(int caseRefNumber);
        HOAssessmentDTO GetAssessmentByCustomerApplicationId(int customerApplicationId);
    }
}