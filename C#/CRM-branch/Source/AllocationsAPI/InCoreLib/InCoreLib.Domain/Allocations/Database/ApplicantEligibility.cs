using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("ApplicantEligibility")]
    public class ApplicantEligibility
    {
        public int ApplicantEligibilityId { get; set; }

        public int CustomerApplicationID { get; set; }

        public int ContactId { get; set; }

        public bool? IsSubjectToImmigrationControl { get; set; }

        public bool? IsReturnedToUKInLast5Years { get; set; }

        public DateTime? WhenEnteredInUk { get; set; }

        public bool? IsEligibleToClaimPublicFunds { get; set; }

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }
    }
}