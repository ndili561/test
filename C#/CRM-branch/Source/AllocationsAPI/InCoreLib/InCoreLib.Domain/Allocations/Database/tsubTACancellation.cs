using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubTACancellation")]
    public partial class tsubTACancellation
    {
        [Key]
        [Column(Order = 0)]
        public int CancellationID { get; set; }

        public DateTime? CancDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TAPlacementID { get; set; }

        public int? CancReasonID { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public int? NoOfNightsCancelled { get; set; }
    }
}
