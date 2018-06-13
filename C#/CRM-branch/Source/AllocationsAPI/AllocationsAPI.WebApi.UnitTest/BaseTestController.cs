using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.Routing;
using AllocationsAPI.WebAPI;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.Audit.Interfaces;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Domain.Enum;
using Microsoft.Data.Edm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.HousingGateway.WebApi.UnitTest
{
    [TestClass]
    public class BaseTestController
    {
        protected IRepository<HRSAlert> AlertRepository;
        protected IRepository<AuditLog> AuditLogRepository;
        protected IRepository<tblCaseNote> CaseNoteRepository;
        protected IRepository<tsubHOAEvent> EventRepository;
        protected IRepository<Hostel> HostelRepository;
        protected IRepository<HRSAlert> HRSAlertRepository;
        protected IRepository<HRSCustomer> HRSCustomerRepository;
        protected IRepository<HRSPlacementMatchedForCustomer> HRSPlacementMatchedForCustomerRepository;
        protected IRepository<HRSPlacement> HRSPlacementRepository;
        protected IRepository<HRSProvider> HRSProviderRepository;
        protected IRepository<HRSQuestionAnswer> HRSQuestionAnswerRepository;

        protected HttpConfiguration HttpConfiguration;
        protected HttpRouteData HttpRouteData;

        protected IRepository<HRSPlacement> PlacementRrepository;
        protected IRepository<lstQuestion> QuestionRepository;
        protected IRepository<ServiceType> ServiceTypeRepository;
        protected IRepository<SupportType> SupportTypeRepository;
        protected IUnitOfWork UnitOfWork;

        [TestInitialize]
        public void SetUp()
        {
            HttpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(HttpConfiguration);
            HttpRouteData = new HttpRouteData(HttpConfiguration.Routes["DefaultApi"],
                new HttpRouteValueDictionary {{"controller", "HRSCustomer"}});

            UnitOfWork = MockRepository.GenerateMock<IUnitOfWork>();

            SupportTypeRepository = MockRepository.GenerateMock<IRepository<SupportType>>();
            ServiceTypeRepository = MockRepository.GenerateMock<IRepository<ServiceType>>();
            HostelRepository = MockRepository.GenerateMock<IRepository<Hostel>>();
            AlertRepository = MockRepository.GenerateMock<IRepository<HRSAlert>>();
            HRSCustomerRepository = MockRepository.GenerateMock<IRepository<HRSCustomer>>();
            HRSPlacementRepository = MockRepository.GenerateMock<IRepository<HRSPlacement>>();
            CaseNoteRepository = MockRepository.GenerateMock<IRepository<tblCaseNote>>();
            HRSPlacementMatchedForCustomerRepository =
                MockRepository.GenerateMock<IRepository<HRSPlacementMatchedForCustomer>>();
            HRSProviderRepository = MockRepository.GenerateMock<IRepository<HRSProvider>>();
            EventRepository = MockRepository.GenerateMock<IRepository<tsubHOAEvent>>();
            HRSAlertRepository = MockRepository.GenerateMock<IRepository<HRSAlert>>();
            QuestionRepository = MockRepository.GenerateMock<IRepository<lstQuestion>>();
            HRSQuestionAnswerRepository = MockRepository.GenerateMock<IRepository<HRSQuestionAnswer>>();
            AuditLogRepository = MockRepository.GenerateMock<IRepository<AuditLog>>();

            AutoMapperConfig.Initialise();
        }

        protected IEdmModel GetOdataModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<HRSCustomer>("HRSCustomer");
            modelBuilder.EntitySet<SupportType>("SupportType");
            modelBuilder.EntitySet<Hostel>("Hostel");
            modelBuilder.EntitySet<HRSAlert>("HRSAlert");
            modelBuilder.EntitySet<HRSProvider>("HRSProvider");
            modelBuilder.EntitySet<AuditLog>("AuditLog");
            var model = modelBuilder.GetEdmModel();
            return model;
        }

        protected IQueryable<Hostel> GetTestHostels()
        {
            var testProducts = new List<Hostel>
            {
                new Hostel
                {
                    HostelId = 1,
                    Code = "Demo1",
                    Description = "Demo1 Description"
                },
                new Hostel
                {
                    HostelId = 2,
                    Code = "Demo2",
                    Description = "Demo2 Description"
                },
                new Hostel
                {
                    HostelId = 3,
                    Code = "Demo3",
                    Description = "Demo3 Description"
                },
                new Hostel
                {
                    HostelId = 4,
                    Code = "Demo4",
                    Description = "Demo4 Description"
                }
            }.AsQueryable();

            return testProducts;
        }

        protected IQueryable<SupportType> GetSupportTypes()
        {
            var testSupportTypes = new List<SupportType>
            {
                new SupportType
                {
                    SupportTypeId = 1,
                    Code = "Hostel",
                    Description = "Hostel"
                },
                new SupportType
                {
                    SupportTypeId = 2,
                    Code = "Dispense",
                    Description = "Dispense"
                },
                new SupportType
                {
                    SupportTypeId = 3,
                    Code = "Floating",
                    Description = "Floating"
                }
            }.AsQueryable();

            return testSupportTypes;
        }

        protected IQueryable<ServiceType> GetServiceTypes()
        {
            var testServiceTypes = new List<ServiceType>
            {
                new ServiceType
                {
                    ServiceTypeId = 1,
                    Code = "Homeless",
                    Description = "Homeless"
                },
                new ServiceType
                {
                    ServiceTypeId = 2,
                    Code = "YoungPerson",
                    Description = "Young Person "
                },
                new ServiceType
                {
                    ServiceTypeId = 3,
                    Code = "MultipleNeedsGeneric",
                    Description = "Multiple Needs Generic"
                },
                new ServiceType
                {
                    ServiceTypeId = 4,
                    Code = "MultipleNeedsHighRisk",
                    Description = "Multiple Needs High Risk"
                }
            }.AsQueryable();

            return testServiceTypes;
        }

        protected IQueryable<HRSAlert> GetTestAlerts()
        {
            var testHRSAlerts = new List<HRSAlert>
            {
                new HRSAlert {CaseEventID = 1},
                new HRSAlert {CaseEventID = 2},
                new HRSAlert {CaseEventID = 3},
                new HRSAlert {CaseEventID = 4}
            }.AsQueryable();

            return testHRSAlerts;
        }

        protected IQueryable<tblCaseNote> GetCaseNotes()
        {
            var testCaseNotes = new List<tblCaseNote>
            {
                new tblCaseNote {CaseRefNumber = 1},
                new tblCaseNote {CaseRefNumber = 2},
                new tblCaseNote {CaseRefNumber = 3},
                new tblCaseNote {CaseRefNumber = 4}
            }.AsQueryable();

            return testCaseNotes;
        }

        protected IQueryable<HRSPlacement> GetHRSPlacements()
        {
            var testHRSPlacements = new List<HRSPlacement>
            {
                new HRSPlacement
                {
                    PlacementId = 1,
                    MinimumBedroom = 1,
                    PlacementStatus = PlacementStatus.Available
                },
                new HRSPlacement
                {
                    PlacementId = 2,
                    MinimumBedroom = 1,
                    PlacementStatus = PlacementStatus.Available
                },
                new HRSPlacement
                {
                    PlacementId = 3,
                    MinimumBedroom = 1,
                    PlacementStatus = PlacementStatus.Occupied
                },
                new HRSPlacement
                {
                    PlacementId = 4,
                    MinimumBedroom = 1,
                    PlacementStatus = PlacementStatus.Available
                }
            }.AsQueryable();

            return testHRSPlacements;
        }

        protected IQueryable<HRSCustomer> GetCustomersWithIncorrectMatchedPlacement()
        {
            var customerWithCorrectMatchedPlacement = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    Name = "Customer1",
                    HRSCustomerId = 1,
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
            return customerWithCorrectMatchedPlacement;
        }

        protected IQueryable<HRSCustomer> GetCustomersWithCorrectMatchedPlacement()
        {
            var customerWithCorrectMatchedPlacement = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    Name = "Customer1",
                    HRSCustomerId = 1,
                    HRSPlacementsMatched = new List<HRSPlacementMatchedForCustomer>
                    {
                        new HRSPlacementMatchedForCustomer
                        {
                            CustomerId = 1,
                            PlacementId = 1
                        }
                    },
                    SupportTypes = new List<SupportType>
                    {
                        new SupportType
                        {
                            SupportTypeId = 1,
                            Code = "Hostel"
                        }
                    },
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType
                        {
                            ServiceTypeId = 1,
                            Code = "Homeless"
                        },
                        new ServiceType
                        {
                            ServiceTypeId = 2,
                            Code = "YoungPerson"
                        }
                    }
                }
            }.AsQueryable();
            return customerWithCorrectMatchedPlacement;
        }

        protected IQueryable<HRSCustomer> GetTestCustomers()
        {
            var testHRSCustomers = new List<HRSCustomer>
            {
                new HRSCustomer
                {
                    Name = "Customer1",
                    HRSCustomerId = 1,
                    Status = Status.AssignedToHRSOfficer,
                    MinBedroomSize = 1,
                    HRSPlacementsMatched = new List<HRSPlacementMatchedForCustomer>
                    {
                        new HRSPlacementMatchedForCustomer
                        {
                            CustomerId = 1,
                            PlacementId = 1
                        }
                    },
                    SupportTypes = new List<SupportType>
                    {
                        new SupportType
                        {
                            SupportTypeId = 1,
                            Code = "Hostel"
                        }
                    },
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType
                        {
                            ServiceTypeId = 1,
                            Code = "Homeless"
                        },
                        new ServiceType
                        {
                            ServiceTypeId = 2,
                            Code = "YoungPerson"
                        }
                    }
                },
                new HRSCustomer
                {
                    Name = "Customer2",
                    HRSCustomerId = 2,
                    MinBedroomSize = 1,
                    Status = Status.RejectedByProvider,
                    SupportTypes = new List<SupportType>
                    {
                        new SupportType
                        {
                            SupportTypeId = 2,
                            Code = "Accommodation"
                        }
                    },
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType
                        {
                            ServiceTypeId = 2,
                            Code = "YoungPerson"
                        }
                    }
                },
                new HRSCustomer
                {
                    Name = "Customer3",
                    HRSCustomerId = 3,
                    MinBedroomSize = 2,
                    Status = Status.AssignedToProvider,
                    SupportTypes = new List<SupportType>
                    {
                        new SupportType
                        {
                            SupportTypeId = 3,
                            Code = "Floating"
                        }
                    },
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType
                        {
                            ServiceTypeId = 3,
                            Code = "MultipleNeedsGeneric"
                        }
                    }
                },
                new HRSCustomer
                {
                    Name = "Customer4",
                    HRSCustomerId = 4,
                    MinBedroomSize = 1,
                    Status = Status.AssignedToProvider,
                    SupportTypes = new List<SupportType>
                    {
                        new SupportType
                        {
                            SupportTypeId = 1,
                            Code = "Hostel"
                        }
                    },
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType
                        {
                            ServiceTypeId = 4,
                            Code = "MultipleNeedsHighRisk"
                        }
                    }
                }
            }.AsQueryable();

            return testHRSCustomers;
        }

        protected IQueryable<HRSPlacement> GetTestPlacements()
        {
            var testPlacements = new List<HRSPlacement>
            {
                new HRSPlacement
                    // This plcaement should match the customer who need ( SupportType as Hostel , ServiceType Homeless or YoungPerson, and MinimumBedroom >= 1)
                {
                    PlacementId = 1,
                    MinimumBedroom = 1,
                    PlacementStatus = PlacementStatus.Available,
                    SupportTypeId = 1,
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType {ServiceTypeId = 1},
                        new ServiceType {ServiceTypeId = 2}
                    }
                },
                new HRSPlacement
                    // This plcaement should match the customer who need (SupportType as Hostel ,ServiceType Homeless or YoungPerson ,  and MinimumBedroom >= 1)
                {
                    PlacementId = 2,
                    MinimumBedroom = 2,
                    PlacementStatus = PlacementStatus.Available,
                    SupportTypeId = 1,
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType {ServiceTypeId = 1},
                        new ServiceType {ServiceTypeId = 2}
                    }
                },
                new HRSPlacement // This plcaement should never match as status is occupied
                {
                    PlacementId = 3,
                    MinimumBedroom = 3,
                    PlacementStatus = PlacementStatus.Occupied,
                    SupportTypeId = 2,
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType {ServiceTypeId = 1}
                    }
                },
                new HRSPlacement
                    // This plcaement should match the customer who need (ServiceType Hostel , SupportType as Floating and MinimumBedroom as 4)
                {
                    PlacementId = 4,
                    MinimumBedroom = 4,
                    PlacementStatus = PlacementStatus.Available,
                    SupportTypeId = 3,
                    ServiceTypes = new List<ServiceType>
                    {
                        new ServiceType {ServiceTypeId = 1}
                    }
                }
            }.AsQueryable();

            return testPlacements;
        }

        protected IQueryable<HRSProvider> GetTestProviders()
        {
            var testProviders = new List<HRSProvider>
            {
                new HRSProvider
                {
                    HRSProviderId = 1,
                    Code = "Code1",
                    Description = "Description1"
                },
                new HRSProvider
                {
                    HRSProviderId = 2,
                    Code = "Code2",
                    Description = "Description2"
                }
            }.AsQueryable();

            return testProviders;
        }

        protected IQueryable<tsubHOAEvent> GetTestEvents()
        {
            var testEvents = new List<tsubHOAEvent>
            {
                new tsubHOAEvent
                {
                    CaseEventID = 1,
                    CaseRef = 1,
                    EntityID = 1,
                    EventID = 134,
                    Seqno = 1,
                    Priority = 1,
                    ForecastStartDate = DateTime.Today,
                    ForecastCompletionDate = DateTime.Today,
                    ActualStartDate = DateTime.Today,
                    ActualCompletionDate = DateTime.Today,
                    RequiredStartDate = DateTime.Today,
                    RequiredCompletionDate = DateTime.Today,
                    Note = "Test1",
                    Completed = true,
                    CompletedUserID = "1",
                    AssignedTo = "Test1",
                    UserID = "1",
                    NotNeeded = false,
                    NotNeededDate = DateTime.Today,
                    NotNeededUserID = "1",
                    UnableToComplete = false,
                    UnableToCompleteDate = DateTime.Today,
                    UnableToCompleteUserID = "1",
                    QstnID = 1
                },
                new tsubHOAEvent
                {
                    CaseEventID = 2,
                    CaseRef = 2,
                    EntityID = 2,
                    EventID = 134,
                    Seqno = 2,
                    Priority = 2,
                    ForecastStartDate = DateTime.Today,
                    ForecastCompletionDate = DateTime.Today,
                    ActualStartDate = DateTime.Today,
                    ActualCompletionDate = DateTime.Today,
                    RequiredStartDate = DateTime.Today,
                    RequiredCompletionDate = DateTime.Today,
                    Note = "Test2",
                    Completed = true,
                    CompletedUserID = "2",
                    AssignedTo = "Test2",
                    UserID = "2",
                    NotNeeded = false,
                    NotNeededDate = DateTime.Today,
                    NotNeededUserID = "2",
                    UnableToComplete = false,
                    UnableToCompleteDate = DateTime.Today,
                    UnableToCompleteUserID = "2",
                    QstnID = 2
                }
            }.AsQueryable();

            return testEvents;
        }

        protected IQueryable<HRSAlert> GetHrsAlerts()
        {
            var testHRSAlerts = new List<HRSAlert>
            {
                new HRSAlert
                {
                    CaseRef = 1,
                    Name = "Name1",
                    Alert = "Alert1",
                    Date = DateTime.Today,
                    CaseEventID = 1,
                    DOB = DateTime.Today
                },
                new HRSAlert
                {
                    CaseRef = 2,
                    Name = "Name2",
                    Alert = "Alert2",
                    Date = DateTime.Today,
                    CaseEventID = 2,
                    DOB = DateTime.Today
                }
            }.AsQueryable();

            return testHRSAlerts;
        }

        protected IQueryable<lstQuestion> GetTestHRSQuestions()
        {
            var testQuestions = new List<lstQuestion>
            {
                new lstQuestion
                {
                    QstnID = 200,
                    QstnairID = 4,
                    Seqno = 1,
                    PrevQstnID = 0,
                    NextQstnID = 2,
                    NextQstnIDYes = null,
                    NextQstnIDNo = null,
                    QstnairSectionID = null,
                    QstnairSubSectionID = null,
                    QstnText = "TestQstnText1",
                    AnswerTypeID = 1,
                    NoteAllowed = true,
                    NoteAllowedYes = false,
                    NoteAllowedNo = false,
                    NoteRequired = false,
                    LookupTableName = null,
                    LookupIDFieldName = null,
                    LookupValueFieldName = null,
                    AllowMultiSelect = false,
                    HintText = "TestHintText1",
                    AllowYNAndNeither = null,
                    YesText = null,
                    NoText = null,
                    EventIDOnAnswer = null,
                    EventIDOnYes = null,
                    EventIDOnNo = null,
                    AllowMultipleEventsOnAnswer = null,
                    RefTable = "",
                    RefColumn = "",
                    NeitherText = null,
                    NoteAllowedNeither = null,
                    ListOther = null,
                    ListDTA = null,
                    ListOtherNoteAllowed = null,
                    ListDTANoteAllowed = null,
                    NextForm = "",
                    NextFormYes = "",
                    NextFormNo = "",
                    NextFormNeither = "",
                    ConfirmAdviceDelivered = null,
                    RelatedRAQstnairID = null,
                    RelatedRAQstnID = null
                },
                new lstQuestion
                {
                    QstnID = 201,
                    QstnairID = 4,
                    Seqno = 2,
                    PrevQstnID = 1,
                    NextQstnID = 3,
                    NextQstnIDYes = null,
                    NextQstnIDNo = null,
                    QstnairSectionID = null,
                    QstnairSubSectionID = null,
                    QstnText = "TestQstnText2",
                    AnswerTypeID = 1,
                    NoteAllowed = true,
                    NoteAllowedYes = false,
                    NoteAllowedNo = false,
                    NoteRequired = false,
                    LookupTableName = null,
                    LookupIDFieldName = null,
                    LookupValueFieldName = null,
                    AllowMultiSelect = false,
                    HintText = "TestHintText2",
                    AllowYNAndNeither = null,
                    YesText = null,
                    NoText = null,
                    EventIDOnAnswer = null,
                    EventIDOnYes = null,
                    EventIDOnNo = null,
                    AllowMultipleEventsOnAnswer = null,
                    RefTable = "",
                    RefColumn = "",
                    NeitherText = null,
                    NoteAllowedNeither = null,
                    ListOther = null,
                    ListDTA = null,
                    ListOtherNoteAllowed = null,
                    ListDTANoteAllowed = null,
                    NextForm = "",
                    NextFormYes = "",
                    NextFormNo = "",
                    NextFormNeither = "",
                    ConfirmAdviceDelivered = null,
                    RelatedRAQstnairID = null,
                    RelatedRAQstnID = null
                }
            }.AsQueryable();

            return testQuestions;
        }

        protected IQueryable<HRSQuestionAnswer> GetTestHRSAnswers()
        {
            var testAnswers = new List<HRSQuestionAnswer>
            {
                new HRSQuestionAnswer
                {
                    AnswerID = 1,
                    QstnairID = 4,
                    QstnID = 1,
                    CaseRef = 1,
                    Seqno = 1,
                    AnswerTypeID = 1,
                    AnswerValue = "TestAnswerValue1",
                    QstnAltID = 1,
                    AddDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    Note = "TestNote1",
                    YesNote = null,
                    NoNote = null,
                    PrevQstnID = 0,
                    NextQstnID = 1,
                    QstnAltChecked = null,
                    OtherChecked = null,
                    OtherNote = null,
                    AdviceDelivered = null,
                    AdviceDeliveredDate = null,
                    QstnChangeTypeID = null,
                    CaseNoteID = null,
                    CommonQstn = null
                },
                new HRSQuestionAnswer
                {
                    AnswerID = 2,
                    QstnairID = 4,
                    QstnID = 2,
                    CaseRef = 1,
                    Seqno = 2,
                    AnswerTypeID = 1,
                    AnswerValue = "TestAnswerValue2",
                    QstnAltID = 2,
                    AddDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    Note = "TestNote2",
                    YesNote = null,
                    NoNote = null,
                    PrevQstnID = 1,
                    NextQstnID = 2,
                    QstnAltChecked = null,
                    OtherChecked = null,
                    OtherNote = null,
                    AdviceDelivered = null,
                    AdviceDeliveredDate = null,
                    QstnChangeTypeID = null,
                    CaseNoteID = null,
                    CommonQstn = null
                },
                new HRSQuestionAnswer
                {
                    AnswerID = 3,
                    QstnairID = 4,
                    QstnID = 1,
                    CaseRef = 2,
                    Seqno = 1,
                    AnswerTypeID = 1,
                    AnswerValue = "TestAnswerValue3",
                    QstnAltID = 1,
                    AddDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    Note = "TestNote3",
                    YesNote = null,
                    NoNote = null,
                    PrevQstnID = 0,
                    NextQstnID = 1,
                    QstnAltChecked = null,
                    OtherChecked = null,
                    OtherNote = null,
                    AdviceDelivered = null,
                    AdviceDeliveredDate = null,
                    QstnChangeTypeID = null,
                    CaseNoteID = null,
                    CommonQstn = null
                }
            }.AsQueryable();

            return testAnswers;
        }

        protected IQueryable<HRSQuestionAnswerDTO> GetTestHRSAnswersDTO()
        {
            var testAnswers = new List<HRSQuestionAnswerDTO>
            {
                new HRSQuestionAnswerDTO
                {
                    AnswerID = 1,
                    QstnairID = 4,
                    QstnID = 1,
                    CaseRef = 1,
                    Seqno = 1,
                    AnswerTypeID = 1,
                    AnswerValue = "TestAnswerValue1",
                    QstnAltID = 1,
                    AddDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    Note = "TestNote1",
                    YesNote = null,
                    NoNote = null,
                    PrevQstnID = 0,
                    NextQstnID = 1,
                    QstnAltChecked = null,
                    OtherChecked = null,
                    OtherNote = null,
                    AdviceDelivered = null,
                    AdviceDeliveredDate = null,
                    QstnChangeTypeID = null,
                    CaseNoteID = null,
                    CommonQstn = null
                },
                new HRSQuestionAnswerDTO
                {
                    AnswerID = 2,
                    QstnairID = 4,
                    QstnID = 2,
                    CaseRef = 1,
                    Seqno = 2,
                    AnswerTypeID = 1,
                    AnswerValue = "TestAnswerValue2",
                    QstnAltID = 2,
                    AddDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    Note = "TestNote2",
                    YesNote = null,
                    NoNote = null,
                    PrevQstnID = 1,
                    NextQstnID = 2,
                    QstnAltChecked = null,
                    OtherChecked = null,
                    OtherNote = null,
                    AdviceDelivered = null,
                    AdviceDeliveredDate = null,
                    QstnChangeTypeID = null,
                    CaseNoteID = null,
                    CommonQstn = null
                },
                new HRSQuestionAnswerDTO
                {
                    AnswerID = 3,
                    QstnairID = 4,
                    QstnID = 1,
                    CaseRef = 2,
                    Seqno = 1,
                    AnswerTypeID = 1,
                    AnswerValue = "TestAnswerValue3",
                    QstnAltID = 1,
                    AddDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    Note = "TestNote3",
                    YesNote = null,
                    NoNote = null,
                    PrevQstnID = 0,
                    NextQstnID = 1,
                    QstnAltChecked = null,
                    OtherChecked = null,
                    OtherNote = null,
                    AdviceDelivered = null,
                    AdviceDeliveredDate = null,
                    QstnChangeTypeID = null,
                    CaseNoteID = null,
                    CommonQstn = null
                }
            }.AsQueryable();

            return testAnswers;
        }

        protected IQueryable<AuditLog> GetTestAuditLogs()
        {
            var testAuditLogs = new List<AuditLog>
            {
                new AuditLog
                {
                    AuditLogId = 1,
                    UserName = "TestUserName1",
                    UserIPAddress = "TestIPAddress1",
                    AuditDescription = "TestAuditDescription1",
                    EventDateUTC = DateTime.Today,
                    EventType = EventType.Added,
                    TableName = "TestTableName1",
                    RecordId = "1",
                    AuditLogDetails = new List<AuditLogDetail>
                    {
                        new AuditLogDetail
                        {
                            Id = 1,
                            ColumnName = "TestColumnName1",
                            OriginalValue = "TestOriginalValue1",
                            NewValue = "NewValue1",
                            AuditLogId = 1
                        },
                        new AuditLogDetail
                        {
                            Id = 2,
                            ColumnName = "TestColumnName2",
                            OriginalValue = "TestOriginalValue2",
                            NewValue = "NewValue2",
                            AuditLogId = 2
                        }
                    }
                },
                new AuditLog
                {
                    AuditLogId = 2,
                    UserName = "TestUserName2",
                    UserIPAddress = "TestIPAddress2",
                    AuditDescription = "TestAuditDescription2",
                    EventDateUTC = DateTime.Today,
                    EventType = EventType.Added,
                    TableName = "TestTableName2",
                    RecordId = "2",
                    AuditLogDetails = new List<AuditLogDetail>
                    {
                        new AuditLogDetail
                        {
                            Id = 3,
                            ColumnName = "TestColumnName3",
                            OriginalValue = "TestOriginalValue3",
                            NewValue = "NewValue3",
                            AuditLogId = 3
                        },
                        new AuditLogDetail
                        {
                            Id = 4,
                            ColumnName = "TestColumnName4",
                            OriginalValue = "TestOriginalValue4",
                            NewValue = "NewValue4",
                            AuditLogId = 4
                        }
                    }
                }
            }.AsQueryable();

            return testAuditLogs;
        }
    }
}