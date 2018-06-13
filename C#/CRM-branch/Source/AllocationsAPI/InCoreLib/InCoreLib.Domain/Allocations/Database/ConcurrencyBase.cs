using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCoreLib.Domain.Allocations.Database
{
   public partial class ConcurrencyBase
    {
        [MaxLength(40)]
        [NotMapped]
        [SkipTracking]
        public string UserId { get; set; }//ApplicationUser.UserName ?? ApplicationUser.Email

        [NotMapped]
        [SkipTracking]
        public string UserIPAddress { get; set; }//Request.ServerVariables["REMOTE_ADDR"]
        public byte[] ConcurrencyCheck { get; set; }

    }
}
