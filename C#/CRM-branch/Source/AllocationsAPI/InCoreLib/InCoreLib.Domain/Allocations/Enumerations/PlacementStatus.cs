using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum PlacementStatus
    {
        [Display(Name = "Available"), DisplayClass("warning"), Description("Available")]
        Available = 0,

        [Display(Name = "Matched by provider"), DisplayClass("info"), Description("Matched by provider")]
        MatchedByProvider = 10,

        [Display(Name = "Referred to provider"), DisplayClass("info"), Description("Referred to provider")]
        ReferredToProvider = 20,

        [Display(Name = "Occupied"), DisplayClass("success"), Description("Occupied")]
        Occupied = 30,

        [Display(Name = "Completed"), DisplayClass("success"), Description("Completed")]
        Completed = 40,


    }
}