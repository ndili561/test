using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface ICustomerBLL
    {
        CustomerViewModel GetProviderCustomerList(CustomerViewModel customerViewModel, int providerId);

        List<HRSCustomerDTO> GetHRSCustomers(ODataQueryOptions<HRSCustomer> options);


        HRSCustomerDTO GetHRSCustomer(int customerId);

        HRSCustomerDTO RunMatchAlgorithmAndGetHRSCustomer(int hrsCustomerId, bool runMatchAlgorithm);

        HRSCustomerDTO PostHRSCustomer(HRSCustomerDTO item);

        HRSCustomerDTO UpdateCustomer(int id, HRSCustomerDTO hrsCustomerDto);

        Task<List<HRSCustomerDTO>> GetHRSCustomersList(string assignedTo);

        List<HRSCustomerDTO> GetHRSCustomersListSync(string assignedTo);
        void DeleteCustomer(int id);
        HRSCustomerDTO GetHRSCustomerSync(int customerId);
        HRSCustomerDTO HRSCustomerByApplicationId(int applicationId);
    }
}