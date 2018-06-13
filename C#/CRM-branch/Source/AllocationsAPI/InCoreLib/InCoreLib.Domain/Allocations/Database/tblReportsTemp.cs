using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblReportsTemp")]
    public partial class tblReportsTemp
    {
        [Key]
        public int ReportID { get; set; }

        [StringLength(50)]
        public string ReportName { get; set; }

        [StringLength(50)]
        public string OfficerID { get; set; }

        [StringLength(50)]
        public string Parameter1 { get; set; }

        [StringLength(50)]
        public string Parameter2 { get; set; }

        [StringLength(50)]
        public string Parameter3 { get; set; }

        [StringLength(50)]
        public string Parameter4 { get; set; }

        [StringLength(50)]
        public string Parameter5 { get; set; }
    }
}
