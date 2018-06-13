using System.Configuration;
using System.Net.Http;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.DTO.CRM;
using Newtonsoft.Json;

namespace Incomm.Allocations.BLL.CRM.ApiClient
{
    public class LookupApiClient : ILookupApiClient
    {
        public CRMLookup GetCRMLookup()
        {
            var url = ConfigurationManager.AppSettings["CRM_WebApiUrl"] + "api/Lookup";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    return JsonConvert.DeserializeObject<CRMLookup>(httpClient.GetStringAsync(url).Result);
                }
                catch
                {
                    return null;
                }
            }
        }

       
    }
}