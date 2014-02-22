namespace Superscribe.WebApi.MultipleCollectionsPerController.Controllers
{
    using System.Web.Http;

    public class BlogsController : ApiController
    {
        public string Get()
        {
            return "Get";
        }

        public string GetById(int blogid)
        {
            return "GetById";
        }

        public string GetBlogPosts()
        {
            return "Blog Posts";
        }

        public string GetBlogTags()
        {
            return "Blog Tags";
        }

        public string GetBlogTags(string query)
        {
            return "Blog Tags - " + query;
        }

        public string PostBlogPost(int blogid)
        {
            return "Post to blog " + blogid;
        }

        public string PostBlogTag(int blogid)
        {
            return "Tag blog " + blogid;
        }
    }
}
