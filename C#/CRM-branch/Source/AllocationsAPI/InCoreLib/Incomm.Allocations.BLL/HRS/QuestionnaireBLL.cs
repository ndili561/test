using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL
{
    public class QuestionnaireBLL :  IQuestionnaireBLL
    {
        private IUnitOfWork _unitOfWork;
        public QuestionnaireBLL() : this(new UnitOfWork())
        {
        }

        public QuestionnaireBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<lstQuestionDTO> GetHRSQuestions()
        {
            var questionnaire = _unitOfWork.Questions().Select().Where(x => x.QstnairID == 4 || x.QstnairID == 5);
            var lstQuestionDtoList = Mapper.Map<List<lstQuestionDTO>>(questionnaire.ToList());
            return lstQuestionDtoList;
        }

        public List<HRSQuestionAnswerDTO> GetHRSAnswers(int caseRef)
        {
            var hoaQuestionAnswer =
                _unitOfWork.HRSQuestionAnswers().Select().Where(x => x.CaseRef == caseRef && x.QstnairID >= 4);
            var hoaQuestionAnswerDtoList = Mapper.Map<List<HRSQuestionAnswerDTO>>(hoaQuestionAnswer);
            return hoaQuestionAnswerDtoList;
        }

        public List<HRSQuestionAnswerDTO> PostAnswers(List<HRSQuestionAnswerDTO> answersDtos)
        {
            var entityTobeSave = Mapper.Map<List<HRSQuestionAnswer>>(answersDtos);
            var caseRef = answersDtos.FirstOrDefault().CaseRef;
            _unitOfWork.HRSQuestionAnswers().AddRange(entityTobeSave);

            var customer = _unitOfWork.HRSCustomer().Select(x => x.HOACaseReference == caseRef, includeProperties: "HRSPlacementsMatched.Placement").FirstOrDefault();

            var firstPlacementId = _unitOfWork.HRSPlacementMatchedForCustomer().Select().FirstOrDefault(x => x.CustomerId == customer.HRSCustomerId && x.Status == Status.AcceptedByProvider || x.Status == Status.Completed).PlacementId;
            var matchHistory =
              _unitOfWork.HRSMatchHistory().Select(x => x.Customer.HRSCustomerId == customer.HRSCustomerId);

            var hrsQuestionAnswer = _unitOfWork.HRSQuestionAnswers()
                .Select()
                .FirstOrDefault(x => x.CaseRef == caseRef && x.PlacementId == firstPlacementId && x.QstnID == 201);
            if (hrsQuestionAnswer != null &&
                (answersDtos.Any(x => x.QstnID == 201)
                && DateTime.Now.Subtract(DateTime.Parse(hrsQuestionAnswer.AnswerValue)).TotalDays >= 182))
            {
                _unitOfWork.CaseNotes().Insert(new tblCaseNote
                {
                    CaseRefNumber = customer.HOACaseReference
                    ,
                    CaseNoteDate = DateTime.Today
                    ,
                    CaseNoteUserID = answersDtos.FirstOrDefault().CreatedBy
                    ,
                    CaseNoteType = "HRSExtendStay"
                    ,
                    CaseNote =
                        "Customer " + customer.Name + " has been on placement " +
                        " for six months"
                });
            }


            if (answersDtos.Any(x => x.QstnID == 300))
            {
                _unitOfWork.CaseNotes().Insert(new tblCaseNote
                {
                    CaseRefNumber = caseRef,
                    CaseNoteType = "HRSEndOfService",
                    CaseNoteDate = DateTime.Today,
                    CaseNoteUserID = answersDtos.FirstOrDefault().CreatedBy,
                    CaseNote =
                        "End of service notice for:" + customer.Name + " at " +
                        customer.HRSPlacementsMatched.FirstOrDefault(x => x.Status == Status.AcceptedByProvider).Placement.Address
                });
                customer.HRSPlacementsMatched.FirstOrDefault(x => x.PlacementId == answersDtos.FirstOrDefault().PlacementId).Status = Status.Completed;
                customer.Status = Status.Completed;
                customer.HRSPlacementsMatched.FirstOrDefault(x => x.PlacementId == answersDtos.FirstOrDefault().PlacementId).Placement.PlacementStatus = PlacementStatus.Completed;
            }

            _unitOfWork.Commit();
           return  Mapper.Map<List<HRSQuestionAnswerDTO>>(entityTobeSave);
           
        }

        public void PutAnswers(int caseRef, List<HRSQuestionAnswerDTO> answersDtos)
        {
            var answerIdList = answersDtos.Select(x => x.AnswerID).ToList();
            var persistedAnswers =
                _unitOfWork.HRSQuestionAnswers()
                    .Select()
                    .Where(x => x.CaseRef == caseRef && answerIdList.Contains(x.AnswerID))
                    .ToList();
            foreach (var answersDto in answersDtos)
            {
                var persistedAnswer = persistedAnswers.FirstOrDefault(x => x.AnswerID == answersDto.AnswerID);
                if (persistedAnswer == null) continue;
                persistedAnswer.AnswerValue = answersDto.AnswerValue;
                persistedAnswer.Note = answersDto.Note;
                persistedAnswer.ModifiedBy = answersDto.ModifiedBy;
                persistedAnswer.ModifiedDate = answersDto.ModifiedDate;
                persistedAnswer.UserIPAddress = answersDto.UserIPAddress;
                persistedAnswer.UserId = answersDto.UserId;
            }


            var customer = _unitOfWork.HRSCustomer().Select(x => x.HOACaseReference == caseRef, includeProperties: "HRSPlacementsMatched.Placement").FirstOrDefault();

            var firstPlacementId = _unitOfWork.HRSPlacementMatchedForCustomer().Select().FirstOrDefault(x => x.CustomerId == customer.HRSCustomerId && x.Status == Status.AcceptedByProvider || x.Status == Status.Completed).PlacementId;
            var matchHistory =
              _unitOfWork.HRSMatchHistory().Select(x => x.Customer.HRSCustomerId == customer.HRSCustomerId);

            var hrsQuestionAnswer = _unitOfWork.HRSQuestionAnswers()
                .Select()
                .FirstOrDefault(x => x.CaseRef == caseRef && x.PlacementId == firstPlacementId && x.QstnID == 201);
            if (hrsQuestionAnswer != null && (answersDtos.Any(x => x.QstnID == 201) &&
                                                                                 DateTime.Now.Subtract(
                                                                                 DateTime.Parse(hrsQuestionAnswer.AnswerValue)).TotalDays >= 182))

            {
                _unitOfWork.CaseNotes().Insert(new tblCaseNote
                {
                    CaseRefNumber = customer.HOACaseReference
                    ,
                    CaseNoteDate = DateTime.Today
                    ,
                    CaseNoteUserID = answersDtos.FirstOrDefault().CreatedBy
                    ,
                    CaseNoteType = "HRSExtendStay"
                    ,
                    CaseNote =
                        "Customer " + customer.Name + " has been on placement " +
                        " for six months"
                });
            }


            if (answersDtos.Any(x => x.QstnID == 300))
            {
                _unitOfWork.CaseNotes().Insert(new tblCaseNote
                {
                    CaseRefNumber = caseRef,
                    CaseNoteType = "HRSEndOfService",
                    CaseNoteDate = DateTime.Today,
                    CaseNoteUserID = answersDtos.FirstOrDefault().CreatedBy,
                    CaseNote =
                        "End of service notice for:" + customer.Name + " at " +
                        customer.HRSPlacementsMatched.FirstOrDefault(x => x.Status == Status.AcceptedByProvider).Placement.Address
                });
                customer.HRSPlacementsMatched.FirstOrDefault(x => x.PlacementId == answersDtos.FirstOrDefault().PlacementId).Status = Status.Completed;
                customer.Status = Status.Completed;
                customer.HRSPlacementsMatched.FirstOrDefault(x => x.PlacementId == answersDtos.FirstOrDefault().PlacementId).Placement.PlacementStatus = PlacementStatus.Completed;
            }

            _unitOfWork.HRSQuestionAnswers().UpdateRange(persistedAnswers);
            _unitOfWork.Commit();

            
        }
    }
}