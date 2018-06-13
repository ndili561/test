using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblUserAdminAudit")]
    public partial class tblUserAdminAudit
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

        public int? OriginalSystemUserIndex { get; set; }

        public int? RevisedSystemUserIndex { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string OriginalUserFullName { get; set; }

        [StringLength(50)]
        public string RevisedUserFullName { get; set; }

        [StringLength(50)]
        public string OriginalUserPostTitle { get; set; }

        [StringLength(50)]
        public string RevisedUserPostTitle { get; set; }

        [StringLength(255)]
        public string OriginalUserRoles { get; set; }

        [StringLength(255)]
        public string RevisedUserRoles { get; set; }

        public bool? OriginalApprovedUser { get; set; }

        public bool? RevisedApprovedUser { get; set; }

        public bool? OriginalViewInLists { get; set; }

        public bool? RevisedViewInLists { get; set; }

        [StringLength(50)]
        public string OriginalUserLocation { get; set; }

        [StringLength(50)]
        public string RevisedUserLocation { get; set; }

        [StringLength(50)]
        public string OriginalUserPassword { get; set; }

        [StringLength(50)]
        public string RevisedUserPassword { get; set; }

        public bool? OriginalAdmin { get; set; }

        public bool? RevisedAdmin { get; set; }
    }
}
