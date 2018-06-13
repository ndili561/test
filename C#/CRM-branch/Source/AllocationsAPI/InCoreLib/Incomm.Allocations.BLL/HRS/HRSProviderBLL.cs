using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL
{
    public class HRSProviderBLL :  IHRSProviderBLL
    {
        private IUnitOfWork _unitOfWork;
        public HRSProviderBLL() : this(new UnitOfWork())
        {
        }

        public HRSProviderBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<HRSProviderDTO> GetHRSProviders(ODataQueryOptions<HRSProvider> options)
        {
            var hostels = options.ApplyTo(_unitOfWork.HRSProvider().Select().AsQueryable());
            return Mapper.Map<List<HRSProviderDTO>>(hostels);
        }

        public HRSProviderDTO GetHRSProvider(int providerId)
        {
            var hrsProvider = _unitOfWork.HRSProvider().Select().FirstOrDefault(x => x.HRSProviderId == providerId);
            var hrsProviderDto = Mapper.Map<HRSProviderDTO>(hrsProvider);
            return hrsProviderDto;
        }

        public HRSProviderDTO PostHRSProvider(HRSProviderDTO item)
        {
            var entityTobeSave = Mapper.Map<HRSProvider>(item);
            _unitOfWork.HRSProvider().Insert(entityTobeSave);
            _unitOfWork.Commit(entityTobeSave.UserId, entityTobeSave.UserIPAddress);
            return Mapper.Map<HRSProviderDTO>(entityTobeSave);
        }

        public HRSProviderDTO PutHRSProvider(int id, HRSProviderDTO hrsProviderDto)
        {
            var persistedObject = _unitOfWork.HRSProvider().Select().FirstOrDefault(x => x.HRSProviderId == id);
            if (persistedObject == null) return null;
            persistedObject.Code = hrsProviderDto.Code;
            persistedObject.Description = hrsProviderDto.Description;
            persistedObject.UserId = hrsProviderDto.UserId;
            persistedObject.UserIPAddress = hrsProviderDto.UserIPAddress;
            //UnitOfWork.HRSProvider().Update(persistedObject);
            _unitOfWork.Commit(persistedObject.UserId, persistedObject.UserIPAddress);
            return Mapper.Map<HRSProviderDTO>(persistedObject);
        }
    }
}