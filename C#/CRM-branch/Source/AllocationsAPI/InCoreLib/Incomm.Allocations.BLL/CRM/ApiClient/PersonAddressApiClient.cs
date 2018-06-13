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
    public class PersonAddressApiClient : IPersonAddressApiClient
    {
        public PersonAddressDto PostPersonAddress(PersonAddressDto person)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + "api/PersonAddress";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var response = httpClient.PostAsJsonAsync(url, person).Result;
                return response.Content.ReadAsAsync<PersonAddressDto>().Result;
            }
        }

        public PersonAddressDto PutPersonAddress(int id, PersonAddressDto person)
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + "api/PersonAddress/" + id;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var response = httpClient.PutAsJsonAsync(url, person).Result;
                return response.Content.ReadAsAsync<PersonAddressDto>().Result;
            }
        }

       
    }
}