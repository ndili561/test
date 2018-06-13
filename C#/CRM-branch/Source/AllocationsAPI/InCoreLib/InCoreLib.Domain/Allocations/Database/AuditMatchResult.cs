using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class AuditMatchResult
    {
        public int id { get; set; }

        public int? CustomerApplicationID { get; set; }

        public int? ApplicationLevelOfNeedID { get; set; }

        public DateTime? ApplicationDate { get; set; }

        [StringLength(50)]
        public string PropertyRef { get; set; }

        public int? MatchPass { get; set; }

        public DateTime? dtStamp { get; set; }

        [StringLength(200)]
        public string whoBy { get; set; }
    }
}
