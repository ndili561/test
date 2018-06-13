using System.ComponentModel.DataAnnotations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class TitleDto
    {
        public int TitleId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool Active { get; set; }
        public int? SortOrder { get; set; }
        public int DefaultGenderID { get; set; }
    }
}