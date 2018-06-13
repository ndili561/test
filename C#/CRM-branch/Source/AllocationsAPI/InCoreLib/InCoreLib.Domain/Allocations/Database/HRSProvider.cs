using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
   [TrackChanges]
    public class HRSProvider : BaseObject
    {

        [Key]
        public int HRSProviderId { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        [Required]
        public string RegisteredCouncilCode { get; set; }

    }
}
