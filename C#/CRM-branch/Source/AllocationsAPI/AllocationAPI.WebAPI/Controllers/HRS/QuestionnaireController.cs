using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Incomm.Allocations.BLL;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class QuestionnaireController : BaseController
    {
        private IQuestionnaireBLL _questionnaireBLL;

        public QuestionnaireController() : this(new QuestionnaireBLL())
        {
        }

        public QuestionnaireController(IQuestionnaireBLL questionnaireBLL)
        {
            _questionnaireBLL = questionnaireBLL;
        }

      
        [HttpGet]
        [Route("Questionnaire/GetHRSQuestions")]
        public List<lstQuestionDTO> GetHRSQuestions()
        {
            return _questionnaireBLL.GetHRSQuestions();
        }

        [HttpGet]
        [Route("Questionnaire/GetHRSAnswers")]
        public List<HRSQuestionAnswerDTO> GetHRSAnswers(int caseRef)
        {
            return _questionnaireBLL.GetHRSAnswers(caseRef);
        }

        [HttpPost]
        [Route("Questionnaire")]
        public HttpResponseMessage PostAnswers(List<HRSQuestionAnswerDTO> answersDtos)
        {
            var item = _questionnaireBLL.PostAnswers(answersDtos);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            return response;
        }

        [HttpPut]
        [Route("Questionnaire/Questionnaire")]
        public HttpResponseMessage PutAnswers(int caseRef, List<HRSQuestionAnswerDTO> answersDtos)
        {
           _questionnaireBLL.PutAnswers(caseRef,answersDtos);
            var response = Request.CreateResponse<HttpStatusCode>(HttpStatusCode.OK);
           
            return response;
        }
    }
}