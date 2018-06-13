using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("AuditCustomerApplication")]
    public partial class AuditCustomerApplication
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }

        public int ApplicationStatusID { get; set; }

        [StringLength(1000)]
        public string ApplicationStatusReason { get; set; }

        public DateTime ApplicationDate { get; set; }

        public bool? ApplicationEligable { get; set; }

        public DateTime? HOALevelOfNeedDate { get; set; }

        public int? ApplicationLevelOfNeedID { get; set; }

        public int? HOACaseRef { get; set; }

        [StringLength(1000)]
        public string HOAOutcome { get; set; }

        public DateTime? HOAOutcomeDate { get; set; }

        public bool? HOACaseIsOpen { get; set; }

        public bool? HOAEligabilitySet { get; set; }

        public DateTime? ApplicationClosedDate { get; set; }

        public bool? DataProtectionIsPrinted { get; set; }

        public bool? DataProtectionIsSigned { get; set; }

        public bool? DataProtectionConsented { get; set; }

        public bool? IsSignedDeclarationUploaded { get; set; }
    }
}
