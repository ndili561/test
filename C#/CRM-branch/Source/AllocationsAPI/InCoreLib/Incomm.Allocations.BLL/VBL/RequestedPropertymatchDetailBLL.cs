using System;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.DAL.Migrations;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.VBL
{
    public class RequestedPropertymatchDetailBLL : IRequestedPropertymatchDetailBLL
    {

        private IUnitOfWork _unitOfWork;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        public RequestedPropertymatchDetailBLL() : this(new UnitOfWork(), new ApplicationHistoryBLL())
        {
        }

        public RequestedPropertymatchDetailBLL(IUnitOfWork unitOfWork, IApplicationHistoryBLL applicationHistoryBLL)
        {
            _unitOfWork = unitOfWork;
            _applicationHistoryBLL = applicationHistoryBLL;
        }


        public VBLRequestedPropertymatchDetail GetRequestedPropertymatchDetail(int applicationId)
        {
            var requestedPropertymatchDetail =
               _unitOfWork.VBLRequestedPropertymatchDetail()
                   .Select(includeProperties: "PropertyTypes,PropertyTypes,AgeRestrictions,AdaptationDetails")
                   .FirstOrDefault(x => x.ApplicationId == applicationId);
            return Mapper.Map<VBLRequestedPropertymatchDetail>(requestedPropertymatchDetail);
        }

        public VBLApplication Update(VBLRequestedPropertymatchDetail requestedPropertymatchDetail, VBLRequestedPropertymatchDetail persistedrequestedApplication)
        {
            requestedPropertymatchDetail = CleanPropertyMatchDetail(requestedPropertymatchDetail);

            var persistedApplication =
                _unitOfWork.VBLApplications()
                    .Select(
                        includeProperties:
                            "VBLRequestedPropertymatchDetail.PropertySizes.PropertySize,VBLRequestedPropertymatchDetail.PropertyTypes.PropertyType,VBLRequestedPropertymatchDetail.AgeRestrictions.AgeRestriction,VBLRequestedPropertymatchDetail.AdaptationDetails.Adaptation")
                    .FirstOrDefault(x => x.ApplicationId == requestedPropertymatchDetail.ApplicationId);
            if (persistedApplication != null)
            {
                UpsertPropertyPreferences(requestedPropertymatchDetail, persistedApplication.VBLRequestedPropertymatchDetail);
            }
            return persistedApplication;
        }

        protected VBLRequestedPropertymatchDetail CleanPropertyMatchDetail(VBLRequestedPropertymatchDetail detail)
        {
            //if propertytype doesnt contain flat, bedsit or maisonette wipe catdog, rehome,communal,highrise and liftserved. propertytypeid = 1,6,12
            if (!detail.PropertyTypes.Any(x => x.PropertyTypeId == 1 || x.PropertyTypeId == 6 || x.PropertyTypeId == 12))
            {
                detail.CatOrDog = null;
                detail.RehousePet = null;
                detail.CommunalEntrance = null;
                detail.HighRise = null;
                detail.LiftServed = null;
            }

            //if age restricted is not required, wipe the age categories
            if (detail.AgeRestricted == false)
            {
                detail.AgeRestrictions = null;
            }

            //if adaptations are not required, wipe the categories
            if (detail.RequireAdaptations == false)
            {
                detail.AdaptationDetails = null;
            }

            return detail;
        }

        protected void UpsertPropertyPreferences(VBLRequestedPropertymatchDetail requestedPropertymatchDetail, VBLRequestedPropertymatchDetail persistedRequestedPropertymatchDetail)
        {
            bool amend = true;
            var changeDescription = string.Empty;
            if (persistedRequestedPropertymatchDetail == null)
            {
                amend = false;
                var criteria = new VBLRequestedPropertymatchDetail
                {
                    ApplicationId = requestedPropertymatchDetail.ApplicationId,
                    CatOrDog = requestedPropertymatchDetail.CatOrDog,
                    RehousePet = requestedPropertymatchDetail.RehousePet,
                    CommunalEntrance = requestedPropertymatchDetail.CommunalEntrance,
                    HighRise = requestedPropertymatchDetail.HighRise,
                    AgeRestricted = requestedPropertymatchDetail.AgeRestricted,
                    ManageSteps = requestedPropertymatchDetail.ManageSteps,
                    RequireAdaptations = requestedPropertymatchDetail.RequireAdaptations,
                    StartDate = requestedPropertymatchDetail.StartDate,
                    EndDate = requestedPropertymatchDetail.EndDate,
                    LiftServed = requestedPropertymatchDetail.LiftServed,
                    NumberOfSteps = requestedPropertymatchDetail.NumberOfSteps,
                    UserIPAddress = requestedPropertymatchDetail.UserIPAddress,
                    UserId = requestedPropertymatchDetail.UserId,
                    CreatedBy = requestedPropertymatchDetail.UserId,
                    CreatedDate = DateTime.Now
                };
                _unitOfWork.VBLRequestedPropertymatchDetail().Insert(criteria);
                changeDescription = changeDescription + string.Format("Property Matching Criteria added:<br />");
                if (requestedPropertymatchDetail.CatOrDog.HasValue)
                {
                    changeDescription = changeDescription + string.Format("Cat or Dog: <span class=\"newvalue\">" + requestedPropertymatchDetail.CatOrDog.Value + "</span><br />");
                }
                if (requestedPropertymatchDetail.RehousePet.HasValue)
                {
                    changeDescription = changeDescription + string.Format("Rehouse Pet: <span class=\"newvalue\">" + requestedPropertymatchDetail.RehousePet.Value + "</span><br />");
                }
                if (requestedPropertymatchDetail.CommunalEntrance.HasValue)
                {
                    changeDescription = changeDescription + string.Format("Communal Entrance Considered: <span class=\"newvalue\">" + requestedPropertymatchDetail.CommunalEntrance.Value + "</span><br />");
                }
                if (requestedPropertymatchDetail.HighRise.HasValue)
                {
                    changeDescription = changeDescription + string.Format("High Rise Considered: <span class=\"newvalue\">" + requestedPropertymatchDetail.HighRise.Value + "</span><br />");
                }
                if (requestedPropertymatchDetail.LiftServed.HasValue)
                {
                    changeDescription = changeDescription + string.Format("Lift Required: <span class=\"newvalue\">" + requestedPropertymatchDetail.LiftServed.Value + "</span><br />");
                }
                if (requestedPropertymatchDetail.AgeRestricted.HasValue)
                {
                    changeDescription = changeDescription + string.Format("Age Restricted: <span class=\"newvalue\">" + requestedPropertymatchDetail.AgeRestricted.Value + "</span><br />");
                }
                if (requestedPropertymatchDetail.ManageSteps.HasValue)
                {
                    changeDescription = changeDescription + string.Format("Manage Steps: <span class=\"newvalue\">" + requestedPropertymatchDetail.ManageSteps.Value + "</span><br />");
                }

                    changeDescription = changeDescription + string.Format("Number of Steps: <span class=\"newvalue\">"+ requestedPropertymatchDetail.NumberOfSteps +"</span><br />");
                
                if (requestedPropertymatchDetail.RequireAdaptations.HasValue)
                {
                    changeDescription = changeDescription + string.Format("Require Adaptations: <span class=\"newvalue\">" + requestedPropertymatchDetail.RequireAdaptations.Value + "</span><br />");
                }
                
            }
            else
            {
                //if updating an old application, wipe the old criteria and mark as new
                if (!persistedRequestedPropertymatchDetail.IsNewVBLApplication)
                {
                    persistedRequestedPropertymatchDetail.IsNewVBLApplication = true;
                    persistedRequestedPropertymatchDetail.LiftServed = null;
                    persistedRequestedPropertymatchDetail.FloorLevel = null;
                    persistedRequestedPropertymatchDetail.Garden = null;
                    persistedRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods = null;
                    persistedRequestedPropertymatchDetail.Schemes = null;
                    persistedRequestedPropertymatchDetail.HeatingTypes = null;
                    persistedRequestedPropertymatchDetail.TrustCare = null;
                    persistedRequestedPropertymatchDetail.Sheltered = null;
                    persistedRequestedPropertymatchDetail.WheelChairAdapted = null;
                    persistedRequestedPropertymatchDetail.RampedAccess = null;
                    persistedRequestedPropertymatchDetail.LevelAccessProperty = null;
                    persistedRequestedPropertymatchDetail.StairLift = null;
                    persistedRequestedPropertymatchDetail.WalkInShower = null;
                    persistedRequestedPropertymatchDetail.StepInShower = null;
                }
                if (persistedRequestedPropertymatchDetail.CatOrDog != requestedPropertymatchDetail.CatOrDog)
                {
                    changeDescription = changeDescription +
                                        $"CatOrDog changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.CatOrDog} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.CatOrDog} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.CatOrDog = requestedPropertymatchDetail.CatOrDog;
                }
                if (persistedRequestedPropertymatchDetail.RehousePet != requestedPropertymatchDetail.RehousePet)
                {
                    changeDescription = changeDescription +
                                         $"RehousePet changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.RehousePet} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.RehousePet} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.RehousePet = requestedPropertymatchDetail.RehousePet;
                }

                if (persistedRequestedPropertymatchDetail.HighRise != requestedPropertymatchDetail.HighRise)
                {
                    changeDescription = changeDescription +
                                        $"HighRise changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.HighRise} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.HighRise} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.HighRise = requestedPropertymatchDetail.HighRise;
                }
                if (persistedRequestedPropertymatchDetail.AgeRestricted != requestedPropertymatchDetail.AgeRestricted)
                {
                    changeDescription = changeDescription +
                                      $"AgeRestricted changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.AgeRestricted} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.AgeRestricted} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.AgeRestricted = requestedPropertymatchDetail.AgeRestricted;
                }

                if (persistedRequestedPropertymatchDetail.ManageSteps != requestedPropertymatchDetail.ManageSteps)
                {
                    changeDescription = changeDescription +
                                     $"ManageSteps changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.ManageSteps} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.ManageSteps} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.ManageSteps = requestedPropertymatchDetail.ManageSteps;
                }

                if (persistedRequestedPropertymatchDetail.RequireAdaptations != requestedPropertymatchDetail.RequireAdaptations)
                {
                    changeDescription = changeDescription +
                                     $"RequireAdaptations changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.RequireAdaptations} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.RequireAdaptations} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.RequireAdaptations = requestedPropertymatchDetail.RequireAdaptations;
                }

                if (persistedRequestedPropertymatchDetail.StartDate != requestedPropertymatchDetail.StartDate)
                {
                    changeDescription = changeDescription +
                                    $"StartDate changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.StartDate} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.StartDate} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.StartDate = requestedPropertymatchDetail.StartDate;
                }

                if (persistedRequestedPropertymatchDetail.EndDate != requestedPropertymatchDetail.EndDate)
                {
                    changeDescription = changeDescription +
                                   $"EndDate changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.EndDate} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.EndDate} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.EndDate = requestedPropertymatchDetail.EndDate;
                }

                if (persistedRequestedPropertymatchDetail.LiftServed != requestedPropertymatchDetail.LiftServed)
                {
                    changeDescription = changeDescription +
                                                     $"LiftServed changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.LiftServed} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.LiftServed} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.LiftServed = requestedPropertymatchDetail.LiftServed;
                }

                if (persistedRequestedPropertymatchDetail.NumberOfSteps != requestedPropertymatchDetail.NumberOfSteps)
                {
                    changeDescription = changeDescription +
                                 $"NumberOfSteps changed from  <span class=\"oldvalue\"> {persistedRequestedPropertymatchDetail.NumberOfSteps} </span> to <span class=\"newvalue\"> {requestedPropertymatchDetail.NumberOfSteps} </span>" + "<br>";
                    persistedRequestedPropertymatchDetail.NumberOfSteps = requestedPropertymatchDetail.NumberOfSteps;
                }
                persistedRequestedPropertymatchDetail.UserIPAddress = requestedPropertymatchDetail.UserIPAddress;
                persistedRequestedPropertymatchDetail.UserId = requestedPropertymatchDetail.UserId;
                persistedRequestedPropertymatchDetail.ModifiedBy = requestedPropertymatchDetail.UserId;
                persistedRequestedPropertymatchDetail.ModifiedDate = DateTime.Now;
            }
            UpsertRequestedPropertyAgeRestrictions(requestedPropertymatchDetail, persistedRequestedPropertymatchDetail, ref changeDescription);
            UpsertAdaptationForRequestedProperty(requestedPropertymatchDetail, persistedRequestedPropertymatchDetail, ref changeDescription);
            UpsertRequestedPropertyPropertySize(requestedPropertymatchDetail, persistedRequestedPropertymatchDetail, ref changeDescription);
            UpsertRequestedPropertyPropertyType(requestedPropertymatchDetail, persistedRequestedPropertymatchDetail, ref changeDescription);
            if (!string.IsNullOrWhiteSpace(changeDescription) )//&& persistedRequestedPropertymatchDetail != null)
            {
                if (amend)
                {
                    _applicationHistoryBLL.Create(requestedPropertymatchDetail.ApplicationId,
                        requestedPropertymatchDetail.UserId, requestedPropertymatchDetail.UserIPAddress,
                        ApplicationActivity.Ammendment, ApplicationChangeType.PreferenceDetails, changeDescription);
                }
                else
                {
                    _applicationHistoryBLL.Create(requestedPropertymatchDetail.ApplicationId, requestedPropertymatchDetail.UserId, requestedPropertymatchDetail.UserIPAddress,
                   ApplicationActivity.NewDetails, ApplicationChangeType.PreferenceDetails, changeDescription);
                }
            }
            _unitOfWork.Commit(requestedPropertymatchDetail.UserId, requestedPropertymatchDetail.UserIPAddress);
        }
        private void UpsertRequestedPropertyAgeRestrictions(VBLRequestedPropertymatchDetail propertyMatchDetails, VBLRequestedPropertymatchDetail persistedMutualExchange, ref string changeDescription)
        {
            //See if agerestricted is false
            if (propertyMatchDetails.AgeRestricted.HasValue && !propertyMatchDetails.AgeRestricted.Value)
            {
                //see if persistedmutex is not null
                //see if existing age restrictions = true
                if (persistedMutualExchange?.AgeRestrictions != null)
                {
                    //if so delete
                    var ageRestrictions = persistedMutualExchange.AgeRestrictions.ToList();
                    _unitOfWork.RequestedPropertyAgeRestriction().DeleteRange(ageRestrictions);
                    _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                }
                //else (agerestricted is true)
            }
            else
            {
                //see if existing age restrictions = true
                if (persistedMutualExchange?.AgeRestrictions != null)
                {
                    var originalValue = string.Join(",", persistedMutualExchange.AgeRestrictions.Select(x => x.AgeRestriction.Name).ToList());
                    //update
                    var deletedAgeRestriction = persistedMutualExchange.AgeRestrictions
                        .Where(a =>
                        propertyMatchDetails.AgeRestrictions.All(x => x.ApplicationId == a.ApplicationId && x.AgeRestrictionId != a.AgeRestrictionId))
                       .ToList();
                    if (deletedAgeRestriction.Any())
                        _unitOfWork.RequestedPropertyAgeRestriction().DeleteRange(deletedAgeRestriction);
                    var addedAgeRestrictions = propertyMatchDetails.AgeRestrictions.Where(a =>
                        persistedMutualExchange.AgeRestrictions.All(x => x.AgeRestrictionId != a.AgeRestrictionId))
                       .ToList();
                    if (addedAgeRestrictions.Any())
                        _unitOfWork.RequestedPropertyAgeRestriction().AddRange(addedAgeRestrictions);
                    _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                    var ageRestrictedIds = propertyMatchDetails.AgeRestrictions.Select(x => x.AgeRestrictionId).ToList();
                    var newValue = string.Join(",", _unitOfWork.AgeRestrictions()
                                           .Select(a => ageRestrictedIds.Contains(a.AgeRestrictionId)).Select(x=>x.Name)
                                          .ToList());
                    if (string.Compare(originalValue,newValue,StringComparison.InvariantCultureIgnoreCase) != 0)
                    {
                        changeDescription = changeDescription +
                                          $"AgeRestrictions changed from  <span class=\"oldvalue\"> {originalValue} </span> to <span class=\"newvalue\"> {newValue} </span>" + "<br>";
                    }
                   
                    //else
                }
                else
                {
                    //insert
                    _unitOfWork.RequestedPropertyAgeRestriction().AddRange(propertyMatchDetails.AgeRestrictions);
                    _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                    var ageRestrictedIds = propertyMatchDetails.AgeRestrictions.Select(x => x.AgeRestrictionId).ToList();
                    var newValue = string.Join(",", _unitOfWork.AgeRestrictions()
                                           .Select(a => ageRestrictedIds.Contains(a.AgeRestrictionId)).Select(x => x.Name)
                                          .ToList());
                    
                        changeDescription = changeDescription +
                                          $"AgeRestrictions <span class=\"newvalue\"> {newValue} </span> added.<br>";
                    
                }
            }

        }
        private void UpsertRequestedPropertyPropertySize(VBLRequestedPropertymatchDetail propertyMatchDetails, VBLRequestedPropertymatchDetail persistedMutualExchange, ref string changeDescription)
        {

            if (persistedMutualExchange?.PropertySizes != null)
            {
                var pSizes = persistedMutualExchange.PropertySizes.Select(x => x.PropertySizeId).ToList();
                var newSizes = propertyMatchDetails.PropertySizes.Select(x => x.PropertySizeId).ToList();
                    if (!(pSizes.All(item => newSizes.Contains(item)) && newSizes.All(item => pSizes.Contains(item))))
                {
                    var originalValue = string.Join(",",
                        persistedMutualExchange.PropertySizes.Select(x => x.PropertySize.Name).ToList());
                    var deletedPropertySize = persistedMutualExchange.PropertySizes
                        .Where(
                            a =>
                                propertyMatchDetails.PropertySizes.All(
                                    x => x.ApplicationId == a.ApplicationId && x.PropertySizeId != a.PropertySizeId))
                        .ToList();
                    if (deletedPropertySize.Any())
                        _unitOfWork.RequestedPropertyPropertySize().DeleteRange(deletedPropertySize);

                    var addedPropertySizes = propertyMatchDetails.PropertySizes.Where(a =>
                        persistedMutualExchange.PropertySizes.All(
                            x => x.ApplicationId == a.ApplicationId && x.PropertySizeId != a.PropertySizeId))
                        .ToList();
                    if (addedPropertySizes.Any())
                        _unitOfWork.RequestedPropertyPropertySize().AddRange(addedPropertySizes);

                    _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                    var propertySizeIds = propertyMatchDetails.PropertySizes.Select(x => x.PropertySizeId).ToList();
                    var newValue = string.Join(",", _unitOfWork.PropertySize()
                        .Select(a => propertySizeIds.Contains(a.PropertySizeId)).Select(x => x.Name)
                        .ToList());
                    changeDescription = changeDescription +
                                        $"PropertySize changed from  <span class=\"oldvalue\"> {originalValue} </span> to <span class=\"newvalue\"> {newValue} </span>" +
                                        "<br>";
                }
            }
            else
            {
                //insert
                _unitOfWork.RequestedPropertyPropertySize().AddRange(propertyMatchDetails.PropertySizes);
                _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                var propertySizeIds = propertyMatchDetails.PropertySizes.Select(x => x.PropertySizeId).ToList();
                var newValue = string.Join(",", _unitOfWork.PropertySize()
                    .Select(a => propertySizeIds.Contains(a.PropertySizeId)).Select(x => x.Name)
                    .ToList());
                changeDescription = changeDescription +
                                    $"PropertySizes <span class=\"newvalue\"> {newValue} </span>added.<br>";
            }

        }
        private void UpsertRequestedPropertyPropertyType(VBLRequestedPropertymatchDetail propertyMatchDetails, VBLRequestedPropertymatchDetail persistedMutualExchange, ref string changeDescription)
        {

            //check if persistedmutex is not null
            //check if there are propertytypes in it
            if (persistedMutualExchange?.PropertyTypes != null)
            {
                var pTypes = persistedMutualExchange.PropertyTypes.Select(x => x.PropertyTypeId).ToList();
                var newTypes = propertyMatchDetails.PropertyTypes.Select(x => x.PropertyTypeId).ToList();
                if (!(pTypes.All(item => newTypes.Contains(item)) && newTypes.All(item => pTypes.Contains(item))))
                {
                    var originalValue = string.Join(",",
                        persistedMutualExchange.PropertyTypes.Select(x => x.PropertyType.Name).ToList());
                    //if so, update
                    var deletedPropertyTypes = persistedMutualExchange.PropertyTypes
                        .Where(
                            a =>
                                propertyMatchDetails.PropertyTypes.All(
                                    x => x.ApplicationId == a.ApplicationId && x.PropertyTypeId != a.PropertyTypeId))
                        .ToList();
                    if (deletedPropertyTypes.Any())
                        _unitOfWork.RequestedPropertyPropertyType().DeleteRange(deletedPropertyTypes);
                    var addedPropertyTypes = propertyMatchDetails.PropertyTypes.Where(a =>
                        persistedMutualExchange.PropertyTypes.All(
                            x => x.ApplicationId == a.ApplicationId && x.PropertyTypeId != a.PropertyTypeId))
                        .ToList();
                    if (addedPropertyTypes.Any())
                        _unitOfWork.RequestedPropertyPropertyType().AddRange(addedPropertyTypes);
                    _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                    var propertyTypeIds = propertyMatchDetails.PropertyTypes.Select(x => x.PropertyTypeId).ToList();
                    var newValue = string.Join(",", _unitOfWork.PropertyTypes()
                        .Select(a => propertyTypeIds.Contains(a.PropertyTypeId)).Select(x => x.Name)
                        .ToList());
                    changeDescription = changeDescription +
                                        $"PropertyTypes changed from  <span class=\"oldvalue\"> {originalValue} </span> to <span class=\"newvalue\"> {newValue} </span>" +
                                        "<br>";
                }
            }
            else
            {
                //insert
                _unitOfWork.RequestedPropertyPropertyType().AddRange(propertyMatchDetails.PropertyTypes);
                _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                var propertyTypeIds = propertyMatchDetails.PropertyTypes.Select(x => x.PropertyTypeId).ToList();
                var newValue = string.Join(",", _unitOfWork.PropertyTypes()
                    .Select(a => propertyTypeIds.Contains(a.PropertyTypeId)).Select(x => x.Name)
                    .ToList());
                changeDescription = changeDescription +
                                    $"PropertyTypes <span class=\"newvalue\"> {newValue} </span>added.<br>";
            }

        }
        private void UpsertAdaptationForRequestedProperty(VBLRequestedPropertymatchDetail propertyMatchDetails, VBLRequestedPropertymatchDetail persistedMutualExchange, ref string changeDescription)
        {
            //see if adaptations is false
            if (propertyMatchDetails.RequireAdaptations.HasValue && !propertyMatchDetails.RequireAdaptations.Value)
            {

                if (persistedMutualExchange?.AdaptationDetails != null)
                {
                    //if so delete
                    var adaptationDetails = persistedMutualExchange.AdaptationDetails.ToList();
                    _unitOfWork.RequestedPropertyAdaptationDetails().DeleteRange(adaptationDetails);
                    persistedMutualExchange.RequireAdaptations = false;
                }
                _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
            }
            //else(adaptations is true)
            else
            {

                //see if existing adaptations = true
                if (persistedMutualExchange?.AdaptationDetails != null)
                {
                    var originalValue = string.Join(",", persistedMutualExchange.AdaptationDetails.Select(x => x.Adaptation.Name).ToList());
                    persistedMutualExchange.RequireAdaptations = true;
                    //update
                    var deletedAdaptationDetails = persistedMutualExchange.AdaptationDetails
                        .Where(a =>
                        propertyMatchDetails.AdaptationDetails.All(x => x.ApplicationId == a.ApplicationId && x.AdaptationId != a.AdaptationId))
                       .ToList();
                    if (deletedAdaptationDetails.Any())
                        _unitOfWork.RequestedPropertyAdaptationDetails().DeleteRange(deletedAdaptationDetails);

                    var addedAdaptationDetails =
                        propertyMatchDetails.AdaptationDetails.Where(a =>
                        persistedMutualExchange.AdaptationDetails.All(x => x.ApplicationId == a.ApplicationId && x.AdaptationId != a.AdaptationId))
                        .ToList();
                    if (addedAdaptationDetails.Any())
                    {
                        _unitOfWork.RequestedPropertyAdaptationDetails().AddRange(addedAdaptationDetails);
                    }

                    _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                    var existingAdaptations =
                        persistedMutualExchange.AdaptationDetails.OrderBy(x=>x.AdaptationId).Select(x => x.AdaptationId).ToList();
                    var newAdaptations = propertyMatchDetails.AdaptationDetails.OrderBy(x => x.AdaptationId).Select(x => x.AdaptationId).ToList();
                    if (!(existingAdaptations.SequenceEqual(newAdaptations)))
                    {
                        var adaptationIds = propertyMatchDetails.AdaptationDetails.Select(x => x.AdaptationId).ToList();
                    var newValue = string.Join(",", _unitOfWork.Adaptations()
                                                 .Select(a => adaptationIds.Contains(a.AdaptationId)).Select(x => x.Name)
                                               .ToList());
                        changeDescription = changeDescription +
                                            $"Adaptation changed from  <span class=\"oldvalue\"> {originalValue} </span> to <span class=\"newvalue\"> {newValue} </span>" +
                                            "<br>";
                    }
                }
                else
                {
                    //insert
                    _unitOfWork.RequestedPropertyAdaptationDetails().AddRange(propertyMatchDetails.AdaptationDetails);
                    _unitOfWork.Commit(propertyMatchDetails.UserId, propertyMatchDetails.UserIPAddress);
                    var adaptationIds = propertyMatchDetails.AdaptationDetails.Select(x => x.AdaptationId).ToList();
                    var newValue = string.Join(",", _unitOfWork.Adaptations()
                                                 .Select(a => adaptationIds.Contains(a.AdaptationId)).Select(x => x.Name)
                                               .ToList());
                    changeDescription = changeDescription +
                                        $"Adaptation <span class=\"newvalue\"> {newValue} </span> added<br>";
                }
            }
        }
    }
}