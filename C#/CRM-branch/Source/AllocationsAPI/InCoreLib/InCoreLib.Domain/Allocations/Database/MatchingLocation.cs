using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class MatchingLocation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SelectedValue { get; set; }

        [StringLength(20)]
        public string MatchingCode { get; set; }

        [StringLength(50)]
        public string Ward { get; set; }
    }
}
