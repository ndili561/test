using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;

namespace AllocationsAPI.WebAPI
{
    /// <summary>
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.Add(new BsonMediaTypeFormatter());

            //config.Routes.MapHttpRoute("VersionApi_HRS", "{controller}/{action}/{id}",
            //    new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute("VersionApi_VBL", "{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", 
                new { id = RouteParameter.Optional });

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore;
            config.Filters.Add(new ElmahHandleWebApiErrorAttribute());
        }
    }
}