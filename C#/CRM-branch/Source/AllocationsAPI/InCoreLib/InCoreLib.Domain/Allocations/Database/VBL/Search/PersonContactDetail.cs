using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL.Search
{
    [NotMapped]
    public class PersonContactDetail : BaseObject
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int ContactByOptionId { get; set; }
        public virtual ContactByOption ContactByOption { get; set; }
        public string ContactValue { get; set; }
        public int? PriorityOrder { get; set; }
        public bool? IsDefault { get; set; }
        public string Comment { get; set; }
    }
}
