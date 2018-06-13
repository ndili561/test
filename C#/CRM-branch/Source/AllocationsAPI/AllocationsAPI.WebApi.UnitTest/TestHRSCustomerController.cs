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
    public class TestHRSCustomerController : BaseTestController
    {
        [TestMethod]
        [Ignore]
        public void GetHRSCustomers_ShouldReturnAllCustomers()
        {
            // Arrange
            HRSCustomerRepository.Expect(x => x.Select(includeProperties: "SupportTypes")).Return(GetTestCustomers());
            UnitOfWork.Stub(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            var testHRSCustomers = GetTestCustomers().ToList();
            var controller = new HRSCustomerController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var context = new ODataQueryContext(GetOdataModel(), typeof (HRSCustomer));
            var options = new ODataQueryOptions<HRSCustomer>(context, request);

            // Act
            var result = controller.GetCustomers(options);

            // Assert
            Assert.AreEqual(testHRSCustomers.ToList().Count, result.Items.Count());
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        public void GetHRSCustomer_ShouldReturnCorrectHRSCustomer()
        {
            HRSCustomerRepository.Expect(
                x => x.Select(includeProperties: "SupportTypes,ServiceTypes,HRSPlacementsMatched.Placement.HRSProvider"))
                .Return(GetTestCustomers());
            UnitOfWork.Expect(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            var testHRSCustomers = GetTestCustomers().ToList();
            var controller = new HRSCustomerController(UnitOfWork);
            // Act
            var result = controller.HRSCustomer(4);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testHRSCustomers[3].HRSCustomerId, result.HRSCustomerId);
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        [Ignore]
        public void GetHRSCustomer_ShouldNotFindHRSCustomer()
        {
            HRSCustomerRepository.Expect(
                x => x.Select(includeProperties: "SupportTypes,ServiceTypes,HRSPlacementsMatched.Placement.HRSProvider"))
                .Return(GetTestCustomers());
            UnitOfWork.Stub(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            var controller = new HRSCustomerController(UnitOfWork);

            var result = controller.HRSCustomer(999);
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        public void PostMethodMustReturnHRSCustomerDTO()
        {
            // Arrange

            CaseNoteRepository.Expect(x => x.Insert(new tblCaseNote()));
            UnitOfWork.Expect(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            UnitOfWork.Expect(x => x.CaseNotes()).Return(CaseNoteRepository);
            UnitOfWork.Expect(x => x.Commit()).Repeat.Times(2);
            var entityTobeSaved = new HRSCustomerDTO {HRSCustomerId = 0, Name = "Customer1"};
            var controller = GetHRSCustomerController(HttpMethod.Post, "http://localhost/api/HRSCustomer/");
            // Act
            var createdResult = controller.PostHRSCustomer(entityTobeSaved);
            var resultObject = createdResult.Content.ReadAsAsync<HRSCustomerDTO>().Result;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(entityTobeSaved.Name, resultObject.Name);
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
            const string selectedServiceType = "2"; //Young Person
            const string selectedSupportType = "1"; // Hostel
            var customerToBeSaved = new HRSCustomerDTO
            {
                Name = customerName,
                HRSCustomerId = customerId,
                MinBedroomSize = 1,
                SelectedServiceType = new[] {selectedServiceType},
                SelectedSupportType = new[] {selectedSupportType}
            };
            var persistedCustomerList = GetPersistedCustomerList(customerId, customerName);
            var expectedMatch = new HRSPlacementMatchedForCustomerDTO
            {
                CustomerId = customerId,
                PlacementId = placementId
            };
            HRSCustomerRepository.Expect(
                x => x.Select(includeProperties: "SupportTypes,ServiceTypes,HRSPlacementsMatched"))
                .Return(persistedCustomerList);
            HRSPlacementRepository.Expect(x => x.Select()).Return(GetTestPlacements());
            SetExpectation();

            var controller = GetHRSCustomerController(HttpMethod.Put, "http://localhost/api/HRSCustomer/");
            // Act
            var createdResult = controller.PutHRSCustomer(customerToBeSaved.HRSCustomerId, customerToBeSaved);
            var actualCustomer = createdResult.Content.ReadAsAsync<HRSCustomerDTO>().Result;
            // Assert
            Assert.IsNotNull(actualCustomer);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(customerToBeSaved.Name, actualCustomer.Name);
            Assert.AreEqual(actualCustomer.HRSPlacementsMatched.First().CustomerId, expectedMatch.CustomerId);
            Assert.AreEqual(actualCustomer.HRSPlacementsMatched.First().PlacementId, expectedMatch.PlacementId);
            Assert.IsTrue(actualCustomer.HRSPlacementsMatched.Count == 2);
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        [Ignore]
        public void PutMethodMustReturnNoMatch()
        {
            // Arrange
            const int customerId = 2;
            const string customerName = "Customer1";
            const string selectedServiceType = "2";
            const string selectedSupportType = "2";
            var customerToBeSaved = GetCustomerToBeSaved(customerName, customerId, selectedServiceType,
                selectedSupportType);
            var persistedCustomerList = GetPersistedCustomerList(customerId, customerName);
            HRSCustomerRepository.Expect(
                x => x.Select(includeProperties: "SupportTypes,ServiceTypes,HRSPlacementsMatched"))
                .Return(persistedCustomerList);
            HRSPlacementRepository.Expect(x => x.Select()).Return(GetTestPlacements());
            SetExpectation();

            var controller = GetHRSCustomerController(HttpMethod.Put, "http://localhost/api/HRSCustomer/");
            // Act
            var createdResult = controller.PutHRSCustomer(customerToBeSaved.HRSCustomerId, customerToBeSaved);
            var actualCustomer = createdResult.Content.ReadAsAsync<HRSCustomerDTO>().Result;
            // Assert
            Assert.IsNotNull(actualCustomer);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(customerToBeSaved.Name, actualCustomer.Name);
            Assert.IsTrue(actualCustomer.HRSPlacementsMatched.Count == 0);
            UnitOfWork.VerifyAllExpectations();
        }

        private static HRSCustomerDTO GetCustomerToBeSaved(string customerName, int customerId,
            string selectedServiceType, string selectedSupportType)
        {
            return new HRSCustomerDTO
            {
                Name = customerName,
                HRSCustomerId = customerId,
                MinBedroomSize = 1,
                SelectedServiceType = new[] {selectedServiceType},
                SelectedSupportType = new[] {selectedSupportType}
            };
        }

        [TestMethod]
        [Ignore]
        public void PutMethodMustReturnCorrectMatchInHRSCustomerDTO()
        {
            // Arrange
            const int customerId = 1;
            const string customerName = "Customer1";
            const string selectedServiceType = "1";
            const string selectedSupportType = "1";
            var customerToBeSaved = GetCustomerToBeSaved(customerName, customerId, selectedServiceType,
                selectedSupportType);
            var persistedCustomerList = GetPersistedCustomerList(customerId, customerName);
            var expectedMatch = new HRSPlacementMatchedForCustomerDTO {CustomerId = customerId, PlacementId = 1};
            HRSCustomerRepository.Expect(
                x => x.Select(includeProperties: "SupportTypes,ServiceTypes,HRSPlacementsMatched"))
                .Return(persistedCustomerList);
            HRSPlacementRepository.Expect(x => x.Select()).Return(GetTestPlacements());
            SetExpectation();

            var controller = GetHRSCustomerController(HttpMethod.Put, "http://localhost/api/HRSCustomer/");
            // Act
            var createdResult = controller.PutHRSCustomer(customerToBeSaved.HRSCustomerId, customerToBeSaved);
            var actualCustomer = createdResult.Content.ReadAsAsync<HRSCustomerDTO>().Result;
            // Assert
            Assert.IsNotNull(actualCustomer);
            Assert.IsTrue(createdResult.IsSuccessStatusCode);
            Assert.AreEqual(customerToBeSaved.Name, actualCustomer.Name);
            Assert.AreEqual(actualCustomer.HRSPlacementsMatched.First().CustomerId, expectedMatch.CustomerId);
            Assert.AreEqual(actualCustomer.HRSPlacementsMatched.First().PlacementId, expectedMatch.PlacementId);
            UnitOfWork.VerifyAllExpectations();
        }

        private IQueryable<HRSCustomer> GetPersistedCustomerList(int customerId, string customerName)
        {
            return new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    Name = customerName,
                    HRSCustomerId = customerId,
                    HRSPlacementsMatched = new List<HRSPlacementMatchedForCustomer>
                    {
                        new HRSPlacementMatchedForCustomer
                        {
                            CustomerId = 1,
                            PlacementId = 4
                        }
                    }
                }
            }.AsQueryable();
        }

        private void SetExpectation()
        {
            SupportTypeRepository.Expect(x => x.Select()).Return(GetSupportTypes());
            ServiceTypeRepository.Expect(x => x.Select()).Return(GetServiceTypes());


            UnitOfWork.Expect(x => x.ServiceType()).Return(ServiceTypeRepository);
            UnitOfWork.Expect(x => x.SupportType()).Return(SupportTypeRepository);
            UnitOfWork.Expect(x => x.Placement()).Return(HRSPlacementRepository);
            UnitOfWork.Expect(x => x.HRSCustomer()).Return(HRSCustomerRepository);
            UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(HRSPlacementMatchedForCustomerRepository);

            UnitOfWork.Expect(x => x.Commit());
        }

        private HRSCustomerController GetHRSCustomerController(HttpMethod httpMethod, string url)
        {
            return new HRSCustomerController(UnitOfWork)
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