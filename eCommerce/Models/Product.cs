namespace eCommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public string ImageURL { get; set; } = string.Empty;

    }
}
