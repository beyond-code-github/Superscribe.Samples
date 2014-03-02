namespace Superscribe.OwinModuleConfig
{
    using System.IO;

    using global::Owin;

    using Newtonsoft.Json;

    using Superscribe.Owin;
    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new SuperscribeOwinOptions();
            options.MediaTypeHandlers.Remove("text/html");
            options.MediaTypeHandlers.Add("application/json", new MediaTypeHandler
            {
                   Write = (env, o) => env.WriteResponse(JsonConvert.SerializeObject(o)),
                   Read = (env, type) =>
                   {
                       object obj;
                       using (var reader = new StreamReader(env.GetRequestBody()))
                       {
                           obj = JsonConvert.DeserializeObject(reader.ReadToEnd(), type);
                       };

                       return obj;
                   }
               });

            // Replace text/html with json handler so example works in a browser
            options.MediaTypeHandlers.Add("text/html", options.MediaTypeHandlers["application/json"]);

            var engine = OwinRouteEngineFactory.Create(options);

            app.UseSuperscribeRouter(engine)
                .UseSuperscribeHandler(engine);
        }
    }
}