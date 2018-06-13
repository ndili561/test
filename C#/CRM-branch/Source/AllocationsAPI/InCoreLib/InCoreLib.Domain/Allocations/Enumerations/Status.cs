using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum Status
    {
        None = 0,

        [Display(Name = "Assigned to officer"), DisplayClass("primary"), Description("Assigned to officer")]
        AssignedToHRSOfficer = 10,

        [Display(Name = "On waiting list"), DisplayClass("info"), Description("On waiting list")]
        OnWaitingList = 20,

        [Display(Name = "Referred to provider"), DisplayClass("warning"), Description("Referred to provider")]
        ReferredToProvider = 30,

        [Display(Name = "Assigned to provider"), DisplayClass("warning"), Description("Assigned to provider")]
        AssignedToProvider = 40,
        [Display(Name = "Placement matched by officer"), DisplayClass("warning"), Description("Placement matched by officer")]
        PlacementMatchedByOfficer = 45,

        [Display(Name = "Placement matched by provider"), DisplayClass("warning"), Description("Placement matched by provider")]
        PlacementMatched = 50,

        [Display(Name = "Rejected by provider"), DisplayClass("danger"), Description("Rejected by provider")]
        RejectedByProvider = 60,

        [Display(Name = "Accepted by provider"), DisplayClass("success"), Description("Accepted by provider")]
        AcceptedByProvider = 70,

        [Display(Name = "Reconsider"), DisplayClass("mint"), Description("Reconsider")]
        Reconsider = 80,

        [Display(Name = "Ready to leave"), DisplayClass("purple"), Description("Ready to leave")]
        ReadyToLeave = 90,

        [Display(Name = "Completed"), DisplayClass("green"), Description("Completed")]
        Completed = 100



    }
}