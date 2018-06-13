using System.Collections.Generic;

namespace Incomm.Allocations.DTO
{
    /// <summary>
    /// </summary>
    public class VBLRequiredSupportDetailDTO
    {
        /// <summary>
        /// </summary>
        public int SupportDetailId { get; set; }

        /// <summary>
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// </summary>
        public string OtherSupportDetails { get; set; }

        /// <summary>
        /// </summary>
        public IList<int> SupportTypeIds { get; set; }

        /// <summary>
        /// </summary>
        public byte[] ContactConcurrency { get; set; }

        /// <summary>
        /// </summary>
        public string ModifiedByUserName { get; set; }
    }
}
