using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Incomm.HousingGateway.WebAPI.Controllers;
using InCoreLib.Domain.Database;
using InCoreLib.Service.Api.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class TestHostelController : BaseTestController
    {
        [TestMethod]
        public void GetAllHostels_ShouldReturnAllHostels()
        {
            var testHostels = GetTestHostels();
            var controller = new HostelController(UnitOfWork)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };


            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var context = new ODataQueryContext(GetOdataModel(), typeof(Hostel));
            var options = new ODataQueryOptions<Hostel>(context, request);
            var result = controller.GetHostels(options);
            Assert.AreEqual(testHostels.ToList().Count, result.Items.Count());
        }

       


        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testHostels = GetTestHostels().ToList();
            var controller = new HostelController(UnitOfWork);

            var result = controller.Hostel(4) as HostelDTO;
            Assert.IsNotNull(result);
            Assert.AreEqual(testHostels[3].Code, result.Code);
        }

    
        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new HostelController(UnitOfWork);

            var result = controller.Hostel(999);
            Assert.IsNull(result);
        }

    }
}

