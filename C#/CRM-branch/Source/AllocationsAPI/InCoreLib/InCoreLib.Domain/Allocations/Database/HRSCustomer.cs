using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database
{
   [TrackChanges]
    public class HRSCustomer : BaseObject
    {
        public HRSCustomer()
        {
            HRSPlacementsMatched = new List<HRSPlacementMatchedForCustomer>();
            SupportTypes = new List<SupportType>();
            ServiceTypes = new List<ServiceType>();
        }

        [Key]
        public int HRSCustomerId { get; set; }

        [SkipTracking]
        public int HOACaseReference { get; set; }

        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public string GatewayOfficer { get; set; }
        public DateTime DateAdded { get; set; }
        public Priority Priority { get; set; }
        public int MinBedroomSize { get; set; }

        [SkipTracking]
        public virtual ICollection<HRSPlacementMatchedForCustomer> HRSPlacementsMatched { get; set; }

        [SkipTracking]
        public virtual ICollection<SupportType> SupportTypes { get; set; }

        [SkipTracking]
        public virtual ICollection<ServiceType> ServiceTypes { get; set; }

        public virtual Status Status { get; set; }

        public virtual CustomerGender Gender { get; set; }
    }
}