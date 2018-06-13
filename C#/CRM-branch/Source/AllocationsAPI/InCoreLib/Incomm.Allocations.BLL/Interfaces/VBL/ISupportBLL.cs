using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface ISupportBLL
    {
        VBLContact GetContact(int contactId);

        VBLSupportDetailsDTO GetSupport(int contactId, int supportId);
        VBLReceivingSupportDetails Create(VBLSupportDetailsDTO supportDetail);
        VBLContact Update(VBLContact contact, VBLContact persistedContact);
        VBLSupportDetailsDTO UpdateSupport(VBLSupportDetailsDTO support, VBLSupportDetailsDTO persistedSupport);
        void Delete(int id, string userId, string userIPAddress);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        List<VBLSupportDetailsDTO> GetSupport(int contactId);

        EntityPager<VBLSupportDetailsDTO> GetSupport(int contactId, int pageSize, int pageNumber);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userIPAddress"></param>
        /// <returns></returns>
        bool DeleteRequiredSupportDetails(int id, string userId, string userIPAddress);

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        VBLRequiredSupportDetailDTO GetSupportDetails(int contactId);
    }
}
