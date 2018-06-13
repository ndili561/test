using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum ApplicationChangeType
    {
        [Display(Name = "None"), DisplayClass("info"), Description("None")]
        None = 0,
        [Display(Name = "Key Details"), DisplayClass("warning"), Description("Key Details")]
        KeyDetails = 10,
        [Display(Name = "Contact by Details"), DisplayClass("success"), Description("Contact by Details")]
        ContactByDetails = 20,
        [Display(Name = "Income Details"), DisplayClass("danger"), Description("Income Details")]
        IncomeDetails = 30,
        [Display(Name = "Support Details"), DisplayClass("mint"), Description("Support Details")]
        SupportDetails = 40,
        [Display(Name = "Property Details"), DisplayClass("info"), Description("Property Details")]
        PropertyDetails = 50,
        [Display(Name = "Preference Details"), DisplayClass("info"), Description("Preference Details")]
        PreferenceDetails = 60,
        [Display(Name = "Reconsider"), DisplayClass("warning"), Description("Reconsider")]
        Reconsider = 70,
        [Display(Name = "Status Changed"), DisplayClass("mint"), Description("Status Changed")]
        StatusChanged = 80,
        [Display(Name = "Document"), DisplayClass("info"), Description("Document")]
        Documents = 90,
        [Display(Name = "SMS"), DisplayClass("info"), Description("SMS")]
        SMS = 100,
        [Display(Name = "Property Interest Status Changed"), DisplayClass("info"), Description("Property Interest Status Changed")]
        PropertyInterestStatusChanged = 110,

        [Display(Name = "Application Date Changed"), DisplayClass("danger"), Description("Application Date Changed")]
        ApplicationDateChanged = 120
    }
}
