using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.DTOs
{
   public class VBLIncomeDetailDTO : BaseObject
    {
        [Key]
        public int IncomeDetailId { get; set; }
        public string IncomesComment { get; set; }
        public int IncomeTypeId { get; set; }
        public virtual IncomeType IncomeType { get; set; }
        public int IncomeFrequencyId { get; set; }
        public virtual IncomeFrequency IncomeFrequency { get; set; }
        public decimal Amount { get; set; }

        public int ContactId { get; set; }
        public VBLContactDTO Contact { get; set; }

        public bool IsSelected { get; set; }
    }
}
