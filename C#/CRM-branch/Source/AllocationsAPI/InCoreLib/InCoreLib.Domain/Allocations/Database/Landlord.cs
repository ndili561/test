using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("Landlord")]
    public partial class Landlord
    {
        public int LandlordId { get; set; }
        [StringLength(50)]
        public string LandlordCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
