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

            var engine = OwinRouteEngineFactory.Create(options);

            app.UseSuperscribeRouter(engine)
                .UseSuperscribeHandler(engine);
        }
    }
}