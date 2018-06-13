using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tbl_Messages
    {
        public int id { get; set; }

        [StringLength(50)]
        public string MessageType { get; set; }

        public int? MessageLevel { get; set; }

        [StringLength(2000)]
        public string Message { get; set; }

        public DateTime? DTStamp { get; set; }

        [StringLength(50)]
        public string User { get; set; }
    }
}
