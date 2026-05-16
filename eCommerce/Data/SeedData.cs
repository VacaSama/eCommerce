using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new eCommerceDatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<eCommerceDatabaseContext>>()))
            {
                // Look for any products.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }
                context.Products.AddRange(
                    new Models.Product
                    {
                        Name = "Original Milkman",
                        Price = 7.99m,
                        Category = "Dairy"
                    },
                    new Models.Product
                    {
                        Name = "Little Chubbs Chocolate Delight",
                        Price = 7.99m,
                        Category = "Dairy"
                    },
                    new Models.Product
                    {
                        Name = "Aunt May Berry Pie",
                        Price = 8.99m,
                        Category = "Dairy"
                    },
                    new Models.Product
                    {
                        Name = "Banana Bean Bliss",
                        Price = 9.99m,
                        Category = "Dairy - Ice Cream"
                    },
                    new Models.Product
                    {
                        Name = "Farmhouse Vanilla",
                        Price = 9.99m,
                        Category = "Dairy - Ice Cream"
                    },
                    new Models.Product
                    {
                        Name = "Martin Cow Plush",
                        Price = 19.99m,
                        Category = "Merch"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
