using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("ContactIncome")]
    public partial class ContactIncome
    {
        public int ContactIncomeID { get; set; }

        public int CustomerApplicationID { get; set; }

        public int ContactID { get; set; }

        public int IncomeTypeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IncomeAmount { get; set; }

        public int IncomeFrequencyID { get; set; }

        public bool Active { get; set; }

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }
    }
}
