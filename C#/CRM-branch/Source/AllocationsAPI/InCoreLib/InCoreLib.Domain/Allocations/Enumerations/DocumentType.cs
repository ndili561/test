using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum DocumentType
    {
        [Display(Name = "None"), DisplayClass("none"), Description("Upload")]
        None = 0,
        [Display(Name = "Upload"), DisplayClass("success"), Description("Upload")]
        Upload = 10,
        [Display(Name = "New Application"), DisplayClass("mint"), Description("NewApplication")]
        NewApplication = 20,
        [Display(Name = "Closure Application"), DisplayClass("info"), Description("Closure Application")]
        ClosureApplication = 30,
        [Display(Name = "Expire Application"), DisplayClass("danger"), Description("Expire Application")]
        ExpireApplication = 40,
        [Display(Name = "Refusal Application"), DisplayClass("warning"), Description("Refusal Application")]
        RefusalApplication = 50
    }
}
