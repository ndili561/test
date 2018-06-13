using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tbl_AudRejections
    {
        public int id { get; set; }

        public DateTime Occured { get; set; }

        [StringLength(100)]
        public string ChangedBy { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }

        [StringLength(50)]
        public string PropertyCode { get; set; }

        public int? CustomerApplicationID { get; set; }
    }
}
