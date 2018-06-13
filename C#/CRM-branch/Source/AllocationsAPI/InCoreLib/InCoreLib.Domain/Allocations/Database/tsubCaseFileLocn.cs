using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubCaseFileLocn")]
    public partial class tsubCaseFileLocn
    {
        [Key]
        public int CaseRefLocnID { get; set; }

        public int CaseRef { get; set; }

        public string Locn { get; set; }

        public bool Active { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
