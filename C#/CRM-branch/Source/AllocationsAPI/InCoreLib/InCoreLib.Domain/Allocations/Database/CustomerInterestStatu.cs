using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public class CustomerInterestStatu
    {
        [Key]
        public int CustomerInterestStatusId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int SortOrder { get; set; }

        public bool StatusIsOpen { get; set; }

        public bool StatusOnlyShowProperty { get; set; }

        public bool StatusHideProperty { get; set; }
    }
}
