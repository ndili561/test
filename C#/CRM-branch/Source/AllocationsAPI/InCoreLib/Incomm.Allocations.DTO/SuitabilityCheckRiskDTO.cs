using System;
using System.ComponentModel;

namespace Incomm.Allocations.DTO
{
    /// <summary>
    /// </summary>
    public class SuitabilityCheckRiskDTO
    {
        /// <summary>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public string DisplayTabName { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Contact")]
        public int ContactId { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Theme")]
        public int RiskThemeId { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Risk Category")]
        public int RiskCategoryId { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Logged Date")]
        public DateTime? LoggedDate { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Logged By User")]
        public string LoggedById { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Details")]
        public string RiskDetail { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Last Reviewed Date")]
        public DateTime? LastReviewedDate { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Reviewed By")]
        public string LastReviewedByName { get; set; }

        /// <summary>
        /// </summary>
        public byte[] ConcurrencyCheck { get; set; }

        /// <summary>
        /// </summary>
        public string LastModifiedById { get; set; }

        /// <summary>
        /// </summary>
        public DateTime ModifiedTimestamp { get; set; }
    }
}
