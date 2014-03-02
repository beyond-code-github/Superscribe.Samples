namespace Superscribe.WebApi.Basic.App_Start
{
    using System.Web.Http;

    using Superscribe.Models;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var engine = SuperscribeConfig.Register(config);
            engine.Route("api" / Any.Controller / (Int)"id");
        }
    }
}
