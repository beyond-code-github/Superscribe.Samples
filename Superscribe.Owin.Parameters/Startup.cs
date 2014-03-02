namespace Superscribe.ComputingChoices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Owin;

    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;

    using String = Superscribe.Models.String;

    public class SayHello
    {
        private readonly Func<IDictionary<string, object>, Task> next;

        public SayHello(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var parameters = environment["route.Parameters"] as IDictionary<string, object>;
            if (parameters != null && parameters.ContainsKey("Name"))
            {
                await environment.WriteResponse("Hello " + parameters["Name"]);    
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var define = OwinRouteEngineFactory.Create();

            define.Route("Hello" / (String)"Name", o => "Hello");

            app.UseSuperscribeRouter(define)
                .Use<SayHello>();
        }
    }
}