namespace Superscribe.Samples.FluentApi
{
    using global::Owin;

    using Superscribe.Models;
    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var define = OwinRouteEngineFactory.Create();
        
            // Set up a route that will respond only to even numbers using the fluent api
            var products = new ConstantNode("Products");
            var evenNumber = new EvenNumberNode("id");

            var helloRoute = products.Slash(evenNumber);
            helloRoute.FinalFunctions.Add(
                new FinalFunction("GET", o => "Product id: " + o.Parameters.id));

            define.Route(helloRoute);
            
            app.UseSuperscribeRouter(define)
                .UseSuperscribeHandler(define);
        }
    }
}