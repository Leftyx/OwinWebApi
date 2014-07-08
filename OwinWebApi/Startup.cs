using System;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(OwinWebApi.Startup))]

namespace OwinWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            //  Enable attribute based routing
            //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            app.UseWelcomePage("/");
            app.UseErrorPage();
        }
    }
}
