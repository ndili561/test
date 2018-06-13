using Incomm.Allocations.BLL.HOA;
using Incomm.Allocations.BLL.Interfaces.HOA;
using Incomm.Allocations.DTO;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AllocationsAPI.WebAPI.Controllers.HOA
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HOA")]
    public class AssessmentController : ApiController
    {
        private readonly IAssessmentBLL _assesmentBll;

        public AssessmentController()
        {
            _assesmentBll = new AssessmentBLL();
        }

        [HttpGet]
        [Route("Assessments/GetAssessment")]
        public HOAssessmentDTO GetAssessment(int caseRefNumber)
        {
            return _assesmentBll.GetAssessment(caseRefNumber);
        }

        [HttpGet]
        [Route("Assessments/GetAssessmentByCustomerApplicationId")]
        public HOAssessmentDTO GetAssessmentByCustomerApplicationId(int customerApplicationId)
        {
            return _assesmentBll.GetAssessmentByCustomerApplicationId(customerApplicationId);
        }
    }
}
