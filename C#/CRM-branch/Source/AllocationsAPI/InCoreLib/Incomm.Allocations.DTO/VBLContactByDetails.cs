using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLContactByDetailsDTO : ConcurrencyBase
    {
        [Key, Column(Order = 0)]
        public int ContactId { get; set; }
        [Key, Column(Order = 1)]
        public int ContactById { get; set; }
        public virtual VBLContactDTO VBLContact { get; set; }
        public virtual ContactByDTO ContactBy { get; set; }
        public string ContactValue { get; set; }
        public string ContactText { get; set; }
    }

}
