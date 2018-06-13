using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using AllocationsAPI.WebAPI.Controllers;
using AllocationsAPI.WebAPI.Controllers.HRS.V1._0._0;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class TestAuditLogController : BaseTestController
    {
        [TestMethod]
        public void GetAuditLogs_ShouldReturnAllAuditLogs()
        {
            // Arrange
            AuditLogRepository.Expect(x => x.Select(includeProperties: "AuditLogDetails")).Return(GetTestAuditLogs());
            UnitOfWork.Stub(x => x.AuditLogs()).Return(AuditLogRepository);
            var testAuditLogs = GetTestAuditLogs().ToList();
            var controller = new AuditLogController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var context = new ODataQueryContext(GetOdataModel(), typeof (AuditLog));
            var options = new ODataQueryOptions<AuditLog>(context, request);

            // Act
            var result = controller.GetAuditLogs(options);

            // Assert
            Assert.AreEqual(testAuditLogs.ToList().Count, result.Items.Count());
            UnitOfWork.VerifyAllExpectations();
        }
    }
}