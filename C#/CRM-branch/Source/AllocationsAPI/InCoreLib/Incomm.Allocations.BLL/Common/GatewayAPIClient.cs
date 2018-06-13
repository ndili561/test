using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.DTO;
using InCoreLib.Helpers;
using InCoreLib.Service.Api.Service;
using Newtonsoft.Json;

namespace Incomm.Allocations.BLL.Common
{
    public abstract class GatewayAPIClient
    {
        protected string GatewayUrl = ConfigurationManager.AppSettings["Gateway_WebApiUrl"];
        protected string CloudVoidUrl = string.Concat(ConfigurationManager.AppSettings["Gateway_WebApiUrl"], "CloudVoids");
        public void LogApiMessage(string url = "")
        {
            LogErrorMessage(null, $"The API call to {url} does not return with success code.");
        }

        public void LogErrorMessage(Exception ex, string customMessage = "")
        {
            var sb = new StringBuilder();
            sb.AppendLine(customMessage);
            while (ex != null)
            {
                sb.AppendLine(ex.Message);
                ex = ex.InnerException;
            }
        }
        protected VBLCustomerInterestDTO CreatePropertyMatchTask(VBLCustomerInterestDTO customerInterestDto    )
        {
            var url = CloudVoidUrl + "/PropertyMatch/CreatePropertyMatchTask";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(customerInterestDto);
                    Console.WriteLine(json);

                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = httpClient.PostAsJsonAsync(url, customerInterestDto).Result;
                    var result = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    var customerInterest = JsonConvert.DeserializeObject<VBLCustomerInterestDTO>(result);
                    return customerInterest;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    throw;
                }
            }
        }
        protected VBLCustomerInterestDTO UpdateRSLProperty(VBLCustomerInterestDTO customerInterestDto)
        {
            var url = CloudVoidUrl+ "/PropertyMatch/UpdateRSLPropertyStatus";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(customerInterestDto);
                    Console.WriteLine(json);

                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = httpClient.PostAsJsonAsync(url, customerInterestDto).Result;
                    var result = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    var customerInterest = JsonConvert.DeserializeObject<VBLCustomerInterestDTO>(result);
                    return customerInterest;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    throw;
                }
            }
        }
        protected VBLPropertyShopDTO GetVBLPropertyShop(string propertyCode)
        {
            var url = CloudVoidUrl + "/PropertyMatch/GetPropertyShop?propertyCode=" + propertyCode;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<VBLPropertyShopDTO>(httpClient.GetStringAsync(url).Result);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    throw;
                }
            }
        }
        protected VBLPropertyShopDTO GetCurrentMatchByPropertyCode(string propertyCode)
        {
            var url = CloudVoidUrl + "/PropertyMatch/GetPropertyShop?propertyCode=" + propertyCode;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<VBLPropertyShopDTO>(httpClient.GetStringAsync(url).Result);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    throw;
                }
            }
        }
        protected List<VBLPropertyShopDTO> GetPotentialVoidMatchesForCustomer(VBLApplicationSummaryDTO customer)
        {
            var jsonFormatted = JsonConvert.SerializeObject(customer, Formatting.Indented);

            Debug.WriteLine(jsonFormatted);
            var url = CloudVoidUrl + "/PropertyMatch/GetPropertyMatch";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = httpClient.PostAsJsonAsync(url, customer).Result;
                    if (!response.IsSuccessStatusCode)
                    {

                    }
                    var result = response.Content.ReadAsStringAsync()
                                               .Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
                    var properties = JsonConvert.DeserializeObject<List<VBLPropertyShopDTO>>(result);
                    if (properties == null)
                    {
                        properties = new List<VBLPropertyShopDTO>();
                    }
                    return properties;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    throw;
                }
            }
        }
        protected List<VBLPropertyNeighbourhoodDTO> GetPropertyNeighbourhood(List<string> neighbourhoodIds)
        {
            var url = CloudVoidUrl + "/PropertyNeighbourhood/GetPropertyNeighbourhoods?" + GetFilterString(neighbourhoodIds);
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var re = JsonConvert.DeserializeObject<OdataResult>(httpClient.GetStringAsync(url).Result);
                    var searchResultCount = 0;
                    if (re.Count != null)
                        int.TryParse(re.Count.ToString(), out searchResultCount);
                    var result = re.Items.Select(item => JsonConvert.DeserializeObject<VBLPropertyNeighbourhoodDTO>(item.ToString()));
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    throw;
                }
            }
        }
        private string GetFilterString(List<string> neighbourhoodIds)
        {
            var filterString = string.Empty;
            foreach (var selectedId in neighbourhoodIds)
            {
                if (string.IsNullOrWhiteSpace(filterString))
                {
                    filterString += ODataFilterConstant.Filter + $"NeighbourhoodId eq {selectedId}";
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(selectedId))
                    {
                        filterString += $" or NeighbourhoodId eq {selectedId}";
                    }

                }
            }
            var filterModal = new BaseFilterModel {PageNumber = 1,PageSize = int.MaxValue };
            AddPageSizeNumberAndSortingInFilterString(filterModal, ref filterString);
            return filterString;
        }
        protected void AddPageSizeNumberAndSortingInFilterString(BaseFilterModel baseFilterModel,ref string filterString)
        {
            if (baseFilterModel.PageSize > 0)
            {
                filterString += ODataFilterConstant.Inlinecount;
                filterString += $"{ODataFilterConstant.Top}{baseFilterModel.PageSize}";
            }
            if (baseFilterModel.PageNumber > 0)
            {
                filterString += $"{ODataFilterConstant.Skip}{(baseFilterModel.PageNumber - 1)*baseFilterModel.PageSize}";
            }

            if (string.IsNullOrWhiteSpace(baseFilterModel.SortColumn))
            {
                return;
            }
            filterString += $"{ODataFilterConstant.Orderby}{baseFilterModel.SortColumn}";
            if (baseFilterModel.SortDirection.Contains("Desc"))
            {
                filterString += " desc";
            }
            else
            {
                filterString += " asc";
            }
        }
    }
}
