using System;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class AuditVBLIncomeDetails : BaseObject
    {


        [Key]
        public int AuditID { get; set; }

        public int IncomeDetailId { get; set; }
        public string IncomesComment { get; set; }
        public int IncomeTypeId { get; set; }
        public virtual IncomeType IncomeType { get; set; }
        public int IncomeFrequencyId { get; set; }
        public virtual IncomeFrequency IncomeFrequency { get; set; }
        public decimal Amount { get; set; }

        public int ContactId { get; set; }
        public VBLContact Contact { get; set; }

        public string LoginName { get; set; }

        public string ChangeType { get; set; }

        public DateTime ChangeDate { get; set; }
    }
}
