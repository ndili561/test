using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.StoreProcedure;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IVBLPropertyShopBLL
    {
        VoidPropertyMatchForApplication GetVBLPropertyShop(string propertyCode);
       
    }
}
