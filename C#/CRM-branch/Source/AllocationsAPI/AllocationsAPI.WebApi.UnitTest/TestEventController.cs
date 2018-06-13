using System;
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
    public class TestEventController : BaseTestController
    {
        [TestMethod]
        public void GetGetAllEvents_ShouldReturnAllEvents()
        {
            // Arrange
            EventRepository.Expect(x => x.Select()).Return(GetTestEvents());
            UnitOfWork.Stub(x => x.tsubHOAEvent()).Return(EventRepository);
            var testEvents = GetTestEvents().ToList();
            var controller = new EventController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");


            // Act
            var result = controller.GetAllEvents();

            // Assert
            Assert.AreEqual(testEvents.ToList().Count, result.AsQueryable().Count());
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetEvent_ShouldReturnCorrectEvent()
        {
            EventRepository.Expect(x => x.Select()).Return(GetTestEvents());
            UnitOfWork.Expect(x => x.tsubHOAEvent()).Return(EventRepository);
            var testEvents = GetTestEvents().ToList();
            var controller = new EventController(UnitOfWork);
            // Act
            var result = controller.GetEvent(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testEvents[0].CaseRef, result.CaseRef);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetEvent_ShouldNotFindEvent()
        {
            EventRepository.Expect(x => x.Select()).Return(GetTestEvents());
            UnitOfWork.Stub(x => x.tsubHOAEvent()).Return(EventRepository);
            var controller = new EventController(UnitOfWork);

            var result = controller.GetEvent(999);
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }


      


        private EventController GetEventController(HttpMethod httpMethod, string url)
        {
            return new EventController(UnitOfWork)
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