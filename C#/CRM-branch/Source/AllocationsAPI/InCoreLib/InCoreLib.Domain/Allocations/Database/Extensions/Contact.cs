using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.Extensions
{
    public partial class Contact
    {
        [ForeignKey("GenderID")]
        public virtual Gender Gender { get; set; }

        [ForeignKey("TitleId")]
        public virtual Title Title { get; set; }
    }
}