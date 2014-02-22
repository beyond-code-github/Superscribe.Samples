namespace Superscribe.WebApiOnOwin
{
    using System.Web.Http;

    using global::Owin;

    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;
    using Superscribe.WebApi;
    using Superscribe.WebApi.Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var define = OwinRouteEngineFactory.Create();
            var httpconfig = new HttpConfiguration();

            httpconfig.Formatters.Remove(httpconfig.Formatters.XmlFormatter);
            httpconfig.MapHttpAttributeRoutes();
            httpconfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "values", id = RouteParameter.Optional });

            SuperscribeConfig.RegisterModules(httpconfig, define);

            define.Route("values".Controller());
            
            app.UseSuperscribeRouter(define)
                .UseWebApiWithSuperscribe(httpconfig, define);
        }
    }
}