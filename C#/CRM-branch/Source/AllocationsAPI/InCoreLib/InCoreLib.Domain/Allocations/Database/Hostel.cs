using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
   [TrackChanges]
    public class Hostel : BaseObject
    {

        [Key]
        public int HostelId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int HRSProviderId { get; set; }
        public HRSProvider HrsProvider { get; set; }
        public bool Active { get; set; }

    }
}
