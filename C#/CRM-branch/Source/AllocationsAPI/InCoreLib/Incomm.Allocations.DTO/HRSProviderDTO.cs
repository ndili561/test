using System.ComponentModel.DataAnnotations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSProviderDTO : BaseObjectDto
    {

        [Key]
        public int HRSProviderId { get; set; }
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        public string RegisteredCouncilCode { get; set; }
    }
}
