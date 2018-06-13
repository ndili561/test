using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblEmailSetting")]
    public partial class tblEmailSetting
    {
        [Key]
        public int EmailSettingID { get; set; }

        [StringLength(20)]
        public string smtp_Host { get; set; }

        public int? smtp_Port { get; set; }

        [StringLength(20)]
        public string smtp_User { get; set; }

        [StringLength(20)]
        public string smtp_Password { get; set; }
    }
}
