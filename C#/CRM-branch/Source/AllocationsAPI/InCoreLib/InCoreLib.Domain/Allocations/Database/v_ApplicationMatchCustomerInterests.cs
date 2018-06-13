using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_ApplicationMatchCustomerInterests
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerInterestID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string PropertyCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerInterestStatusID { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool StatusIsOpen { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool StatusHideProperty { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool StatusOnlyShowProperty { get; set; }
    }
}
