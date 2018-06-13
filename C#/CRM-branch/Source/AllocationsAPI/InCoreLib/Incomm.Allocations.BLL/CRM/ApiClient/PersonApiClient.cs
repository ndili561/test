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
    public class PersonApiClient : IPersonApiClient
    {
        public PersonDto PostPerson(PersonDto person)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + "api/Person";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var response = httpClient.PostAsJsonAsync(url, person).Result;
                return response.Content.ReadAsAsync<PersonDto>().Result;
            }
        }

        public PersonDto PutPerson(Guid globalIdentityKey, PersonDto person)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + "api/Person/" + globalIdentityKey;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var response = httpClient.PutAsJsonAsync(url, person).Result;
                return response.Content.ReadAsAsync<PersonDto>().Result;
            }
        }

        public PersonDto GetPerson(Guid globalIdentityKey)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + $"odata/Person?$filter=GlobalIdentityKey eq { globalIdentityKey}&$top=1&$expand=PersonAddresses($expand=Address),Applications,PersonContactDetails";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var re = JsonConvert.DeserializeObject<OdataResult>(httpClient.GetStringAsync(url).Result.StandarizedForOdata());
                var result = re.Items.Select(item => JsonConvert.DeserializeObject<PersonDto>(item.ToString()));
                return result.FirstOrDefault();
            }
        }
    }
}