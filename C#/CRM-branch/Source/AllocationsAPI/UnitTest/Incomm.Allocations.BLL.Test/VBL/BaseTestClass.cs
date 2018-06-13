using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.Allocations.BLL.Test.VBL
{
    [TestClass]
    public class BaseTestClass
    {
        protected IUnitOfWork UnitOfWork;
        protected IApplicationHistoryBLL ApplicationHistoryBll;
        protected IPersonApiClient PersonApiClient;
        protected IPersonAddressApiClient PersonAddressApiClient;
        protected IContactBLL ContactBLL;
        protected IApplicationBLL ApplicationBll;
        protected IDocumentBLL DocumentBLL;
        [TestInitialize]
        public void Setup()
        {
            UnitOfWork= MockRepository.GenerateMock<IUnitOfWork>();
            ApplicationHistoryBll= MockRepository.GenerateMock<IApplicationHistoryBLL>();
            ContactBLL = MockRepository.GenerateMock<IContactBLL>();
            ApplicationBll = MockRepository.GenerateMock<IApplicationBLL>();
            DocumentBLL = MockRepository.GenerateMock<IDocumentBLL>();
            PersonApiClient = MockRepository.GenerateMock<IPersonApiClient>();
            PersonAddressApiClient = MockRepository.GenerateMock<IPersonAddressApiClient>();
        }
    }
}
