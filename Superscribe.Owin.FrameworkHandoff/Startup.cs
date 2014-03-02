namespace Superscribe.Owin.FrameworkHandoff
{
    using System.Web.Http;

    using global::Owin;

    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpconfig = new HttpConfiguration();
            httpconfig.Routes.MapHttpRoute("DefaultApi", "api/webapi/", new { controller = "Hello" });

            var define = OwinRouteEngineFactory.Create();

            // Set up a route that will forward requests to either web api or nancy
            define.Pipeline("api/webapi").UseWebApi(httpconfig);
            define.Pipeline("api/nancy").UseNancy();
            
            app.UseSuperscribeRouter(define);
        }
    }
}