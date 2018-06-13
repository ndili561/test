using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using AllocationsAPI.WebAPI.Controllers;
using AllocationsAPI.WebAPI.Controllers.HRS.V1._0._0;
using InCoreLib.Domain.Allocations.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class TestHRSAlertController : BaseTestController
    {
        [TestMethod]
        public void GetHRSAlerts_ShouldReturn_Paged_HRSAlerts()
        {
            // Arrange
            HRSAlertRepository.Expect(x => x.Select()).Return(GetTestAlerts());
            UnitOfWork.Stub(x => x.HRSAlert()).Return(HRSAlertRepository);
            var testHRSAlerts = GetTestAlerts().ToList();
            var controller = new HRSAlertController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var context = new ODataQueryContext(GetOdataModel(), typeof (HRSAlert));
            var options = new ODataQueryOptions<HRSAlert>(context, request);

            // Act
            var result = controller.GetHRSAlerts(options);

            // Assert
            Assert.AreEqual(testHRSAlerts.ToList().Count, result.Items.Count());
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetAlert_ShouldReturnCorrectAlert()
        {
            AlertRepository.Expect(x => x.Select()).Return(GetTestAlerts());
            UnitOfWork.Expect(x => x.HRSAlert()).Return(AlertRepository);
            var testAlerts = GetTestAlerts().ToList();
            var controller = new HRSAlertController(UnitOfWork);
            // Act
            var result = controller.GetAlert(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testAlerts[0].CaseRef, result.CaseRef);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetAlert_ShouldNotFindAlert()
        {
            AlertRepository.Expect(x => x.Select()).Return(GetTestAlerts());
            UnitOfWork.Stub(x => x.HRSAlert()).Return(AlertRepository);
            var controller = new HRSAlertController(UnitOfWork);

            var result = controller.GetAlert(999);
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }


        private HRSAlertController GetHRSAlertController(HttpMethod httpMethod, string url)
        {
            return new HRSAlertController(UnitOfWork)
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