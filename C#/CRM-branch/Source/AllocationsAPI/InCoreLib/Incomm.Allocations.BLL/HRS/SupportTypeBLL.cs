using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL
{
    public class SupportTypeBLL :  ISupportTypeBLL
    {

        private IUnitOfWork _unitOfWork;
        public SupportTypeBLL() : this(new UnitOfWork())
        {
        }

        public SupportTypeBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<SupportTypeDTO> GetSupportTypes()
        {
            var persistedObject = _unitOfWork.SupportType().Select();
            var placementTypeViewModel = Mapper.Map<List<SupportTypeDTO>>(persistedObject.ToList());
            return placementTypeViewModel;
        }

        public SupportTypeDTO GetSupportType(int supportTypeId)
        {
            var persistedObject = _unitOfWork.SupportType()
               .Select()
               .FirstOrDefault(x => x.SupportTypeId == supportTypeId);
            var placementTypeViewModel = Mapper.Map<SupportTypeDTO>(persistedObject);
            return placementTypeViewModel;
        }

        public SupportTypeDTO Create(SupportTypeDTO supportTypeDto)
        {
            var entityTobeSave = Mapper.Map<SupportType>(supportTypeDto);
            _unitOfWork.SupportType().Insert(entityTobeSave);
            _unitOfWork.Commit(supportTypeDto.UserId, supportTypeDto.UserIPAddress);
            return Mapper.Map<SupportTypeDTO>(entityTobeSave);
          
        }

        public SupportTypeDTO Update(SupportTypeDTO supportTypeDto)
        {
            var persistedObject = _unitOfWork.SupportType().Select().FirstOrDefault(x => x.SupportTypeId == supportTypeDto.SupportTypeId);
            if (persistedObject != null)
            {
                persistedObject.UserId = supportTypeDto.UserId;
                persistedObject.UserIPAddress = supportTypeDto.UserIPAddress;
                _unitOfWork.Commit(supportTypeDto.UserId, supportTypeDto.UserIPAddress);
            }
            return Mapper.Map<SupportTypeDTO>(persistedObject);
        }
    }
}