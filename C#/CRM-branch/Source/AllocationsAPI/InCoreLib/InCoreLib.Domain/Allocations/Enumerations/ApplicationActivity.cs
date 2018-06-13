using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Enum;

namespace InCoreLib.Domain.Allocations.Enumerations
{
    public enum ApplicationActivity
    {
        [Display(Name = "None"), DisplayClass("info"), Description("None")]
        None = 0,
        [Display(Name = "Amendment"), DisplayClass("warning"), Description("Amendment")]
        Ammendment = 10,
        [Display(Name = "Match"), DisplayClass("success"), Description("Match")]
        Match = 20,
        [Display(Name = "Close Application"), DisplayClass("danger"), Description("Close Application")]
        CloseApplication = 30,
        [Display(Name = "Open Application"), DisplayClass("mint"), Description("Reopen Application")]
        ReopenApplication = 40,
        [Display(Name = "Export Data"), DisplayClass("info"), Description("Export Data")]
        ExportData = 50,
        [Display(Name = "Action"), DisplayClass("info"), Description("Action")]
        Action = 60,
        [Display(Name = "Document Uploaded"), DisplayClass("warning"), Description("Document Uploaded")]
        DocumentUploaded = 70,
        [Display(Name = "Document Downloaded"), DisplayClass("success"), Description("Document Downloaded")]
        DocumentDownloaded = 80,
        [Display(Name = "Document Emailed"), DisplayClass("info"), Description("Document Emailed")]
        DocumentEmailed = 90,
        [Display(Name = "Document Deleted"), DisplayClass("danger"), Description("Document Deleted")]
        DocumentDeleted = 100,
        [Display(Name = "SMS Sent"), DisplayClass("danger"), Description("SMS Sent")]
        SMSSent = 110,
        [Display(Name = "Property Interest"), DisplayClass("info"), Description("Property Interest")]
        PropertyInterest = 120,
        [Display(Name = "New Details"), DisplayClass("info"), Description("New Details")]
        NewDetails = 130
    }
}
