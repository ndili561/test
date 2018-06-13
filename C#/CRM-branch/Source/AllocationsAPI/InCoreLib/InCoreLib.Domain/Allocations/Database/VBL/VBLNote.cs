using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLNote : BaseObject
    {
        [Key]
        public int NoteId { get; set; }
        public NoteType NoteType { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public VBLContact VBLContact { get; set; }
    }
}