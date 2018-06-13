using System;
using System.Net.Http;
using System.Web.Http.Hosting;
using AllocationsAPI.WebAPI.Controllers;
using AllocationsAPI.WebAPI.Controllers.HRS.V1._0._0;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class TestCaseNoteController : BaseTestController
    {
        [TestMethod]
        public void PostMethodMustReturnCaseNoteDTO()
        {
            // Arrange

            CaseNoteRepository.Expect(x => x.Insert(new tblCaseNote()));
            UnitOfWork.Expect(x => x.CaseNotes()).Return(CaseNoteRepository);
            UnitOfWork.Expect(x => x.Commit()).Repeat.Times(1);
            var entityTobeSaved = new tblCaseNoteDTO
            {
                CaseRefNumber = 1,
                CaseNoteIndex = 1,
                CaseNoteDate = DateTime.Today,
                CaseNoteUserID = "1",
                CaseNoteType = "Test",
                CaseNote = "Test",
                CaseNoteConfidentialFlag = false,
                CaseNoteConfidentialFlagDateSet = null,
                CaseNoteLastEditedDateTime = null
            };
            var controller = GetCaseNoteController(HttpMethod.Post, "http://localhost/api/CaseNote/");
            // Act
            var createdResult = controller.PostCaseNote(entityTobeSaved);
            var resultObject = createdResult.Content.ReadAsAsync<tblCaseNoteDTO>().Result;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(entityTobeSaved.CaseNoteType, resultObject.CaseNoteType);
            UnitOfWork.VerifyAllExpectations();
        }


        private CaseNoteController GetCaseNoteController(HttpMethod httpMethod, string url)
        {
            return new CaseNoteController(UnitOfWork)
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