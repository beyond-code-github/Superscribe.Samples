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

            var blogs = define.Route("api" / "Blogs".Controller() / (Int)"blogid");

            define.Get(blogs / "Posts", To.Action("GetBlogPosts"));
            define.Get(blogs / "Tags", To.Action("GetBlogTags"));

            define.Post(blogs / "Posts", To.Action("PostBlogPost"));
            define.Post(blogs / "Tags", To.Action("PostBlogTag"));
        }
    }
}
