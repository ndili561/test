using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.DTO
{
    /// <summary>
    /// </summary>
    public class VBLExpenditureDetailsDTO : BaseObject
    {
        [Key]
        public int ExpenditureDetailId { get; set; }

        public string ExpenditureComment { get; set; }

        public int ExpenditureTypeId { get; set; }

        //public virtual ExpenditureType ExpenditureType { get; set; }

        public int ExpenditureFrequencyId { get; set; }

        //public virtual ExpenditureFrequency ExpenditureFrequency { get; set; }

        public decimal Debt { get; set; }

        public decimal FutureCostInUse { get; set; }
        
        public decimal Amount { get; set; }

        public int ContactId { get; set; }

        public virtual VBLContactDTO Contact { get; set; }

        public bool IsSelected { get; set; }
    }
}
