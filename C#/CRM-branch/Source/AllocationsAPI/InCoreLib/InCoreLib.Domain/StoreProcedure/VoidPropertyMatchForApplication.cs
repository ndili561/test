using System;
using System.Collections.Generic;

namespace InCoreLib.Domain.StoreProcedure
{
    public class VoidPropertyMatchForApplication 
    {
        public VoidPropertyMatchForApplication()
        {
            Images = new List<byte[]>();
        }
        public int VoidId { get; set; }
        public string PropertyCode { get; set; }
        public string PropertyType { get; set; }
        public int? Bedrooms { get; set; }
        public bool? WheelchairAdapted { get; set; }
        public bool? RampedAccess { get; set; }
        public bool? WalkInShower { get; set; }
        public bool? StepInShower { get; set; }
        public bool? Stairlift { get; set; }
        public string AgeRestriction { get; set; }
        public string Pets { get; set; }
        public int? NumberOfSteps { get; set; }
        public bool? Lift { get; set; }
        public bool? CommunalEntrance { get; set; }
        public bool? HighRise { get; set; }
        public int NeighbourhoodId { get; set; }
        public string Area { get; set; }
        public DateTime TenancyEndDate { get; set; }
        public decimal? Rent { get; set; }
        public decimal? ServiceCharges { get; set; }
        public string Landlord { get; set; }
        public int LandlordId { get; set; }
        public string RentFrequency { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string PostCode { get; set; }
        public bool? Driveway { get; set; }
        public bool? Outbuildings { get; set; }
        public bool? Parking { get; set; }
        public bool? Bin { get; set; }
        public bool? Garden { get; set; }
        public int? NumberOfFloors { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? NumberOfReceptionRooms { get; set; }
        public string BathroomType { get; set; }
        public bool? SeparateWC { get; set; }
        public string WCType { get; set; }
        public bool? Trustcare { get; set; }
        public int? FloorLevel { get; set; }
        public bool? Concierge { get; set; }
        public bool? DoorEntry { get; set; }
        public bool? WasherSpace { get; set; }
        public bool? DryerSpace { get; set; }
        public bool? CommunalLaundry { get; set; }
        public bool? Furnished { get; set; }
        public string ElectricMeterType { get; set; }
        public string ElectricSupplier { get; set; }
        public string ElectricMeterLocation { get; set; }
        public string GasMeterType { get; set; }
        public string GasSupplier { get; set; }
        public string GasMeterLocation { get; set; }
        public string OtherAdaptations { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public List<byte[]> Images { get; set; }
        public int PropertyInterestStatus { get; set; }
        public int MatchedApplicationId { get; set; }
        public string Comment { get; set; }

    }
}
