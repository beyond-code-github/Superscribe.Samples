﻿namespace Superscribe.Samples.FluentApi
{
    using global::Owin;

    using Superscribe.Models;
    using Superscribe.Owin;
    using Superscribe.Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new SuperscribeOwinConfig();
            config.MediaTypeHandlers.Add(
                "text/html",
                new MediaTypeHandler
                    {
                        Write = (env, o) => env.WriteResponse(o.ToString())
                    });

            app.UseSuperscribeRouter(config)
                .UseSuperscribeHandler(config);

            // Set up a route that will respond only to even numbers using the fluent api

            var helloRoute = new ConstantNode("Products").Slash(new EvenNumberNode("id"));
            helloRoute.FinalFunctions.Add(new FinalFunction("GET", o => "Product id: " + o.Parameters.id));

            ʃ.Base.Zip(helloRoute.Base());
        }
    }
}