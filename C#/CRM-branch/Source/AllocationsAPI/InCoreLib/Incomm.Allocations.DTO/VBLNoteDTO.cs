using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Enumerations;
using Incomm.Allocations.BLL.DTOs;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    public class VBLNoteDTO : BaseObjectDto
    {
        [Key]
        public int NoteId { get; set; }
        public NoteType NoteType { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public VBLContactDTO VBLContact { get; set; }

    }
}