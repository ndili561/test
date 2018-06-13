using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL
{
    public class HousingGatewayBLL :  IHousingGatewayBLL
    {
        private IUnitOfWork _unitOfWork;
        public HousingGatewayBLL() : this(new UnitOfWork())
        {
        }

        public HousingGatewayBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<SupportTypeDTO> GetSupportTypeSync()
        {
            throw new NotImplementedException();
        }

        public Task<List<SupportTypeDTO>> GetSupportType()
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceTypeDTO>> GetServiceType()
        {
            throw new NotImplementedException();
        }

        public List<ServiceTypeDTO> GetServiceTypeSync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetApplicationHealth()
        {
            throw new NotImplementedException();
        }
    }
}