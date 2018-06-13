using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Configuration;

namespace Incomm.Allocations.BLL.DTOs
{
    public class AlertDTO
    {
        [Display(Name = "Hoa Reference")]
        public int CaseRef { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Alert")]
        public string Alert { get; set; }

        [Display(Name = "Provider")]
        public string Provider { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public int CaseEventID { get; set; }
        public DateTime DOB { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        public int HoursSinceDecisionOutstanding = int.Parse(WebConfigurationManager.AppSettings["HoursSinceDecisionOutstanding"]);

        private TimeSpan span { get { return DateTime.Now.Subtract(Date); } }
      
        public string CssClassForOfficerAlerts { get { return span.TotalHours > HoursSinceDecisionOutstanding ? "danger" : string.Empty; } } 
    }
}