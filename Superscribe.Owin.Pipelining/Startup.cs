namespace Superscribe.Owin.Pipelining
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Owin;

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
            var config = new SuperscribeOwinConfig();
            config.MediaTypeHandlers.Add(
                "text/html",
                new MediaTypeHandler { Write = (env, o) => env.WriteResponse(o.ToString()) });

            // Regular Owin pipeline example:

            app.UseSuperscribeRouter(config)
                .Use(typeof(PadResponse), "h1")
                .UseSuperscribeHandler(config);

            ʃ.Route(ʅ => ʅ / "Hello" / "World" * (o => "Hello World"));


            // Basic superscribe pipelining example

            //app.UseSuperscribeRouter(config)
            //  .UseSuperscribeHandler(config);

            //ʃ.Route(ʅ => ʅ / "Hello" * Pipeline.Action<PadResponse>("h1") 
            //                    / "World" * (o => "Hello World"));


            // Advanced superscribe pipelining example

            //app.UseSuperscribeRouter(config)
            //  .UseSuperscribeHandler(config);

            //ʃ.Route(ʅ => ʅ / "Hello" * Pipeline.Action<PadResponse>("h1") 
            //                    / "World" * (o => "Hello World"));

            //ʃ.Route(ʅ => ʅ / "Mad" * Pipeline.Action<PadResponse>("marquee") 
            //                    / "World" * (o => "Hello World"));
        }
    }
}