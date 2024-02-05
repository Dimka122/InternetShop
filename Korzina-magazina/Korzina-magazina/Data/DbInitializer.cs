using Korzina_magazina.Models;
using System;
using System.Linq;

namespace Korzina_magazina.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();
            //Look for any products
            if (context.Products.Any())
            {
                return;//DB has been seeded
            }
            var products = new Product[]
            {
                  new Product()
                  {
                      Id = "1",
                     Name = "Aconitum",
                      Photo = "Georgina.png",
                      Price = 2.80
                  },

                new Product()
                {
                    Id="2",
                    Name = "African Daisy",
                    Photo = "HZ.png",
                    Price = 3.80
                },
                new Product()
                {
                    Id="3",
                    Name = "Begonia",
                    Photo = "jordlia.png",
                    Price = 3.80
                },
                  new Product()
                  {
                      Id="4",
                      Name = "Chrysanthemum",
                      Photo = "Lutik.png",
                      Price = 3.60
                  },
                new Product()
                {
                    Id="5",
                    Name = "Dahlia",
                    Photo = "Mayory.png",
                    Price = 6.80
                },
                new Product()
                {
                    Id="6",
                    Name = "Daisy",
                    Photo = "Peon.png",
                    Price = 1.68
                },
                  new Product()
                  {
                      Id="7",
                      Name = "Echinacea",
                      Photo = "Romshka.png",
                      Price = 3.80
                  },
                  new Product()
                  {
                      Id="8",
                      Name = "ForgetMeNot",
                      Photo = "Rosa.png",
                      Price = 3.45
                  },
                new Product()
                {
                    Id = "9",
                    Name = "Jasmine",
                    Photo = "Rozochka.png",
                    Price = 3.80
                },
                new Product()
                {
                    Id="10",
                    Name="Tulpan",
                    Photo="Tulpan.png",
                  Price=4.25
                }

            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

        }
    }
}
