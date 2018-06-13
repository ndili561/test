using System.ComponentModel;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.DTO.CRM
{
    public class PersonApplicationLinkDto : BaseObjectDto
    {
        public PersonApplicationLinkDto()
        {
            
        }
        public PersonApplicationLinkDto(int vblContactId)
        {
            ExternalLinkId = vblContactId.ToString();
        }
        public int PersonId { get; set; }
        public int ApplicationId => 5;

        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string ExternalLinkId { get; set; }
    }
}
