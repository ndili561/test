using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Test.VBL;
using Incomm.Allocations.BLL.VBL;
using InCoreLib.Data.Enum;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.Allocations.BLL.Test
{
    [TestClass]
    public class ApplicationBLLTest: BaseTestClass
    {
        string query= "ApplicationStatus,Contacts.Addresses,Contacts.ContactType";
        private IRepository<VBLApplication> applicationRepository;
        private IRepository<PropertyType> propertyTypeRepository;
        private IRepository<AgeRestriction> ageRestrictionRepository;
        private IRepository<Adaptation> adaptationRepository;
        private IRepository<VBLCustomerInterest> vblCustomerInterestRepository;
        private IRepository<VBLRequestedPropertyPrefferedNeighbourhoodDetail> requestedPropertyPrefferedNeighbourhoodDetailRepository;
       //private Expression<Func<VBLApplication, bool>> filter;
       //private Func<IQueryable<VBLApplication>, Boolean, IOrderedQueryable<VBLApplication>> orderBy = null;
       //private SortDirection sortDir = SortDirection.Ascending;
       //private string includeProperties = "";
       [TestMethod]
        public void GetApplication_Calls_UnitOfWork_VBLApplications_Select2()
        {
            //Arrange
            Expression<Func<VBLApplication, bool>> filter;
            Func<IQueryable<VBLApplication>, Boolean, IOrderedQueryable<VBLApplication>> orderBy = null;
            SortDirection sortDir = SortDirection.Ascending;
            string includeProperties = "";
            var request = new HttpRequestMessage();
            var builder = new ODataModelBuilder();
            var customer = builder.Entity<VBLApplication>();
            customer.HasKey(c => c.ApplicationId);
            customer.Property(c => c.ApplicationId);
            var model = builder.GetEdmModel();
            var context = new ODataQueryContext(model, typeof(VBLApplication));
            var oDataQueryOptions = new ODataQueryOptions<VBLApplication>(context, request);

            applicationRepository = MockRepository.GenerateMock<IRepository<VBLApplication>>();
            applicationRepository.Expect(x => 
            x.Select()
                ).IgnoreArguments().Return(new List<VBLApplication>
                {
                    new VBLApplication {ApplicationId =  1}
                }.AsQueryable());
           
            base.UnitOfWork.Expect(x => x.VBLApplications()).Return(applicationRepository);

            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetApplications(oDataQueryOptions);
           
            //Assert
            applicationRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void GetOpenUnmatchedApplicationsWithNeighbourhoodsDetailReturn_ErrorMessageWhen_VoidPropertyType_IsNULL()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = null, AgeRestriction = "55.00", Bedrooms = 1, NeighbourhoodId = 10, };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
          Assert.AreEqual("The Property Type cannot be null.\r\n", voidToMatch.ErrorMessage);
        }
        [TestMethod]
        public void GetOpenUnmatchedApplicationsWithNeighbourhoodsDetailReturn_ErrorMessageWhen_VoidAgeRestriction_IsNULL()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = null,  NeighbourhoodId = 10, Bedrooms = 1 };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual("The Age Restriction cannot be null.\r\n", voidToMatch.ErrorMessage);
        }
        [TestMethod]
        public void GetOpenUnmatchedApplicationsWithNeighbourhoodsDetailReturn_ErrorMessageWhen_VoidAgeRestriction_IsIncorrectFormat()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "55", NeighbourhoodId = 10, Bedrooms = 1 };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual("The Age Restriction format is not correct. It must be in {00.00} format.\r\n", voidToMatch.ErrorMessage);
        }
        [TestMethod]
        public void Void_PropertyType_Bedsit_Bedrooms_0ReturnNoErrorMessage()
        {
            //Arrange
            ArrangeRepositories(1, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Bedsit", AgeRestriction = "18.00", NeighbourhoodId = 10 };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.IsNull( voidToMatch.ErrorMessage);
        }

        [TestMethod]
        public void Void_PropertyType_Bedsit_Without_Bedrooms_Return_ApplicationId()
        {
            //Arrange
            ArrangeRepositories(1, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Bedsit", AgeRestriction = "18.00", NeighbourhoodId = 10, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);
            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_PropertyType_Bedsit_With_Bedrooms_Return_ApplicationId()
        {
            //Arrange
            ArrangeRepositories(1, 0, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Bedsit", AgeRestriction = "18.00", NeighbourhoodId = 10, Lift = true, Pets = "Y", CommunalEntrance = false ,Bedrooms = 5};
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);
            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_PropertyType_Flat_With_SameBedroomsAsApplication_Return_CorrectApplicationId()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Lift = true, Pets = "Y", CommunalEntrance = false, Bedrooms = 1 };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);
            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_PropertyType_Flat_With_DifferentBedroomsAsApplication_Return_ApplicationId_0()
        {
            //Arrange
            ArrangeRepositories(1, 3, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Lift = true, Pets = "Y", CommunalEntrance = false, Bedrooms = 1 };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);
            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_PropertyType_Flat_Bedrooms_0ReturnoErrorMessage()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "55.00", NeighbourhoodId = 10 };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual("Only property type Bedsit can have 0 Bedrooms.\r\n", voidToMatch.ErrorMessage);
        }
        [TestMethod]
        public void GetOpenUnmatchedApplicationsWithNeighbourhoodsDetailReturn_ErrorMessageWhen_VoidNeighbourhoodId_0()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "55.00", NeighbourhoodId = 0, Bedrooms = 1 };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual("The NeighbourhoodId cannot be 0.\r\n", voidToMatch.ErrorMessage);
        }
       
        [TestMethod]
        public void Void_NoAgeRestriction_ReturnApplicationId_12346_WhenApplication_NoAgeRestrictions()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1,Lift = true,Pets = "Y",CommunalEntrance = false};
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_AgeRestriction_55_ReturnApplicationId_0_WhenApplication_NoAgeRestrictions()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "55.00", NeighbourhoodId = 10, Bedrooms = 1, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_AgeRestriction_65_ReturnApplicationId_0_WhenApplication_NoAgeRestrictions()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "65.00", NeighbourhoodId = 10, Bedrooms = 1, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_AgeRestriction_18_ReturnApplicationId_0_WhenApplication_AgeRestrictions65()
        {
            //Arrange
            ArrangeRepositories(6, 1, 2);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_AgeRestriction_55_ReturnApplicationId_12346_WhenApplication_AgeRestrictions55()
        {
            //Arrange
            ArrangeRepositories(6, 1, 2);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "55.00", NeighbourhoodId = 10, Bedrooms = 1, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId,12346);
        }
        [TestMethod]
        public void Void_AgeRestriction_55_ReturnApplicationId_0_WhenApplication_AgeRestrictions65()
        {
            //Arrange
            ArrangeRepositories(6, 1, 2);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "65.00", NeighbourhoodId = 10, Bedrooms = 1, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_AgeRestriction_65_ReturnApplicationId_12346_WhenApplication_AgeRestrictions65()
        {
            //Arrange
            ArrangeRepositories(6, 1, 3);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "65.00", NeighbourhoodId = 10, Bedrooms = 1, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_PropertyType_Flat_ReturnApplicationId_12346_WhenApplication_PropertyType_Flat()
        {
            //Arrange
            ArrangeRepositories(6,1,0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Lift = true, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Lift_Null_ReturnApplicationId_12346_WhenApplication_LiftServed_True()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1,  Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Lift_True_ReturnApplicationId_12346()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Lift_False_ReturnApplicationId_12346()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Lift_False_ReturnApplicationId_0_WhenApplication_LiftServed_True()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0,true);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_Lift_True_ReturnApplicationId_12346_WhenApplication_LiftServed_True()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0, true);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false,Lift = true};
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HighRise_Null_ReturnApplicationId_12346_WhenApplication_HighRise_Null()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0, true,null);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false, Lift = true, HighRise = null };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HighRise_Null_ReturnApplicationId_12346_WhenApplication_HighRise_False()
        {
            //Arrange
            ArrangeRepositories(6, 1, 0, true,false);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false, Lift = true, HighRise = null };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HighRise_Null_ReturnApplicationId_12346_WhenApplication_HighRise_True()
        {
            //Arrange
            bool? highrise = true;
            ArrangeRepositories(6, 1, 0, true, highrise);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false, Lift = true ,HighRise = null};
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HighRise_False_ReturnApplicationId_12346_WhenApplication_HighRise_False()
        {
            //Arrange
            bool? highrise = false;
            ArrangeRepositories(6, 1, 0, true, highrise);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false, Lift = true, HighRise = highrise };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HighRise_False_ReturnApplicationId_12346_WhenApplication_HighRise_True()
        {
            //Arrange
            bool? highrise = true;
            ArrangeRepositories(6, 1, 0, true,true);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false, Lift = true,HighRise = !highrise };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HighRise_True_ReturnApplicationId_12346_WhenApplication_HighRise_False()
        {
            //Arrange
            bool? highrise = false;
            ArrangeRepositories(6, 1, 0, true, highrise);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false, Lift = true,HighRise = !highrise };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_HighRise_True_ReturnApplicationId_12346_WhenApplication_HighRise_True()
        {
            //Arrange
            bool? highrise = true;
            ArrangeRepositories(6, 1, 0, true, highrise);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, Pets = "Y", CommunalEntrance = false, Lift = true,HighRise = highrise };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Pet_NULL_ReturnApplicationId_12346_WhenApplication_CatOrDog_NULL()
        {
            //Arrange
            bool? catOrDog = null;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1,  CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Pet_NULL_ReturnApplicationId_12346_WhenApplication_CatOrDog_True()
        {
            //Arrange
            bool? catOrDog = true;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Pet_NULL_ReturnApplicationId_12346_WhenApplication_CatOrDog_False()
        {
            //Arrange
            bool? catOrDog = false;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Pet_N_ReturnApplicationId_12346_WhenApplication_CatOrDog_NULL()
        {
            //Arrange
            bool? catOrDog = null;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00",Pets = "N",NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Pet_N_ReturnApplicationId_0_WhenApplication_CatOrDog_True()
        {
            //Arrange
            bool? catOrDog = true;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "N", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }

        [TestMethod]
        public void Void_Pet_N_ReturnApplicationId_12346_WhenApplication_CatOrDog_False()
        {
            //Arrange
            bool? catOrDog = false;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "N", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Pet_Y_ReturnApplicationId_12346_WhenApplication_CatOrDog_NULL()
        {
            //Arrange
            bool? catOrDog = null;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_Pet_Y_ReturnApplicationId_12346_WhenApplication_CatOrDog_True()
        {
            //Arrange
            bool? catOrDog = true;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }

        [TestMethod]
        public void Void_Pet_Y_ReturnApplicationId_12346_WhenApplication_CatOrDog_False()
        {
            //Arrange
            bool? catOrDog = false;
            ArrangeRepositories(6, 1, 0, true, false, catOrDog);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_NULL_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_NULL()
        {
            //Arrange
            bool? communalEntrance = null;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = communalEntrance, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_NULL_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_True()
        {
            //Arrange
            bool? communalEntrance = null;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = communalEntrance, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_NULL_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_False()
        {
            //Arrange
            bool? communalEntrance = null;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = communalEntrance, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_False_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_NULL()
        {
            //Arrange
            bool? communalEntrance = false;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = null, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_False_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_True()
        {
            //Arrange
            bool? communalEntrance = true;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = !communalEntrance, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_False_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_False()
        {
            //Arrange
            bool? communalEntrance = false;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = communalEntrance, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_True_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_NULL()
        {
            //Arrange
            bool? communalEntrance = false;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = null, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_True_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_True()
        {
            //Arrange
            bool? communalEntrance = true;
            bool? rehousePets = true;
            ArrangeRepositories(6, 1, 0, true, true, true, communalEntrance, rehousePets);
            var voidToMatch = new VBLPropertyShopDTO { PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = communalEntrance, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_CommunalEntrance_True_ReturnApplicationId_12346_WhenApplication_CommunalEntrance_False()
        {
            //Arrange
            bool? communalEntrance = false;
            ArrangeRepositories(6, 1, 0, true, false, false, communalEntrance);
            var voidToMatch = new VBLPropertyShopDTO { WheelchairAdapted = true, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = !communalEntrance, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HasAdaption_False_ReturnApplicationId_12346_WhenApplication_RequiredAdaptation_False()
        {
            //Arrange
            bool? wheelchairAdapted = false;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, wheelchairAdapted);
            var voidToMatch = new VBLPropertyShopDTO { WheelchairAdapted = wheelchairAdapted, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HasAdaption_False_ReturnApplicationId_0_WhenApplication_RequiredAdaptation_True()
        {
            //Arrange
            bool? wheelchairAdapted = true;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, wheelchairAdapted);
            var voidToMatch = new VBLPropertyShopDTO { WheelchairAdapted = !wheelchairAdapted, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = true, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_HasAdaption_True_ReturnApplicationId_12346_WhenApplication_RequiredAdaptation_False()
        {
            //Arrange
            bool? wheelchairAdapted = false;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, wheelchairAdapted);
            var voidToMatch = new VBLPropertyShopDTO { WheelchairAdapted = !wheelchairAdapted, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_HasAdaption_True_ReturnApplicationId_12346_WhenApplication_RequiredAdaptation_True()
        {
            //Arrange
            bool? wheelchairAdapted = true;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, wheelchairAdapted);
            var voidToMatch = new VBLPropertyShopDTO {WheelchairAdapted = wheelchairAdapted, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_NULL_ReturnApplicationId_12346_WhenApplication_NumberOfSteps_TwentyPlus()
        {
            //Arrange
            bool? wheelchairAdapted = true;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, wheelchairAdapted);
            var voidToMatch = new VBLPropertyShopDTO { WheelchairAdapted = wheelchairAdapted, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBLL = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_25_ReturnApplicationId_12346_WhenApplication_NumberOfStep_TwentyPlus()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.TwentyPlus;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 25, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_20_ReturnApplicationId_12346_WhenApplication_NumberOfStep_TenToTwenty()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.TenToTwenty;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 20, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_21_ReturnApplicationId_0_WhenApplication_NumberOfStep_TenToTwenty()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.TenToTwenty;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 21, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_NumberOfSteps_10_ReturnApplicationId_12346_WhenApplication_NumberOfStep_ThreeToTen()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.ThreeToTen;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 10, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_11_ReturnApplicationId_0_WhenApplication_NumberOfStep_ThreeToTen()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.ThreeToTen;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 11, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_NumberOfSteps_2_ReturnApplicationId_12346_WhenApplication_NumberOfStep_OneToTwo()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.OneToTwo;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 2, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_3_ReturnApplicationId_0_WhenApplication_NumberOfStep_OneToTwo()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.OneToTwo;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 3, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        [TestMethod]
        public void Void_NumberOfSteps_0_ReturnApplicationId_12346_WhenApplication_NumberOfStep_Zero()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.Zero;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 0, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_1_ReturnApplicationId_0_WhenApplication_NumberOfStep_Zero()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.TwentyPlus;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 1, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 12346);
        }
        [TestMethod]
        public void Void_NumberOfSteps_20_ReturnApplicationId_0_WhenApplication_NumberOfStep_Zero()
        {
            //Arrange
            var numberOfSteps = NumberOfSteps.Zero;
            ArrangeRepositories(6, 1, 0, true, false, false, false, false, null, numberOfSteps);
            var voidToMatch = new VBLPropertyShopDTO { NumberOfSteps = 20, PropertyType = "Flat", AgeRestriction = "18.00", Pets = "Y", NeighbourhoodId = 10, Bedrooms = 1, CommunalEntrance = false, Lift = true, HighRise = false };
            //Act
            var applicationBll = new ApplicationBLL(UnitOfWork, ApplicationHistoryBll,PersonApiClient,PersonAddressApiClient);
            applicationBll.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);

            //Assert
            Assert.AreEqual(voidToMatch.MatchedApplicationId, 0);
        }
        private void ArrangeRepositories(int propertyTypeId, int propertySizeId,int ageRestrictionId,bool? liftServed= null, bool? highRise= null, bool? catOrDog = null, bool? communalEntrance = null,bool? rehousePet=null, bool? requireAdaptation = null, NumberOfSteps numberOfSteps= NumberOfSteps.Unselected)
        {
            adaptationRepository = MockRepository.GenerateMock<IRepository<Adaptation>>();
            adaptationRepository.Expect(x =>
                x.Select()
                ).IgnoreArguments().Return(new List<Adaptation>
                {
                     new Adaptation {AdaptationId = 1, Name = "Wheelchair Adapted"},
                    new Adaptation {AdaptationId = 2, Name = "Ramped Access"},
                    new Adaptation {AdaptationId = 3, Name = "Walk in Shower"},
                    new Adaptation {AdaptationId = 4, Name = "Stairlift"},
                    new Adaptation {AdaptationId = 5, Name = "Step in Shower"},
                }.AsQueryable());

            base.UnitOfWork.Expect(x => x.Adaptations()).Return(adaptationRepository);

            propertyTypeRepository = MockRepository.GenerateMock<IRepository<PropertyType>>();
            propertyTypeRepository.Expect(x =>
                x.Select()
                ).IgnoreArguments().Return(new List<PropertyType>
                {
                     new PropertyType {PropertyTypeId = 1, Name = "Bedsit"},
                    new PropertyType {PropertyTypeId = 4, Name = "Bunglow"},
                    new PropertyType {PropertyTypeId = 6, Name = "Flat"},
                    new PropertyType {PropertyTypeId = 10, Name = "House"},
                    new PropertyType {PropertyTypeId = 12, Name = "Maisonette"},
                }.AsQueryable());

            base.UnitOfWork.Expect(x => x.PropertyTypes()).Return(propertyTypeRepository);

            ageRestrictionRepository = MockRepository.GenerateMock<IRepository<AgeRestriction>>();
            ageRestrictionRepository.Expect(x =>
                x.Select()
                ).IgnoreArguments().Return(new List<AgeRestriction>
                {
                    new AgeRestriction {AgeRestrictionId = 2, Name = "55+"},
                    new AgeRestriction {AgeRestrictionId = 3, Name = "65+"}
                }.AsQueryable());

            base.UnitOfWork.Expect(x => x.AgeRestrictions()).Return(ageRestrictionRepository);

            vblCustomerInterestRepository = MockRepository.GenerateMock<IRepository<VBLCustomerInterest>>();
            vblCustomerInterestRepository.Expect(x =>
                x.Select()
                ).IgnoreArguments().Return(new List<VBLCustomerInterest>
                {
                    new VBLCustomerInterest {CustomerInterestId = 10, CustomerInterestStatusId = 10},
                    new VBLCustomerInterest {CustomerInterestId = 4, CustomerInterestStatusId = 20}
                }.AsQueryable());

            base.UnitOfWork.Expect(x => x.VBLCustomerInterests()).Return(vblCustomerInterestRepository);

            requestedPropertyPrefferedNeighbourhoodDetailRepository =
                MockRepository.GenerateMock<IRepository<VBLRequestedPropertyPrefferedNeighbourhoodDetail>>();
            requestedPropertyPrefferedNeighbourhoodDetailRepository.Expect(x =>
                x.Select()
                ).IgnoreArguments().Return(new List<VBLRequestedPropertyPrefferedNeighbourhoodDetail>
                {
                    new VBLRequestedPropertyPrefferedNeighbourhoodDetail
                    {
                        NeighbourhoodId = 5,
                        RequestedPropertyPrefferedNeighbourhood =
                            new VBLRequestedPropertyPrefferedNeighbourhood {ApplicationId = 12345, IsCurrent = true}
                    },
                    new VBLRequestedPropertyPrefferedNeighbourhoodDetail
                    {
                        NeighbourhoodId = 6,
                        RequestedPropertyPrefferedNeighbourhood =
                            new VBLRequestedPropertyPrefferedNeighbourhood {ApplicationId = 12346, IsCurrent = true}
                    },
                       new VBLRequestedPropertyPrefferedNeighbourhoodDetail
                    {
                        NeighbourhoodId = 10,
                        RequestedPropertyPrefferedNeighbourhood =
                            new VBLRequestedPropertyPrefferedNeighbourhood {ApplicationId = 12346, IsCurrent = true}
                    }
                }.AsQueryable());

            base.UnitOfWork.Expect(x => x.RequestedPropertyPrefferedNeighbourhoodDetail())
                .Return(requestedPropertyPrefferedNeighbourhoodDetailRepository);

            applicationRepository = MockRepository.GenerateMock<IRepository<VBLApplication>>();
            applicationRepository.Expect(x =>x.Select()).IgnoreArguments().Return(new List<VBLApplication>
                {
                    new VBLApplication {
                        ApplicationId = 12346,
                        ApplicationStatusID = 1,
                        ApplicationLevelOfNeedID = 1,
                       
                        VBLRequestedPropertymatchDetail = new VBLRequestedPropertymatchDetail
                        {
                            PropertySizes = new List<VBLRequestedPropertyPropertySize> {
                                new VBLRequestedPropertyPropertySize
                                                {
                                                    PropertySizeId = propertySizeId
                                                }
                            },
                            PropertyTypes =new List<VBLRequestedPropertyPropertyType>
                            {
                                new VBLRequestedPropertyPropertyType
                                {
                                    ApplicationId = 12346,
                                    PropertyTypeId =propertyTypeId //Flat
                                }
                            },
                            LiftServed = liftServed,
                            HighRise = highRise,
                            RequireAdaptations = requireAdaptation,
                            CatOrDog = catOrDog,
                            RehousePet = rehousePet,
                            CommunalEntrance = communalEntrance,
                            StartDate = DateTime.Now,
                            NumberOfSteps= numberOfSteps,
                            AgeRestrictions = new List<VBLRequestedPropertyAgeRestriction>
                            {
                                new VBLRequestedPropertyAgeRestriction
                                {
                                    AgeRestrictionId = ageRestrictionId
                                }
                            }
                        }
                        }
                }.AsQueryable());

            base.UnitOfWork.Expect(x => x.VBLApplications()).Return(applicationRepository);

         
        }
    }
}
