using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum RejectionReason
    {
        [Display(Name = "Banned from this service in previous 28 days"), DisplayClass("positive"), Description("Banned from this service in previous 28 days")]
        Banned = 10,

        [Display(Name = "Needs Additional Care"), DisplayClass("positive"), Description("Needs Additional Care")]
        NeedsAdditionalCare = 20,

        [Display(Name = "Poses Risk to staff/residents"), DisplayClass("positive"), Description("Poses Risk to staff/residents")]
        PosesRisk = 30,

        [Display(Name = "Customer Refused"), DisplayClass("positive"), Description("Customer Refused")]
        CustomerRefused = 40,

        [Display(Name = "Unable to contact"), DisplayClass("positive"), Description("Unable to contact")]
        UnableToContact = 50,

        [Display(Name = "Found alternative"), DisplayClass("positive"), Description("Found alternative")]
        FoundAlternative = 60,


    }
}