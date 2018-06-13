using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL.Search
{
    [NotMapped]
    public class PersonApplicationLink : BaseObject
    {
        public int PersonId { get; set; }
        public int ApplicationId => 5;

        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
