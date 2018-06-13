using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class HostelBLL :  IHostelBLL
    {
        private IUnitOfWork _unitOfWork;
        public HostelBLL() : this(new UnitOfWork())
        {
        }

        public HostelBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<HostelDTO> GetHostels(ODataQueryOptions<Hostel> options)
        {
            var hostels = options.ApplyTo(_unitOfWork.Hostel().Select(includeProperties: "HrsProvider").Where(x=>x.Active == true).AsQueryable());
            return  Mapper.Map<List<HostelDTO>>(hostels);
        }

        public List<HostelDTO> GetAllHostels()
        {
            var hostels = _unitOfWork.Hostel().Select().AsQueryable();
            return Mapper.Map<List<HostelDTO>>(hostels);
        } 

        public HostelDTO Hostel(int hostelId)
        {
            var result = _unitOfWork.Hostel().Select().FirstOrDefault(x => x.HostelId == hostelId);
            var result2 = Mapper.Map<HostelDTO>(result);
            return result2;
        }
        public HostelDTO PostHostel(HostelDTO item)
        {
            var entityTobeSave = Mapper.Map<Hostel>(item);
            _unitOfWork.Hostel().Insert(entityTobeSave);
            _unitOfWork.Commit(entityTobeSave.UserId, entityTobeSave.UserIPAddress);
          return  Mapper.Map<HostelDTO>(entityTobeSave);
         
        }
        public HostelDTO PutHostel(int id, HostelDTO hostelDto)
        {
            var persistedObject = _unitOfWork.Hostel().Select().FirstOrDefault(x => x.HostelId == id);
            if (persistedObject == null) return null;
            persistedObject.UserId = hostelDto.UserId;
            persistedObject.UserIPAddress = hostelDto.UserIPAddress;
            persistedObject.Code = hostelDto.Code;
            persistedObject.Description = hostelDto.Description;
            persistedObject.HRSProviderId = hostelDto.HRSProviderId;
            persistedObject.Active = hostelDto.Active;
            _unitOfWork.Commit(persistedObject.UserId, persistedObject.UserIPAddress);
            return Mapper.Map<HostelDTO>(persistedObject);
            
        }

    }
}