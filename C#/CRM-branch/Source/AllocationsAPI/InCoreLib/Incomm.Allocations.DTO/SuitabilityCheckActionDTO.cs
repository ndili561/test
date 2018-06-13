using System;

namespace Incomm.Allocations.DTO
{
    /// <summary>
    /// </summary>
    public class SuitabilityCheckActionDTO
    {

        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// </summary>
        public string DisplayTabName { get; set; }

        /// <summary>
        /// </summary>
        public int ActionCategoryId { get; set; }

        /// <summary>
        /// </summary>
        public int ActionTypeId { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? ActionLoggedDate { get; set; }

        /// <summary>
        /// </summary>
        public string ActionLoggedById { get; set; }

        /// <summary>
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? DateToComplete { get; set; }

        /// <summary>
        /// </summary>
        public int ActionResponsibilityId { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? ActionCompletedDate { get; set; }

        /// <summary>
        /// </summary>
        public string ActionCompletedByUserName { get; set; }

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
