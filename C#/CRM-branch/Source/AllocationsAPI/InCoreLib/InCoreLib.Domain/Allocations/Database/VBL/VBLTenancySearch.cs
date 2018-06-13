using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    public class VBLTenancySearch
    {
        [Key, Column(Order = 0)]
        public string PropertyCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Postcode { get; set; }
        public string IBSPropertyType { get; set; }
        public decimal AgeCriteria { get; set; }
        public string PetsAllowed { get; set; }
        public int PropertyNumBedrooms { get; set; }
        public int SchemeID { get; set; }
        public int SubNeighbourhoodId { get; set; }
        public string SubNeighbourhoodCode { get; set; }
        public string SubNeighbourhoodName { get; set; }
        public string NeighbourhoodCode { get; set; }
        public string NeighbourhoodName { get; set; }
        public int FlatFloorLevel { get; set; }
        public int LiftAccess { get; set; }
        public int Careline { get; set; }
        public int HeatingTypeID { get; set; }
        public int Garden { get; set; }
        public int StepsToAccess { get; set; }
        public int IsWheelChairAdapted { get; set; }
        public int HasRampedAccess { get; set; }
        public int IsLevelAccessProperty { get; set; }
        public int HasStairlift { get; set; }
        public int HasWalkInShower { get; set; }
        public int HasStepInShower { get; set; }
        public int BlockID { get; set; }
        public string IBSTypeCode { get; set; }
        public string IBSCatCode { get; set; }
        public DateTime TenancyStart { get; set; }
        public DateTime TenancyEnd { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Key, Column(Order = 1)]
        public string TenantCode { get; set; }
        public int VoidId { get; set; }
        public int TerminationTypeID { get; set; }
        public int IBSTerminating { get; set; }
        public string TenancyType { get; set; }
        public string TenancyTypeName { get; set; }
        public int TenancyTypeId { get; set; }
        public int CustomerApplicationID { get; set; }

        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

    }
}
