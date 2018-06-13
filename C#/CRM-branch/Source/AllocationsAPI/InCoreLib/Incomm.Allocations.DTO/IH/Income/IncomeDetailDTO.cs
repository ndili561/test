using System;

namespace Incomm.Allocations.DTO.IH.Income
{
    /// <summary>
    /// </summary>
    public class IncomeDetailDTO
    {
        /// <summary>
        /// </summary>
        public int IncomeDetailId { get; set; }

        /// <summary>
        /// </summary>
        public string IncomesComment { get; set; }

        /// <summary>
        /// </summary>
        public int IncomeTypeId { get; set; }

        /// <summary>
        /// </summary>
        public int IncomeFrequencyId { get; set; }

        /// <summary>
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// </summary>
        public int ContactId { get; set; }

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
