namespace Superscribe.OwinHelloWorld
{
    using global::Owin;

    using Superscribe.Owin;
    using Superscribe.Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new SuperscribeOwinConfig();
            config.MediaTypeHandlers.Add("text/html", new MediaTypeHandler { Write = (env, o) => env.WriteResponse(o.ToString()) });

            app.UseSuperscribeRouter(config)
                .UseSuperscribeHandler(config);

            ʃ.Route(ʅ => ʅ / "Hello" / "World" * (o => "Hello World"));
        }
    }
}