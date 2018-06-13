using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubTACancellationNight")]
    public partial class tsubTACancellationNight
    {
        [Key]
        [Column(Order = 0)]
        public int TACancNightID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CancellationID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime DateCancelled { get; set; }
    }
}
