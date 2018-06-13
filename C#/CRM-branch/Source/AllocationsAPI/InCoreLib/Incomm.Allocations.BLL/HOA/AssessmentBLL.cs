using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.HOA;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using System.Linq;

namespace Incomm.Allocations.BLL.HOA
{
    public class AssessmentBLL : IAssessmentBLL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICaseNotesBLL _caseNotesBll;
        private readonly IApplicationBLL _vblApplicationBll;
        private readonly IQuestionAnswerBLL _questionAndAnswerBll;

        public AssessmentBLL() : this(new UnitOfWork(), new CaseNotesBLL(), new ApplicationBLL(), new QuestionAnswerBLL())
        {
        }

        public AssessmentBLL(IUnitOfWork unitOfWork, ICaseNotesBLL caseNotesBll, IApplicationBLL vblApplicationBll, IQuestionAnswerBLL questionAndAnswerBll)
        {
            _unitOfWork = unitOfWork;
            _caseNotesBll = caseNotesBll;
            _vblApplicationBll = vblApplicationBll;
            _questionAndAnswerBll = questionAndAnswerBll;
        }

        public HOAssessmentDTO GetAssessment(int caseRefNumber)
        {
            var hoAssessmentDto =
                _unitOfWork.TblHOAssessments()
                    .Select(a => a.CaseRefNumber == caseRefNumber)
                    .AsEnumerable()
                    .Select(Mapper.Map<HOAssessmentDTO>)
                    .SingleOrDefault();

            if (hoAssessmentDto == null)
            {
                return null;
            }

            hoAssessmentDto.HoaUserAdminDto = _unitOfWork.TblUserAdmins()
                    .Select(a => a.UserID == hoAssessmentDto.AssessorUserID)
                    .AsEnumerable()
                    .Select(Mapper.Map<HOAUserAdminDTO>)
                    .SingleOrDefault();

            hoAssessmentDto.HoaContactTypeDto = _unitOfWork.LstContactTypes()
                    .Select(a => a.ContactPref == hoAssessmentDto.AssessmentContactType)
                    .AsEnumerable()
                    .Select(Mapper.Map<HOAContactTypeDTO>)
                    .FirstOrDefault();

            hoAssessmentDto.HoaEthnicityDto = _unitOfWork.LstEthnicities()
                    .Select(a => a.EthnicityCode == hoAssessmentDto.Ethnicity)
                    .AsEnumerable()
                    .Select(Mapper.Map<lstEthnicity, HOAEthnicityDTO>)
                    .SingleOrDefault();

            hoAssessmentDto.HoaNationalityTypeDto = _unitOfWork.LstNationalityTypes()
                    .Select(a => a.NationalityType == hoAssessmentDto.RTANationality)
                    .AsEnumerable()
                    .Select(Mapper.Map<HOANationalityTypeDTO>)
                    .SingleOrDefault();

            hoAssessmentDto.HoaApproachReasonDto = _unitOfWork.LstApproachReasons()
                    .Select(a => a.ApproachReasonCode == hoAssessmentDto.AssessmentApproachReason)
                    .AsEnumerable()
                    .Select(Mapper.Map<HOAApproachReasonDTO>)
                    .SingleOrDefault();

            hoAssessmentDto.HoaEligibilityRightsDto = _unitOfWork.LstEligibilityRights()
                    .Select(a => a.EligibilityRights == hoAssessmentDto.RTAEligibilityRights)
                    .AsEnumerable()
                    .Select(Mapper.Map<HOAEligibilityRightsDTO>)
                    .SingleOrDefault();

            hoAssessmentDto.HoaCaseNoteDto = _caseNotesBll.GetCaseNotes(caseRefNumber);

            hoAssessmentDto.HoaQuestionAndAnswerDto = _questionAndAnswerBll.GetQuestionsAnswers(caseRefNumber);

            return hoAssessmentDto;
        }

        public HOAssessmentDTO GetAssessmentByCustomerApplicationId(int applicationId)
        {
            var application = _vblApplicationBll.GetApplication(applicationId);

            return application?.HOACaseRef != null ? GetAssessment((int)application.HOACaseRef) : null;
        }
    }
}
