namespace Superscribe.Demo.WebApi.OwinDependencyInjection
{
    using System.Collections.Generic;

    public interface IRepository
    {
        IEnumerable<string> Values();
    }

    public class Repository : IRepository
    {
        public IEnumerable<string> Values()
        {
            return new[] { "value1", "value2" };
        }
    }

    public class ApiRepository : IRepository
    {
        public IEnumerable<string> Values()
        {
            return new[] { "value3", "value4" };
        }
    }
}