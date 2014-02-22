namespace Superscribe.OwinHelloWorld
{
    using global::Owin;

    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var define = OwinRouteEngineFactory.Create();
            
            define.Route("Hello/World", o => "Hello World");
            
            app.UseSuperscribeRouter(define)
                .UseSuperscribeHandler(define);
        }
    }
}