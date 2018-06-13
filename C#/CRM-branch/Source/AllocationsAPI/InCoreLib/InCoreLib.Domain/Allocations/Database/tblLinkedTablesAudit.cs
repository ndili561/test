using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblLinkedTablesAudit")]
    public partial class tblLinkedTablesAudit
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

        public int? LinkedTableID { get; set; }

        [StringLength(255)]
        public string OriginalName { get; set; }

        [StringLength(255)]
        public string RevisedName { get; set; }

        [StringLength(255)]
        public string OriginalForeignName { get; set; }

        [StringLength(255)]
        public string RevisedForeignName { get; set; }

        [StringLength(255)]
        public string OriginalConnect { get; set; }

        [StringLength(255)]
        public string RevisedConnect { get; set; }
    }
}
