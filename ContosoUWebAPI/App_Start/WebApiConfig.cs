using System.Web.Http;
using System.Web.Http.Cors;

namespace ContosoUWebAPI
{
    /// <summary>
    /// Having the WebAPI configuration settings in order
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// This is to have plenty of things registered at the time that the 
        /// WebAPI is being launched
        /// </summary>
        /// <param name="config">Various settings</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}