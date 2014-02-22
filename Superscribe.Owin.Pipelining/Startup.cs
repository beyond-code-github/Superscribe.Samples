namespace Superscribe.Owin.Pipelining
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Owin;

    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;

    public class PadResponse
    {
        private readonly Func<IDictionary<string, object>, Task> next;

        private readonly string tag;

        public PadResponse(Func<IDictionary<string, object>, Task> next, string tag)
        {
            this.next = next;
            this.tag = tag;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await environment.WriteResponse("<" + tag + ">");
            await this.next(environment);
            await environment.WriteResponse("</" + tag + ">");
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var define = OwinRouteEngineFactory.Create();

            // Regular Owin pipeline example:

            //app.UseSuperscribeRouter(define)
            //    .Use(typeof(PadResponse), "h1")
            //    .UseSuperscribeHandler(define);

            //define.Route("Hello/World", o => "Hello World");


            // Basic superscribe pipelining example

            //app.UseSuperscribeRouter(define)
            //  .UseSuperscribeHandler(define);

            //define.Pipeline("Hello").Use(typeof(PadResponse), "h1");
            //define.Route("Hello/World", o => "Hello World");
            
            // Advanced superscribe pipelining example

            app.UseSuperscribeRouter(define)
              .UseSuperscribeHandler(define);

            define.Pipeline("Hello").Use(typeof(PadResponse), "h1");
            define.Pipeline("Goodbye").Use(typeof(PadResponse), "marquee");
            
            define.Route("Hello/World", o => "Hello World");
            define.Route("Goodbye/World", o => "Goodbye World");
        }
    }
}