namespace eCommerce.Models
{

    /// <summary>
    /// This class represents a product for this eCommerce website.
    /// There is sample data within the database that can be uesd to populate and 
    /// simulate a working eCommerce site.
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }

    }
}
