using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum NumberOfSteps
    {
        [Display(Name = "Unselected"), DisplayClass("info"), Description("Unselected")]
        Unselected = 0,
        [Display(Name = "0"), DisplayClass("info"), Description("0")]
        Zero = 1,
        [Display(Name = "1-2"), DisplayClass("info"), Description("1-2")]
        OneToTwo = 2,
        [Display(Name = "3-10"), DisplayClass("info"), Description("3-10")]
        ThreeToTen = 3,
        [Display(Name = "10-20"), DisplayClass("info"), Description("10-20")]
        TenToTwenty = 4,
        [Display(Name = "20+"), DisplayClass("info"), Description("20+")]
        TwentyPlus = 5,
    }
}
