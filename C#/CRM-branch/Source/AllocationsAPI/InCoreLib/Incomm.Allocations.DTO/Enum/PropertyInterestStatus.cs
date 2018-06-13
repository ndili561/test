using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace Incomm.Allocations.DTO.Enum
{
    public enum PropertyInterestStatus
    {
        [Display(Name = "NotSelected"), DisplayClass("info"), Description("Not Selected")]
        NotSelected = 0,
        [Display(Name = "Interested"), DisplayClass("success"), Description("Interested")]
        Interested = 10,
        [Display(Name = "Not Interested"), DisplayClass("danger"), Description("Not Interested")]
        NotInterested =20,
        [Display(Name = "Reconsider"), DisplayClass("danger"), Description("Reconsider")]
        Reconsider = 20
    }
}
