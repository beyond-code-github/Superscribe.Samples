namespace Superscribe.Demo.WebApi.OwinDependencyInjection
{
    using System.Collections.Generic;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        private readonly IRepository repository;

        public ValuesController(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<string> Get()
        {
            return this.repository.Values();
        }
    }
}