using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.DTO.IH.Income
{
  public class AuditIncomeDetailDTO
    {
        public int AuditID { get; set; }

        public int IncomeDetailId { get; set; }
        public string IncomesComment { get; set; }
        public int IncomeTypeId { get; set; }

        public string IncomeTypeName { get; set; }
        public int SortOrder { get; set; }

        public int IncomeFrequencyId { get; set; }

        public decimal Amount { get; set; }

        public int ContactId { get; set; }


        public string LoginName { get; set; }

        public string ChangeType { get; set; }
      
        public DateTime ChangeDate { get; set; }
 
        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }
     
        public DateTime ModifiedDate { get; set; }
    }
}
