using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblUserExtraScanLocn")]
    public partial class tblUserExtraScanLocn
    {
        [Key]
        public int RecID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        public string ScanLocn { get; set; }

        [Required]
        [StringLength(3)]
        public string LocnShortCode { get; set; }

        public bool Active { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; }
    }
}
