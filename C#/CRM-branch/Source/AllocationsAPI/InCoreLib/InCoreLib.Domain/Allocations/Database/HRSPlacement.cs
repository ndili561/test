using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database
{
    public class HRSPlacement : BaseObject
    {
        public HRSPlacement()
        {
            HRSCustomersMatched = new List<HRSPlacementMatchedForCustomer>();
        }

        [Key]
        public int PlacementId { get; set; }

        public bool MoveOnPlacement { get; set; }

        [Required]
        public int HRSProviderId { get; set; }

        public HRSProvider HRSProvider { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public int MinimumBedroom { get; set; }
        public virtual int SupportTypeId { get; set; }
        public virtual SupportType SupportType { get; set; }
        public virtual int? HostelId { get; set; }
        public virtual Hostel Hostel { get; set; }
        public virtual ICollection<ServiceType> ServiceTypes { get; set; }
        public virtual PlacementStatus PlacementStatus { get; set; }
        public List<HRSPlacementMatchedForCustomer> HRSCustomersMatched { get; set; }
        public virtual PlacementGender PlacementGender { get; set; }
    }
}