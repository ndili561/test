using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace InCoreLib.Domain.Allocations.Database
{
    public class TransferCheck : BaseObject
    {
        [Key]
        public int Id { get; set; }

        [Index("IX_TransferCheck_ContactId", IsClustered = false, IsUnique = true)]
        public int ContactId { get; set; }
        public bool IsAsbCheckOk { get; set; }
        public bool IsDebtCheckOk { get; set; }
        public bool IsOtherTenancyBreachesCheckOk { get; set; }

        [ForeignKey("ContactId")]
        public virtual VBLContact VBLContact { get; set; }
    }
}