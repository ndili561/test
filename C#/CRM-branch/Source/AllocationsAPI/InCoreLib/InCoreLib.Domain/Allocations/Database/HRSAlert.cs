using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCoreLib.Domain.Allocations.Database
{
    public class HRSAlert
    {
  
        public int CaseRef { get; set; }
        public string Name { get; set; }
        public string Alert { get; set; }
        public DateTime Date { get; set; }
        [Key]
        public int CaseEventID { get; set; }
        public DateTime DOB { get; set; }

        public string Gender { get; set; }

    }
}
