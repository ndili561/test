using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.DTO
{
    public class MutualExchangeDTO : BaseObject
    {
        public int applicationIdA { get; set; }
        public int applicationIdB { get; set; }
        public string propertyCodeA { get; set; }
        public string propertyCodeB { get; set; }
        public int CIStatusA { get; set; }
        public int CIStatusB { get; set; }
        public string UserId { get; set; } //UserId of the patch officer who completes the Mutex task
        public int? TaskId { get; set; }//TaskId of the completed Mutex task

    }
}
