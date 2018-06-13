using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using AllocationsAPI.WebAPI.Controllers;
using AllocationsAPI.WebAPI.Controllers.HRS.V1._0._0;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class TestSupportTypeController : BaseTestController
    {
        ISupportTypeBLL _supportTypeBLL = MockRepository.GenerateMock<ISupportTypeBLL>();

        [TestMethod]
        public void SupportTypeList_ShouldReturnAllSupportTypes()
        {
            // Arrange
            SupportTypeRepository.Expect(x => x.Select()).Return(GetSupportTypes());
            UnitOfWork.Stub(x => x.SupportType()).Return(SupportTypeRepository);
            var testSupportTypes = GetSupportTypes().ToList();
            var controller = new SupportTypeController(_supportTypeBLL)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");

            // Act
            var result = controller.SupportTypeList();

            // Assert
            Assert.AreEqual(testSupportTypes.ToList().Count, result.AsEnumerable().Count());
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void SupportType_ShouldReturnCorrectSupportType()
        {
            SupportTypeRepository.Expect(x => x.Select()).Return(GetSupportTypes());
            UnitOfWork.Expect(x => x.SupportType()).Return(SupportTypeRepository);
            var testSupportTypes = GetSupportTypes().ToList();
            var controller = new SupportTypeController(_supportTypeBLL);
            // Act
            var result = controller.SupportType(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testSupportTypes[0].SupportTypeId, result.SupportTypeId);
            Assert.AreEqual(testSupportTypes[0].Code, result.Code);
            Assert.AreEqual(testSupportTypes[0].Description, result.Description);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void SupportType_ShouldNotFindSupportType()
        {
            SupportTypeRepository.Expect(x => x.Select()).Return(GetSupportTypes());
            UnitOfWork.Stub(x => x.SupportType()).Return(SupportTypeRepository);
            var controller = new SupportTypeController(_supportTypeBLL);

            var result = controller.SupportType(999);
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void PostMethodMustReturnSupportTypeDTO()
        {
            // Arrange
            UnitOfWork.Expect(x => x.SupportType()).Return(SupportTypeRepository);
            UnitOfWork.Expect(x => x.Commit()).Repeat.Times(1);
            var entityTobeSaved = new SupportTypeDTO {SupportTypeId = 0, Code = "Code", Description = "Description"};
            var controller = GetSupportTypeController(HttpMethod.Post, "http://localhost/api/SupportType/");
            // Act
            var createdResult = controller.PostSupportType(entityTobeSaved);
            var resultObject = createdResult.Content.ReadAsAsync<SupportTypeDTO>().Result;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(entityTobeSaved.Code, resultObject.Code);
            Assert.AreEqual(entityTobeSaved.Description, resultObject.Description);
            UnitOfWork.VerifyAllExpectations();
        }


        private SupportTypeController GetSupportTypeController(HttpMethod httpMethod, string url)
        {
            return new SupportTypeController(_supportTypeBLL)
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