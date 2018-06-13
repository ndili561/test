using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL
{
    public class MatchHistoryBLL :  IMatchHistoryBLL
    {
        private IUnitOfWork _unitOfWork;
        public MatchHistoryBLL() : this(new UnitOfWork())
        {
        }

        public MatchHistoryBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public HRSMatchHistoryDTO HRSMatch(int matchId, bool returnSingle)
        {
            var match =
                _unitOfWork.HRSMatchHistory()
                    .Select(
                        includeProperties:
                            "Placement.SupportType,Placement.ServiceTypes,Placement,Customer,Customer.SupportTypes,Customer.ServiceTypes,Placement.HRSProvider")
                    .FirstOrDefault(x => x.MatchHistoryId == matchId);
            var matchDTO = Mapper.Map<HRSMatchHistoryDTO>(match);

            return matchDTO;
        }

        public HRSMatchHistoryDTO GetAcceptedHRSMatch(int customerId, bool returnSingle, int placementId)
        {
            var match =
                _unitOfWork.HRSMatchHistory()
                    .Select(
                        includeProperties:
                            "Placement.SupportType,Placement.ServiceTypes,Placement,Customer,Customer.SupportTypes,Customer.ServiceTypes,Placement.HRSProvider")
                    .Where(x => x.Customer.HRSCustomerId == customerId && x.Outcome == Status.AcceptedByProvider && x.Placement.PlacementId == placementId)
                    .OrderByDescending(x => x.MatchHistoryId)
                    .FirstOrDefault();
            var matchDTO = Mapper.Map<HRSMatchHistoryDTO>(match);

            return matchDTO;
        }

        public List<HRSMatchHistoryDTO> GetMatchHistoryForCustomer(int hrsCustomerId)
        {
            var matches =
               _unitOfWork.HRSMatchHistory()
                   .Select(
                       includeProperties:
                           "Placement.SupportType,Placement.ServiceTypes,Placement,Customer,Customer.SupportTypes,Customer.ServiceTypes,Placement.HRSProvider")
                   .Where(x => x.Customer.HRSCustomerId == hrsCustomerId);
            var matchesDTO = Mapper.Map<List<HRSMatchHistoryDTO>>(matches.ToList());
            //foreach (var hrsMatchHistoryDto in matchesDTO)
            //{
            //    if (!string.IsNullOrWhiteSpace(hrsMatchHistoryDto.Notes)) continue;
            //    var matchedPlacement = _unitOfWork
            //        .HRSPlacementMatchedForCustomer()
            //        .Select()
            //        .FirstOrDefault(
            //            y =>
            //                y.CustomerId == hrsMatchHistoryDto.Customer.HRSCustomerId &&
            //                y.PlacementId == hrsMatchHistoryDto.Placement.PlacementId
            //                && (int) y.RejectionReason > 0
            //                && (int) hrsMatchHistoryDto.Reason > 0);
            //    if (matchedPlacement != null)
            //        hrsMatchHistoryDto.Notes = matchedPlacement.Notes;
            //}
         
            return matchesDTO;
        }

        public List<HRSMatchHistoryDTO> GetAllMatchHistory()
        {
            var matches =
                 _unitOfWork.HRSMatchHistory()
                     .Select(
                         includeProperties:
                             "Placement.SupportType,Placement.ServiceTypes,Placement,Customer,Customer.SupportTypes,Customer.ServiceTypes,Placement.HRSProvider");
            var matchesDTO = Mapper.Map<List<HRSMatchHistoryDTO>>(matches.ToList());

            return matchesDTO;
        }

        public HRSMatchHistoryDTO ReconsiderPreviousMatch(int matchId, HRSPlacementMatchedForCustomerDTO match)
        {
            var persistedMatch =
                _unitOfWork.HRSMatchHistory()
                    .Select(includeProperties: "Customer,Placement")
                    .FirstOrDefault(x => x.MatchHistoryId == matchId);
            if (persistedMatch != null)
            {
                persistedMatch.UserId = match.UserId;
                persistedMatch.UserIPAddress = match.UserIPAddress;
                persistedMatch.ModifiedBy = match.ModifiedBy;
                persistedMatch.ModifiedDate = match.ModifiedDate;

                persistedMatch.Reconsidered = true;
                _unitOfWork.HRSMatchHistory().Update(persistedMatch);
                _unitOfWork.Commit(persistedMatch.UserId, persistedMatch.UserIPAddress);
            }
          return  Mapper.Map<HRSMatchHistoryDTO>(persistedMatch);
        }
    }
}