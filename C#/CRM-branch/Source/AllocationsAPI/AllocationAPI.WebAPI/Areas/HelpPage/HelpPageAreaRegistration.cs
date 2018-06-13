using System.Web.Http;
using System.Web.Mvc;
using AllocationsAPI.WebAPI.Areas.HelpPage.App_Start;

namespace AllocationsAPI.WebAPI.Areas.HelpPage
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "HelpPage"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "HRS_HelpPage_Default",
                "Help/{action}/{apiId}",
                new {controller = "Help", action = "Index", apiId = UrlParameter.Optional});

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}