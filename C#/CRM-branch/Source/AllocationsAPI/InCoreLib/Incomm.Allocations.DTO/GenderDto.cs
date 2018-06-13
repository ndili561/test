using System.ComponentModel.DataAnnotations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class GenderDto
    {
        public int GenderId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}