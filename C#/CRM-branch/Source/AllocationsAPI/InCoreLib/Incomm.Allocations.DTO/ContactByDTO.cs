using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.DTOs
{
    public class ContactByDTO : ConcurrencyBase
    {
        [Key]
        public int ContactById { get; set; }
        public string Code { get; set; }//Phone,Mobile,MobileText,Email,Mail,SecondaryPhone
        public string Description { get; set; }
        public bool Active { get; set; }
        public int? SortOrder { get; set; }
        public string ContactByValue { get; set; }
        public bool IsSelected { get; set; }
        public string ContactByText { get; set; }
    }

}
