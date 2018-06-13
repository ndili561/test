using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.StoreProcedure;

namespace Incomm.Allocations.BLL.VBL
{
    public class VBLPropertyShopBLL : GatewayAPIClient, IVBLPropertyShopBLL
    {
        private IUnitOfWork _unitOfWork;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public VBLPropertyShopBLL() : this(new UnitOfWork(), new ApplicationHistoryBLL())
        {
        }

        public VBLPropertyShopBLL(IUnitOfWork unitOfWork, IApplicationHistoryBLL applicationHistoryBLL)
        {
            _unitOfWork = unitOfWork;
            _applicationHistoryBLL = applicationHistoryBLL;
        }

        public VoidPropertyMatchForApplication GetVBLPropertyShop(string propertyCode)
        {
            return _unitOfWork.GetPropertyDetails(propertyCode);
          //return  base.GetVBLPropertyShop(propertyCode);
        }

    }
}
