using System;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database.VBL.Search
{
    [NotMapped]
    public class PersonAddress : BaseObject
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }

        public DateTime? LivingSince { get; set; }
        public DateTime? LivingTill { get; set; }
    }
}
