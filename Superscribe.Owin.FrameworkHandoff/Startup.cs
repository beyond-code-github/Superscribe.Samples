namespace Superscribe.Owin.FrameworkHandoff
{
    using System.Web.Http;

    using global::Owin;

    using Superscribe.Owin;
    using Superscribe.Owin.Pipelining;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpconfig = new HttpConfiguration();
            httpconfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/webapi/",
                defaults: new { controller = "Hello" }
            );

            app.UseSuperscribeRouter(new SuperscribeOwinConfig());

            // Set up a route that will forward requests to either web api or nancy
            ʃ.Route(ʅ => ʅ / "api" / (
                  ʅ / "webapi" * Pipeline.Action(o => o.UseWebApi(httpconfig))
                | ʅ / "nancy" * Pipeline.Action(o => o.UseNancy())));
        }
    }
}