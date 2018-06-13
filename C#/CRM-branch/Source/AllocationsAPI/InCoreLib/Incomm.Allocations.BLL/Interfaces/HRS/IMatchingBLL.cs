using System.Collections.Generic;

namespace Incomm.Allocations.BLL.Interfaces.HRS
{
   public interface IMatchingBLL
   {
       void AddMatchingCustomerListToPlacement(int hrsPlacementId, string selectedSupportTypeId, string selectedServiceTypeId);

       void AddMatchingPlacementListToCustomer(int hrsCustomerId, List<string> selectedSupportTypeIds,List<string> selectedServiceTypeIds);
   }
}
