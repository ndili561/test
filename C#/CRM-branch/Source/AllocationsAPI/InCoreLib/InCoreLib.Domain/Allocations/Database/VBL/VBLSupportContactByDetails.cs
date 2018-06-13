using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLSupportContactByDetails : BaseObject
    {
        [Key]
        public int SupportContactByDetailId { get; set; }
        public int? ReceivingSupportDetailId { get; set; }
        public virtual VBLReceivingSupportDetails VblReceivingSupportDetail { get; set; }
        public int ContactById { get; set; }
        public virtual ContactBy ContactBy { get; set; }
        public string ContactValue { get; set; }
    }
}