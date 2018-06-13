using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblBnBDataSendLog")]
    public partial class tblBnBDataSendLog
    {
        [Key]
        [Column(Order = 0)]
        public int LogID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime SendDate { get; set; }

        [StringLength(250)]
        public string DestEMailAddrs { get; set; }

        public string FileNameAndPath { get; set; }

        [StringLength(250)]
        public string SenderUserID { get; set; }
    }
}
