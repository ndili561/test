using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IVBLCustomerInterestBLL
    {
        VBLCustomerInterest GetLatestCustomerInterest(int applicationId);

        VBLCustomerInterestDTO Interested(VBLCustomerInterestDTO customerInterest);
        VBLCustomerInterestDTO NotInterested(VBLCustomerInterestDTO customerInterest);
        VBLCustomerInterestDTO Reconsider(VBLCustomerInterestDTO customerInterest);
        List<VBLCustomerInterest> GetAllCustomerInterestsForApplication(int applicationId);

        VBLCustomerInterest GetCustomerInterest(int taskId, string propertyCode);
        VBLCustomerInterestDTO Rejected(VBLCustomerInterestDTO customerInterest);
        VBLCustomerInterestDTO MatchedFromWaitingList(VBLCustomerInterestDTO customerInterest);
        void UpdateRSLPropertyStatus(VBLCustomerInterestDTO customerInterest);
        VBLCustomerInterestDTO UpSertVblCustomerInterest(VBLCustomerInterestDTO customerInterest);
        IList<VBLCustomerInterest> GetCustomerInterests(IList<int> propertyMatchTaskIds);
    }
}
