using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Domain.StoreProcedure;
using Newtonsoft.Json;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    [ElmahHandleWebApiError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/VBL")]
    public class MatchingController : ApiController
    {

        private IVBLMatchingBLL _vblMatchingBLL;
        private IApplicationBLL _applicationBLL;
        private IVBLCustomerInterestBLL _customerInterestBLL;
        public MatchingController() : this(new VBLMatchingBLL(), new ApplicationBLL(), new VBLCustomerInterestBLL())
        {
        }

        public MatchingController(IVBLMatchingBLL vblMatchingBLL, IApplicationBLL applicationBLL, IVBLCustomerInterestBLL customerInterestBLL)
        {
            _vblMatchingBLL = vblMatchingBLL;
            _applicationBLL = applicationBLL;
            _customerInterestBLL = customerInterestBLL;
        }

        [HttpGet]
        [Route("Matching/GetVoidPropertyAvailableForRent")]
        public HttpResponseMessage GetVoidPropertyAvailableForRent()
        {
            HttpResponseMessage response;
            var propList = new List<VoidPropertyMatchForApplication>();
            propList = _vblMatchingBLL.GetVoidPropertyAvailableForRent();
            response = Request.CreateResponse(HttpStatusCode.OK, propList);
            return response;
        }

        [HttpGet]
        [Route("Matching/GetMatchingVoids")]
        public HttpResponseMessage GetPotentialVoidMatchesForVBLApplication(int applicationId)
        {
            HttpResponseMessage response;
            var propList = new List<VoidPropertyMatchForApplication>();
            //check to see if there is an active match
            var activeStatuses = new List<int> { 1, 6, 7, 4, 8, 10 };
            var inactiveStatuses = new List<int> { 2, 3, 5, 9 };
            var customerinterests = _customerInterestBLL.GetAllCustomerInterestsForApplication(applicationId).OrderByDescending(x => x.CustomerInterestId);
            var activeCustomerInterest = customerinterests.FirstOrDefault(x => activeStatuses.Contains(x.CustomerInterestStatusId));
            var excludedProperties = customerinterests.Where(x => inactiveStatuses.Contains(x.CustomerInterestStatusId)).Select(x => x.PropertyCode);

            //if so, return only that one
            if (activeCustomerInterest != null)
            {
                var propertyShop = new VoidPropertyMatchForApplication();
                if (activeCustomerInterest.VoidId > 0)
                {
                     propertyShop = _vblMatchingBLL.GetCurrentMatch(activeCustomerInterest.PropertyCode);
                }
                else
                {
                    propertyShop = _vblMatchingBLL.GetCurrentMatch(activeCustomerInterest.PropertyCode,
                        activeCustomerInterest.LandlordId);
                }


                if (propertyShop == null)
                {
                    var customerInterest = new VBLCustomerInterestDTO {CustomerInterestId = activeCustomerInterest.CustomerInterestId };
                    _customerInterestBLL.Rejected(customerInterest);
                    //response = Request.CreateResponse(HttpStatusCode.PreconditionFailed);
                }
                else
                {
                    propList.Add(propertyShop);
                    return Request.CreateResponse(HttpStatusCode.OK, propList);
                }
            }
            //else, go find some potentials

            var application = _applicationBLL.GetApplication(applicationId);
            //make sure we have matching criteria
            if (application.VBLRequestedPropertymatchDetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, propList);//OK as the query ran successfully, even if it didn't find anything
            }
            int? age = null;
            if (application.VblMutualExchagePropertyDetail != null)
            {
                if (application.VblMutualExchagePropertyDetail.AgeCritera == 1)
                {
                    age = 18;
                }
                else if (application.VblMutualExchagePropertyDetail.AgeCritera == 2)
                {
                    age = 55;
                }
                else if (application.VblMutualExchagePropertyDetail.AgeCritera == 3)
                {
                    age = 65;
                }
            }

            var summary = GetApplicationSummary(applicationId, application, age);
            var neighbourhoods = application.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.FirstOrDefault(x => x.IsCurrent);
            if (neighbourhoods != null)
                summary.PreferredNeighbourhoodIds = neighbourhoods.RequestedPropertyPrefferedNeighbourhoodDetails
                                                                .Select(x => x.NeighbourhoodId)
                                                                .ToList();
            summary.PropertyTypes = new List<string>();
            foreach (var propertyType in application.VBLRequestedPropertymatchDetail.PropertyTypes)
            {
                summary.PropertyTypes.Add(propertyType.PropertyType.Name.ToUpper());
            }
            summary.NumberOfBedrooms = new List<int>();
            foreach (var propertySize in application.VBLRequestedPropertymatchDetail.PropertySizes)
            {
                summary.NumberOfBedrooms.Add(propertySize.PropertySizeId);
            }
            //call the bll
            var results = _vblMatchingBLL.GetPotentialVoidMatches(summary);
            if (!results.Any())
            {
                // results = _vblMatchingBLL.GetMutexMatches(applicationId);
            }
            else
            {
                //remove previous matches
                results = results.Where(x => !excludedProperties.Contains(x.PropertyCode)).ToList();

                //get the postcodes that are in the current area selection for the application
                var postcodes = _vblMatchingBLL.GetPostcodesInApplicationAreaSelection(applicationId);
                //limit results to the ones that have postcodes contained in the list


                //results = results.Where(x => postcodes.Contains(x.PostCode)).ToList();

                //oldest void first
                // results = results.OrderBy(x => x.TenancyEndDate).ToList();

            }

            response = Request.CreateResponse(HttpStatusCode.OK, results);//OK as the query ran successfully, even if it didn't find anything


            return response;
        }

        [HttpPost]
        [Route("Matching/GetPropertyDetails")]
        public HttpResponseMessage GetPropertyDetails([FromBody] VBLApplicationDTO application)
        {
            var responseMessage = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            if (application.SearchPropertyList.Count == 0)
            {
                responseMessage.StatusCode = HttpStatusCode.PreconditionFailed;
                responseMessage.Content = new StringContent("Please send some property code in SearchPropertyList property of VBLApplicationDTO.");
            }
            else
            {
                var results = _vblMatchingBLL.GetPropertyDetails(application);
                if (results == null || !results.Any())
                {
                    responseMessage.StatusCode = HttpStatusCode.NotFound;
                }
                var jsonContent = JsonConvert.SerializeObject(results, Formatting.Indented);
                responseMessage.Content = new StringContent(jsonContent);
            }

            return responseMessage;
        }

        private static VBLApplicationSummaryDTO GetApplicationSummary(int applicationId, VBLApplication application, int? age)
        {
            return new VBLApplicationSummaryDTO
            {
                ApplicationId = applicationId,
                IsSuitableForMutex = application.VblMutualExchagePropertyDetail != null,
                PropertyCode = application.VblMutualExchagePropertyDetail?.PropertyCode,
                MutexPropertyType = application.VblMutualExchagePropertyDetail?.PropertyType?.Name,
                MutexNumberOfBeds = application.VblMutualExchagePropertyDetail?.PropertyNumberOfBedrooms,
                MutexAgeRestriction = age,
                MutexNumberSteps = application.VblMutualExchagePropertyDetail?.NumberOfStepsToAccess,
                MutexWheelchairAdapted =
                    application.VblMutualExchagePropertyDetail?.AdaptationDetails.Any(x => x.AdaptationId == 1),
                MutexRampedAccess =
                    application.VblMutualExchagePropertyDetail?.AdaptationDetails.Any(x => x.AdaptationId == 2),
                MutexStairLift =
                    application.VblMutualExchagePropertyDetail?.AdaptationDetails.Any(x => x.AdaptationId == 4),
                MutexWalkInShower =
                    application.VblMutualExchagePropertyDetail?.AdaptationDetails.Any(x => x.AdaptationId == 3),
                MutexStepInShower =
                    application.VblMutualExchagePropertyDetail?.AdaptationDetails.Any(x => x.AdaptationId == 5),
                HasPet = (application.VBLRequestedPropertymatchDetail.CatOrDog == true &&
                          application.VBLRequestedPropertymatchDetail.RehousePet == false),
                CommunalEntrance = application.VBLRequestedPropertymatchDetail.CommunalEntrance,
                HighRise = application.VBLRequestedPropertymatchDetail.HighRise,
                LiftServed = application.VBLRequestedPropertymatchDetail.LiftServed,
                EighteenPlus = (!application.VBLRequestedPropertymatchDetail.AgeRestricted == false ||
                                application.VBLRequestedPropertymatchDetail.AgeRestrictions.Any(
                                    x => x.AgeRestrictionId == 1)),
                FiftyFivePlus =
                    application.VBLRequestedPropertymatchDetail.AgeRestrictions.Any(x => x.AgeRestrictionId == 2),
                SixtyFivePlus =
                    application.VBLRequestedPropertymatchDetail.AgeRestrictions.Any(x => x.AgeRestrictionId == 3),
                WheelchairAdapted = (application.VBLRequestedPropertymatchDetail.RequireAdaptations == true &&
                                     application.VBLRequestedPropertymatchDetail.AdaptationDetails.Any(
                                         x => x.AdaptationId == 1)),
                RampedAccess = (application.VBLRequestedPropertymatchDetail.RequireAdaptations == true &&
                                application.VBLRequestedPropertymatchDetail.AdaptationDetails.Any(
                                    x => x.AdaptationId == 2)),
                WalkInShower = (application.VBLRequestedPropertymatchDetail.RequireAdaptations == true &&
                                application.VBLRequestedPropertymatchDetail.AdaptationDetails.Any(
                                    x => x.AdaptationId == 3)),
                StairLift = (application.VBLRequestedPropertymatchDetail.RequireAdaptations == true &&
                             application.VBLRequestedPropertymatchDetail.AdaptationDetails.Any(
                                 x => x.AdaptationId == 4)),
                StepInShower = (application.VBLRequestedPropertymatchDetail.RequireAdaptations == true &&
                                application.VBLRequestedPropertymatchDetail.AdaptationDetails.Any(
                                    x => x.AdaptationId == 5)),
                MaxNumberSteps = GetNumberOfSteps(application.VBLRequestedPropertymatchDetail.NumberOfSteps)
            };
        }

        private static int? GetNumberOfSteps(NumberOfSteps numberOfSteps)
        {
            switch (numberOfSteps)
            {
                case NumberOfSteps.Zero:
                    return 0;
                case NumberOfSteps.OneToTwo:
                    return 2;
                case NumberOfSteps.ThreeToTen:
                    return 10;
                case NumberOfSteps.TenToTwenty:
                    return 20;
                case NumberOfSteps.TwentyPlus:
                case NumberOfSteps.Unselected:
                    return null;
                default:
                    return null;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="voidToMatch"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Matching/GetMatchingApplicationId")]
        public HttpResponseMessage GetMatchingVBLApplicationIdForVoid([FromBody] VBLPropertyShopDTO voidToMatch)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            var applicationMatch = _applicationBLL.GetOpenUnmatchedApplicationsWithNeighbourhoodsDetail(voidToMatch);
            if (!string.IsNullOrWhiteSpace(applicationMatch.ErrorMessage))
            {
                responseMessage.StatusCode = HttpStatusCode.PreconditionFailed;
            }
            else
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, applicationMatch);
            }
            return responseMessage;
        }
    }
}
