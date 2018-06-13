using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class AuditCustomerContactDetail
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }

        [StringLength(25)]
        public string TelNum { get; set; }

        public bool? ContactByPhone { get; set; }

        [StringLength(25)]
        public string MobileNum { get; set; }

        public bool? ContactByMobile { get; set; }

        public bool? ContactByMobileText { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public bool? ContactByEmail { get; set; }

        public bool? ContactByMail { get; set; }

        public bool? WillVisitTheOffices { get; set; }

        [StringLength(255)]
        public string ContactAddress1 { get; set; }

        [StringLength(255)]
        public string ContactAddress2 { get; set; }

        [StringLength(255)]
        public string ContactAddress3 { get; set; }

        [StringLength(255)]
        public string ContactAddress4 { get; set; }

        [StringLength(16)]
        public string ContactPostCode { get; set; }
    }
}
