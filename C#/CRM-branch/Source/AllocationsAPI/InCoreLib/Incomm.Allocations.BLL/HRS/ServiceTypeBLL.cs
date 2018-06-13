using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL
{
    public class ServiceTypeBLL :  IServiceTypeBLL
    {

        private IUnitOfWork _unitOfWork;
        public ServiceTypeBLL() : this(new UnitOfWork())
        {
        }

        public ServiceTypeBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ServiceTypeDTO> GetServiceTypes()
        {
            var persistedObject = _unitOfWork.ServiceType().Select();
            var serviceTypes = Mapper.Map<List<ServiceTypeDTO>>(persistedObject.ToList());
            return serviceTypes;
        }

        public ServiceTypeDTO GetServiceType(int serviceTypeId)
        {
            var persistedObject = _unitOfWork.ServiceType()
              .Select()
              .FirstOrDefault(x => x.ServiceTypeId == serviceTypeId);
            var placementTypeViewModel = Mapper.Map<ServiceTypeDTO>(persistedObject);
            return placementTypeViewModel;
        }

        public ServiceTypeDTO Create(ServiceTypeDTO serviceTypeDto)
        {
            var entityTobeSave = Mapper.Map<ServiceType>(serviceTypeDto);
            _unitOfWork.ServiceType().Insert(entityTobeSave);
            _unitOfWork.Commit(serviceTypeDto.UserId, serviceTypeDto.UserIPAddress);
            return  Mapper.Map<ServiceTypeDTO>(entityTobeSave);
        }

        public ServiceTypeDTO Update(ServiceTypeDTO serviceTypeDto)
        {
            var persistedObject = _unitOfWork.ServiceType().Select().FirstOrDefault(x => x.ServiceTypeId == serviceTypeDto.ServiceTypeId);
            if (persistedObject != null)
            {
                // update the properties
                persistedObject.UserId = serviceTypeDto.UserId;
                persistedObject.UserIPAddress = serviceTypeDto.UserIPAddress;
                _unitOfWork.Commit(serviceTypeDto.UserId, serviceTypeDto.UserIPAddress);
            }
            return Mapper.Map<ServiceTypeDTO>(persistedObject);
        }
    }
}