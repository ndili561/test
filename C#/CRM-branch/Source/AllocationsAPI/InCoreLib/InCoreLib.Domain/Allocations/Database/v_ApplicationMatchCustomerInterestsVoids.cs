using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_ApplicationMatchCustomerInterestsVoids
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VoidContactID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string PropertyCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerInterestStatusID { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool StatusIsOpen { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool StatusHideProperty { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool StatusOnlyShowProperty { get; set; }

        public int? ActivityID { get; set; }
    }
}
