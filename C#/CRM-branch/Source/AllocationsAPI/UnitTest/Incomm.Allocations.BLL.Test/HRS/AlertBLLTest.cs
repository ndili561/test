using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.Allocations.BLL.Test.HRS
{
    [TestClass]
    public class AlertBLLTest : HRSBaseTestClass
    {
        private IRepository<HRSAlert> alertRepository;


        [TestMethod]
        public void GetAlerts_Calls_UnitOfWork_HRSAlerts_Select()
        {
            //Arrange
            var request = new HttpRequestMessage();
            var builder = new ODataModelBuilder();
            var alert = builder.Entity<HRSAlert>();
            alert.HasKey(a=> a.CaseEventID);
            alert.Property(a => a.CaseEventID);
            var model = builder.GetEdmModel();
            var context = new ODataQueryContext(model , typeof(HRSAlert));
            var oDataQueryOptions = new ODataQueryOptions<HRSAlert>(context,request);

            alertRepository = MockRepository.GenerateMock<IRepository<HRSAlert>>();
            alertRepository.Expect(x =>
            x.Select()
                ).IgnoreArguments().Return(new List<HRSAlert>
                {
                    new HRSAlert {Alert = "Test",CaseEventID =  1,CaseRef = 1, Date = new DateTime(1999,1,1),DOB = new DateTime(2000,2,2),Gender = "Male",Name="Test"}
                }.AsQueryable());

            base.UnitOfWork.Expect(x=> x.HRSAlert()).Return(alertRepository);
            //Act
            var alertBLL = new AlertBLL(UnitOfWork);
            alertBLL.GetAlerts(oDataQueryOptions);

            //Assert
            alertRepository.VerifyAllExpectations();
        }


        [TestMethod]
        public void GetAlert_Calls_UnitOfWork_HRSAlerts_Select()
        {
            ////Arrange
            //alertRepository = MockRepository.GenerateMock<IRepository<HRSAlert>>();
            //alertRepository.Expect(x =>
            //x.Select().FirstOrDefault(a => a.CaseEventID == Arg<int>.Is.Anything)
            //    ).IgnoreArguments().Return(

            //        new HRSAlert { Alert = "Test", CaseEventID = 1, CaseRef = 1, Date = new DateTime(1999, 1, 1), DOB = new DateTime(2000, 2, 2), Gender = "Male", Name = "Test" }
            //    );

            //base.UnitOfWork.Expect(x => x.HRSAlert()).Return(alertRepository);
            ////Act
            //var alertBLL = new AlertBLL(UnitOfWork);
            //alertBLL.GetAlert(1);

            ////Assert
            //alertRepository.VerifyAllExpectations();
        }

    }
}
