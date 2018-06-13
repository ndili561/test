using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
   public interface IRequestedPropertymatchDetailBLL
    {
        VBLRequestedPropertymatchDetail GetRequestedPropertymatchDetail(int applicationId);
        VBLApplication Update(VBLRequestedPropertymatchDetail requestedPropertymatchDetail, VBLRequestedPropertymatchDetail persistedrequestedPropertymatchDetail);
    }
}
