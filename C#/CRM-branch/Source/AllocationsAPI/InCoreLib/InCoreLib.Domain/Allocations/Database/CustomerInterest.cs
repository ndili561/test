using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("CustomerInterest")]
    public partial class CustomerInterest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerInterest()
        {
            CustomerInterestStatusReasons = new HashSet<CustomerInterestStatusReason>();
        }

        public int CustomerInterestID { get; set; }

        public int CustomerApplicationID { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyCode { get; set; }

        public int CustomerInterestStatusID { get; set; }

        public int CustomerInterestStatusReasonsID { get; set; }

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }

        public int VoidContactID { get; set; }

        [StringLength(40)]
        public string UserId { get; set; }

        public bool? IsPreViewingUndertaken { get; set; }

        public Guid? EventId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerInterestStatusReason> CustomerInterestStatusReasons { get; set; }
    }
}
