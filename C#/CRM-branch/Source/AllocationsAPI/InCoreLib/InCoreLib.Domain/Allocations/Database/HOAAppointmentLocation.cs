using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("HOAAppointmentLocation")]
    public partial class HOAAppointmentLocation
    {
        public int HOAAppointmentLocationID { get; set; }

        [Column("HOAAppointmentLocation")]
        [StringLength(50)]
        public string HOAAppointmentLocation1 { get; set; }

        public bool? Active { get; set; }
    }
}
