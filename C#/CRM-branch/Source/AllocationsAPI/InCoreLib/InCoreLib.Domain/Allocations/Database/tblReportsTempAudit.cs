using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblReportsTempAudit")]
    public partial class tblReportsTempAudit
    {
        [Key]
        [Column(Order = 0)]
        public DateTime RevisionDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RevisionUserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string AuditAction { get; set; }

        public int? ReportID { get; set; }

        [StringLength(50)]
        public string OriginalReportName { get; set; }

        [StringLength(50)]
        public string RevisedReportName { get; set; }

        [StringLength(50)]
        public string OriginalOfficerID { get; set; }

        [StringLength(50)]
        public string RevisedOfficerID { get; set; }

        [StringLength(50)]
        public string OriginalParameter1 { get; set; }

        [StringLength(50)]
        public string RevisedParameter1 { get; set; }

        [StringLength(50)]
        public string OriginalParameter2 { get; set; }

        [StringLength(50)]
        public string RevisedParameter2 { get; set; }

        [StringLength(50)]
        public string OriginalParameter3 { get; set; }

        [StringLength(50)]
        public string RevisedParameter3 { get; set; }

        [StringLength(50)]
        public string OriginalParameter4 { get; set; }

        [StringLength(50)]
        public string RevisedParameter4 { get; set; }

        [StringLength(50)]
        public string OriginalParameter5 { get; set; }

        [StringLength(50)]
        public string RevisedParameter5 { get; set; }
    }
}
