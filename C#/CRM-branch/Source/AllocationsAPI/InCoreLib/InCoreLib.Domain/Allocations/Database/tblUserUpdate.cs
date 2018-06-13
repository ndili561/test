using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblUserUpdate
    {
        [Key]
        public int UserUpdateIndex { get; set; }

        public DateTime? UserUpdateDateTime { get; set; }

        [Column(TypeName = "ntext")]
        public string UserUpdateNote { get; set; }

        [StringLength(50)]
        public string UserUpdateUserID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
