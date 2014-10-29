using System;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(OwinWebApi.Startup))]

namespace OwinWebApi
{
    using OwinWebApi.Infrastructure.Middleware;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //  Enable attribute-based routing
            //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            config.MapHttpAttributeRoutes();

            // We don't need this has we've enabled attribute-based routing

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            app.Use(typeof(LoggingMiddleware));

            app.UseWebApi(config);

            app.UseWelcomePage("/");
            app.UseErrorPage();
        }
    }
}
