using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.DTO.IH.SuitabilityNote
{
    public class SuitabilityNoteDTO : BaseObjectDto
    {
        public int SuitabilityNoteId { get; set; }

        public int SuitabilityNoteTypeId { get; set; }

        public int ContactId { get; set; }

        public string Text { get; set; }
    }
}
