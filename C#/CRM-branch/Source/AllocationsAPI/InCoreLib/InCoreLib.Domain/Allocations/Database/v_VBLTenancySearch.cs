using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public class v_VBLTenancySearch
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(32)]
        public string PropertyCode { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(100)]
        public string Address3 { get; set; }

        [StringLength(100)]
        public string Address4 { get; set; }

        [StringLength(16)]
        public string Postcode { get; set; }

        [Column(Order = 1)]
        [StringLength(100)]
        public string IBSPropertyType { get; set; }

        public decimal? AgeCriteria { get; set; }

        [StringLength(1)]
        public string PetsAllowed { get; set; }

        public int? PropertyNumBedrooms { get; set; }

        [Column(Order = 2)]
        public int SchemeID { get; set; }

        [Column(Order = 3)]
        public int SubNeighbourhoodId { get; set; }

        [Column(Order = 4)]
        [StringLength(15)]
        public string SubNeighbourhoodCode { get; set; }

        [Column(Order = 5)]
        [StringLength(50)]
        public string SubNeighbourhoodName { get; set; }

        [Column(Order = 6)]
        [StringLength(15)]
        public string NeighbourhoodCode { get; set; }

        [Column(Order = 7)]
        [StringLength(50)]
        public string NeighbourhoodName { get; set; }

        public int? FlatFloorLevel { get; set; }

        [Column(Order = 8)]
        public int LiftAccess { get; set; }

        [Column(Order = 9)]
        public int Careline { get; set; }

        [Column(Order = 10)]
        public int HeatingTypeID { get; set; }

        [Column(Order = 11)]
        public int Garden { get; set; }

        [Column(Order = 12)]
        public int StepsToAccess { get; set; }

        [Column(Order = 13)]
        public int IsWheelChairAdapted { get; set; }

        [Column(Order = 14)]
        public int HasRampedAccess { get; set; }

        [Column(Order = 15)]
        public int IsLevelAccessProperty { get; set; }

        [Column(Order = 16)]
        public int HasStairlift { get; set; }

        [Column(Order = 17)]
        public int HasWalkInShower { get; set; }

        [Column(Order = 18)]
        public int HasStepInShower { get; set; }

        public int? BlockID { get; set; }

        [Column(Order = 19)]
        [StringLength(4)]
        public string IBSTypeCode { get; set; }

        [Column(Order = 20)]
        [StringLength(4)]
        public string IBSCatCode { get; set; }

        public DateTime? TenancyStart { get; set; }

        [Column(Order = 21)]
        public DateTime TenancyEnd { get; set; }

        [StringLength(80)]
        public string Forename { get; set; }

        [StringLength(80)]
        public string Surname { get; set; }

        [Column(Order = 22)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(19)]
        public string TenancyRef { get; set; }

        [StringLength(32)]
        public string TenantCode { get; set; }

        [Column(Order = 23)]
        public int MainTenant { get; set; }

        [Key]
        [Column(Order = 24)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VoidId { get; set; }

        [Column(Order = 25)]
        public int TerminationTypeID { get; set; }

        [Column(Order = 26)]
        public int IBSTerminating { get; set; }

        [Column(Order = 27)]
        [StringLength(9)]
        public string TenancyType { get; set; }

        [Key]
        [Column(Order = 28)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }
    }
}