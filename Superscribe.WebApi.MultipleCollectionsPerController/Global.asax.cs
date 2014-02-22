namespace Superscribe.WebApi.MultipleCollectionsPerController
{
    using System.Web;
    using System.Web.Http;

    using Superscribe.WebApi.MultipleCollectionsPerController.App_Start;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
