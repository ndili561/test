using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.DTO.CRM;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;

namespace Incomm.Allocations.BLL.CRM.ApiClient
{
    public class AddressApiClient : IAddressApiClient
    {
        public AddressDto GetAddress(int id)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + $"/PersonAddress/GetAsync?$filter=GlobalIdentityKey eq { id}&$top=1";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var re = JsonConvert.DeserializeObject<OdataResult>(httpClient.GetStringAsync(url).Result);
                var result = re.Items.Select(item => JsonConvert.DeserializeObject<AddressDto>(item.ToString()));
                return result.FirstOrDefault();
            }
            return new AddressDto();
        }

     

        public AddressDto PostAddress(Guid globalkeyGuid)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + "/Address";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var response = httpClient.PostAsJsonAsync(url, globalkeyGuid).Result;
                return response.Content.ReadAsAsync<AddressDto>().Result;
            }
        }

        public AddressDto PutAddress(int id, AddressDto address)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + "PersonAddress/Put" + id;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var response = httpClient.PutAsJsonAsync(url, address).Result;
                return response.Content.ReadAsAsync<AddressDto>().Result;
            }

        }
    }
}
