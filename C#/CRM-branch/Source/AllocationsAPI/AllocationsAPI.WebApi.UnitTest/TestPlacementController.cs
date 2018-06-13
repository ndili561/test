using System.Collections.Generic;
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
    public class TestPlacementController : BaseTestController
    {
        [TestMethod]
        [Ignore]
        public void GetPlacement_ShouldReturnAllPlacement()
        {
            // Arrange
            HRSPlacementRepository.Expect(
                x => x.Select(includeProperties: "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer"))
                .Return(GetTestPlacements());
            UnitOfWork.Stub(x => x.Placement()).Return(HRSPlacementRepository);
            var testPlacements = GetTestPlacements().ToList();
            var controller = new PlacementController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var context = new ODataQueryContext(GetOdataModel(), typeof (HRSPlacement));
            var options = new ODataQueryOptions<HRSPlacement>(context, request);

            // Act
            var result = controller.GetPlacements(options);

            // Assert
            Assert.AreEqual(testPlacements.ToList().Count, result.Items.Count());
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        public void GetPlacement_ShouldReturnCorrectPlacement()
        {
            HRSPlacementRepository.Expect(
                x => x.Select(includeProperties: "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer"))
                .Return(GetTestPlacements());
            UnitOfWork.Expect(x => x.Placement()).Return(HRSPlacementRepository);
            var testPlacements = GetTestPlacements().ToList();
            var controller = new PlacementController(UnitOfWork);
            // Act
            var result = controller.Placement(4);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testPlacements[3].PlacementId, result.PlacementId);
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        public void GetPlacement_ShouldNotFindPlacement()
        {
            HRSPlacementRepository.Expect(
                x => x.Select(includeProperties: "ServiceTypes,SupportType,Hostel,HRSCustomersMatched.Customer"))
                .Return(GetTestPlacements());
            UnitOfWork.Stub(x => x.Placement()).Return(HRSPlacementRepository);
            var controller = new PlacementController(UnitOfWork);

            var result = controller.Placement(999);
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        [Ignore]
        public void PostMethodMustReturnPlacementDTO()
        {
            // Arrange
            HRSCustomerRepository.Expect(x => x.Select(includeProperties: "ServiceTypes,SupportTypes"))
                .Return(GetTestCustomers());
            ServiceTypeRepository.Expect(x => x.Select()).Return(GetServiceTypes());
            UnitOfWork.Expect(x => x.ServiceType()).Return(ServiceTypeRepository);
            UnitOfWork.Expect(x => x.Placement()).Return(HRSPlacementRepository);
            UnitOfWork.Expect(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            UnitOfWork.Expect(x => x.Commit()).Repeat.Times(2);
            var entityTobeSaved = new HRSPlacementDTO {PlacementId = 0, ContactName = "Customer1", ServiceTypeId = 3};
            var controller = GetPlacementController(HttpMethod.Post, "http://localhost/api/Placement/");
            // Act
            var createdResult = controller.PostHRSPlacement(entityTobeSaved);
            var resultObject = createdResult.Content.ReadAsAsync<HRSPlacementDTO>().Result;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(entityTobeSaved.ContactName, resultObject.ContactName);
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        [Ignore]
        public void PutMethodMustReturnCorrectMatch()
        {
            // Arrange
            const int customerId = 2;
            const int placementId = 1;
            const string customerName = "Customer1";
            const string selectedServiceType = "1"; //Homeless
            const int selectedSupportType = 1; // Hostel
            var placementToBeSaved = new HRSPlacementDTO
            {
                ContactName = customerName,
                PlacementId = placementId,
                MinimumBedroom = 1,
                ServiceTypeId = 1,
                SupportTypeId = selectedSupportType
            };
            HRSCustomerRepository.Expect(x => x.Select(includeProperties: "ServiceTypes,SupportTypes"))
                .Return(GetTestCustomers());
            var persistedPlacementList = GetPersistedPlacementList(placementId, customerName);
            var expectedMatch = new HRSPlacementMatchedForCustomerDTO
            {
                CustomerId = customerId,
                PlacementId = placementId
            };
            HRSPlacementRepository.Expect(
                x => x.Select(includeProperties: "HRSCustomersMatched,SupportType,ServiceTypes,Hostel"))
                .Return(persistedPlacementList);
            UnitOfWork.Expect(x => x.Placement()).Return(HRSPlacementRepository);
            UnitOfWork.Expect(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            SetStub();

            var controller = GetPlacementController(HttpMethod.Put, "http://localhost/api/Placement/");
            // Act
            var createdResult = controller.PutPlacement(placementToBeSaved.PlacementId, placementToBeSaved);
            var actualPlacement = createdResult.Content.ReadAsAsync<HRSPlacementDTO>().Result;
            // Assert
            Assert.IsNotNull(actualPlacement);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(actualPlacement.ContactName, placementToBeSaved.ContactName);
            Assert.AreEqual(actualPlacement.HRSCustomersMatched.Count, 1);
        }

        [TestMethod]
        [Ignore]
        public void PutMethodMustReturnNoMatch()
        {
            // Arrange
            const int placementId = 2;
            const string placementName = "Placement1";
            const int selectedServiceType = 4;
            const int selectedSupportType = 3;
            var placementToBeSaved = GetPlacementToBeSaved(placementName, placementId, selectedServiceType,
                selectedSupportType);
            HRSCustomerRepository.Expect(x => x.Select(includeProperties: "ServiceTypes,SupportTypes"))
                .Return(GetTestCustomers());
            var persistedPlacementList = GetPersistedPlacementList(placementId, placementName);
            HRSPlacementRepository.Expect(
                x => x.Select(includeProperties: "HRSCustomersMatched,SupportType,ServiceTypes,Hostel"))
                .Return(persistedPlacementList);
            UnitOfWork.Expect(x => x.Placement()).Return(HRSPlacementRepository);
            UnitOfWork.Expect(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            SetStub();

            var controller = GetPlacementController(HttpMethod.Put, "http://localhost/api/Placement/");
            // Act
            var createdResult = controller.PutPlacement(placementToBeSaved.PlacementId, placementToBeSaved);
            var actualPlacement = createdResult.Content.ReadAsAsync<HRSPlacementDTO>().Result;
            // Assert
            Assert.IsNotNull(actualPlacement);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(actualPlacement.ContactName, placementToBeSaved.ContactName);
            Assert.AreEqual(actualPlacement.HRSCustomersMatched.Count, 0);
        }

        private static HRSPlacementDTO GetPlacementToBeSaved(string customerName, int customerId,
            int selectedServiceType, int selectedSupportTypeId)
        {
            return new HRSPlacementDTO
            {
                ContactName = customerName,
                PlacementId = customerId,
                MinimumBedroom = 1,
                ServiceTypeId = selectedServiceType,
                SupportTypeId = selectedSupportTypeId
            };
        }

        [TestMethod]
        [Ignore]
        public void PutMethodMustReturnCorrectMatchInPlacementDTO()
        {
            // Arrange
            const int placementId = 1;
            const string placementName = "Customer1";
            const int selectedServiceType = 1;
            const int selectedSupportType = 1;
            var placementToBeSaved = GetPlacementToBeSaved(placementName, placementId, selectedServiceType,
                selectedSupportType);
            HRSCustomerRepository.Expect(x => x.Select(includeProperties: "ServiceTypes,SupportTypes"))
                .Return(GetTestCustomers());
            var persistedPlacementList = GetPersistedPlacementList(placementId, placementName);
            HRSPlacementRepository.Expect(
                x => x.Select(includeProperties: "HRSCustomersMatched,SupportType,ServiceTypes,Hostel"))
                .Return(persistedPlacementList);
            UnitOfWork.Expect(x => x.Placement()).Return(HRSPlacementRepository);
            UnitOfWork.Expect(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            SetStub();

            var controller = GetPlacementController(HttpMethod.Put, "http://localhost/api/Placement/");
            // Act
            var createdResult = controller.PutPlacement(placementToBeSaved.PlacementId, placementToBeSaved);
            var actualPlacement = createdResult.Content.ReadAsAsync<HRSPlacementDTO>().Result;
            // Assert
            Assert.IsNotNull(actualPlacement);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(actualPlacement.ContactName, placementToBeSaved.ContactName);
        }

        private IQueryable<HRSPlacement> GetPersistedPlacementList(int placementId, string contactName)
        {
            return new List<HRSPlacement>
            {
                new HRSPlacement
                {
                    ContactName = contactName,
                    PlacementId = placementId,
                    ServiceTypes = new List<ServiceType> {new ServiceType {ServiceTypeId = 1}}
                }
            }.AsQueryable();
        }

        private void SetStub()
        {
            SupportTypeRepository.Stub(x => x.Select()).Return(GetSupportTypes());
            ServiceTypeRepository.Stub(x => x.Select()).Return(GetServiceTypes());
            UnitOfWork.Stub(x => x.ServiceType()).Return(ServiceTypeRepository);
            UnitOfWork.Stub(x => x.SupportType()).Return(SupportTypeRepository);
            UnitOfWork.Stub(x => x.Commit());
        }

        private PlacementController GetPlacementController(HttpMethod httpMethod, string url)
        {
            return new PlacementController(UnitOfWork)
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