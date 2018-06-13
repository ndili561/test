using System.Collections.Generic;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
   public class EndOfServiceAlertModel : BaseFilterModel
    {
       public EndOfServiceAlertModel()
       {
            tblCaseNoteDtoList = new List<tblCaseNoteDTO>();
       }

       public List<tblCaseNoteDTO> tblCaseNoteDtoList { get; set; }
    }
}
