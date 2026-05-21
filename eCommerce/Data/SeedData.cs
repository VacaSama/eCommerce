using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new eCommerceDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<eCommerceDbContext>>()))
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
                        Category = "Dairy", 
                        Description = "The Original Milkman is a classic, creamy beverage that has been a favorite for generations. " +
                        "Made with the finest ingredients, this delicious dairy product offers a rich and smooth flavor that will transport" +
                        " you back to simpler times." +
                        "The Original Milkman is sure to satisfy your cravings and bring a smile to your face.",
                        ImageUrl = "MartinOriginal.png"
                    },
                    new Models.Product
                    {
                        Name = "Little Chubbs Chocolate Delight",
                        Price = 7.99m,
                        Category = "Dairy", 
                        Description = "Indulge in the irresistible sweetness of Little Chubbs Chocolate Delight, a delectable treat that will satisfy your chocolate cravings. ",
                        ImageUrl = "ChocolateMartin.png"
                    },
                    new Models.Product
                    {
                        Name = "Aunt May Berry Pie",
                        Price = 8.99m,
                        Category = "Dairy",
                        Description = "Experience the delightful taste of Aunt May Berry Pie, our limited edition milk flavor" +
                        " a scrumptious beverage that combines the sweetness of ripe strawberries with a buttery, flaky, graham cracker crust.",
                        ImageUrl = "BerryPieMartin.png"
                    },
                    new Models.Product
                    {
                        Name = "Banana Bean Bliss",
                        Price = 9.99m,
                        Category = "Dairy - Ice Cream",
                        Description = "Banana Bean Bliss is a heavenly blend of creamy banana and rich java bean flavors, " +
                        "creating a delightful treat that will transport your taste buds to a caffinated paradise.",
                        ImageUrl = "Milkman-BJavaChip.png"
                    },
                    new Models.Product
                    {
                        Name = "Farmhouse Vanilla",
                        Price = 9.99m,
                        Category = "Dairy - Ice Cream", 
                        Description = "Farmhouse Vanilla is a timeless classic that captures the essence of creamy, rich vanilla bean flavor.",
                        ImageUrl = "Milkman-VanillaBean.png"
                    },
                    new Models.Product
                    {
                        Name = "Martin Cow Plush",
                        Price = 19.99m,
                        Category = "Merch",
                        Description = "Bring home the charm of our mascot, Martin Cow! The cutest dairy deliverer in the game, " +
                        "all purchases of the Martin Cow Plush will help local dairy farms deliver fresh milk to participating schools.",
                        ImageUrl = "MilkmanPlush.png"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
