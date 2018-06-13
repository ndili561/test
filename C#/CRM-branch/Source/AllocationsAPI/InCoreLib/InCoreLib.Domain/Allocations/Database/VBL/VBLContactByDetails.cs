using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [NotMapped]
    public class VBLContactByDetails : ConcurrencyBase
    {
        [Key, Column(Order = 0)]
        public int ContactId { get; set; }

        [Key, Column(Order = 1)]
        public int ContactById { get; set; }

        public virtual VBLContact VBLContact { get; set; }
        public virtual ContactBy ContactBy { get; set; }
        public string ContactValue { get; set; }
        public string ContactText { get; set; }
    }
}