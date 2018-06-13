using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.DTO.CRM
{
    public class PersonContactDetailDto : BaseObjectDto
    {
        public int PersonId { get; set; }
        public virtual PersonDto Person { get; set; }

        public int ContactByOptionId { get; set; }
        public virtual ContactByOption ContactByOption { get; set; }
        public string ContactValue { get; set; }
        public int? PriorityOrder { get; set; }
        public bool? IsDefault { get; set; }
        public string Comment { get; set; }
    }
}
