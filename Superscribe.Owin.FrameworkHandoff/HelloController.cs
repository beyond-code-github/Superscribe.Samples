namespace Superscribe.Owin.FrameworkHandoff
{
    using System.Web.Http;

    public class HelloController : ApiController
    {
        public string Get()
        {
            return "Hello from Web Api";
        }
    }
}