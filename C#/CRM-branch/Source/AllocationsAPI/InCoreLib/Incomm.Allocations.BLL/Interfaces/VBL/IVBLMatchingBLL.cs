using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.StoreProcedure;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IVBLMatchingBLL
    {
        List<VoidPropertyMatchForApplication> GetPotentialVoidMatches(VBLApplicationSummaryDTO customer);
        List<string> GetPostcodesInApplicationAreaSelection(int applicationId);
        List<VBLPropertyShopDTO> GetMutexMatches(int applicationId);
        VoidPropertyMatchForApplication GetCurrentMatch(string propertyCode);
        VoidPropertyMatchForApplication GetCurrentMatch(string propertyCode, int landlordId);

        List<VBLPropertyShopDTO> GetPropertyDetails(VBLApplicationDTO application);
        List<VoidPropertyMatchForApplication> GetVoidPropertyAvailableForRent();
    }
}
