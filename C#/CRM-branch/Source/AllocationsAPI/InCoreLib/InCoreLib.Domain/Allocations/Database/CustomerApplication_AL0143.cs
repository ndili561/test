using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class CustomerApplication_AL0143
    {
        [Key]
        [Column(Order = 0)]
        public int CustomerApplicationId { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ApplicationDate { get; set; }

        [Column("Old Move Date", TypeName = "date")]
        public DateTime? Old_Move_Date { get; set; }

        [Column("New Move Date", TypeName = "date")]
        public DateTime? New_Move_Date { get; set; }

        [Key]
        [Column("DateTime Updated", Order = 2)]
        public DateTime DateTime_Updated { get; set; }
    }
}
