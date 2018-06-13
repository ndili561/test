using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLIncomeDetail : BaseObject
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
        public VBLContact Contact { get; set; }
    }
}
