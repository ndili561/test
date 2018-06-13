using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL.Search
{
    [NotMapped]
    public class ContactByOption : BaseObject
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public bool IsActive { get; set; }
    }
}