using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace InCoreLib.Domain.Allocations.Database
{
    public class AuditVblExpenditureDetails : BaseObject
    {

        /// <summary>
        /// </summary>
        [Key]
        public int AuditID { get; set; }

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

        /// <summary>
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// </summary>
        public string ChangeType { get; set; }

        /// <summary>
        /// </summary>
        public DateTime ChangeDate { get; set; }

        [NotMapped]
        public override byte[] RowVersion { get; set; }
    }
}
