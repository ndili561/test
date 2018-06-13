using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    [NotMapped]
    public class VBLAddress : BaseObject
    {
        [Key]
        public int AddressId { get; set; }
        public int? LivedAtAddressYears { get; set; }
        public int? LivedAtAddressMonths { get; set; }
        public AddressType AddressType { get; set; }
        public string PropertyCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string PostCode { get; set; }
        public bool IsActive { get; set; }
        public VBLApplication Application { get; set; }
    }
}
