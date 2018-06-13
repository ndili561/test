using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.DTOs
{
   public class VBLSupportTypeDTO : BaseObject
    {
        [Key]
        public int SupportTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
