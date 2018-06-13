using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{

    public class SchemeBlock
    {
        [Key, Column(Order = 0)]
        public int SchemeId { get; set; }

        [Key, Column(Order = 1)]
        public string BlockRef { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}

