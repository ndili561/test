using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.DTOs.Audit;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.CRM;
using Incomm.Allocations.DTO.IH.Expenditure;
using Incomm.Allocations.DTO.IH.Income;
using Incomm.Allocations.DTO.IH.SuitabilityNote;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.Audit.Domain;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;
using System.Linq;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Service.Api.DTOs;
using GenderDto = Incomm.Allocations.BLL.DTOs.GenderDto;
using TitleDto = Incomm.Allocations.BLL.DTOs.TitleDto;

namespace AllocationsAPI.WebAPI
{
    public class AutoMapperConfig
    {
        /// <summary>
        ///     A convention based object to object mapper.
        /// </summary>
        public static void Initialise()
        {
            MapEnums();
            InitializeAllocationMappings();
        }

        private static void InitializeAllocationMappings()
        {
            #region Allocations

            Mapper.CreateMap<BaseObjectDto, BaseObject>().ReverseMap();
                //.Include<VBLContactDTO, VBLContact>()
                //.Include<VBLContact, VBLContactDTO>();
                
            Mapper.CreateMap<VBLContact, VBLContactDTO>()
                .IncludeBase<BaseObject, BaseObjectDto>()
                .ReverseMap();
            Mapper.CreateMap<VBLDocument, VBLDocumentDTO>()
                .IncludeBase<BaseObject, BaseObjectDto>()
                .ReverseMap();
            Mapper.CreateMap<PersonApplicationLink, PersonApplicationLinkDto>().ReverseMap();
            Mapper.CreateMap<Person, PersonDto>().ReverseMap();

            Mapper.CreateMap<PersonApplicationLink, PersonApplicationLinkDto>().ReverseMap();
            Mapper.CreateMap<PersonAddress, PersonAddressDto>()
                .ForMember(x => x.AddressType, m => m.Ignore())
                .ReverseMap();
          
            Mapper.CreateMap<Address, AddressDto>().ReverseMap();
            Mapper.CreateMap<PersonContactDetail, PersonContactDetailDto>().ReverseMap();

            Mapper.CreateMap<PersonContactDetailDto, VBLContactByDetailsDTO>()
                .ForMember(x => x.ContactById, m => m.MapFrom(i => i.ContactByOptionId))
                .ForMember(x => x.ContactText, m => m.MapFrom(i => i.Comment));
            Mapper.CreateMap<VBLContactByDetailsDTO, PersonContactDetailDto>()
                .ForMember(x => x.ContactByOptionId, m => m.MapFrom(i => i.ContactById))
                .ForMember(x => x.Comment, m => m.MapFrom(i => i.ContactText));

            Mapper.CreateMap<VBLContactByDetails, VBLContactByDetailsDTO>()
                .ReverseMap();
            Mapper.CreateMap<VBLIncomeDetail, VBLIncomeDetailDTO>().ReverseMap();
            Mapper.CreateMap<VBLApplication, VBLApplicationDTO>()
                .IncludeBase<BaseObject, BaseObjectDto>()
                .ReverseMap();
            Mapper.CreateMap<VBLApplication, CRMVBLApplicationDTO>()
                .IncludeBase<BaseObject, BaseObjectDto>()
                .ReverseMap();
            Mapper.CreateMap<VBLRequestedPropertymatchDetail, VBLRequestedPropertymatchDetailDTO>()
                .ReverseMap();
            Mapper.CreateMap<VBLMutualExchagePropertyDetail, VBLMutualExchagePropertyDetailDTO>()
                .ReverseMap();
            Mapper.CreateMap<CRMVBLContactDTO, VBLContact>()
                .IncludeBase<BaseObject, BaseObjectDto>()
                .ReverseMap();
            Mapper.CreateMap<SearchContact, SearchContactDto>()
                .ReverseMap();
            Mapper.CreateMap<ContactBy, ContactByDTO>()
                .ReverseMap();
            Mapper.CreateMap<VBLAddress, VBLAddressDTO>()
                .IncludeBase<BaseObject, BaseObjectDto>()
                .ReverseMap();
            Mapper.CreateMap< AddressDto, VBLAddress>()
                .ForMember(x => x.AddressId,m => m.MapFrom(i => i.Id))
                .IncludeBase<BaseObject, BaseDto>()
                .ReverseMap();

            Mapper.CreateMap<VBLCustomerInterest, VBLCustomerInterestDTO>()
                .IncludeBase<BaseObject, BaseObjectDto>()
                .ReverseMap();
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
            Mapper.CreateMap<VBLPropertyShopDTO, tbl_Property>();
            Mapper.CreateMap<tbl_Property, VBLPropertyShopDTO>();

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
            Mapper.CreateMap<VBLReceivingSupportDetails, VBLSupportDetailsDTO>()
                .ForMember(dest => dest.SupportDetailId, opts => opts.MapFrom(src => src.ReceivingSupportDetailId));
            Mapper.CreateMap<VBLSupportDetailsDTO, VBLReceivingSupportDetails>()
                .ForMember(dest => dest.ReceivingSupportDetailId, opts => opts.MapFrom(src => src.SupportDetailId)); ;
            Mapper.CreateMap<VBLIncomeDetail, IncomeDetailDTO>();
            Mapper.CreateMap<VBLExpenditureDetail, ExpenditureDetailDTO>();
            Mapper.CreateMap<IncomeType, IncomeTypeDTO>();
            Mapper.CreateMap<IncomeFrequency, IncomeFrequencyDTO>();
            Mapper.CreateMap<ExpenditureType, ExpenditureTypeDTO>();
            Mapper.CreateMap<VBLExpenditureDetail, ExpenditureDetailDTO>();
            Mapper.CreateMap<AuditVblExpenditureDetails, AuditVblExpenditureDetailsDTO>();
            Mapper.CreateMap<AuditVBLIncomeDetails, AuditIncomeDetailDTO>();
            Mapper.CreateMap<VBLNote, VBLNoteDTO>();
            

            Mapper.CreateMap<SuitabilityCheckAction, SuitabilityCheckActionDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayTabName, opts => opts.MapFrom(src => src.DisplayTabName))
                .ForMember(dest => dest.ContactId, opts => opts.MapFrom(src => src.ContactId))
                .ForMember(dest => dest.ActionCategoryId, opts => opts.MapFrom(src => src.ActionCategoryId))
                .ForMember(dest => dest.ActionTypeId, opts => opts.MapFrom(src => src.ActionTypeId))
                .ForMember(dest => dest.ActionLoggedDate, opts => opts.MapFrom(src => src.ActionLoggedDate))
                .ForMember(dest => dest.ActionLoggedById, opts => opts.MapFrom(src => src.ActionLoggedById))
                .ForMember(dest => dest.DateToComplete, opts => opts.MapFrom(src => src.DateToComplete))
                .ForMember(dest => dest.ActionResponsibilityId, opts => opts.MapFrom(src => src.ActionResponsibilityId))
                .ForMember(dest => dest.ActionCompletedDate, opts => opts.MapFrom(src => src.ActionCompletedDate))
                .ForMember(dest => dest.ConcurrencyCheck, opts => opts.MapFrom(src => src.ConcurrencyCheck))
                .ForMember(dest => dest.LastModifiedById, opts => opts.MapFrom(src => src.LastModifiedById))
                .ForMember(dest => dest.ModifiedTimestamp, opts => opts.MapFrom(src => src.ModifiedTimestamp));

            Mapper.CreateMap<SuitabilityCheckAction, SuitabilityCheckActionDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayTabName, opts => opts.MapFrom(src => src.DisplayTabName))
                .ForMember(dest => dest.ContactId, opts => opts.MapFrom(src => src.ContactId))
                .ForMember(dest => dest.ActionCategoryId, opts => opts.MapFrom(src => src.ActionCategoryId))
                .ForMember(dest => dest.ActionTypeId, opts => opts.MapFrom(src => src.ActionTypeId))
                .ForMember(dest => dest.ActionLoggedDate, opts => opts.MapFrom(src => src.ActionLoggedDate))
                .ForMember(dest => dest.ActionLoggedById, opts => opts.MapFrom(src => src.ActionLoggedById))
                .ForMember(dest => dest.DateToComplete, opts => opts.MapFrom(src => src.DateToComplete))
                .ForMember(dest => dest.ActionResponsibilityId, opts => opts.MapFrom(src => src.ActionResponsibilityId))
                .ForMember(dest => dest.ActionCompletedDate, opts => opts.MapFrom(src => src.ActionCompletedDate))
                .ForMember(dest => dest.ConcurrencyCheck, opts => opts.MapFrom(src => src.ConcurrencyCheck))
                .ForMember(dest => dest.LastModifiedById, opts => opts.MapFrom(src => src.LastModifiedById))
                .ForMember(dest => dest.ModifiedTimestamp, opts => opts.MapFrom(src => src.ModifiedTimestamp));

            Mapper.CreateMap<SuitabilityCheckRisk, SuitabilityCheckRiskDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayTabName, opts => opts.MapFrom(src => src.DisplayTabName))
                .ForMember(dest => dest.ContactId, opts => opts.MapFrom(src => src.ContactId))
                .ForMember(dest => dest.RiskThemeId, opts => opts.MapFrom(src => src.RiskThemeId))
                .ForMember(dest => dest.RiskCategoryId, opts => opts.MapFrom(src => src.RiskCategoryId))
                .ForMember(dest => dest.RiskDetail, opts => opts.MapFrom(src => src.RiskDetail))
                .ForMember(dest => dest.LoggedDate, opts => opts.MapFrom(src => src.LoggedDate))
                .ForMember(dest => dest.LoggedById, opts => opts.MapFrom(src => src.LoggedById))
                .ForMember(dest => dest.ConcurrencyCheck, opts => opts.MapFrom(src => src.ConcurrencyCheck))
                .ForMember(dest => dest.LastModifiedById, opts => opts.MapFrom(src => src.LastModifiedById))
                .ForMember(dest => dest.ModifiedTimestamp, opts => opts.MapFrom(src => src.ModifiedTimestamp));

            Mapper.CreateMap<SuitabilityCheckRisk, SuitabilityCheckRiskDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayTabName, opts => opts.MapFrom(src => src.DisplayTabName))
                .ForMember(dest => dest.ContactId, opts => opts.MapFrom(src => src.ContactId))
                .ForMember(dest => dest.RiskThemeId, opts => opts.MapFrom(src => src.RiskThemeId))
                .ForMember(dest => dest.RiskCategoryId, opts => opts.MapFrom(src => src.RiskCategoryId))
                .ForMember(dest => dest.RiskDetail, opts => opts.MapFrom(src => src.RiskDetail))
                .ForMember(dest => dest.LoggedDate, opts => opts.MapFrom(src => src.LoggedDate))
                .ForMember(dest => dest.LoggedById, opts => opts.MapFrom(src => src.LoggedById))
                .ForMember(dest => dest.ConcurrencyCheck, opts => opts.MapFrom(src => src.ConcurrencyCheck))
                .ForMember(dest => dest.LastModifiedById, opts => opts.MapFrom(src => src.LastModifiedById))
                .ForMember(dest => dest.ModifiedTimestamp, opts => opts.MapFrom(src => src.ModifiedTimestamp));


            Mapper.CreateMap<ActionCategory, ActionCategoryDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<ActionCategory, ActionCategoryDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<ActionType, ActionTypeDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Action, opts => opts.MapFrom(src => src.Action))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<ActionType, ActionTypeDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Action, opts => opts.MapFrom(src => src.Action))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<ActionResponsibility, ActionResponsibilityDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<ActionResponsibility, ActionResponsibilityDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<RiskTheme, RiskThemeDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<RiskTheme, RiskThemeDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<RiskCategory, RiskCategoryDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.SortOrder));

            Mapper.CreateMap<SuitabilityNote, SuitabilityNoteDTO>();
            Mapper.CreateMap<SuitabilityNoteType, SuitabilityNoteTypeDTO>();
            Mapper.CreateMap<VBLIncommunitiesRelationship, VBLIncommunitiesRelationshipDTO>();

            Mapper.CreateMap<TransferCheck, TransferCheckDto>();
            Mapper.CreateMap<TransferCheckDto, TransferCheck>();

            #endregion Allocations
        }

        private static void MapEnums()
        {
            //Mapper.CreateMap<SupplierPriority, string>().ConvertUsing(src => src.ToString());
        }

        //public class ContactModelResolver<T> : ValueResolver<IContactModel, T>
        //{

        //    protected override T ResolveCore(IContactModel source)
        //    {
        //        return Mapper.Map<T>(source);
        //    }
        //}
    }
}