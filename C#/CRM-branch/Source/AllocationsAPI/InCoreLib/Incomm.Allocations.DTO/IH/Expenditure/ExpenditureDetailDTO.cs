using System;

namespace Incomm.Allocations.DTO.IH.Expenditure
{
    /// <summary>
    /// </summary>
    public class ExpenditureDetailDTO
    {
        /// <summary>
        /// </summary>
        public int ExpenditureDetailId { get; set; }

        /// <summary>
        /// </summary>
        public string ExpendituresComment { get; set; }

        /// <summary>
        /// </summary>
        public int ExpenditureTypeId { get; set; }

        /// <summary>
        /// </summary>
        public int ExpenditureFrequencyId { get; set; }

        /// <summary>
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// </summary>
        public decimal? Debt { get; set; }

        /// <summary>
        /// </summary>
        public decimal? FutureCostInUse { get; set; }

        /// <summary>
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// </summary>
        public string UserIPAddress { get; set; }

        /// <summary>
        /// </summary>
        public string UserId { get; set; }
    }
}
