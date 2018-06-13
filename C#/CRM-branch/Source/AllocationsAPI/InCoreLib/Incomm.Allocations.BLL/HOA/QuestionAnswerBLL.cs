using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.HOA;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using System.Collections.Generic;
using System.Linq;

namespace Incomm.Allocations.BLL.HOA
{
    public class QuestionAnswerBLL : IQuestionAnswerBLL
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionAnswerBLL() : this (new UnitOfWork())
        {
        }

        public QuestionAnswerBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<HOAAnswerTypeDTO> GetAnswerTypes()
        {
            return _unitOfWork.LstAnswerTypes().Select().AsEnumerable().Select(Mapper.Map<HOAAnswerTypeDTO>).ToList();
        }

        public ICollection<HOAQuestionAnswerDTO> GetQuestionsAnswers(int caseRefNumber)
        {
            var questionAnswers = _unitOfWork.TsubHOAQuestionAnswers().Select(qa => qa.CaseRef == caseRefNumber).ToList();
            var questions = GetQuestions(questionAnswers.Select(qa => qa.QstnID).ToList());
            var answerTypes = GetAnswerTypes();
            int? nextQuestionId = GetFirstQuestionId(questions);

            var result = new List<HOAQuestionAnswerDTO>();
            int sequenceNumber = 0;

            while (nextQuestionId != null)
            {
                var questionAnswer = questionAnswers.SingleOrDefault(q => q.QstnID == nextQuestionId);
                var question = questions.SingleOrDefault(q => q.QstnID == questionAnswer?.QstnID);

                if (questionAnswer == null || question == null)
                {
                    break;
                }

                var hoaQuestionAnswerDto = CreateHoaQuestionAnswerDto(questionAnswer, question, answerTypes, ref sequenceNumber);
                nextQuestionId = GetNextQuestionId(questionAnswer, question);
                result.Add(hoaQuestionAnswerDto);
            }
            return result;
        }

        private HOAQuestionAnswerDTO CreateHoaQuestionAnswerDto(tsubHOAQuestionAnswer questionAnswer, lstQuestion question, ICollection<HOAAnswerTypeDTO> answerTypes, ref int sequenceNumber)
        {
            return new HOAQuestionAnswerDTO
            {
                QuestionId = questionAnswer.QstnID,
                Question = question.QstnText,
                AnswerId = questionAnswer.AnswerID,
                Answer = questionAnswer.AnswerValue,
                AnswerNote = questionAnswer.Note,
                AnswerTypeId = questionAnswer.AnswerTypeID,
                HoaAnswerTypeDto = answerTypes.SingleOrDefault(at => at.AnswerTypeId == questionAnswer.AnswerTypeID),
                CalculatedSequenceNumber = sequenceNumber++
            };
        }

        private int GetFirstQuestionId(ICollection<lstQuestion> questions)
        {
            return questions.Where(q => q.QstnairID == 1 && q.PrevQstnID == 0).Select(q => q.QstnID).SingleOrDefault();
        }

        private int? GetNextQuestionId(tsubHOAQuestionAnswer questionAnswer, lstQuestion question)
        {
            if (questionAnswer.AnswerTypeID == 1 
                && questionAnswer.AnswerValue.ToLower() == "yes" 
                && question.NextQstnIDYes != null)
            {
                return question.NextQstnIDYes;
            }

            if (questionAnswer.AnswerTypeID == 1 
                && questionAnswer.AnswerValue.ToLower() == "no" 
                && question.NextQstnIDNo != null)
            {
                return question.NextQstnIDNo;
            }

            return question.NextQstnID;
        }

        private ICollection<lstQuestion> GetQuestions(IList<int> questionIds)
        {
            return _unitOfWork.LstQuestions().Select(q => questionIds.Contains(q.QstnID)).ToList();
        }
    }
}