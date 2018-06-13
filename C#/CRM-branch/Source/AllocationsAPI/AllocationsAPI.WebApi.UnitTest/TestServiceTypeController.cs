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
    public class TestServiceTypeController : BaseTestController
    {
        IServiceTypeBLL _serviceTypeBll = MockRepository.GenerateMock<IServiceTypeBLL>();
        [TestMethod]
        public void ServiceTypeList_ShouldReturnAllServiceTypes()
        {
            // Arrange
           
            ServiceTypeRepository.Expect(x => x.Select()).Return(GetServiceTypes());
            UnitOfWork.Stub(x => x.ServiceType()).Return(ServiceTypeRepository);
            var testServiceTypes = GetServiceTypes().ToList();
            var controller = new ServiceTypeController(_serviceTypeBll)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");

            // Act
            var result = controller.ServiceTypeList();

            // Assert
            Assert.AreEqual(testServiceTypes.ToList().Count, result.AsEnumerable().Count());
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void ServiceType_ShouldReturnCorrectServiceType()
        {
            ServiceTypeRepository.Expect(x => x.Select()).Return(GetServiceTypes());
            UnitOfWork.Expect(x => x.ServiceType()).Return(ServiceTypeRepository);
            var testServiceTypes = GetServiceTypes().ToList();
            var controller = new ServiceTypeController(_serviceTypeBll);
            // Act
            var result = controller.ServiceType(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testServiceTypes[0].ServiceTypeId, result.ServiceTypeId);
            Assert.AreEqual(testServiceTypes[0].Code, result.Code);
            Assert.AreEqual(testServiceTypes[0].Description, result.Description);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void ServiceType_ShouldNotFindServiceType()
        {
            ServiceTypeRepository.Expect(x => x.Select()).Return(GetServiceTypes());
            UnitOfWork.Stub(x => x.ServiceType()).Return(ServiceTypeRepository);
            var controller = new ServiceTypeController(_serviceTypeBll);

            var result = controller.ServiceType(999);
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void PostMethodMustReturnServiceTypeDTO()
        {
            // Arrange
            UnitOfWork.Expect(x => x.ServiceType()).Return(ServiceTypeRepository);
            UnitOfWork.Expect(x => x.Commit()).Repeat.Times(1);
            var entityTobeSaved = new ServiceTypeDTO { ServiceTypeId = 0, Code = "Code", Description = "Description" };
            var controller = GetServiceTypeController(HttpMethod.Post, "http://localhost/api/ServiceType/");
            // Act
            var createdResult = controller.PostServiceType(entityTobeSaved);
            var resultObject = createdResult.Content.ReadAsAsync<ServiceTypeDTO>().Result;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(entityTobeSaved.Code, resultObject.Code);
            Assert.AreEqual(entityTobeSaved.Description, resultObject.Description);
            UnitOfWork.VerifyAllExpectations();
        }

        private ServiceTypeController GetServiceTypeController(HttpMethod httpMethod, string url)
        {
            return new ServiceTypeController(_serviceTypeBll)
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