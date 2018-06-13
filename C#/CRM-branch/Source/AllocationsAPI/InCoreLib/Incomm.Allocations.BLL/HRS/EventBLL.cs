using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL
{
    public class EventBLL : IEventBLL
    {
        private IUnitOfWork _unitOfWork;

        public EventBLL() : this(new UnitOfWork())
        {
        }

        public EventBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public tsubHOAEventDTO GetEvent(int id)
        {
            var eventId = 0;
            int.TryParse(WebConfigurationManager.AppSettings["EventID"], out eventId);
            var result =
                _unitOfWork.tsubHOAEvent().Select().FirstOrDefault(x => x.CaseEventID == id && x.EventID == eventId);
            var result2 = Mapper.Map<tsubHOAEventDTO>(result);
            return result2;
        }

        public IEnumerable<tsubHOAEventDTO> GetAllEvents()
        {
            var result = _unitOfWork.tsubHOAEvent().Select();
            var result2 = Mapper.Map<List<tsubHOAEventDTO>>(result);
            return result2;
        }


        public tsubHOAEventDTO PutEvent(int id, tsubHOAEventDTO eventDto)
        {
            var hoaEvent = _unitOfWork.tsubHOAEvent().Select().FirstOrDefault(x => x.CaseEventID == id);
            var alert = _unitOfWork.HRSAlert().Select().FirstOrDefault(x => x.CaseEventID == id);
            var hoaEventDto = new tsubHOAEventDTO();
            if (hoaEvent != null && alert != null)
            {
                hoaEvent.AssignedTo = eventDto.AssignedTo;
                _unitOfWork.tsubHOAEvent().Update(hoaEvent);
                var customer = new HRSCustomer
                {
                    HOACaseReference = alert.CaseRef,
                    Name = alert.Name,
                    DoB = alert.DOB,
                    DateAdded = alert.Date,
                    Gender = CustomerGender.None,
                    Status = Status.AssignedToHRSOfficer,
                    GatewayOfficer = eventDto.AssignedTo,
                    CreatedBy = eventDto.UserId,
                    CreatedDate = DateTime.Now,
                    UserId = eventDto.UserId,
                    UserIPAddress = eventDto.UserIPAddress
                };
                _unitOfWork.HRSCustomer().Insert(customer);
                _unitOfWork.Commit(customer.UserId, customer.UserIPAddress);
                hoaEventDto = Mapper.Map<tsubHOAEventDTO>(hoaEvent);
                hoaEventDto.HRSCustomerId = customer.HRSCustomerId;
                return hoaEventDto;
            }
            return hoaEventDto;
        }

        public void DeleteEvent(int id)
        {
            _unitOfWork.tsubHOAEvent().Delete(id);
            _unitOfWork.Commit();
        }
    }
}
