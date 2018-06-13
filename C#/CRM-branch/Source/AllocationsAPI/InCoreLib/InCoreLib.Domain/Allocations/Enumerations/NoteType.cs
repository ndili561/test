using InCoreLib.Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum NoteType
    {
        [Display(Name = "Please Select"), DisplayClass("info"), Description("None")]
        None = 0,
        [Display(Name = "Action"), DisplayClass("success"), Description("Action")]
        Action = 10,
        [Display(Name = "Risk"), DisplayClass("danger"), Description("Risk")]
        Risk = 20
    }
}
