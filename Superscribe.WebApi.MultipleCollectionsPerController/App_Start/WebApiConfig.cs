namespace Superscribe.WebApi.MultipleCollectionsPerController.App_Start
{
    using System.Web.Http;

    using Superscribe.Models;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var define = SuperscribeConfig.Register(config);

            var blogs = define.Route(r => r / "api" / "Blogs".Controller() / -(Int)"blogid");

            define.Get(blogs / "Posts".Action("GetBlogPosts"));
            define.Get(blogs / "Tags".Action("GetBlogTags"));

            define.Post(blogs / "Posts".Action("PostBlogPost"));
            define.Post(blogs / "Tags".Action("PostBlogTag"));
        }
    }
}
