using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("MoveReason")]
    public partial class MoveReason
    {
        public int MoveReasonId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }

        public int LevelOfNeedID { get; set; }

        public bool ReferToHousingsOptionsOfficer { get; set; }

        public bool ReferToNeighbourhoodOfficer { get; set; }
    }
}
