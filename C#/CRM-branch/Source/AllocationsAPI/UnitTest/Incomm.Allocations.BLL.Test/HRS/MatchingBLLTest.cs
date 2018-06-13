using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Query;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Allocations.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.Allocations.BLL.Test.HRS
{
    [TestClass]
    public class MatchingBLLTest : HRSBaseTestClass
    {
        private IRepository<HRSPlacement> placementRepository;
        private IRepository<HRSCustomer> customerRepository;
        private IRepository<HRSMatchHistory> matchHistoryRepository;
        private IRepository<HRSPlacementMatchedForCustomer> hrsPlacementMatchedForCustomerRepository;

        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Customer_Matches_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 2
                    },
                SupportTypeId = 1
            };


            
            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType { 
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 2
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();
            
            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);
            

            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> {newObj}.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();
           
            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1,"2","1");
            hrsPlacementMatchedForCustomerRepository.AssertWasCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Customer_Was_Rejected_From_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>
            {
                new HRSMatchHistory
                {
                    Customer = new HRSCustomer
                    {
                        DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList

                    },
                   DecisionDate = new DateTime(2000,11,11),
                   MatchHistoryId = 1,
                   Outcome = Status.RejectedByProvider,
                   Placement = new HRSPlacement
                   {
                       Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1

                   },
                   Reason = RejectionReason.Banned,
                   Reconsidered = false
                }
                

            };


           


            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }




        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Customer_ServiceType_DoesNotMatch_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 2,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();


       

            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }


        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Customer_SupportType_DoesNotMatch_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 2
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();


     

            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Customer_MinBedRoomSize_DoesNotMatch_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 2,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Customer_Gender_DoesNotMatch_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Female,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }


        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Customer_Status_IsNot_OnWaitingList()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.PlacementMatched
                }
            };


            var matchHistory = new List<HRSMatchHistory>();


        

            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }






        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Placement_ServiceType_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 2,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "2");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Placement_SupportType_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 2
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "2", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Placement_MinBedRoomSize_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 2,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 3,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Placement_Gender_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Female,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }


        [TestMethod]
        public void Test_AddMatchingCustomerListToPlacement_When_Placement_Status_IsNot_Available()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.MatchedByProvider,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingCustomerListToPlacement(1, "1", "1");
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }









        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Customer_Matches_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();

            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> {"1"}, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Customer_Was_Rejected_From_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>
            {
                new HRSMatchHistory
                {
                    Customer = new HRSCustomer
                    {
                        DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList

                    },
                   DecisionDate = new DateTime(2000,11,11),
                   MatchHistoryId = 1,
                   Outcome = Status.RejectedByProvider,
                   Placement = new HRSPlacement
                   {
                       Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1

                   },
                   Reason = RejectionReason.Banned,
                   Reconsidered = false
                }


            };





            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Customer_ServiceType_DoesNotMatch_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 2,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "2" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Customer_MinBedRoomSize_DoesNotMatch_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 2,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Customer_Gender_DoesNotMatch_Placement()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Female,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Customer_Status_IsNot_OnWaitingList()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.PlacementMatched
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Placement_SupportType_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 2
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "2" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Placement_ServiceType_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 2,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Placement_MinBedRoomSize_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 2,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 3,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Placement_Gender_DoesNotMatch_Customer()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Female,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.Available,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();



            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }


        [TestMethod]
        public void Test_AddMatchingPlacementListToCustomer_When_Placement_Status_IsNot_Available()
        {

            var newObj = new HRSPlacement
            {
                Address = "aaa",
                Comments = "",
                ContactName = "Placement 1",
                ContactNumber = "111 1111 1111",
                CreatedBy = null,
                CreatedDate = new DateTime(2016, 07, 20, 10, 35, 49),
                HRSProviderId = 2,
                Hostel =
                    new Hostel
                    {
                        Code = "MILLHAVEN",
                        CreatedBy = null,
                        CreatedDate = new DateTime(2016, 04, 04),
                        Description = "Millhaven",
                        HRSProviderId = 2,
                        HostelId = 2
                    },
                HostelId = 2,
                MinimumBedroom = 1,
                ModifiedBy = "",
                MoveOnPlacement = false,
                PlacementGender = PlacementGender.Male,
                PlacementId = 1,
                PlacementStatus = PlacementStatus.MatchedByProvider,
                ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                SupportType =
                    new SupportType
                    {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    },
                SupportTypeId = 1
            };



            var customers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    DateAdded = new DateTime(2000,11,11),
                    DoB = new DateTime(2000,11,11),
                    GatewayOfficer = "a",
                    Gender = CustomerGender.Male,
                    HOACaseReference = 1,
                    HRSCustomerId = 1,
                    MinBedroomSize = 1,
                    Name = "A",
                    Priority = Priority.High,
                    ServiceTypes =
                    new List<ServiceType>
                    {
                        new ServiceType
                        {
                            Active = true,
                            Code = "Homeless",
                            Description = "Homeless",
                            ServiceTypeId = 1,
                            SortOrder = 1
                        }
                    },
                   SupportTypes =
                    new List<SupportType>
                    {new SupportType {
                        Active = true,
                        Code = "Hostel",
                        Description = "Hostel",
                        SortOrder = 1,
                        SupportTypeId = 1
                    }},
                   Status = Status.OnWaitingList
                }
            };


            var matchHistory = new List<HRSMatchHistory>();




            var builder = new ODataModelBuilder();
            var placement = builder.Entity<HRSPlacement>();
            placement.HasKey(a => a.PlacementId);
            placement.Property(a => a.PlacementId);


            placementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            placementRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(new List<HRSPlacement> { newObj }.AsQueryable());
            base.UnitOfWork.Expect(x => x.Placement()).Return(placementRepository);

            customerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            customerRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(customers.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSCustomer()).Return(customerRepository);

            matchHistoryRepository = MockRepository.GenerateMock<IRepository<HRSMatchHistory>>();
            matchHistoryRepository.Stub(x =>
            x.Select()).IgnoreArguments().Return(matchHistory.AsQueryable());
            base.UnitOfWork.Expect(x => x.HRSMatchHistory()).Return(matchHistoryRepository);

            hrsPlacementMatchedForCustomerRepository = MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();

            base.UnitOfWork.Expect(x => x.HRSPlacementMatchedForCustomer()).Return(hrsPlacementMatchedForCustomerRepository);


            //Act
            var matchingBLL = new MatchingBLL(UnitOfWork);
            matchingBLL.AddMatchingPlacementListToCustomer(1, new List<string> { "1" }, new List<string> { "1" });
            hrsPlacementMatchedForCustomerRepository.AssertWasNotCalled(
               x => x.Insert(Arg<HRSPlacementMatchedForCustomer>.Is.Anything));

            //Assert
            placementRepository.VerifyAllExpectations();
        }
    }

}

