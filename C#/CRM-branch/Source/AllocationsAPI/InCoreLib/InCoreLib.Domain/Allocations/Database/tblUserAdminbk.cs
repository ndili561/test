using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblUserAdminbk")]
    public partial class tblUserAdminbk
    {
        [Key]
        [Column(Order = 0)]
        public int SystemUserIndex { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string UserFullName { get; set; }

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
    }
}
