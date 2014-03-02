namespace Superscribe.WebApi.Basic.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new[] { "Value1", "Value2" };
        }

        public string Get(int id)
        {
            return "Value" + id;
        }

        public string Post(int id)
        {
            return "Post id: " + id;
        }
    }
}
