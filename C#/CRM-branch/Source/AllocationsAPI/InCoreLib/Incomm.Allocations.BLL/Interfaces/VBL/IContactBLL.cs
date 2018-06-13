using System.Collections.Generic;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Database.VBL.Search;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IContactBLL
    {
        string GetContactRowVersion(int applicationId);
        VBLContactDTO GetContactDto(int contactId);
        VBLContact GetContact(int contactId);
        List<VBLContact> GetContacts(ODataQueryOptions<VBLContact> options);
        List<SearchContact> GetContactsForSearch(ODataQueryOptions<SearchContact> options);
        VBLContactDTO Create(VBLContactDTO contact);
        VBLContactDTO Update(VBLContactDTO contact);

        void Delete(int contactId, string userId, string userIPAddress);
        IList<VBLContact> GetContacts(IList<int> applicationIds);
        TransferCheck GetTransferCheck(int contactId);
        bool SaveTransferCheck(TransferCheck transferCheck);
        VBLContact GetMainContactForApplication(int applicationApplicationId);
    }
}