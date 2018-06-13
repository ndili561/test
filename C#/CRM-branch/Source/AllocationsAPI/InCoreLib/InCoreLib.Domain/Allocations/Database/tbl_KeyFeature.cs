using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tbl_KeyFeature
    {
        [Key]
        [StringLength(32)]
        public string PropertyReference { get; set; }

        [StringLength(300)]
        public string KeyFeature { get; set; }
    }
}
