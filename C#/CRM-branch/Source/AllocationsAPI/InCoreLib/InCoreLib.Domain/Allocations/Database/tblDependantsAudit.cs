using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblDependantsAudit")]
    public partial class tblDependantsAudit
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

        public int? OriginalCaseRefNumber { get; set; }

        public int? RevisedCaseRefNumber { get; set; }

        public int? DependantsIndex { get; set; }

        [StringLength(50)]
        public string OriginalDependantsForename { get; set; }

        [StringLength(50)]
        public string RevisedDependantsForename { get; set; }

        [StringLength(50)]
        public string OriginalDependantsSurname { get; set; }

        [StringLength(50)]
        public string RevisedDependantsSurname { get; set; }

        public DateTime? OriginalDependantsDOB { get; set; }

        public DateTime? RevisedDependantsDOB { get; set; }

        [StringLength(50)]
        public string OriginalDependantsRelationship { get; set; }

        [StringLength(50)]
        public string RevisedDependantsRelationship { get; set; }

        [StringLength(50)]
        public string OriginalDependantsGender { get; set; }

        [StringLength(50)]
        public string RevisedDependantsGender { get; set; }
    }
}
