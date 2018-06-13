using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{

    public class VBLExpenditureDetail : BaseObject
    {
        /// <summary>
        /// </summary>
        [Key]
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
        public decimal Debt { get; set; }

        /// <summary>
        /// </summary>
        public decimal FutureCostInUse { get; set; }

        /// <summary>
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// </summary>
        public VBLContact Contact { get; set; }
    }
}
