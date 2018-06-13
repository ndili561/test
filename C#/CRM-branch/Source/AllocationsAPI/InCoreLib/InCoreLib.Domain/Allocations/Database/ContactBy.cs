using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("ContactBy")]
    public class ContactBy : ConcurrencyBase
    {
        [Key]
        public int ContactById { get; set; }

        public string Code { get; set; }//Phone,Mobile,MobileText,Email,Mail,SecondaryPhone
        public string Description { get; set; }
        public bool Active { get; set; }
        public int? SortOrder { get; set; }
    }
}