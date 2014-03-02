namespace Superscribe.Demo.WebApi.OwinDependencyInjection
{
    using System.Reflection;
    using System.Web.Http;

    using Autofac;
    using Autofac.Integration.WebApi;

    using DotNetDoodle.Owin;
    using DotNetDoodle.Owin.Dependencies.Autofac;

    using global::Owin;

    using Superscribe.Owin.Engine;
    using Superscribe.Owin.Extensions;
    using Superscribe.WebApi;
    using Superscribe.WebApi.Owin.Extensions;
    
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var engine = OwinRouteEngineFactory.Create();

            var httpconfig = new HttpConfiguration();
            httpconfig.Formatters.Remove(httpconfig.Formatters.XmlFormatter);
            SuperscribeConfig.Register(httpconfig, engine);

            engine.Route("Values".Controller());
            engine.Route("Api" / "Values".Controller());

            engine.Pipeline("Api").Use<ApiDependencies>();

            appBuilder.UseAutofacContainer(this.RegisterServices())
                .UseSuperscribeRouter(engine)
                .UseWebApiWithContainer(httpconfig)
                .WithSuperscribe(httpconfig, engine);
        }

        public IContainer RegisterServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterOwinApplicationContainer();

            builder.RegisterType<Repository>()
                   .As<IRepository>()
                   .InstancePerLifetimeScope();
            
            return builder.Build();
        }
    }
}