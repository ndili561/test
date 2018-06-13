using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblUserAdmin")]
    public partial class tblUserAdmin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SystemUserIndex { get; set; }

        [Key]
        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string UserFullName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string UserPostTitle { get; set; }

        [StringLength(255)]
        public string UserRoles { get; set; }

        public bool? ApprovedUser { get; set; }

        [Column(TypeName = "image")]
        public byte[] UserPhoto { get; set; }

        public bool? ViewInLists { get; set; }

        [StringLength(50)]
        public string UserLocation { get; set; }

        [StringLength(50)]
        public string UserPassword { get; set; }

        public bool? Admin { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public bool? HasAccessToHighlySensitive { get; set; }
    }
}
