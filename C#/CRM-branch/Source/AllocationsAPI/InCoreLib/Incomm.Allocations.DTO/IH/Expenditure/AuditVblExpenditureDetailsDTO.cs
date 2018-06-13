using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.DTO.IH.Expenditure
{
   public class AuditVblExpenditureDetailsDTO
    {

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
        public string LoginName { get; set; }

        /// <summary>
        /// </summary>
        public string ChangeType { get; set; }

        /// <summary>
        /// </summary>
        public DateTime ChangeDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

       public string ModifiedBy { get; set; }

       public string CreatedBy { get; set; }

    }
}
