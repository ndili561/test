using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tbl_ActiveManagementAreas
    {
        [Key]
        [StringLength(5)]
        public string MANAGEMENT_AREA { get; set; }

        [StringLength(50)]
        public string MANAGEMENT_AREA_DESCRIPTION { get; set; }

        public int? Status { get; set; }
    }
}
