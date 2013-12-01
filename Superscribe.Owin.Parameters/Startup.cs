namespace Superscribe.ComputingChoices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Owin;

    using Superscribe.Models;
    using Superscribe.Owin;
    using Superscribe.Owin.Extensions;

    public class AddName
    {
        private readonly Func<IDictionary<string, object>, Task> next;

        public AddName(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await this.next(environment);

            var parameters = environment["route.Parameters"] as IDictionary<string, object>;
            if (parameters != null && parameters.ContainsKey("Name"))
            {
                await environment.WriteResponse(" " + parameters["Name"]);    
            }
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

            app.UseSuperscribeRouter(config)
                .Use(typeof(AddName))
                .UseSuperscribeHandler(config);

            ʃ.Route(ʅ => ʅ / "Hello" / (ʃString)"Name" * (o => "Hello"));
        }
    }
}