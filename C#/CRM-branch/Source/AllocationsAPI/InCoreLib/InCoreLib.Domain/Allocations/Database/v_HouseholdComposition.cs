using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_HouseholdComposition
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(31)]
        public string HouseholdComposition { get; set; }

        [StringLength(15)]
        public string ApplicantAgeBand { get; set; }

        public int? ApplicantAge { get; set; }

        [StringLength(50)]
        public string ApplicantEthnicity { get; set; }

        [StringLength(14)]
        public string TenureBand { get; set; }

        public int? TenureLengthMonths { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string LevelOfNeed { get; set; }
    }
}
