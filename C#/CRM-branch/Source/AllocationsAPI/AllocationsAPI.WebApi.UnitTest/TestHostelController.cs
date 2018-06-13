using System.Linq;
using System.Net.Http;
using System.Web.Http;
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
    public class TestHostelController : BaseTestController
    {
        [TestMethod]
        public void GetAllHostels_ShouldReturnAllHostels()
        {
            //Arrange
            HostelRepository.Expect(x => x.Select(includeProperties: "HrsProvider")).Return(GetTestHostels());
            UnitOfWork.Stub(x => x.Hostel()).Return(HostelRepository);
            var testHostels = GetTestHostels();
            var controller = new HostelController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var context = new ODataQueryContext(GetOdataModel(), typeof (Hostel));
            var options = new ODataQueryOptions<Hostel>(context, request);
            //Act
            var result = controller.GetHostels(options);
            //Assert
            Assert.AreEqual(testHostels.ToList().Count, result.Items.Count());
            UnitOfWork.VerifyAllExpectations();
        }

        [TestMethod]
        public void GetHostel_ShouldReturnCorrectHostel()
        {
            //Arrange
            HostelRepository.Expect(x => x.Select()).Return(GetTestHostels());
            UnitOfWork.Stub(x => x.Hostel()).Return(HostelRepository);
            var testHostels = GetTestHostels().ToList();
            var controller = new HostelController(UnitOfWork);
            //Act
            var result = controller.Hostel(4);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testHostels[3].Code, result.Code);
            UnitOfWork.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetHostel_ShouldNotFindHostel()
        {
            //Arrange
            HostelRepository.Expect(x => x.Select()).Return(GetTestHostels());
            UnitOfWork.Stub(x => x.Hostel()).Return(HostelRepository);
            var controller = new HostelController(UnitOfWork);
            //Act
            var result = controller.Hostel(999);
            //Assert
            Assert.IsNull(result);
            UnitOfWork.VerifyAllExpectations();
        }
    }
}