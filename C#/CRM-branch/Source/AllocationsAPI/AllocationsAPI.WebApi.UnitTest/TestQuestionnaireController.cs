using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using AllocationsAPI.WebAPI.Controllers;
using AllocationsAPI.WebAPI.Controllers.HRS.V1._0._0;
using Incomm.Allocations.BLL.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class TestQuestionnaireController : BaseTestController
    {
        [TestMethod]
        public void GetHRSQuestions_ShouldReturnAllQuestions()
        {
            // Arrange
            QuestionRepository.Expect(x => x.Select()).Return(GetTestHRSQuestions());
            UnitOfWork.Stub(x => x.Questions()).Return(QuestionRepository);
            var testQuestions = GetTestHRSQuestions().ToList();
            var controller = new QuestionnaireController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");

            // Act
            var result = controller.GetHRSQuestions();

            // Assert
            Assert.AreEqual(testQuestions.ToList().Count, result.AsEnumerable().Count());
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetHRSAnswers_ShouldReturnAllCorrectAnswers()
        {
            HRSQuestionAnswerRepository.Expect(x => x.Select()).Return(GetTestHRSAnswers());
            UnitOfWork.Expect(x => x.HRSQuestionAnswers()).Return(HRSQuestionAnswerRepository);
            var testHRSAnswers = GetTestHRSAnswers().ToList();
            var controller = new QuestionnaireController(UnitOfWork);
            // Act
            var result = controller.GetHRSAnswers(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testHRSAnswers[0].AnswerID, result[0].AnswerID);
            Assert.AreEqual(testHRSAnswers[0].CaseRef, result[0].CaseRef);
            Assert.AreEqual(testHRSAnswers[0].AnswerValue, result[0].AnswerValue);
            Assert.AreEqual(testHRSAnswers[1].AnswerID, result[1].AnswerID);
            Assert.AreEqual(testHRSAnswers[1].CaseRef, result[1].CaseRef);
            Assert.AreEqual(testHRSAnswers[1].AnswerValue, result[1].AnswerValue);

            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetHRSAnswers_ShouldNotReturnAnyResult()
        {
            HRSQuestionAnswerRepository.Expect(x => x.Select()).Return(GetTestHRSAnswers());
            UnitOfWork.Stub(x => x.HRSQuestionAnswers()).Return(HRSQuestionAnswerRepository);
            var controller = new QuestionnaireController(UnitOfWork);

            var result = controller.GetHRSAnswers(999);
            Assert.IsTrue(!result.Any());
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        [Ignore]
        public void PostMethodMustReturnHRSQuestionAnswerDTO()
        {
            // Arrange
            UnitOfWork.Expect(x => x.HRSQuestionAnswers()).Return(HRSQuestionAnswerRepository);
            UnitOfWork.Expect(x => x.Commit()).Repeat.Times(1);
            var entitiesTobeSaved = GetTestHRSAnswersDTO().ToList();


            var controller = GetQuestionnaireController(HttpMethod.Post, "http://localhost/api/Questionnaire/");
            // Act
            var createdResult = controller.PostAnswers(entitiesTobeSaved);
            var resultObject = createdResult.Content.ReadAsAsync<List<HRSQuestionAnswerDTO>>().Result;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);

            Assert.AreEqual(entitiesTobeSaved[0].AnswerID, resultObject[0].AnswerID);
            Assert.AreEqual(entitiesTobeSaved[0].CaseRef, resultObject[0].CaseRef);
            Assert.AreEqual(entitiesTobeSaved[0].AnswerValue, resultObject[0].AnswerValue);
            Assert.AreEqual(entitiesTobeSaved[1].AnswerID, resultObject[1].AnswerID);
            Assert.AreEqual(entitiesTobeSaved[1].CaseRef, resultObject[1].CaseRef);
            Assert.AreEqual(entitiesTobeSaved[1].AnswerValue, resultObject[1].AnswerValue);

            UnitOfWork.VerifyAllExpectations();
        }

        private QuestionnaireController GetQuestionnaireController(HttpMethod httpMethod, string url)
        {
            return new QuestionnaireController(UnitOfWork)
            {
                Request = new HttpRequestMessage(httpMethod, url)
                {
                    Properties =
                    {
                        {HttpPropertyKeys.HttpConfigurationKey, HttpConfiguration},
                        {HttpPropertyKeys.HttpRouteDataKey, HttpRouteData}
                    }
                }
            };
        }
    }
}