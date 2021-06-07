using System;
using System.Collections.Generic;
using System.Linq;
using marketplace.Data.Models;

namespace marketplace.Data.Seeds
{
    public interface ISeeder
    {
        void Seed();
    }

    public class DatabaseSeeder : ISeeder
    {
        private readonly ApplicationDbContext context;

        public DatabaseSeeder(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product
                    {
                        Name = "Lavender heart",
                        CreatedOn = DateTimeOffset.UtcNow,
                        Price = (decimal) 9.25
                    },
                    new Product
                    {
                        Name = "Personalised cufflinks",
                        CreatedOn = DateTimeOffset.UtcNow,
                        Price = (decimal) 45.00
                    },
                    new Product
                    {
                        Name = "Kids T-shirt",
                        CreatedOn = DateTimeOffset.UtcNow,
                        Price = (decimal) 19.95
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
