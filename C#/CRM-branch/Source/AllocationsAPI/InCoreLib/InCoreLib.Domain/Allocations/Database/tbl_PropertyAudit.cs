using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tbl_PropertyAudit
    {
        public int id { get; set; }

        public int PropertyId { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyCode { get; set; }

        [StringLength(50)]
        public string RSL { get; set; }

        [StringLength(20)]
        public string PropertyType { get; set; }

        public bool? HasDriveway { get; set; }

        public bool? HasParking { get; set; }

        public bool? HasBin { get; set; }

        public bool? HasOutbuildings { get; set; }

        public bool? HasStepsToAccess { get; set; }

        public int? NumStepsToAccess { get; set; }

        public bool? HasGarden { get; set; }

        public int? PropertyNumFloors { get; set; }

        public int? PropertyNumBedrooms { get; set; }

        public int? PropertyNumReceptionRooms { get; set; }

        public int? PropertyNumBathrooms { get; set; }

        [StringLength(50)]
        public string BathroomType { get; set; }

        [StringLength(50)]
        public string WCType { get; set; }

        public bool? WCIsSeperate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AgeCriteria { get; set; }

        public bool? Careline { get; set; }

        public int? FlatFloorLevel { get; set; }

        public bool? HasConcierge { get; set; }

        public bool? HasDoorEntry { get; set; }

        public bool? HasLift { get; set; }

        public bool? HasWasherSpace { get; set; }

        public bool? HasDryerSpace { get; set; }

        public bool? HasCommunalLaundry { get; set; }

        public bool? HasFurnishings { get; set; }

        [StringLength(255)]
        public string FurnishingDetails { get; set; }

        public bool? IsWheelChairAdapted { get; set; }

        public bool? HasRampedAccess { get; set; }

        public bool? IsLevelAccessProperty { get; set; }

        public bool? HasStairlift { get; set; }

        public bool? HasWalkInShower { get; set; }

        public bool? HasStepInShower { get; set; }

        [StringLength(255)]
        public string OtherAdaptationsDescription { get; set; }

        [StringLength(50)]
        public string HeatingType { get; set; }

        [StringLength(50)]
        public string ElectricMeterType { get; set; }

        [StringLength(255)]
        public string ElectricSupplier { get; set; }

        [StringLength(255)]
        public string ElectricMeterLocation { get; set; }

        public bool? HasGas { get; set; }

        [StringLength(50)]
        public string GasMeterType { get; set; }

        [StringLength(255)]
        public string GasSupplier { get; set; }

        [StringLength(255)]
        public string GasMeterLocation { get; set; }

        public bool? HasOutstandingRepairs { get; set; }

        [StringLength(1000)]
        public string OutstandingRepairComments { get; set; }

        [StringLength(1000)]
        public string OutstandingRepairsReason { get; set; }

        public int? PropertyStatusID { get; set; }

        [StringLength(50)]
        public string LandLord { get; set; }

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }

        public bool? HasSecurity { get; set; }

        [StringLength(50)]
        public string SecurityType { get; set; }

        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [StringLength(100)]
        public string AddressLine3 { get; set; }

        [StringLength(100)]
        public string AddressLine4 { get; set; }

        [StringLength(10)]
        public string Postcode { get; set; }

        [StringLength(50)]
        public string Ward { get; set; }

        public string AdvertDetails { get; set; }

        [Required]
        [StringLength(100)]
        public string ChangedBy { get; set; }

        [Required]
        [StringLength(100)]
        public string ChangeType { get; set; }

        public DateTime Occured { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string SubNeighbourhood { get; set; }

        public decimal? Rent { get; set; }

        public decimal? ServiceCharge { get; set; }

        public decimal? OtherCharge { get; set; }

        [StringLength(50)]
        public string PaymentCycle { get; set; }
    }
}
