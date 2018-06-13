using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.DTOs
{
   public class VBLDisabilityTypeDTO : BaseObject
    {
        [Key]
        public int DisabilityTypeId { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
