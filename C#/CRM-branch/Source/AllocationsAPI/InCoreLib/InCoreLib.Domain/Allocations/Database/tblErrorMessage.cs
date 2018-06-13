using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblErrorMessage
    {
        [Key]
        public int RecID { get; set; }

        public DateTime? MsgDate { get; set; }

        [StringLength(50)]
        public string RecType { get; set; }

        public string ErrorMsg { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string AppName { get; set; }

        [StringLength(50)]
        public string AppForm { get; set; }

        [StringLength(50)]
        public string AppModule { get; set; }

        public string Note { get; set; }
    }
}
