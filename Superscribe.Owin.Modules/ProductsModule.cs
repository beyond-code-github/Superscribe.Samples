﻿namespace Superscribe.OwinModuleConfig
{
    using System.Collections.Generic;
    using System.Linq;

    using Superscribe.Models;
    using Superscribe.Owin;

    public class ProductsModule : SuperscribeOwinModule
    {
        private readonly List<Product> products = new List<Product>
            {
                new Product { Id = 1, Description = "Shoes", Price = 123.50, Category = "Fashion"},
                new Product { Id = 2, Description = "Hats", Price = 55.20, Category = "Fashion"},
                new Product { Id = 3, Description = "iPad", Price = 324.50, Category = "Electronics"},
                new Product { Id = 4, Description = "Kindle", Price = 186.20, Category = "Electronics"},
                new Product { Id = 5, Description = "Dune", Price = 13.50, Category = "Books"}
            };

        public ProductsModule()
        {
            this.Get["Products"] = o => products;

            this.Get["Products" / (ʃInt)"Id"] = o => 
                products.FirstOrDefault(p => o.Parameters.Id == p.Id);

            this.Get["Products" / (ʃString)"Category"] = o => 
                products.Where(p => o.Parameters.Category == p.Category);

            this.Post["Products"] = o =>
                {
                    var product = o.Bind<Product>();
                    return new { Message = string.Format(
                        "Received product id: {0}, description: {1}", 
                        product.Id, product.Description) };
                };
        }
    }
}