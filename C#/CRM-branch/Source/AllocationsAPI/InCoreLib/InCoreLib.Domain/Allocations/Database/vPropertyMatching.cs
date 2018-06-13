using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("vPropertyMatching")]
    public class vPropertyMatching
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyID { get; set; }

        public DateTime? DateImported { get; set; }

        [StringLength(50)]
        public string LandlordDescription { get; set; }

        [StringLength(50)]
        public string LandlordPropertyRef { get; set; }

        [StringLength(291)]
        public string Address { get; set; }

        [StringLength(10)]
        public string PostCode { get; set; }

        [StringLength(10)]
        public string PostCodeArea { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? NumberBedrooms { get; set; }

        public int? AllocatedCustomerID { get; set; }

        public DateTime? AllocatedDateTime { get; set; }

        [StringLength(50)]
        public string AllocationsOfficerID { get; set; }

        [StringLength(50)]
        public string HousingOfficerID { get; set; }

        [StringLength(50)]
        public string OptionsOfficerID { get; set; }

        public int? StatusID { get; set; }

        public bool? UnderOffer { get; set; }

        public DateTime? LastUpdatedDateTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MinimumClientAge { get; set; }

        public int? CaseRefNumber { get; set; }

        [StringLength(154)]
        public string AllocatedCustomer { get; set; }
    }
}