using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblRehousedCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }

        public DateTime? OutcomeDate { get; set; }
    }
}
