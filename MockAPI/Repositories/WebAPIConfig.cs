using System.Web.Http;

namespace MockAPI.Repositories
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
                // Configure Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
        }
        
    }
}
