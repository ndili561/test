using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public class ServiceType : ConcurrencyBase
    {
        [Key]
        public int ServiceTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }

}
