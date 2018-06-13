using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("AuditApplicantEligibility")]
    public partial class AuditApplicantEligibility
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicantEligibilityId { get; set; }

        public int CustomerApplicationID { get; set; }

        public int ContactId { get; set; }

        public bool? IsSubjectToImmigrationControl { get; set; }

        public bool? IsReturnedToUKInLast5Years { get; set; }

        public DateTime? WhenEnteredInUk { get; set; }

        public bool? IsEligibleToClaimPublicFunds { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }
    }
}
