namespace Superscribe.WebApi.Basic
{
    using System.Web.Http;

    using Superscribe.WebApi.Basic.App_Start;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
