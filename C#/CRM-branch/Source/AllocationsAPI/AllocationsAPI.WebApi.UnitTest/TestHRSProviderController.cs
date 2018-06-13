using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using AllocationsAPI.WebAPI.Controllers;
using AllocationsAPI.WebAPI.Controllers.HRS.V1._0._0;
using InCoreLib.Domain.Allocations.Database;
using Incomm.Allocations.BLL.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class TestHRSProviderController : BaseTestController
    {
        [TestMethod]
        public void GetHRSProviders_ShouldReturnAllProviders()
        {
            // Arrange
            HRSProviderRepository.Expect(x => x.Select()).Return(GetTestProviders());
            UnitOfWork.Stub(x => x.HRSProvider()).Return(HRSProviderRepository);
            var testHRSProviders = GetTestProviders().ToList();
            var controller = new HRSProviderController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var context = new ODataQueryContext(GetOdataModel(), typeof (HRSProvider));
            var options = new ODataQueryOptions<HRSProvider>(context, request);

            // Act
            var result = controller.GetHRSProviders(options);

            // Assert
            Assert.AreEqual(testHRSProviders.ToList().Count, result.Items.Count());
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetHRSProvider_ShouldReturnCorrectHRSProvider()
        {
            HRSProviderRepository.Expect(x => x.Select()).Return(GetTestProviders());
            UnitOfWork.Expect(x => x.HRSProvider()).Return(HRSProviderRepository);
            var testHRSProviders = GetTestProviders().ToList();
            var controller = new HRSProviderController(UnitOfWork);
            // Act
            var result = controller.GetHRSProvider(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testHRSProviders[0].HRSProviderId, result.HRSProviderId);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetHRSProvider_ShouldNotFindHRSProvider()
        {
            HRSProviderRepository.Expect(x => x.Select()).Return(GetTestProviders());
            UnitOfWork.Stub(x => x.HRSProvider()).Return(HRSProviderRepository);
            var controller = new HRSProviderController(UnitOfWork);

            var result = controller.GetHRSProvider(999);
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void PostMethodMustReturnHRSProviderDTO()
        {
            // Arrange
            UnitOfWork.Expect(x => x.HRSProvider()).Return(HRSProviderRepository);
            UnitOfWork.Expect(x => x.Commit()).Repeat.Times(1);
            var entityTobeSaved = new HRSProviderDTO {HRSProviderId = 0, Code = "Code", Description = "Description"};
            var controller = GetHRSProviderController(HttpMethod.Post, "http://localhost/api/HRSProvider/");
            // Act
            var createdResult = controller.PostHRSProvider(entityTobeSaved);
            var resultObject = createdResult.Content.ReadAsAsync<HRSProviderDTO>().Result;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(entityTobeSaved.Code, resultObject.Code);
            Assert.AreEqual(entityTobeSaved.Description, resultObject.Description);
            UnitOfWork.VerifyAllExpectations();
        }


        private HRSProviderController GetHRSProviderController(HttpMethod httpMethod, string url)
        {
            return new HRSProviderController(UnitOfWork)
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