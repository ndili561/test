using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Enum
{
    public enum EventType
    {
        [Display(Name = "None"), Description("Active")]
        None = 0,

        [Display(Name = "Added"), Description("Active")]
        Added = 10,

        [Display(Name = "Deleted"), Description("Deleted")]
        Deleted = 20,

        [Display(Name = "Modified"), Description("Modified")]
        Modified = 30
    }
}