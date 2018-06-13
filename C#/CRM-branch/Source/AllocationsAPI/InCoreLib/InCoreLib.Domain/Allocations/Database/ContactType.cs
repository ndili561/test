using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("ContactType")]
    public partial class ContactType
    {
        public int ContactTypeId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool? Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
