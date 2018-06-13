using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstLocalAuthority")]
    public partial class lstLocalAuthority
    {
        [Key]
        public int LocalAuthorityID { get; set; }

        [StringLength(250)]
        public string LocalAuthorityName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Active { get; set; }
    }
}
