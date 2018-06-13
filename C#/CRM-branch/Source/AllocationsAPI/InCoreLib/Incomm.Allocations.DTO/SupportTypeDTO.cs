using System.ComponentModel.DataAnnotations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class SupportTypeDTO : BaseObjectDto
    {
        public int SupportTypeId { get; set; }
        public string Code { get; set; }
        [Display(Name = "Support type description")]
        public string Description { get; set; }
        public bool Active { get; set; }
        public int? SortOrder { get; set; }
       

    }
}
