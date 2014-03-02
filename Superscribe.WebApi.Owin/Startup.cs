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
            
            SuperscribeConfig.RegisterModules(httpconfig, define);

            define.Route("values".Controller());
            
            app.UseSuperscribeRouter(define)
                .UseWebApi(httpconfig)
                .WithSuperscribe(httpconfig, define);
        }
    }
}