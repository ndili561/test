using System.Web.Mvc;
using System.Web.Routing;

namespace AllocationsAPI.WebAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("Version_HRS", "HRS/V1.0.0/{controller}/{action}/{id}",
            //    new { Controller = "Home", action = "Index", id = UrlParameter.Optional });

            //routes.MapRoute("Version_VBL", "VBL/V1.0.0/{controller}/{action}/{id}",
            //    new { Controller = "Home", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}