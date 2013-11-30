﻿namespace Superscribe.WebApi2.MultipleCollectionsPerController.App_Start
{
    using System.Web.Http;

    using Superscribe.Models;
    using Superscribe.WebApi;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            SuperscribeConfig.Register(config);

            ʃ.Route(ʅ => "api" / "Blogs".Controller() / (
                  ʅ / -(ʃInt)"id"
                | ʅ["GET"] / (
                      ʅ / "Posts".Action("GetBlogPosts")
                    | ʅ / "Tags".Action("GetBlogTags"))
                | ʅ["POST"] / (
                      ʅ / "Posts".Action("PostBlogPost") / (ʃInt)"id" 
                    | ʅ / "Tags".Action("PostBlogTag") / (ʃInt)"id")));
            
        }
    }
}
