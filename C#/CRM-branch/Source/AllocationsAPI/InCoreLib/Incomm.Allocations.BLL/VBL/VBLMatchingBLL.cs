using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.Enum;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Domain.StoreProcedure;

namespace Incomm.Allocations.BLL.VBL
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class VBLMatchingBLL: GatewayAPIClient, IVBLMatchingBLL
    {
        private IUnitOfWork _unitOfWork;
        public VBLMatchingBLL() : this(new UnitOfWork())
        {
        }

        public VBLMatchingBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<VoidPropertyMatchForApplication> GetPotentialVoidMatches(VBLApplicationSummaryDTO customer)
        {
            return _unitOfWork.VoidPropertyMatchForApplication(customer.ApplicationId).ToList();
            //return GetPotentialVoidMatchesForCustomer(customer);
        }

        public VoidPropertyMatchForApplication GetCurrentMatch(string propertyCode)
        {
            return _unitOfWork.GetPropertyDetails(propertyCode);
          // return GetCurrentMatchByPropertyCode(propertyCode);
        }

        public VoidPropertyMatchForApplication GetCurrentMatch(string propertyCode, int landlordId)
        {
            return _unitOfWork.GetPropertyDetails(propertyCode, landlordId);
        }

        public List<VBLPropertyShopDTO> GetPropertyDetails(VBLApplicationDTO application)
        {
            return _unitOfWork.GetPropertyDetailsByPropertyCodeList(application.SearchPropertyList);
        }

        public List<VoidPropertyMatchForApplication> GetVoidPropertyAvailableForRent()
        {
            return _unitOfWork.GetVoidPropertyAvailableForRent();
        }


        public List<VBLPropertyShopDTO> GetMutexMatches(int applicationId)
        {
            List<VBLPropertyShopDTO> results = new List<VBLPropertyShopDTO>();

            var preferences =
                _unitOfWork
                    .VBLRequestedPropertymatchDetail()
                    .Select(includeProperties: "PropertyTypes,PropertyTypes.PropertyType,PropertySizes,PropertySizes.PropertySize,AgeRestrictions,AdaptationDetails")
                    .FirstOrDefault(x => x.ApplicationId == applicationId);

            int max = 0;
            int min = 0;
           
            
            if (preferences != null)
            {
                switch (preferences.NumberOfSteps)
                {
                    case NumberOfSteps.OneToTwo:
                        min = 1;
                        max = 2;
                        break;
                    case NumberOfSteps.ThreeToTen:
                        min = 3;
                        max = 10;
                        break;
                    case NumberOfSteps.TenToTwenty:
                        min = 10;
                        max = 20;
                        break;
                    case NumberOfSteps.TwentyPlus:
                        min = 20;
                        max = 5000;
                        break;
                        
                }

                bool adaptations = preferences.RequireAdaptations == true;
                var propSizes = preferences.PropertySizes.Select(x => x.PropertySizeId).ToList();
                var propTypes = preferences.PropertyTypes.Select(x => x.PropertyTypeId).ToList();
               
                var mutexMatches = _unitOfWork.VblMutualExchagePropertyDetail().Select().Where(
                    x => x.ApplicationId != applicationId &&
                        //preferences.propertytypes contains mutex.propertytype
                        propTypes.Contains((int) x.PropertyTypeId) &&
                        //preferences.propertysize contains mutex propertysize
                        propSizes.Contains(x.PropertyNumberOfBedrooms) &&
                      
                    //number of steps
                    (x.NumberOfStepsToAccess >= min && x.NumberOfStepsToAccess <= max) &&
                    //adapations
                   ((x.HasStairLift && x.HasRampledAccess && 
                   x.HasStepInShower && x.HasWalkInShower && 
                   x.IsWheelChairAdapted) || (x.AdaptationDetails.Count > 0) 
                   == adaptations)
                    ).ToList();

                if (preferences.HighRise == false)
                {
                    mutexMatches =
                        mutexMatches.Where(x => x.PropertyBlockTypeId != 1).ToList();
                }
                if(preferences.CommunalEntrance == false || (preferences.CatOrDog == true && preferences.RehousePet == false))
                {
                    mutexMatches = mutexMatches.Where(x => x.PropertyEntranceTypeId != 1).ToList();
                }
                if (preferences.AgeRestricted == true)
                {

                    mutexMatches =
                        mutexMatches.Where(x => preferences.AgeRestrictions
                            .Select(a => a.AgeRestrictionId).ToList()
                            .Contains(x.AgeRestrictionId ?? 1)).ToList();
                }

                var mutexPreferences =
                    _unitOfWork.VBLRequestedPropertymatchDetail()
                        .Select()
                        .Where(x => mutexMatches.Select(y => y.ApplicationId).ToList().Contains(x.ApplicationId));

                var currentMutexDetails =
                    _unitOfWork
                        .VblMutualExchagePropertyDetail()
                        .Select()
                        .FirstOrDefault(x => x.ApplicationId == applicationId);

                if (currentMutexDetails != null)
                {

                    NumberOfSteps steps;

                    if (currentMutexDetails.NumberOfStepsToAccess > 20)
                    {
                        steps = NumberOfSteps.TwentyPlus;
                    }
                    else if (currentMutexDetails.NumberOfStepsToAccess > 9 &&
                             currentMutexDetails.NumberOfStepsToAccess < 21)
                    {
                        steps = NumberOfSteps.TenToTwenty;
                    }
                    else if (currentMutexDetails.NumberOfStepsToAccess > 2 &&
                             currentMutexDetails.NumberOfStepsToAccess < 10)
                    {
                        steps = NumberOfSteps.ThreeToTen;
                    }
                    else if (currentMutexDetails.NumberOfStepsToAccess > 0 &&
                             currentMutexDetails.NumberOfStepsToAccess < 3)
                    {
                        steps = NumberOfSteps.OneToTwo;
                    }
                    else
                    {
                        steps = NumberOfSteps.Zero;
                    }

                    mutexPreferences = mutexPreferences.Where(x => x.NumberOfSteps == steps);

                    bool mutexAdaptations = currentMutexDetails.AdaptationDetails!= null && currentMutexDetails.AdaptationDetails.Any();

                    mutexPreferences =
                        mutexPreferences.Where(
                            x =>
                                ((x.RampedAccess == true && x.WheelChairAdapted == true && x.StepInShower == true &&
                                  x.WalkInShower == true && x.StairLift == true) ||
                                 (x.AdaptationDetails.Any()) == mutexAdaptations));

                    mutexPreferences =
                        mutexPreferences.Where(
                            x =>
                                x.PropertyTypes.Select(y => y.PropertyTypeId)
                                    .ToList()
                                    .Contains((int) currentMutexDetails.PropertyTypeId));
                    mutexPreferences =
                        mutexPreferences.Where(
                            x =>
                                x.PropertySizes.Select(y => y.PropertySizeId)
                                    .ToList()
                                    .Contains((int) currentMutexDetails.PropertySizeId));
                    if (currentMutexDetails.PropertyEntranceTypeId != 1)
                    {
                        mutexPreferences =
                            mutexPreferences.Where(
                                x => (x.CommunalEntrance != false) || !(x.CatOrDog == true && x.RehousePet == false));
                    }
                    if (currentMutexDetails.AgeRestrictionId != 1 && currentMutexDetails.AgeRestrictionId != null)
                    {
                        mutexPreferences =
                            mutexPreferences.Where(
                                x =>
                                    x.AgeRestricted == true &&
                                    x.AgeRestrictions.Select(y => y.AgeRestrictionId)
                                        .ToList()
                                        .Contains((int) currentMutexDetails.AgeRestrictionId));
                    }
                    var preferencesAppIds = mutexPreferences.Select(x => x.ApplicationId).ToList();

                    mutexMatches = mutexMatches.Where(x => preferencesAppIds.Contains(x.ApplicationId)).ToList();

                    foreach(var mutex in mutexMatches)
                    {
                        var propertyDetails = GetPropertyDetailsForMutex(mutex.PropertyCode);

                        VBLPropertyShopDTO property = new VBLPropertyShopDTO
                        {
                            VoidId = -100,
                            PropertyCode = mutex.PropertyCode,
                            PropertyType = mutex.PropertyType.Name,
                            Bedrooms = mutex.PropertyNumberOfBedrooms,
                            WheelchairAdapted = mutex.IsWheelChairAdapted,//check this isnt needed from mutexadaptations
                            RampedAccess = mutex.HasRampledAccess,//check this isnt needed from mutexadaptations
                            WalkInShower = mutex.HasWalkInShower,//check this isnt needed from mutexadaptations
                            StepInShower = mutex.HasStepInShower,//check this isnt needed from mutexadaptations
                            Stairlift = mutex.HasStairLift,//check this isnt needed from mutexadaptations
                            AgeRestriction = mutex.AgeRestriction.Name,
                            Pets = propertyDetails.Pets,
                            NumberOfSteps = mutex.NumberOfStepsToAccess,
                            Lift = mutex.HasLift,
                            CommunalEntrance = propertyDetails.CommunalEntrance,
                            HighRise = propertyDetails.HighRise,
                            NeighbourhoodId = propertyDetails.NeighbourhoodId,
                            Area = propertyDetails.Area,
                            TenancyEndDate = propertyDetails.TenancyEndDate,
                            Rent = mutex.Rent,
                            ServiceCharges = mutex.ServiceCharges,
                            RentFrequency = propertyDetails.RentFrequency,
                            Landlord = "INCOMM",
                            AddressLine1 = propertyDetails.AddressLine1,
                            AddressLine2 = propertyDetails.AddressLine2,
                            AddressLine3 = propertyDetails.AddressLine3,
                            AddressLine4 = propertyDetails.AddressLine4,
                            PostCode = propertyDetails.PostCode,
                            Driveway = propertyDetails.Driveway,
                            Outbuildings = propertyDetails.Outbuildings,
                            Parking = propertyDetails.Parking,
                            Bin = propertyDetails.Bin,
                            Garden = mutex.HasGarden,
                            NumberOfFloors = propertyDetails.NumberOfFloors,
                            NumberOfBathrooms = propertyDetails.NumberOfBathrooms,
                            NumberOfReceptionRooms = propertyDetails.NumberOfReceptionRooms,
                            BathroomType = propertyDetails.BathroomType,
                            SeparateWC = propertyDetails.SeparateWC,
                            WCType = propertyDetails.WCType,
                            Trustcare = mutex.HasTrustcare,
                            FloorLevel = mutex.FlatFloorLevel,
                            Concierge = propertyDetails.Concierge,
                            DoorEntry = propertyDetails.DoorEntry,
                            WasherSpace = propertyDetails.WasherSpace,
                            DryerSpace = propertyDetails.DryerSpace,
                            CommunalLaundry = propertyDetails.CommunalEntrance,
                            Furnished = propertyDetails.Furnished,
                            ElectricMeterType = propertyDetails.ElectricMeterType,
                            ElectricMeterLocation = propertyDetails.ElectricMeterLocation,
                            ElectricSupplier = propertyDetails.ElectricSupplier,
                            GasMeterLocation = propertyDetails.GasMeterLocation,
                            GasSupplier = propertyDetails.GasSupplier,
                            GasMeterType = propertyDetails.GasMeterType,
                            OtherAdaptations = propertyDetails.OtherAdaptations,
                            Longitude = propertyDetails.Longitude,
                            Latitude = propertyDetails.Latitude,
                            PropertyInterestStatus = PropertyInterestStatus.NotSelected
                            
                        };
                        results.Add(property);
                    }
                }
            }

            return results;
        }

        private VoidPropertyMatchForApplication GetPropertyDetailsForMutex(string propertyCode)
        {
            return _unitOfWork.GetPropertyDetails(propertyCode);
            //return  base.GetVBLPropertyShop(propertyCode);
        }


        public List<string> GetPostcodesInApplicationAreaSelection(int applicationId)
        {
            var areaSelection =
                _unitOfWork.RequestedPropertyPrefferedNeighbourhood()
                    .Select(includeProperties: "RequestedPropertyPrefferedNeighbourhoodDetails")
                    .Where(x => x.ApplicationId == applicationId && x.IsCurrent);

            var neighbourhoodIds = new List<string>();

            var vblRequestedPropertyPrefferedNeighbourhood =
                  areaSelection.OrderByDescending(
                      x => x.RequestedPropertyPrefferedNeighbourhoodId).FirstOrDefault();
            if (vblRequestedPropertyPrefferedNeighbourhood != null)
                neighbourhoodIds.AddRange(
                    vblRequestedPropertyPrefferedNeighbourhood.RequestedPropertyPrefferedNeighbourhoodDetails.Select(
                        x => x.NeighbourhoodId.ToString()).ToList());

            var vblNeighbourhoods = GetPropertyNeighbourhood(neighbourhoodIds);
            var vblPostcodes= vblNeighbourhoods.SelectMany(x => x.PropertyPostcodes).ToList();
            return vblPostcodes.Select(x=>x.Postcode).ToList();
        }

    }
}
