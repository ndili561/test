using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    public class AgeRestriction
    {
        public int AgeRestrictionId { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
