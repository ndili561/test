using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.DTOs.Audit;
using Incomm.Allocations.BLL.Interfaces;
using Incomm.Allocations.BLL.Interfaces.HRS;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Incomm.Allocations.BLL.Test.HRS
{
    [TestClass]
    public class HRSBaseTestClass
    {
        protected IUnitOfWork UnitOfWork;
        protected IAlertBLL AlertBLL;
        protected IAuditLogBLL AuditLogBLL;
        protected ICaseNoteBLL CaseNoteBLL;
        protected ICustomerBLL CustomerBLL;
        protected IEventBLL EventBLL;
        protected IExtendCaseNotesBLL ExtendCaseNotesBLL;
        protected IHostelBLL HostelBLL;
        protected IHRSProviderBLL HrsProviderBLL;
        protected IMatchHistoryBLL MatchHistoryBLL;
        protected IMatchingBLL MatchingBLL;
        protected IPlacementBLL PlacementBLL;
        protected IQuestionnaireBLL QuestionnaireBLL;
        protected IServiceTypeBLL ServiceTypeBLL;
        protected ISupportTypeBLL SupportTypeBLL;


        [TestInitialize]
        public void Setup()
        {
            Mapper.CreateMap<BaseObjectDto, BaseObject>();
            Mapper.CreateMap<BaseObject, BaseObjectDto>();
            Mapper.CreateMap<Gender, GenderDto>();
            Mapper.CreateMap<Title, TitleDto>();
            Mapper.CreateMap<Contact, ContactDto>();
            Mapper.CreateMap<HRSAlert, AlertDTO>();
            Mapper.CreateMap<tsubHOAEvent, tsubHOAEventDTO>();
            Mapper.CreateMap<tsubHOAEventDTO, tsubHOAEvent>();
            Mapper.CreateMap<HRSCustomer, HRSCustomerDTO>()
                .ForMember(x => x.SelectedServiceType,
                    m => m.MapFrom(i => i.ServiceTypes.Select(a => a.ServiceTypeId).ToList()))
                .ForMember(x => x.SelectedSupportType,
                    m => m.MapFrom(i => i.SupportTypes.Select(a => a.SupportTypeId).ToList()))
                .ForMember(x => x.SelectedServiceTypeDescription,
                    m => m.MapFrom(i => i.ServiceTypes.Select(a => a.Description).ToList()))
                .ForMember(x => x.SelectedSupportTypeDescription,
                    m => m.MapFrom(i => i.SupportTypes.Select(a => a.Description).ToList()));

            Mapper.CreateMap<HRSCustomerDTO, HRSCustomer>();
            Mapper.CreateMap<SupportTypeDTO, SupportType>();
            Mapper.CreateMap<ServiceTypeDTO, ServiceType>();
            Mapper.CreateMap<SupportType, SupportTypeDTO>();
            Mapper.CreateMap<ServiceType, ServiceTypeDTO>();
            Mapper.CreateMap<HRSPlacement, HRSPlacementDTO>();
            Mapper.CreateMap<HRSPlacementDTO, HRSPlacement>();
            Mapper.CreateMap<HRSPlacementMatchedForCustomer, HRSPlacementMatchedForCustomerDTO>();
            Mapper.CreateMap<HRSPlacementMatchedForCustomerDTO, HRSPlacementMatchedForCustomer>();
            Mapper.CreateMap<tblCaseNote, tblCaseNoteDTO>();
            Mapper.CreateMap<tblCaseNoteDTO, tblCaseNote>();
            Mapper.CreateMap<Hostel, HostelDTO>();
            Mapper.CreateMap<HostelDTO, Hostel>();
            Mapper.CreateMap<lstQuestion, lstQuestionDTO>();
            Mapper.CreateMap<lstQuestionDTO, lstQuestion>();
            Mapper.CreateMap<HRSQuestionAnswer, HRSQuestionAnswerDTO>();
            Mapper.CreateMap<HRSQuestionAnswerDTO, HRSQuestionAnswer>();
            Mapper.CreateMap<HRSProviderDTO, HRSProvider>();
            Mapper.CreateMap<HRSProvider, HRSProviderDTO>();
            Mapper.CreateMap<AuditLog, AuditLogDto>();
            Mapper.CreateMap<AuditLogDto, AuditLog>();
            Mapper.CreateMap<AuditLogDetail, AuditLogDetailDto>();
            Mapper.CreateMap<AuditLogDetailDto, AuditLogDetail>();
            Mapper.CreateMap<HRSMatchHistoryDTO, HRSMatchHistory>();
            Mapper.CreateMap<HRSMatchHistory, HRSMatchHistoryDTO>();

            Mapper.CreateMap<tblHOAssessment, HOAssessmentDTO>();
            Mapper.CreateMap<tblUserAdmin, HOAUserAdminDTO>();
            Mapper.CreateMap<lstContactType, HOAContactTypeDTO>();
            Mapper.CreateMap<lstEthnicity, HOAEthnicityDTO>();
            Mapper.CreateMap<lstNationalityType, HOANationalityTypeDTO>();
            Mapper.CreateMap<lstApproachReason, HOAApproachReasonDTO>();
            Mapper.CreateMap<lstEligibilityRight, HOAEligibilityRightsDTO>();
            Mapper.CreateMap<tblCaseNote, HOACaseNoteDTO>();
            Mapper.CreateMap<lstCaseNoteType, HOACaseNoteTypeDTO>();
            Mapper.CreateMap<tsubHOAExclusion, HOAExclusionDTO>();
            Mapper.CreateMap<lstAnswerType, HOAAnswerTypeDTO>();

            UnitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
            AlertBLL = MockRepository.GenerateMock<IAlertBLL>();
            AuditLogBLL = MockRepository.GenerateMock<IAuditLogBLL>();
            CaseNoteBLL = MockRepository.GenerateMock<ICaseNoteBLL>();
            CustomerBLL = MockRepository.GenerateMock<ICustomerBLL>();
            EventBLL = MockRepository.GenerateMock<IEventBLL>();
            ExtendCaseNotesBLL = MockRepository.GenerateMock<IExtendCaseNotesBLL>();
            HostelBLL = MockRepository.GenerateMock<IHostelBLL>();
            HrsProviderBLL = MockRepository.GenerateMock<IHRSProviderBLL>();
            MatchHistoryBLL = MockRepository.GenerateMock<IMatchHistoryBLL>();
            PlacementBLL = MockRepository.GenerateMock<IPlacementBLL>();
            QuestionnaireBLL = MockRepository.GenerateMock<IQuestionnaireBLL>();
            ServiceTypeBLL = MockRepository.GenerateMock<IServiceTypeBLL>();
            SupportTypeBLL = MockRepository.GenerateMock<ISupportTypeBLL>();
        }
    }
}